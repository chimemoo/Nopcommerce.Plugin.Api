using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Nop.Plugin.Api.DTO.Base;

namespace Nop.Plugin.Api.DTO.Topics
{
    [JsonObject(Title = "province")]
    public class ProvinceDTO : BaseDto
    {
        [JsonProperty("province")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
