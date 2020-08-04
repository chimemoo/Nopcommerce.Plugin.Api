using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Api.Attributes;
using Nop.Plugin.Api.DTO.Errors;
using Nop.Plugin.Api.DTO.Topics;
using Nop.Plugin.Api.Helpers;
using Nop.Plugin.Api.JSON.Serializers;
using Nop.Plugin.Api.Services;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Services.Topics;
using Nop.Plugin.Api.Infrastructure;
using Nop.Plugin.Api.JSON.ActionResults;
using Nop.Plugin.Api.Models.TopicsParameters;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Configuration;
using Nop.Core.Domain;

namespace Nop.Plugin.Api.Controllers
{
    public class TopicsController : ApiByPassController
    {
        private readonly ITopicApiService _topicApiService;
        private readonly ITopicService _topicService;
        private readonly IDTOHelper _dtoHelper;
        private readonly IStoreContext _storeContext;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IStaticCacheManager _cacheManager;
        private readonly StoreInformationSettings _storeInformationSettings;
        private readonly IPictureService _pictureService;

        public TopicsController(
            ITopicApiService topicApiService,
            IJsonFieldsSerializer jsonFieldsSerializer,
            ITopicService categoryService,
            IUrlRecordService urlRecordService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            IAclService aclService,
            IStaticCacheManager cacheManager,
            ICustomerService customerService,
            IDTOHelper dtoHelper,
            IStoreContext storeContext,
            StoreInformationSettings storeInformationSettings) : base(jsonFieldsSerializer, aclService, customerService, storeMappingService, storeService, discountService,
                                         customerActivityService, localizationService, pictureService)
        {
            _topicApiService = topicApiService;
            _topicService = categoryService;
            _urlRecordService = urlRecordService;
            _dtoHelper = dtoHelper;
            _storeContext = storeContext;
            _cacheManager = cacheManager;
            _storeInformationSettings = storeInformationSettings;
            _pictureService = pictureService;
        }

        /// <summary>
        ///     Receive a list of all Topics
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Route("/api/topics")]
        [ProducesResponseType(typeof(TopicsRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public IActionResult GetCategories(TopicsParametersModel parameters)
        {
            if (parameters.Limit < Constants.Configurations.MinLimit || parameters.Limit > Constants.Configurations.MaxLimit)
            {
                return Error(HttpStatusCode.BadRequest, "limit", "Invalid limit parameter");
            }

            if (parameters.Page < Constants.Configurations.DefaultPageValue)
            {
                return Error(HttpStatusCode.BadRequest, "page", "Invalid page parameter");
            }

            var allTopics = _topicApiService.GetTopics(parameters.Ids, parameters.CreatedAtMin, parameters.CreatedAtMax,
                                                                  parameters.UpdatedAtMin, parameters.UpdatedAtMax,
                                                                  parameters.Limit, parameters.Page, parameters.SinceId)
                                                   .Where(c => StoreMappingService.Authorize(c));

            IList<TopicDto> topicsAsDtos = allTopics.Select(topic => _dtoHelper.PrepareTopicToDTO(topic)).ToList();

            var topicsRootObject = new TopicsRootObject
            {
                Topics = topicsAsDtos
            };

            var json = JsonFieldsSerializer.Serialize(topicsRootObject, parameters.Fields);

            return new RawJsonActionResult(json);
        }

        /// <summary>
        ///     Retrieve product by spcified id
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <param name="fields">Fields from the topic you want your json to contain</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Route("/api/topics/{id}")]
        [ProducesResponseType(typeof(TopicsRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [GetRequestsErrorInterceptorActionFilter]
        public IActionResult GetTopicById(int id, string fields = "")
        {
            if (id <= 0)
            {
                return Error(HttpStatusCode.BadRequest, "id", "invalid id");
            }

            var topic = _topicApiService.GetTopicById(id);

            if (topic == null)
            {
                return Error(HttpStatusCode.NotFound, "topic", "not found");
            }

            var topicsRootObject = new TopicsRootObject();

            var topicDto = _dtoHelper.PrepareTopicToDTO(topic);

            topicsRootObject.Topics.Add(topicDto);

            var json = JsonFieldsSerializer.Serialize(topicsRootObject, fields);

            return new RawJsonActionResult(json);
        }


        // get logos
        [HttpGet]
        [Route("/api/logos")]
        [ProducesResponseType(typeof(LogoModel), (int)HttpStatusCode.OK)]
        [GetRequestsErrorInterceptorActionFilter]
        public IActionResult GetLogos()
        {
            var logoPictureId = _storeInformationSettings.LogoPictureId;
            var model = new LogoModel
            {
                StoreName = LocalizationService.GetLocalized(_storeContext.CurrentStore, x => x.Name),
                LogoPath = _pictureService.GetPictureUrl(logoPictureId, showDefaultPicture: false)
            };
            
            return Ok(model);
        }

    }
}
