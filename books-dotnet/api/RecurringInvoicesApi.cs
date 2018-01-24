using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class RecurringInvoicesApi is used to<br></br>
    ///     Create new recurring invoice for the customer,<br></br>
    ///     Get the List of recurring invoices and invoice history,<br></br>
    ///     Get the details of a specific recurring invoice,<br></br>
    ///     Update the details of a recurring invoice,<br></br>
    ///     Stop an active recurring invoice,<br></br>
    ///     Resume a stopped recurring invoice,<br></br>
    ///     Update the recurring invoice template,<br></br>
    ///     Delete a recurring invoice. <br></br>
    /// </summary>
    public class RecurringInvoicesApi : Api
    {
        private static readonly string baseAddress = baseurl + "/recurringinvoices";

        /// <summary>
        ///     Initializes a new instance of the <see cref="RecurringInvoicesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public RecurringInvoicesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     List all recurring invoices with pagination.
        /// </summary>
        /// <param name="parameters">
        ///     The parameters is the Dictionary object which conrains the filters in the form of key,value pair to refine the
        ///     list.<br></br>The possible filters are listed below<br></br>
        ///     <table>
        ///         <tr>
        ///             <td>recurrence_name</td>
        ///             <td>
        ///                 Search recurring invoices by name.<br></br>Variants: <i>recurrence_name_startswith</i> and
        ///                 <i>recurrence_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>item_name</td>
        ///             <td>
        ///                 Search recurring invoices by item name.<br></br>Variants: <i>item_name_startswith</i> and
        ///                 <i>profileitemname_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>item_description</td>
        ///             <td>
        ///                 Search recurring invoices by item description.<br></br>Variants: <i>item_description_startswith</i> and
        ///                 <i>item_description_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>customer_name</td>
        ///             <td>
        ///                 Search recurring invoices by customer name.<br></br>Variants: <i>customer_name_startswith</i> and
        ///                 <i>customer_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>line_item_id</td><td>Search recurring invoices by line item id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>item_id</td><td>Search recurring invoices by item id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>tax_id</td><td>Search recurring invoices by tax id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>notes</td>
        ///             <td>
        ///                 Search recurring invoices by notes.<br></br>Variants: <i>notes_startswith</i> and <i>notes_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>start_date</td>Search recurring invoices by start date.<br></br>Variants:
        ///             <i>start_date_start, start_date_end, start_date_before</i> and <i>start_date_after</i><td></td>
        ///         </tr>
        ///         <tr>
        ///             <td>end_date</td>
        ///             <td>
        ///                 Search recurring invoices by end date.<br></br>Variants:
        ///                 <i>end_date_start, end_date_end, end_date_before</i> and <i>end_date_after</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>customer_id</td><td>Search recurring invoices by customer id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>status</td>
        ///             <td>
        ///                 Search recurring invoices by status.<br></br>Allowed Values: <i>active, stopped</i> and <i>expired</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>filter_by</td>
        ///             <td>
        ///                 Filter recurring invoices by any status.<br></br>Allowed Values:
        ///                 <i>Status.All, Status.Active, Status.Stopped</i> and <i>Status.Expired</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>search_text</td><td>Search recurring invoices by recurring invoice name or customer name.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>sort_column</td>
        ///             <td>
        ///                 Sort recurring invoices.<br></br>Allowed Values:
        ///                 <i>customer_name, recurrence_name, total, start_date, end_date, last_sent_date, next_invoice_date</i>
        ///                 and <i>created_time</i>
        ///             </td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>RecurringInvoiceList.</returns>
        public RecurringInvoiceList GetRecurringInvoices(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return RecurringInvoiceParser.getRecurringInvoiceList(responce);
        }

        /// <summary>
        ///     Get the details of a recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <returns>RecurringInvoice object.</returns>
        public RecurringInvoice Get(string recurring_invoice_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return RecurringInvoiceParser.getRecurringInvoice(responce);
        }

        /// <summary>
        ///     Create a recurring invoice for customer.
        /// </summary>
        /// <param name="new_recurring_invoice_info">
        ///     The new_recurring_invoice_info is the RecurringInvoice object with
        ///     recurrence_name,customer_id and recurrence_frequency as mandatory attributes.
        /// </param>
        /// <returns>RecurringInvoice object.</returns>
        public RecurringInvoice Create(RecurringInvoice new_recurring_invoice_info)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(new_recurring_invoice_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return RecurringInvoiceParser.getRecurringInvoice(responce);
        }

        /// <summary>
        ///     Update an existing recurring invoice. To delete a line item just remove it from the line_items list.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <param name="update_info">The update_info is the RecurringInvoice object which contains the updation information.</param>
        /// <returns>RecurringInvoice object.</returns>
        public RecurringInvoice Update(string recurring_invoice_id, RecurringInvoice update_info)
        {
            var url = baseAddress + "/" + recurring_invoice_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return RecurringInvoiceParser.getRecurringInvoice(responce);
        }

        /// <summary>
        ///     Deletes an existing recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring invoice has been deleted."</returns>
        public string Delete(string recurring_invoice_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return RecurringInvoiceParser.getMessage(responce);
        }

        /// <summary>
        ///     Stops an active recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring invoice has been stopped."</returns>
        public string Stop(string recurring_invoice_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id + "/status/stop";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return RecurringInvoiceParser.getMessage(responce);
        }

        /// <summary>
        ///     Resumes a stopped recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring invoice has been activated."</returns>
        public string Resume(string recurring_invoice_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id + "/status/resume";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return RecurringInvoiceParser.getMessage(responce);
        }

        /// <summary>
        ///     Update the pdf template associated with the recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <param name="template_id">The template_id is the identifier of the template.</param>
        /// <returns>System.String.<br></br>The success message is "Recurring invoice information has been updated."</returns>
        public string UpdateTemplate(string recurring_invoice_id, string template_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id + "/templates/" + template_id;
            var responce = ZohoHttpClient.put(url, getQueryParameters());
            return RecurringInvoiceParser.getMessage(responce);
        }

        /// <summary>
        ///     Get the complete history and comments of a recurring invoice.
        /// </summary>
        /// <param name="recurring_invoice_id">The recurring_invoice_id is the identifier of the recuuring invoice.</param>
        /// <returns>List of Comment objects.</returns>
        public CommentList GetComments(string recurring_invoice_id)
        {
            var url = baseAddress + "/" + recurring_invoice_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }
    }
}