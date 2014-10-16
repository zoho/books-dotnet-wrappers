using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace BankaccountsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ZohoBooks();
            service.initialize("{authtoken}", "{organizationId}");
            var bankAccountsApi = service.GetBankAccountsApi();
            try
            {
                var parameters = new Dictionary<object, object>();
                var bankaccountsList = bankAccountsApi.GetBankAccounts(parameters);
                var bankaccounts = bankaccountsList;
                if (bankaccounts != null)
                    foreach (var bankAccount in bankaccounts)
                        Console.WriteLine("{0},{1},{2}", bankAccount.account_id, bankAccount.account_name, bankAccount.balance);
                string accountId = bankaccounts[0].account_id;
               var bankaccount = bankAccountsApi.Get(accountId);
                if(bankaccount!=null)
                    Console.WriteLine("{0},{1},{2}", bankaccount.account_number, bankaccount.account_name, bankaccount.balance);
                var newAccountInfo = new BankAccount()
                {
                    account_name = "name of account",
                    account_type = "bank",
                    is_primary_account = true
                };
                var newAccount = bankAccountsApi.Create(newAccountInfo);
                if (newAccount != null)
                    Console.WriteLine("{0},{1},{2}", newAccount.is_primary_account, newAccount.account_name, newAccount.balance);
                var updateInfo = new BankAccount()
                {
                    account_name = "name of account",
                    routing_number = "158987"
                };
                var updatedAccount = bankAccountsApi.Update(accountId, updateInfo);
                if(updatedAccount!=null)
                    Console.WriteLine("{0},{1},{2}", updatedAccount.routing_number, updatedAccount.account_name, updatedAccount.balance);
               var delAccount = bankAccountsApi.Delete(bankaccounts[1].account_id);
               Console.WriteLine(delAccount);
               var deactAccount = bankAccountsApi.DeactivateAccount(accountId);
               Console.WriteLine(deactAccount);
               var actAccount = bankAccountsApi.ActivateAccount(accountId);
               Console.WriteLine(actAccount);
               var statement = bankAccountsApi.GetLastImportedStatement(accountId);
              if (statement != null)
              {
                  Console.WriteLine("{0},{1},{2}", statement.statement_id, statement.to_date, statement.transactions.Count);
                  var transactions = statement.transactions;
                  foreach(var transaction in transactions)
                  {
                      Console.WriteLine("{0},{1},{2}", transaction.debit_or_credit, transaction.amount, transaction.transaction_type);
                  }
              }
               var delstatement = bankAccountsApi.DeleteLastImportedStatement(accountId, statement.statement_id);
               Console.WriteLine(delstatement);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
