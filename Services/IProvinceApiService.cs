using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Topics;
using Nop.Plugin.Api.Infrastructure;

namespace Nop.Plugin.Api.Services
{
    public interface IProvinceApiService
    {
        IList<StateProvince> GetProvinces(
               IList<int> ids = null,
               DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null,
               int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
               int sinceId = Constants.Configurations.DefaultSinceId,
               int? productId = null, bool? publishedStatus = null);
    }
}
