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
    /// Used to define the parser object of InvoiceApi.
    /// </summary>
    class InvoiceParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static InvoicesList getInvoiceList(HttpResponseMessage responce)
        {
            var invoiceList = new InvoicesList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("invoices"))
            {
                var invoicesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["invoices"].ToString());
                foreach(var invoiceObj in invoicesArray)
                {
                    var invoice = new Invoice();
                    invoice = JsonConvert.DeserializeObject<Invoice>(invoiceObj.ToString());
                    invoiceList.Add(invoice);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                invoiceList.page_context = pageContext;
            }
            return invoiceList;
        }

        internal static Invoice getInvoice(HttpResponseMessage responce)
        {
            var invoice = new Invoice();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("invoice"))
            {
                invoice = JsonConvert.DeserializeObject<Invoice>(jsonObj["invoice"].ToString());
            }
            return invoice;
        }

        internal static PaymentList getPaymentsList(HttpResponseMessage responce)
        {
            var paymentList = new PaymentList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("payments"))
            {
                var paymentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["payments"].ToString());
                foreach(var paymentObj in paymentsArray)
                {
                    var payment = new Payment();
                    payment = JsonConvert.DeserializeObject<Payment>(paymentObj.ToString());
                    paymentList.Add(payment);
                }
            }
            return paymentList;
        }

        internal static CreditNoteList getCredits(HttpResponseMessage responce)
        {
            var creditList = new CreditNoteList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("credits"))
            {
                var paymentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["credits"].ToString());
                foreach (var paymentObj in paymentsArray)
                {
                    var credit = new CreditNote();
                    credit = JsonConvert.DeserializeObject<CreditNote>(paymentObj.ToString());
                    creditList.Add(credit);
                }
            }
            return creditList;
        }

        internal static UseCredits getUseCredits(HttpResponseMessage responce)
        {
            var useCredits = new UseCredits(); 
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("use_credits"))
            {
                useCredits = JsonConvert.DeserializeObject<UseCredits>(jsonObj["use_credits"].ToString());
            }
            return useCredits;
        }
    }
}
