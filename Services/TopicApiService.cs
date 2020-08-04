using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Core.Data;
using Nop.Core.Domain.Topics;
using Nop.Plugin.Api.DataStructures;
using Nop.Services.Stores;

namespace Nop.Plugin.Api.Services
{
    public class TopicApiService : ITopicApiService
    {
        private readonly IRepository<Topic> _topicRepository;
        private readonly IStoreMappingService _storeMappingService;


        public TopicApiService(
            IRepository<Topic> topicRepository,
            IStoreMappingService storeMappingService)
        {
            _topicRepository = topicRepository;
            _storeMappingService = storeMappingService;
        }

        public IList<Topic> GetTopics(IList<int> ids = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, int limit = 50, int page = 1, int sinceId = 0, int? productId = null, bool? publishedStatus = null)
        {
            var query = GetTopicsQuery(createdAtMin, createdAtMax, updatedAtMin, updatedAtMax, publishedStatus, productId, ids);


            if (sinceId > 0)
            {
                query = query.Where(c => c.Id > sinceId);
            }

            return new ApiList<Topic>(query, page - 1, limit);
        }

        public Topic GetTopicById(int topicId)
        {
            if (topicId == 0)
            {
                return null;
            }

            return _topicRepository.Table.FirstOrDefault(topic => topic.Id == topicId);
        }

        private IQueryable<Topic> GetTopicsQuery(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null,
            bool? publishedStatus = null, int? productId = null, IList<int> ids = null)
        {
            var query = _topicRepository.Table;

            if (ids != null && ids.Count > 0)
            {
                query = query.Where(c => ids.Contains(c.Id));
            }

            if (publishedStatus != null)
            {
                query = query.Where(c => c.Published == publishedStatus.Value);
            }

            query = query.OrderBy(topic=> topic.Id);

            return query;
        }
    }

    

}
