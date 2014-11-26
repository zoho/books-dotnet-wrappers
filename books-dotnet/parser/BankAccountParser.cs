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
    /// Used to define the parser object of BankAccountsApi.
    /// </summary>
    
     class BankAccountParser
    {
        internal static BankAccountList getBankAccountList(HttpResponseMessage responce)
        {
            var bankAccountList = new BankAccountList();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("bankaccounts"))
            {
                var bankAccountsArray = JsonConvert.DeserializeObject<List<object>>(jsonObject["bankaccounts"].ToString());
                foreach (var bankAccountObj in bankAccountsArray)
                {
                    var bankAccount = new BankAccount();
                    bankAccount = JsonConvert.DeserializeObject<BankAccount>(bankAccountObj.ToString());
                    bankAccountList.Add(bankAccount);
                }
            }
            if (jsonObject.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObject["page_context"].ToString());
                bankAccountList.page_context = pageContext;
            }
            return bankAccountList;
        }

        internal static BankAccount getBankAccount(HttpResponseMessage responce)
        {
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            var bankAccount = new BankAccount();
            if (jsonObj.ContainsKey("bankaccount"))
            {
                bankAccount = JsonConvert.DeserializeObject<BankAccount>(jsonObj["bankaccount"].ToString());
            }
            return bankAccount;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
            {
                message = jsonObj["message"].ToString();
            }
            return message;
        }

        internal static Statement getStatement(HttpResponseMessage responce)
        {
            var statement = new Statement();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string,object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("statement"))
            {
                statement = JsonConvert.DeserializeObject<Statement>(jsonObj["statement"].ToString());
            }
            return statement;
        }
    }
}
