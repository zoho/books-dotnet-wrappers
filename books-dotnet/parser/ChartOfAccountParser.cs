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
    /// Used to define the parser object of ChartofaccountsApi.
    /// </summary>
    class ChartofaccountParser
    {
        internal static ChartOfAccountList getChartOfAccountList(HttpResponseMessage responce)
        {
            var chartOfAccountList = new ChartOfAccountList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("chartofaccounts"))
            {
                var chartOfAccountsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["chartofaccounts"].ToString());
                foreach(var chartOfAccountObj in chartOfAccountsArray)
                {
                    var chartOfAccount = new ChartOfAccount();
                    chartOfAccount = JsonConvert.DeserializeObject<ChartOfAccount>(chartOfAccountObj.ToString());
                    chartOfAccountList.Add(chartOfAccount);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                chartOfAccountList.page_context = pageContext;
            }
            return chartOfAccountList;
        }

        internal static ChartOfAccount getChartOfAccount(HttpResponseMessage responce)
        {
            var chartOfAccount = new ChartOfAccount();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("chart_of_account"))
            {
                chartOfAccount = JsonConvert.DeserializeObject<ChartOfAccount>(jsonObj["chart_of_account"].ToString());
            }
            return chartOfAccount;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static TransactionList getTransactionList(HttpResponseMessage responce)
        {
            var transactionList = new TransactionList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("transactions"))
            {
                var transactionArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["transactions"].ToString());
                foreach (var transactionObj in transactionArray)
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
    }
}
