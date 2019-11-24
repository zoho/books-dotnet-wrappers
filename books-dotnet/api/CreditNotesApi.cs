using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using zohobooks.exceptions;
using zohobooks.util;
using zohobooks.parser;
namespace zohobooks.api
{
    /// <summary>
    /// Class CreditNoteApi is used to <br></br>
    ///     Create a new credit note for a customer.<br></br>
    ///     Get the Lists of credit notes,invoice credits,credit note refunds,credit note comments and its templates.<br></br>
    ///     Get the details of the specified creditnote,refund of a creditnote,email content and email history of a creditnote.<br></br>
    ///     Send a mail to a cutomer.<br></br>
    ///     Add a creditnote refund or comment for the credit note.<br></br>
    ///     Update the details,creditnote refund,pdf templates,billing and shipping addresses of the specifed creditnote.<br></br>
    ///     Change the status as to open or void.<br></br>
    ///     Delete the existing creditnote,credits applied to the invoices, creitnote refund and comments of the specified credit note. <br></br>
    /// </summary>
    public class CreditNotesApi:Api
    {
        static string baseAddress =baseurl + "/creditnotes";
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditNotesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public CreditNotesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List credit notes with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which is having the filters to refine the list in the form of key,value pairs.<br></br>The possible filters are described in the following list<br></br>
        /// <table>
        /// <tr><td>creditnote_number</td><td>Search credit notes by credit note number.<br></br>Variants: <i>creditnote_number_startswith</i> and <i>creditnote_number_contains</i></td></tr>
        /// <tr><td>date</td><td>Search credit notes by credit note date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date_after</i></td></tr>
        /// <tr><td>status</td><td>Search credit notes by credit note status. Allowed statuses are draft,open,closed and void.<br></br>Allowed Values: <i>open, closed</i> and <i>void</i></td></tr>
        /// <tr><td>total</td><td>Search credit notes by credit note total amount.<br></br>Variants: <i>total_less_than, total_less_equals, total_greater_than</i> and <i>total_greater_equals</i></td></tr>
        /// <tr><td>reference_number</td><td>Search credit notes by credit note reference number.<br></br>Variants: reference_number_startswith and reference_number_contains</td></tr>
        /// <tr><td>customer_name</td><td>Search credit notes by customer name.<br></br>Variants: <i>customer_name_startswith</i> and <i>customer_name_contains</i></td></tr>
        /// <tr><td>item_name</td><td>Search credit notes by item name.<br></br>Variants: <i>item_name_startswith</i> and <i>item_name_contains</i></td></tr>
        /// <tr><td>item_description</td><td>Search credit notes by credit note item description.<br></br>Variants: <i>item_description_startswith</i> and <i>item_description_contains</i></td></tr>
        /// <tr><td>customer_id</td><td>Search credit notes by customer id.</td></tr>
        /// <tr><td>line_item_id</td><td>Search credit notes by credit note line item id.</td></tr>
        /// <tr><td>item_id</td><td>Search credit notes by item id.</td></tr>
        /// <tr><td>tax_id</td><td>Search credit notes by tax id.</td></tr>
        /// <tr><td>filter_by</td><td>Filter credit notes by statuses.<br></br>Allowed Values: <i>Status.All, Status.Open, Status.Draft, Status.Closed</i> and <i>Status.Void</i></td></tr>
        /// <tr><td>search_text</td>Search credit notes by credit note number or customer name or credit note reference number.<td></td></tr>
        /// <tr><td>sort_column</td><td>Sort credit notes by following columns customer_name, creditnote_number, balance, total, date and created_time.<br></br>Allowed Values: <i>customer_name, creditnote_number, balance, total, date</i> and <i>created_time</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>CreditnoteList object.</returns>
        public CreditNoteList GetCreditnotes(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return CreditNoteParser.getCreditnoteList(responce);
        }

        /// <summary>
        /// Gets details of a specified credit note.
        /// </summary>
        /// <param name="creitnote_id">The creitnote_id is the identifier of the creditnote.</param>
        /// <param name="parameters">The parameters is the dictionary object with the two optional key,value pair parameters.<br></br>Those parameters are <br></br>
        /// <table>
        /// <tr><td>print</td><td>Export credit note pdf with default print option.<br></br>Allowed Values: <i>true, false, on</i> and <i>off</i></td></tr>
        /// <tr><td>accept</td><td>You can get credit note details as json/pdf/html. Default format is html.<br></br>Allowed Values: <i>json, xml, csv, xls, pdf</i> and <i>html</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>Creditnote object.</returns>
        public CreditNote Get(string creitnote_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress+"/"+creitnote_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return CreditNoteParser.getCreditnote(responce);
        }

