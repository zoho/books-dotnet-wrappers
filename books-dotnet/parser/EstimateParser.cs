using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.Parser
{
    /// <summary>
    /// Used to define the parser object of EstimateApi.
    /// </summary>
    class EstimateParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static EstimateList getEstimateList(HttpResponseMessage responce)
        {
            var estimateList = new EstimateList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("estimates"))
            {
                var estimatesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["estimates"].ToString());
                foreach(var estimateObj in estimatesArray)
                {
                    var estimate = new Estimate();
                    estimate = JsonConvert.DeserializeObject<Estimate>(estimateObj.ToString());
                    estimateList.Add(estimate);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                estimateList.page_context = pageContext;
            }
            return estimateList;
        }

        internal static Estimate getEstimate(HttpResponseMessage responce)
        {
            var estimate = new Estimate();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("estimate"))
            {
                estimate = JsonConvert.DeserializeObject<Estimate>(jsonObj["estimate"].ToString());
            }
            return estimate;
        }
    }
}
