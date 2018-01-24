using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of BaseCurrencyAdjustmentApi.
    /// </summary>
    internal class BaseCurrencyAdjustmentParser
    {
        internal static BaseCurrencyAdjustmentsList getBaseCurrencyAdjustmentList(HttpResponseMessage responce)
        {
            var baseCurrencyAdjustmentList = new BaseCurrencyAdjustmentsList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("base_currency_adjustments"))
            {
                var baseCurrencyAdjArray =
                    JsonConvert.DeserializeObject<List<object>>(jsonObj["base_currency_adjustments"].ToString());
                foreach (var baseCurrencyAdjObj in baseCurrencyAdjArray)
                {
                    var baseCurrencyAdj = new BaseCurrencyAdjustment();
                    baseCurrencyAdj =
                        JsonConvert.DeserializeObject<BaseCurrencyAdjustment>(baseCurrencyAdjObj.ToString());
                    baseCurrencyAdjustmentList.Add(baseCurrencyAdj);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                baseCurrencyAdjustmentList.page_context = pageContext;
            }
            return baseCurrencyAdjustmentList;
        }

        internal static BaseCurrencyAdjustment getBaseCurrencyAdjustment(HttpResponseMessage responce)
        {
            var baseCurrencyAdjustment = new BaseCurrencyAdjustment();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("data"))
                baseCurrencyAdjustment =
                    JsonConvert.DeserializeObject<BaseCurrencyAdjustment>(jsonObj["data"].ToString());
            return baseCurrencyAdjustment;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }
    }
}