        /// <summary>
        /// Creates a credit note for a customer..
        /// </summary>
        /// <param name="new_creditnote_info">The new_creditnote_info is the Creditnote object which contains the information to create a new creditnote with customer_id as mandatory parameter.</param>
        /// <param name="parameters">The parameters is the dictionary object which is having the optional parameters to the new creditnote.<br></br>Those are listed below<br></br>
        /// <table>
        /// <tr><td>invoice_id</td><td>Create a credit note and apply it to an invoice.</td></tr>
        /// <tr><td>ignore_auto_number_generation</td><td>Ignore auto number generation for this credit note only. On enabling this option credit note number is mandatory.</td></tr>
        /// </table></param>
        /// <returns>Creditnote object.</returns>
        public CreditNote Create(CreditNote new_creditnote_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_creditnote_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return CreditNoteParser.getCreditnote(responce);
        }

        /// <summary>
        /// Updates an existing credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="update_info">The update_info is the Creditnote object which is having the updation details.</param>
        /// <param name="parameters">The parameters is the dictionary object which is having the optional parameters.<br></br>Those are<br></br>
        /// <table>
        /// <tr><td>ignore_auto_number_generation</td><td>Ignore auto number generation for this credit note only. On enabling this option credit note number is mandatory.</td></tr>
        /// </table>
        /// </param>
        /// <returns>Creditnote object.</returns>
        public CreditNote Update(string creditnote_id, CreditNote update_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + creditnote_id;
            var json = JsonConvert.SerializeObject(update_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(parameters));
            return CreditNoteParser.getCreditnote(responce);
        }

        /// <summary>
        /// Deletes the specified creditnote.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <returns>System.String.<br></br>The success message is "The credit note has been deleted."</returns>
        public string Delete(string creditnote_id)
        {
            string url = baseAddress + "/" + creditnote_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }

        /// <summary>
        /// Changes an existing credit note status to open. Voided credit note can't be changed to open.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <returns>System.String.<br></br>The success message is "The status of the credit note has been changed to open."</returns>
        public string ConvertToOpen(string creditnote_id)
        {
            string url = baseAddress+"/"+creditnote_id+"/status/open";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce); 
        }

