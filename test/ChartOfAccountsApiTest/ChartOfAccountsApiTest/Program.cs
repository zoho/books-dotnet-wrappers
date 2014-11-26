using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace ChartOfAccountsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organizationId}");
                var chartofAccountApi = service.GetChartOfAccountsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("sort_column", "account_name");
                Console.WriteLine("----------------------------List of Accounts-----------------");
                var chartofaccountsList = chartofAccountApi.GetChartOfAcounts(parameters);
                var accounts = chartofaccountsList;
                foreach (var account in accounts)
                    Console.WriteLine("{0},{1},{2}", account.account_id, account.account_name, account.account_type);
                Console.WriteLine("----------------------------Specified Chart of Account-----------------");
                var account1 = chartofAccountApi.Get(accounts[0].account_id);
                Console.WriteLine("{0},{1},{2}", account1.account_id, account1.account_name, account1.account_type);
                var newAccountInfo = new ChartOfAccount()
                {
                    account_name = "account name",
                    account_type = "cost_of_goods_sold"
                };
                Console.WriteLine("----------------------------New Account-----------------");
                var newAccount = chartofAccountApi.Create(newAccountInfo);
                Console.WriteLine("{0},{1},{2}", newAccount.account_id, newAccount.account_name, newAccount.account_type);
                var updateInfo = new ChartOfAccount()
                {
                    account_name = "hari-test",
                };
                Console.WriteLine("----------------------------Updated Account-----------------");
                var updatedAccount = chartofAccountApi.Update(newAccount.account_id, updateInfo);
                Console.WriteLine("{0},{1},{2}", updatedAccount.account_id, updatedAccount.account_name, updatedAccount.account_type);
                Console.WriteLine("----------------------------Delete Account-----------------");
                var delInfo = chartofAccountApi.Delete(updatedAccount.account_id);
                Console.WriteLine(delInfo);
                Console.WriteLine("----------------------------Mark Account as active/inactive-----------------");
                var markasinactive = chartofAccountApi.MarkAsInactive(accounts[16].account_id);
                Console.WriteLine(markasinactive);
                var markasactive = chartofAccountApi.MarkAsActive(accounts[16].account_id);
                Console.WriteLine(markasactive);
                var parameters1 = new Dictionary<object, object>();
                parameters1.Add("account_id", accounts[0].account_id);
                parameters1.Add("date.start", "2014-02-06");
                parameters1.Add("date.end", "2014-02-08");
                parameters1.Add("amount.less_than", 100);
                Console.WriteLine("----------------------------Transactions of Account-----------------");
                var transactionsList = chartofAccountApi.GetTransactions(parameters1);
                var trans = transactionsList;
                foreach (var tran in trans)
                    Console.WriteLine("{0},{1},{2}", tran.transaction_id, tran.payee, tran.payment_mode);
                Console.WriteLine("----------------------------Delete Transaction of Account-----------------");
                var deltran = chartofAccountApi.DeleteATransaction(trans[0].transaction_id);
                Console.WriteLine(deltran);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            Console.ReadKey();
        }
    }
}
