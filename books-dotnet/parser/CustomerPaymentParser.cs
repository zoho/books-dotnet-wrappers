using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of CustomerPaymentsApi.
    /// </summary>
    internal class CustomerPaymentParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static CustomerPaymentList getPaymentList(HttpResponseMessage responce)
        {
            var customerPaymentlist = new CustomerPaymentList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("customerpayments"))
            {
                var paymentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["customerpayments"].ToString());
                foreach (var paymentObj in paymentsArray)
                {
                    var payment = new CustomerPayment();
                    payment = JsonConvert.DeserializeObject<CustomerPayment>(paymentObj.ToString());
                    customerPaymentlist.Add(payment);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                customerPaymentlist.page_context = pageContext;
            }
            return customerPaymentlist;
        }

        internal static CustomerPayment getPayment(HttpResponseMessage responce)
        {
            var payment = new CustomerPayment();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("payment"))
                payment = JsonConvert.DeserializeObject<CustomerPayment>(jsonObj["payment"].ToString());
            return payment;
        }
    }
}