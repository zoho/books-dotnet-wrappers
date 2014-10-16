using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace CurrenciesApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var currenciesApi = service.GetSettingsApi();
                var parameters = new Dictionary<object, object>();
               parameters.Add("filter_by", "Currencies.ExcludeBaseCurrency");
                var currenciesList = currenciesApi.GetCurrencies(parameters);
                var currencies = currenciesList;
                var currencyId = currencies[0].currency_id;
                foreach (var currency in currencies)
                    Console.WriteLine("Id:{0},\ncode:{1},\nname:{2},\nsymbol:{3}\nFormat:{4}\n", currency.currency_id, currency.currency_code, currency.currency_name, currency.currency_symbol, currency.currency_format);
                var currency1 = currenciesApi.GetACurrency(currencyId);
                Console.WriteLine("Id:{0},\ncode:{1},\nname:{2},\nsymbol:{3}\nFormat:{4}\n", currency1.currency_id, currency1.currency_code, currency1.currency_name, currency1.currency_symbol, currency1.currency_format);
                var newCurrencyInfo = new Currency()
                {
                    currency_code = "CUP",
                    currency_symbol = "%",
                    currency_format = "1,234,567.89"
                };
                var newCurrency = currenciesApi.CreateCurrency(newCurrencyInfo);
                Console.WriteLine("Id:{0},\ncode:{1},\nname:{2},\nsymbol:{3}\nFormat:{4}\n", newCurrency.currency_id, newCurrency.currency_code, newCurrency.currency_name, newCurrency.currency_symbol, newCurrency.currency_format);
                var updateInfo = new Currency()
                {
                    currency_symbol = "&"
                };
                var updatedCurrncy = currenciesApi.UpdateCurrency(currencyId, updateInfo);
                Console.WriteLine("Id:{0},\ncode:{1},\nname:{2},\nsymbol:{3}\nFormat:{4}\n", updatedCurrncy.currency_id, updatedCurrncy.currency_code, updatedCurrncy.currency_name, updatedCurrncy.currency_symbol, updatedCurrncy.currency_format);
                var deletemsg = currenciesApi.DeleteCurrency(currencies[2].currency_id);
                Console.WriteLine(deletemsg);
                var exchangeratesList = currenciesApi.GetExchangeRates(currencyId, parameters);
                var exchangerates = exchangeratesList;
                var exchangeRateId = exchangerates[1].exchange_rate_id;
                foreach (var exchangerate in exchangerates)
                    Console.WriteLine("ExchangerateId:{0},\ncurrency Id:{1},Currency Code:{2},\nRate:{3}\n",exchangerate.exchange_rate_id,exchangerate.currency_id,exchangerate.currency_code,exchangerate.rate);
                var exchngerate = currenciesApi.GetAnExchangeRate(currencyId, exchangeRateId);
                Console.WriteLine("ExchangerateId:{0},\ncurrency Id:{1},\nCurrency Code:{2},\nRate:{3}\n", exchngerate.exchange_rate_id, exchngerate.currency_id, exchngerate.currency_code, exchngerate.rate);
                var newExchangerateInfo = new ExchangeRate()
                {
                    effective_date="2014-05-14",
                    rate=31,
                };
                var newExchangerate = currenciesApi.CreateAnExchangeRate(currencyId, newExchangerateInfo);
                Console.WriteLine("ExchangerateId:{0},\ncurrency Id:{1},\nCurrency Code:{2},\nRate:{3}\n", newExchangerate.exchange_rate_id, newExchangerate.currency_id, newExchangerate.currency_code, newExchangerate.rate);
                var updateinfo = new ExchangeRate()
                {
                    rate = 40,
                };
                var updatedExchangerate = currenciesApi.UpdateAnExchangeRate(currencyId, exchangeRateId, updateinfo);
                Console.WriteLine("ExchangerateId:{0},\ncurrency Id:{1},\nCurrency Code:{2},\nRate:{3}\n", updatedExchangerate.exchange_rate_id, updatedExchangerate.currency_id, updatedExchangerate.currency_code, updatedExchangerate.rate);
                var deleteMsg = currenciesApi.DeleteAnExchangeRate(currencyId, exchangerates[1].exchange_rate_id);
                Console.WriteLine(deleteMsg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
