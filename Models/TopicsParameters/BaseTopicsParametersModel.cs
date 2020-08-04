using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Nop.Plugin.Api.Models.TopicsParameters
{
    public class BaseTopicsParametersModel
    {
        public BaseTopicsParametersModel()
        {
            CreatedAtMin = null;
            CreatedAtMax = null;
            UpdatedAtMin = null;
            UpdatedAtMax = null;
        }

        /// <summary>
        ///     Show topics created after date (format: 2008-12-31 03:00)
        /// </summary>
        [JsonProperty("created_at_min")]
        public DateTime? CreatedAtMin { get; set; }

        /// <summary>
        ///     Show topics created before date (format: 2008-12-31 03:00)
        /// </summary>
        [JsonProperty("created_at_max")]
        public DateTime? CreatedAtMax { get; set; }

        /// <summary>
        ///     Show topics last updated after date (format: 2008-12-31 03:00)
        /// </summary>
        [JsonProperty("updated_at_min")]
        public DateTime? UpdatedAtMin { get; set; }

        /// <summary>
        ///     Show topics last updated before date (format: 2008-12-31 03:00)
        /// </summary>
        [JsonProperty("updated_at_max")]
        public DateTime? UpdatedAtMax { get; set; }
    }
}
