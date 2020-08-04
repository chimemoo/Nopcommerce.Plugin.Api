using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Nop.Plugin.Api.DTO.Topics
{
    public class TopicsRootObject : ISerializableObject
    {
        public TopicsRootObject()
        {
            Topics = new List<TopicDto>();
        }

        [JsonProperty("topics")]
        public IList<TopicDto> Topics { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "topics";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(TopicDto);
        }
    }
}
