using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Nop.Plugin.Api.DTO.Base;

namespace Nop.Plugin.Api.DTO.Topics
{
    public class PictureDTO : BaseDto
    {
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

    }
}
