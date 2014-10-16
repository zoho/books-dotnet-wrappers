using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace BaseCurrencyAdjustmentApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var baseCurrencyAdjustmentApi = service.GetBaseCurrencyAdjustmentsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("filter_by", "Date.All");
                var baseCurrencyAdjustmentsList = baseCurrencyAdjustmentApi.GetBaseCurrencyAdjustments(parameters);
                var adjustments = baseCurrencyAdjustmentsList;
                foreach (var adjustment in adjustments)
                    Console.WriteLine("{0},{1},{2}", adjustment.base_currency_adjustment_id, adjustment.currency_code, adjustment.exchange_rate);
                var baseAdjust = baseCurrencyAdjustmentApi.Get(adjustments[1].base_currency_adjustment_id);
                Console.WriteLine("{0},{1},{2}", baseAdjust.base_currency_adjustment_id, baseAdjust.currency_code, baseAdjust.exchange_rate);
                var accounts = baseAdjust.accounts;
                foreach (var account in accounts)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
                var parameters1 = new Dictionary<object, object>();
                
                parameters1.Add("adjustment_date", "2014-02-11");
                parameters1.Add("exchange_rate", "48");
                parameters1.Add("notes", "note");
                var baseAdjust1 = baseCurrencyAdjustmentApi.GetBaseCurrencyAdjustmentAccounts(parameters);
                Console.WriteLine("{0},{1},{2}", baseAdjust.base_currency_adjustment_id, baseAdjust.currency_code, baseAdjust.exchange_rate);
                var accounts1 = baseAdjust.accounts;
                foreach (var account in accounts)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
                var parameters2 = new Dictionary<object, object>();
                parameters.Add("account_ids", adjustments[1].accounts[0].account_id);
                var newAdjustInfo=new BaseCurrencyAdjustment()
                {
                    currency_id = "{currency id}",
                    adjustment_date="2014-02-11",
                    exchange_rate=47.7,
                    notes="notes",
                };
                var newAdjust = baseCurrencyAdjustmentApi.Create(newAdjustInfo,parameters);
                Console.WriteLine("{0},{1},{2}", newAdjust.base_currency_adjustment_id, newAdjust.currency_code, newAdjust.exchange_rate);
                var accounts2 = newAdjust.accounts;
                foreach (var account in accounts2)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
            }   
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        
    }
}
