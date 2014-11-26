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
                service.initialize("{authtoken}", "{organizationId}");
                var baseCurrencyAdjustmentApi = service.GetBaseCurrencyAdjustmentsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("filter_by", "Date.All");
                var baseCurrencyAdjustmentsList = baseCurrencyAdjustmentApi.GetBaseCurrencyAdjustments(parameters);
                var adjustments = baseCurrencyAdjustmentsList;
                Console.WriteLine("------------------Adjustment List---------------------");
                foreach (var adjustment in adjustments)
                    Console.WriteLine("{0},{1},{2}", adjustment.base_currency_adjustment_id, adjustment.currency_code, adjustment.exchange_rate);
                var baseAdjust = baseCurrencyAdjustmentApi.Get(adjustments[0].base_currency_adjustment_id);
                Console.WriteLine("----------------specific Adjustment----------------");
                Console.WriteLine("{0},{1},{2}", baseAdjust.base_currency_adjustment_id, baseAdjust.currency_code, baseAdjust.exchange_rate);
                var accounts = baseAdjust.accounts;
                foreach (var account in accounts)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
                var parameters1 = new Dictionary<object, object>();
                parameters1.Add("currency_id", adjustments[0].currency_id);
                parameters1.Add("adjustment_date", adjustments[0].adjustment_date);
                parameters1.Add("exchange_rate", adjustments[0].exchange_rate);
                parameters1.Add("notes", adjustments[0].notes);
                var baseAdjust1 = baseCurrencyAdjustmentApi.GetBaseCurrencyAdjustmentAccounts(parameters1);
                Console.WriteLine("----------------specific Adjustment accounts----------------");
                Console.WriteLine("{0},{1},{2}", baseAdjust.base_currency_adjustment_id, baseAdjust.currency_code, baseAdjust.exchange_rate);
                var accounts1 = baseAdjust.accounts;
                foreach (var account in accounts1)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
                var parameters2 = new Dictionary<object, object>();
                parameters2.Add("account_ids", accounts1[0].account_id);
                var newAdjustInfo=new BaseCurrencyAdjustment()
                {
                    currency_id = baseAdjust1.currency_id,
                    adjustment_date="2014-11-14",
                    exchange_rate=35,
                    notes="notes",
                };
                var newAdjust = baseCurrencyAdjustmentApi.Create(newAdjustInfo, parameters2);
                Console.WriteLine("----------------New Adjustment----------------");
                Console.WriteLine("{0},{1},{2}", newAdjust.base_currency_adjustment_id, newAdjust.currency_code, newAdjust.exchange_rate);
                var accounts2 = newAdjust.accounts;
                foreach (var account in accounts2)
                    Console.WriteLine("{0},{1},{2}", account.account_name, account.adjusted_balance, account.gain_or_loss_formatted);
                var deleteMsg = baseCurrencyAdjustmentApi.Delete(newAdjust.base_currency_adjustment_id);
                Console.WriteLine("----------------Delete Adjustment----------------");
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
