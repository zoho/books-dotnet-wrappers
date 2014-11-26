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
    /// Used to define the parser object of RecurringInvoicesApi.
    /// </summary>
    class RecurringInvoiceParser
    {

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static RecurringInvoiceList getRecurringInvoiceList(HttpResponseMessage responce)
        {
            var recInvoiceList = new RecurringInvoiceList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("recurring_invoices"))
            {
                var recInvoiceArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["recurring_invoices"].ToString());
                foreach (var recInvoiceObj in recInvoiceArray)
                {
                    var recInvoice = new RecurringInvoice();
                    recInvoice = JsonConvert.DeserializeObject<RecurringInvoice>(recInvoiceObj.ToString());
                    recInvoiceList.Add(recInvoice);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                recInvoiceList.page_context = pageContext;
            }
            return recInvoiceList;
        }

        internal static RecurringInvoice getRecurringInvoice(HttpResponseMessage responce)
        {
            var recInvoice = new RecurringInvoice();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("recurring_invoice"))
            {
                recInvoice = JsonConvert.DeserializeObject<RecurringInvoice>(jsonObj["recurring_invoice"].ToString());
            }
            return recInvoice;
        }
    }
}
