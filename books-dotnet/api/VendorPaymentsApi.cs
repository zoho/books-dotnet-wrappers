using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.util;
using zohobooks.parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class VendorPaymentsApi is used to<br></br> 
    ///     Create a payment made for the vendor,<br></br>
    ///     Get the list of vendor payments,<br></br>
    ///     Get the details of the specified vendor payment,<br></br>
    ///     Update or delete the specified vendor payment.<br></br>
    /// </summary>
    public class VendorPaymentsApi:Api
    {
        static string baseAddress = baseurl + "/vendorpayments";
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorPaymentsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public VendorPaymentsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// Gets the vendor payments.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which conrains the filters in the form of key,value pair to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>vendor_name</td><td>Search payments by vendor name.<br></br>Variants: <i>vendor_name_startswith</i> and <i>vendor_name_contains</i></td></tr>
        /// <tr><td>reference_number</td><td>Search payments by reference number.<br></br>Variants: <i>reference_number_startswith</i> and <i>reference_number_contains</i></td></tr>
        /// <tr><td>date</td><td>Search payments by payment made date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date_after</i></td></tr>
        /// <tr><td>amount</td><td>Search payments by payment amount.<br></br>Variants: <i>amount_less_than, amount_less_equals, amount_greater_than</i> and <i>amount_greater_equals</i></td></tr>
        /// <tr><td>payment_mode</td><td>Search payments by payment mode.<br></br>Variants: <i>payment_mode_startswith</i> and <i>payment_mode_contains</i></td></tr>
        /// <tr><td>vendor_id</td><td>Search payments by vendor id.</td></tr>
        /// <tr><td>bill_id</td><td>Search payments by bill id.</td></tr>
        /// <tr><td>filter_by</td><td>Filter payments by mode.<br></br>Allowed Values: <i>PaymentMode.All, PaymentMode.Check, PaymentMode.Cash, PaymentMode.BankTransfer, PaymentMode.Paypal, PaymentMode.CreditCard, PaymentMode.GoogleCheckout, PaymentMode.Credit, PaymentMode.Authorizenet, PaymentMode.BankRemittance, PaymentMode.Payflowpro</i> and <i>PaymentMode.Others</i></td></tr>
        /// <tr><td>search_text</td><td>Search payments by reference number or vendor name or payment description.</td></tr>
        /// <tr><td>sort_column</td><td>Sort the payment list.<br></br>Allowed Values: <i>vendor_name, date, reference_number, amount</i> and <i>balance</i></td></tr>
        /// <tr><td>notes</td><td>Search payments by notes.<br></br>Variants: <i>notes_startswith</i> and <i>notes_contains</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>VendorPaymentList object.</returns>
        public VendorPaymentList GetVendorPayments(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return VendorPaymentParser.getVendorPaymentList(responce);
        }

        /// <summary>
        /// Get the details of a vendor payment.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of the vendor payment.</param>
        /// <returns>VendorPayment object.</returns>
        public VendorPayment Get(string payment_id)
        {
            string url = baseAddress + "/" + payment_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return VendorPaymentParser.getVendorPayment(responce);
        }

        /// <summary>
        /// Create a payment made to vendor and also apply them to bills either partially or fully.
        /// </summary>
        /// <param name="new_vendorpayment_info">The new_vendorpayment_info is the VendorPayment object with vendor_id and amount as mandatory attributes.</param>
        /// <returns>VendorPayment object.</returns>
        public VendorPayment Create(VendorPayment new_vendorpayment_info)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_vendorpayment_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return VendorPaymentParser.getVendorPayment(responce);
        }

        /// <summary>
        /// Update an existing vendor payment. You can also modify the amount applied to the bills.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of the vendor payment.</param>
        /// <param name="update_info">The update_info is the VendorPayment object which contains the updation information.</param>
        /// <returns>VendorPayment object.</returns>
        public VendorPayment Update(string payment_id, VendorPayment update_info)
        {
            string url = baseAddress + "/" + payment_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return VendorPaymentParser.getVendorPayment(responce);
        }

        /// <summary>
        /// Deletes an existing vendor payment.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of the vendor payment.</param>
        /// <returns>System.String.<br></br>The success message is "The payment has been deleted."</returns>
        public string Delete(string payment_id)
        {
            string url = baseAddress + "/" + payment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return VendorPaymentParser.getMessage(responce);
        }
    }
}
