using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    /// Used to define the parser object of EstimateSettingsApi.
    /// </summary>
    class EstimateSettingsParser
    {
        
        internal static EstimateSettings getEstimateSettings(System.Net.Http.HttpResponseMessage response)
        {
            var estimateSettings = new EstimateSettings();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("estimate_settings"))
            {
                estimateSettings = JsonConvert.DeserializeObject<EstimateSettings>(jsonObj["estimate_settings"].ToString());
            }
            return estimateSettings;
        }
    }
}
