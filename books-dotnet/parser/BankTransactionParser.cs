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
    /// Used to define the parser object of BankTransactionsApi.
    /// </summary>
    class BankTransactionParser
    {
        internal static TransactionList getTransactionList(HttpResponseMessage responce)
        {
            var transactionList = new TransactionList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("banktransactions"))
            {
                var transactionArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["banktransactions"].ToString());
                foreach(var transactionObj in transactionArray)
                {
                    var transaction = new Transaction();
                    transaction = JsonConvert.DeserializeObject<Transaction>(transactionObj.ToString());
                    transactionList.Add(transaction);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                transactionList.page_context = pageContext;
            }
            return transactionList;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static Transaction getTransaction(HttpResponseMessage responce)
        {
            var transaction = new Transaction();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("banktransaction"))
            {
                transaction = JsonConvert.DeserializeObject<Transaction>(jsonObj["banktransaction"].ToString());
            }
            return transaction;
        }

        internal static MatchingTransactions getMatchingTransactions(HttpResponseMessage responce)
        {
            var matchingTransactions = new MatchingTransactions();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("matching_transactions"))
            {
                var transArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["matching_transactions"].ToString());
                foreach(var transactionObj in transArray)
                {
                    var transaction = new Transaction();
                    transaction = JsonConvert.DeserializeObject<Transaction>(transactionObj.ToString());
                    matchingTransactions.Add(transaction);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                matchingTransactions.page_context = pageContext;
            }
            if (jsonObj.ContainsKey("instrumentation"))
            {
                var instrumentation = new Instrumentation();
                instrumentation = JsonConvert.DeserializeObject<Instrumentation>(jsonObj["instrumentation"].ToString());
                matchingTransactions.instrumentation = instrumentation;
            }
            return matchingTransactions;
        }

        internal static Transaction getAssociatedTransaction(HttpResponseMessage responce)
        {
            var transaction = new Transaction();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("transaction"))
            {
                transaction = JsonConvert.DeserializeObject<Transaction>(jsonObj["transaction"].ToString());
            }
            return transaction;
        }
    }
}
