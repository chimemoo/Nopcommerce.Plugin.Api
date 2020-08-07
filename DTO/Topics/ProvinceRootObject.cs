using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Nop.Core.Domain.Directory;

namespace Nop.Plugin.Api.DTO.Topics
{
    public class ProvinceRootObject : ISerializableObject
    {
        public ProvinceRootObject()
        {
            Provinces = new List<ProvinceDTO>();
        }

        [JsonProperty("provinces")]
        public IList<ProvinceDTO> Provinces { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "provinces";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(ProvinceDTO);
        }
    }
}
