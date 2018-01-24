﻿using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of VendorPaymentsApi.
    /// </summary>
    internal class VendorPaymentParser
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

        internal static VendorPaymentList getVendorPaymentList(HttpResponseMessage responce)
        {
            var vendorPaymentList = new VendorPaymentList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("vendorpayments"))
            {
                var paymentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["vendorpayments"].ToString());
                foreach (var paymentObj in paymentsArray)
                {
                    var payment = new VendorPayment();
                    payment = JsonConvert.DeserializeObject<VendorPayment>(paymentObj.ToString());
                    vendorPaymentList.Add(payment);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                vendorPaymentList.page_context = pageContext;
            }
            return vendorPaymentList;
        }

        internal static VendorPayment getVendorPayment(HttpResponseMessage responce)
        {
            var payment = new VendorPayment();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("vendorpayment"))
                payment = JsonConvert.DeserializeObject<VendorPayment>(jsonObj["vendorpayment"].ToString());
            return payment;
        }
    }
}