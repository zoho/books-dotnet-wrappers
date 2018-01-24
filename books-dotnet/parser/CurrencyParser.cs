using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of currenciesApi.
    /// </summary>
    internal class CurrencyParser
    {
        internal static CurrencyList getCurrencyList(HttpResponseMessage response)
        {
            var currencylist = new CurrencyList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("currencies"))
            {
                var currencyArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["currencies"].ToString());
                foreach (var currencyObj in currencyArray)
                {
                    var currency = new Currency();
                    currency = JsonConvert.DeserializeObject<Currency>(currencyObj.ToString());
                    currencylist.Add(currency);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                currencylist.page_context = pageContext;
            }
            return currencylist;
        }

        internal static Currency getCurrency(HttpResponseMessage response)
        {
            var currency = new Currency();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("currency"))
                currency = JsonConvert.DeserializeObject<Currency>(jsonObj["currency"].ToString());
            return currency;
        }

        internal static ExchangeRateList getExchangeRateList(HttpResponseMessage response)
        {
            var rateList = new ExchangeRateList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("exchange_rates"))
            {
                var ratesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["exchange_rates"].ToString());
                foreach (var rateObj in ratesArray)
                {
                    var rate = new ExchangeRate();
                    rate = JsonConvert.DeserializeObject<ExchangeRate>(rateObj.ToString());
                    rateList.Add(rate);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                rateList.page_context = pageContext;
            }
            return rateList;
        }

        internal static ExchangeRate getExchangeRate(HttpResponseMessage response)
        {
            var rate = new ExchangeRate();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("exchange_rate"))
                rate = JsonConvert.DeserializeObject<ExchangeRate>(jsonObj["exchange_rate"].ToString());
            return rate;
        }
    }
}