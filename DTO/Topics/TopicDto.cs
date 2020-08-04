using System;
using System.Collections.Generic;
using System.Text;
using Nop.Plugin.Api.DTO.Base;
using Nop.Core.Domain.Catalog;
using Newtonsoft.Json;

namespace Nop.Plugin.Api.DTO.Topics
{
    [JsonObject(Title = "topic")]
    public class TopicDto : BaseDto
    {
        /// <summary>
        ///     Gets or sets the title
        /// </summary>
        [JsonProperty("systemName")]
        public string SystemName { get; set; }

        /// <summary>
        ///     Gets or sets the title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
