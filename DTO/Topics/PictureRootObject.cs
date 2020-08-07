using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Nop.Core.Domain.Media;

namespace Nop.Plugin.Api.DTO.Topics
{
    public class PictureRootObject : ISerializableObject
    {
        public PictureRootObject()
        {
            AvatarUrl = new PictureDTO();
        }

        [JsonProperty("avatarUrl")]
        public PictureDTO AvatarUrl { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "avatarUrl";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(PictureDTO);
        }
    }
}