        /// <summary>
        /// Mark an existing credit note as void.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <returns>System.String.<br></br>The success message is "The credit note has been marked as void."</returns>
        public string ConvertToVoid(string creditnote_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/status/void";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }

        /// <summary>
        /// Emails a credit note to the customer.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="mail_content_info">The mail_content_info is the EmailNotification object with to_mail_ids,subject and body as mandatory parameters.</param>
        /// <param name="parameters">The parameters is the dictionary object which is having the option parameter of customer_id as a key,value pair.</param>
        /// <returns>System.String.<br></br>The success message is "Your credit note has been sent."</returns>
        public string SendEmail(string creditnote_id, EmailNotification mail_content_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress+"/"+creditnote_id+"/email";
            var json = JsonConvert.SerializeObject(mail_content_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return CreditNoteParser.getMessage(responce);
        }

        /// <summary>
        /// Gets the email history of a credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the object.</param>
        /// <returns>List of EmailHistory object.</returns>
        public EmailHistoryList GetEmailHistory(string creditnote_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/emailhistory";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getEmailHistoryList(responce);
        }

        /// <summary>
        /// Gets the content of the email for the creditnote.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the contact.</param>
        /// <param name="parameters">The parameters is the dictionary object which is having the optional parameter email_template_id as key,value pair.</param>
        /// <returns>Email object.</returns>
        public Email GetEmailContent(string creditnote_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + creditnote_id + "/email";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ContactParser.getEmailContent(responce);
        }

        /// <summary>
        /// Updates the billing address for an existing credit note alone. You can set this address as default billing address for your customer by specifying 'is_update_customer' node as true.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="update_info">The update_info is the Address object which contains the changes information.</param>
        /// <returns>System.String.<br></br>the success message is "Billing address updated"</returns>
        public string UpdateBillingAddress(string creditnote_id, Address update_info)
        {
            string url = baseAddress + "/" + creditnote_id + "/address/billing";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getMessage(responce);
        }

        /// <summary>
        /// Updates the shipping address for an existing credit note alone. You can set this address as default shipping address for your customer by specifying 'is_update_customer' node as true.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="update_info">The update_info is the Address object which contains the changes information.</param>
        /// <returns>System.String.<br></br>The success message is "Shipping address updated"</returns>
        public string UpdateShippingAddress(string creditnote_id, Address update_info)
        {
            string url = baseAddress + "/" + creditnote_id + "/address/shipping";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getMessage(responce);
        }

        /// <summary>
        /// Get all credit note pdf templates.
        /// </summary>
        /// <returns>List of Template objects.</returns>
        public TemplateList GetTemplates()
        {
            string url = baseAddress + "/templates";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getTemplateList(responce);
        }

        /// <summary>
        /// Updates the pdf template associated with the credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="template_id">The template_id is the identifier of the template.</param>
        /// <returns>System.String.</returns>
        public string UpdateTemplate(string creditnote_id, string template_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/templates/"+template_id;
            var responce = ZohoHttpClient.put(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }
//---------------------------------------------------------------------------------------------
        /// <summary>
        /// List invoices to which the credit note is applied.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <returns>List of CreditedInvoice object.</returns>
        public CreditedInvoiceList GetInvoicesCredited(string creditnote_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/invoices";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCreditedInvoiceList(responce);
        }

        /// <summary>
        /// Apply credit note to existing invoices.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="invoices_to_apply">The invoices_to_apply is the ApplyToInvoices object which is having the information regarding for which invoices the specifed creditnote is going to apply with invoice_id and amount_applied are mandatory parameters.</param>
        /// <returns>List of CreditedInvoice object.</returns>
        public CreditedInvoiceList CreditToInvoices(string creditnote_id, ApplyToInvoices invoices_to_apply)
        {
            string url = baseAddress + "/" + creditnote_id + "/invoices";
            var json = JsonConvert.SerializeObject(invoices_to_apply);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getCreditsAppliedInvoices(responce);
        }

        /// <summary>
        /// Delete the credits applied to an invoice.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote.</param>
        /// <param name="creditnote_invoice_id">The creditnote_invoice_id is the identifier of the crdited invoice.</param>
        /// <returns>System.String.<br></br>The success message is "Credits applied to an invoice have been deleted."</returns>
        public string DeleteInvoiceCredited(string creditnote_id, string creditnote_invoice_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/invoices/"+creditnote_invoice_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }
//-------------------------------------------------------------------------------------------------
        /// <summary>
        ///List all refunds with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the multiple key,value pair object which helps to refine the list.<br></br>The possible filters are<br></br>
        /// <table>
        /// <tr><td>customer_id</td><td>List credit note refunds made for a particular customer.</td></tr>
        /// <tr><td>sort_column</td><td>Sort refunds list.<br></br>Allowed Values: <i>refund_mode, reference_number, date, creditnote_number, customer_name, amount_bcy</i> and <i>amount_fcy</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>CreditnoteRefundList object.</returns>
        public CreditNoteRefundList GetCreditnoteRefunds(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/refunds";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return CreditNoteParser.getCreditnoteRefundList(responce);
        }

        /// <summary>
        /// List all refunds of an existing credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <returns>CreditnoteRefundList object.</returns>
        public CreditNoteRefundList GetRefundsOfCrreditnote(string creditnote_id)
        {
            string url = baseAddress +"/"+creditnote_id+ "/refunds";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCreditnoteRefundList(responce);
        }

        /// <summary>
        /// Gets refund of a particular credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="creditnote_refund_id">The creditnote_refund_id is the identifier of the refund.</param>
        /// <returns>Creditnote.</returns>
        public CreditNote GetCreditnoteRefund(string creditnote_id, string creditnote_refund_id)
        {
            string url = baseAddress +"/"+creditnote_id+ "/refunds"+creditnote_refund_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCreditnoteRefund(responce);
        }

        /// <summary>
        /// Refund credit note amount.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="refund_details">The refund_details is the Creditnote object which is having the refund details with date and amount parameters as mandatory.</param>
        /// <returns>Creditnote object.</returns>
        public CreditNote AddRefund(string creditnote_id, CreditNote refund_details)
        {
            string url = baseAddress + "/" + creditnote_id + "/refunds";
            var json = JsonConvert.SerializeObject(refund_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getCreditnoteRefund(responce);
        }

        /// <summary>
        /// Updates the refunded transaction.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="creditnote_refund_id">The creditnote_refund_id is the identifier of the refund.</param>
        /// <param name="update_info">The update_info is the Creditnote object which is having the updation details.</param>
        /// <returns>Creditnote object.</returns>
        public CreditNote UpdateRefund(string creditnote_id, string creditnote_refund_id, CreditNote update_info)
        {
            string url = baseAddress + "/" + creditnote_id + "/refunds/"+creditnote_refund_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getCreditnoteRefund(responce);
        }

        /// <summary>
        /// Deletes a credit note refund.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="creditnote_refund_id">The creditnote_refund_id is the identifier of the refund.</param>
        /// <returns>System.String.<br></br>The success message is "The refund has been successfully deleted."</returns>
        public string DeleteRefund(string creditnote_id, string creditnote_refund_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/refunds/"+creditnote_refund_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }
//-----------------------------------------------------------------------------------------------
        /// <summary>
        /// Get history and comments of a credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <returns>List of Comment objects.</returns>
        public CommentList GetcreditnoteComments(string creditnote_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }

        /// <summary>
        /// Adds a comment to an existing credit note.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="new_comment">The new_comment is the Comment object which is having new comment information.</param>
        /// <returns>Comment object.</returns>
        public Comment AddComment(string creditnote_id, Comment new_comment)
        {
            string url = baseAddress + "/" + creditnote_id + "/comments";
            var json = JsonConvert.SerializeObject(new_comment);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getComment(responce);
        }

        /// <summary>
        /// Deletes a credit note comment.
        /// </summary>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the crditnote.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment.</param>
        /// <returns>System.String.<br></br>The success message is "The comment has been deleted."</returns>
        public string DeleteComment(string creditnote_id, string comment_id)
        {
            string url = baseAddress + "/" + creditnote_id + "/comments/"+comment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return CreditNoteParser.getMessage(responce);
        }
    }
}
