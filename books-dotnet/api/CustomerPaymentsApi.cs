using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class CustomerPaymentsApi is used to
    ///     Create a payment made by the customer.<br></br>
    ///     Get the list of payments or details of the specified payment made by the customer.<br></br>
    ///     Update or delete an existing payment.
    /// </summary>
    public class CustomerPaymentsApi : Api
    {
        private static readonly string baseAddress = baseurl + "/customerpayments";

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomerPaymentsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public CustomerPaymentsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     List all the payments made by your customer.
        /// </summary>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which is having the filters to refine the list as key,value pairs.<br></br>
        ///     The possible filters are described below<br></br>
        ///     <table>
        ///         <tr>
        ///             customer_name<td></td>
        ///             <td>
        ///                 Search payments by customer name.<br></br>Variants: <i>customer_name_startswith</i> and
        ///                 <i>customer_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>reference_number</td>
        ///             <td>
        ///                 Search payments by reference number.<br></br>Variants: <i>reference_number_startswith</i> and
        ///                 <i>reference_number_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>date</td>
        ///             <td>
        ///                 Search payments by payment made date.<br></br>Variants: <i>date_start, date_end, date_before</i> and
        ///                 <i>date_after</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>amount</td>
        ///             <td>
        ///                 Search payments by payment amount.<br></br>Variants:
        ///                 <i>amount_less_than, amount_less_equals, amount_greater_than</i> and <i>amount_greater_equals</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>payment_mode</td>
        ///             <td>
        ///                 Search payments by payment mode.<br></br>Variants: <i>payment_mode_startswith</i> and
        ///                 <i>payment_mode_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>notes</td>
        ///             <td>
        ///                 Search payments by customer notes.<br></br>Variants: <i>notes_startswith</i> and <i>notes_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>customer_id</td><td>Search payments by customer id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>invoice_id</td><td>Search payments by invoice id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>filter_by</td>
        ///             <td>
        ///                 Filter payments by mode.<br></br>Allowed Values:
        ///                 <i>
        ///                     PaymentMode.All, PaymentMode.Check, PaymentMode.Cash, PaymentMode.BankTransfer, PaymentMode.Paypal,
        ///                     PaymentMode.CreditCard, PaymentMode.GoogleCheckout, PaymentMode.Credit, PaymentMode.Authorizenet,
        ///                     PaymentMode.BankRemittance, PaymentMode.Payflowpro, PaymentMode.Stripe, PaymentMode.TwoCheckout,
        ///                     PaymentMode.Braintree
        ///                 </i>
        ///                 and <i>PaymentMode.Others</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>search_text</td><td>Search payments by reference number or customer name or payment description.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>sort_column</td>
        ///             <td>
        ///                 Sort the payment list.<br></br>Allowed Values:
        ///                 <i>customer_name, unused_amount, amount, bcy_amount, date, reference_number, account_name</i> and
        ///                 <i>payment_mode</i>
        ///             </td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>CustomerPaymentList object.</returns>
        public CustomerPaymentList GetCustomerPayments(Dictionary<object, object> parameters)
        {
            var address = baseAddress;
            var responce = ZohoHttpClient.get(address, getQueryParameters(parameters));
            return CustomerPaymentParser.getPaymentList(responce);
        }

        /// <summary>
        ///     Gets the details of a customer payment.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of the customer payment.</param>
        /// <returns>Customerpayment object.</returns>
        public CustomerPayment Get(string payment_id)
        {
            var address = baseAddress + "/" + payment_id;
            var responce = ZohoHttpClient.get(address, getQueryParameters());
            return CustomerPaymentParser.getPayment(responce);
        }

        /// <summary>
        ///     Create a payment made by your customer and you can also apply them to invoices either partially or fully.
        /// </summary>
        /// <param name="new_customer_payment_info">
        ///     The new_customer_payment_info is the Customerpayment object which having the
        ///     info to made payment with date and amount as mandatory attributes.
        /// </param>
        /// <returns>Customerpayment object.</returns>
        public CustomerPayment Create(CustomerPayment new_customer_payment_info)
        {
            var address = baseAddress;
            var json = JsonConvert.SerializeObject(new_customer_payment_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(address, getQueryParameters(jsonstring));
            return CustomerPaymentParser.getPayment(responce);
        }

        /// <summary>
        ///     Update an existing customer payment. You can also modify the amount applied to the invoices.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of the customer payment.</param>
        /// <param name="update_info">The update_info is the Customerpayment object which is having the changes to apply.</param>
        /// <returns>Customerpayment object.</returns>
        public CustomerPayment Update(string payment_id, CustomerPayment update_info)
        {
            var address = baseAddress + "/" + payment_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(address, getQueryParameters(jsonstring));
            return CustomerPaymentParser.getPayment(responce);
        }

        /// <summary>
        ///     Deletes an existing customer payment.
        /// </summary>
        /// <param name="payment_id">The payment_id is the identifier of an existing customer payment.</param>
        /// <returns>System.String.<br></br>The success message is "The payment has been deleted."</returns>
        public string Delete(string payment_id)
        {
            var address = baseAddress + "/" + payment_id;
            var responce = ZohoHttpClient.delete(address, getQueryParameters());
            return CustomerPaymentParser.getMessage(responce);
        }
    }
}