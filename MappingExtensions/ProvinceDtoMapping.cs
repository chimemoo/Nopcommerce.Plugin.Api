using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Topics;
using Nop.Plugin.Api.AutoMapper;
using Nop.Plugin.Api.DTO.Topics;

namespace Nop.Plugin.Api.MappingExtensions
{
    public static class ProvinceDtoMapping
    {
        public static ProvinceDTO ToDTO(this StateProvince province)
        {
            return province.MapTo<StateProvince, ProvinceDTO>();
        }
    }
}
