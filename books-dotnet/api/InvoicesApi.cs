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
using zohobooks.util;
using zohobooks.parser;


namespace zohobooks.api
{
    /// <summary>
    /// Class InvoicesApi is used to <br></br>
    ///     Get the list of invoices,invoice payments,credits applied or comments for an invoice,<br></br>
    ///     Get the details of the invoice,invoice mail content,invoices as pdf,invoice templates or an invoice 
    ///     ,<br></br>
    ///     Update the details,templates,billing and shipping addresses,attachment preferences,comment of the specifed invoice,<br></br>
    ///     Mark the status as sent,void or draft,<br></br>
    ///     Reminder to the customer or multiple customers by email,<br></br>
    ///     Apply creditnote to the invoice,<br></br>
    ///     Add a comment or attachment to the invoice,<br></br>
    ///     Delete the invoice,payment made to invoice or comment of the invoice.<br></br>
    /// </summary>
    public class InvoicesApi:Api
    {
        
        static string baseAddress =baseurl + "/invoices";
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public InvoicesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List all invoices with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters in the form of key,value pairs to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>invoice_number</td><td>Search invoices by invoice number.<br></br>Variants: <i>invoice_number_startswith</i> and <i>invoice_number_contains</i></td></tr>
        /// <tr><td>item_name</td><td>Search invoices by item name.<br></br>Variants: <i>item_name_startswith</i> and <i>item_name_contains</i></td></tr>
        /// <tr><td>item_id</td><td>Search invoices by item id.</td></tr>
        /// <tr><td>item_description</td><td>Search invoices by item description.<br></br>Variants: <i>item_description_startswith</i> and <i>item_description_contains</i></td></tr>
        /// <tr><td>reference_number</td><td>Search invoices by invoice reference number (i.e., P.O.#).<br></br>Variants: <i>reference_number_startswith</i> and <i>reference_number_contains</i></td></tr>
        /// <tr><td>customer_name</td><td>Search invoices by customer name.<br></br>Variants: <i>customer_name_startswith</i> and <i>customer_name_contains</i></td></tr>
        /// <tr><td>recurring_invoice_id</td><td>Search invoices by recurring profile id.</td></tr>
        /// <tr><td>email</td><td>Search invoices by customer contact persons email.</td></tr>
        /// <tr><td>total</td><td>Search invoices by invoice total.<br></br>Variants: <i>total_less_than, total_less_equals, total_greater_than</i> and <i>total_greater_equals</i></td></tr>
        /// <tr><td>balance</td><td>Search invoices by invoice total.<br></br>Variants: <i>balance_less_than, balance_less_equals, balance_greater_than</i> and <i>balance_greater_equals</i></td></tr>
        /// <tr><td>date</td><td>Search invoices by invoice date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date_after</i></td></tr>
        /// <tr><td>due_date</td><td>Search invoices by due date.<br></br>Variants: <i>due_date_start, due_date_end, due_date_before</i> and <i>due_date_after</i></td></tr>
        /// <tr><td>status</td><td>Search invoices by invoice status.<br></br>Allowed Values: <i>sent, draft, overdue, paid, void, unpaid, partiallypaid</i> and <i>viewed</i></td></tr>
        /// <tr><td>customer_id</td><td>Search invoices by customer id.</td></tr>
        /// <tr><td>custom_field</td><td>Search invoices by custom fields.<br></br>Variants: <i>custom_field_startswith</i> and <i>custom_field_contains</i></td></tr>
        /// <tr><td>filter_by</td><td>Filter invoices by any status or payment expected date.<br></br>Allowed Values: <i>Status.All, Status.Sent, Status.Draft, Status.OverDue, Status.Paid, Status.Void, Status.Unpaid, Status.PartiallyPaid, Status.Viewed</i> and <i>Date.PaymentExpectedDate</i></td></tr>
        /// <tr><td>search_text</td><td>Search invoices by invoice number or purchase order or customer name.</td></tr>
        /// <tr><td>sort_column</td><td>Sort invoices.<br></br>Allowed Values: <i>customer_name, invoice_number, date, due_date, total, balance</i> and <i>created_time</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>InvoicesList object.</returns>
        public InvoicesList GetInvoices(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return InvoiceParser.getInvoiceList(responce);
        }

        /// <summary>
        /// Get the details of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the following optional parameters in the key,value pair forms.<br></br>
        /// <table>
        /// <tr><td>print</td><td>Print the exported pdf.</td></tr>
        /// <tr><td>accept</td><td>Get the details of a particular invoice in formats such as json/ pdf/ html. Default format is json.<br></br>Allowed Values: <i>json, pdf</i> and <i>html</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>Invoice object.</returns>
        public Invoice Get(string invoice_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return InvoiceParser.getInvoice(responce);
        }

        /// <summary>
        /// Create an invoice for customer.
        /// </summary>
        /// <param name="new_invoice_info">The new_invoice_info is the Invoice object .</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the following optional parameters in the key,value pair forms.<br></br>
        /// <table>
        /// <tr><td>send</td><td>Send the invoice to the contact person(s) associated with the invoice.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr>
        /// <tr><td>ignore_auto_number_generation</td><td>Ignore auto invoice number generation for this invoice. This mandates the invoice number.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr>
        /// </table></param>
        /// <returns>Invoice object.</returns>
        public Invoice Create(Invoice new_invoice_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_invoice_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            var responceContent = responce.Content.ReadAsStringAsync().Result;
            return InvoiceParser.getInvoice(responce);
        }

        /// <summary>
        /// Update an existing invoice. To delete a line item just remove it from the line_items list.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="update_info">The update_info is the Invoice object which contains the update information.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the following optional parameters in the key,value pair forms.<br></br>
        /// <table>
        /// <tr><td>ignore_auto_number_generation</td><td>Ignore auto invoice number generation for this invoice. This mandates the invoice number.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr>
        /// </table></param>
        /// <returns>Invoice object.</returns>
        public Invoice Update(string invoice_id, Invoice update_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id;
            var json = JsonConvert.SerializeObject(update_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(parameters));
            var responceContent = responce.Content.ReadAsStringAsync().Result;
            return InvoiceParser.getInvoice(responce);
        }

        /// <summary>
        /// Delete an existing invoice. Invoices which have payment or credits note applied cannot be deleted.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "The invoice has been deleted."</returns>
        public string Delete(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Mark a draft invoice as sent.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Invoice status has been changed to Sent."</returns>
        public string MarkAsSent(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/status/sent";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Mark an invoice status as void. Upon voiding, the payments and credits associated with the invoices will be unassociated and will be under customer credits.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Invoice status has been changed to Void."</returns>
        public string MarkAsVoid(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/status/void";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        ///Mark a voided invoice as draft.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Status of invoice changed from void to draft."</returns>
        public string MarkAsDraft(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/status/draft";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Email an invoice to the customer. Input json string is not mandatory. If input json string is empty, mail will be send with default mail content.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="email_details">The email_details is the EmailNotification object with to_mail_ids as mandatory attribute.</param>
        /// <param name="attachment_paths">The attachment_paths is the file paths which are going to be attached to the mail.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the following optional parameters in the key,value pair forms.<br></br>
        /// <table>
        /// <tr><td>send_customer_statement</td><td>Send customer statement pdf a with email.</td></tr>
        /// <tr><td>send_attachment</td><td>Send the invoice attachment a with the email.</td></tr>
        /// </table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Your invoice has been sent."</returns>
        public string SendEmail(string invoice_id, EmailNotification email_details, string[] attachment_paths, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id + "/email";
            var json = JsonConvert.SerializeObject(email_details);
            var jsonString = new Dictionary<object, object>();
            jsonString.Add("JSONString", json);
            var files = new KeyValuePair<string, string[]>("attachments", attachment_paths);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters),jsonString,files);
            string responceContent = responce.Content.ReadAsStringAsync().Result;
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Send invoices to your customers by email. Maximum of 10 invoices can be sent at once.
        /// </summary>
        /// <param name="contacts">The contacts is the Contacts object with contact_id as a mandatory attribute.</param>
        /// <param name="parameters">The parameters is the dictionary object which is having the following mandatory parameter in the form of key,value pair.<br></br>
        /// <table><tr><td>invoice_ids</td><td>Comma separated invoice ids which are to be emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Mission accomplished! We've sent all the invoices." </returns>
        public string EmailInvoices(Contacts contacts, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/email";
            var json = JsonConvert.SerializeObject(contacts);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            string responceContent = responce.Content.ReadAsStringAsync().Result;
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Get the email content of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the optional parameter that will provides the template as key,value pair.<br></br>
        /// <table><tr><td>email_template_id</td><td>Get the email content based on a specific email template. If this param is not inputted, then the content will be based on the email template associated with the customer. If no template is associated with the customer, then default template will be used.</td></tr></table>
        /// </param>
        /// <returns>Email object.</returns>
        public Email GetEmailContent(string invoice_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id + "/email";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ContactParser.getEmailContent(responce);
        }

        /// <summary>
        /// Remind your customer about an unpaid invoice by email. Reminder will be sent, only for the invoices which are in open or overdue status.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="notify_details">The notify_details is the EmailNotification object with to_mail_ids as mandatory parameter.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the following optional parameter in the key,value pair format.<br></br>
        /// <table><tr><td>send_customer_statement</td><td>Send customer statement pdf a with payment reminder.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Your payment reminder has been sent."</returns>
        public string RemindCustomer(string invoice_id, EmailNotification notify_details, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id + "/paymentreminder";
            var json = JsonConvert.SerializeObject(notify_details);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Remind your customer about an unpaid invoices by email. Reminder mail will be send, only for the invoices is in open or overdue status. Maximum 10 invoices can be reminded at once.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which conatins the following mandatory pameter in the key value pair format.<br></br>
        /// <table><tr><td>invoice_ids*</td><td>Array of invoice ids for which the reminder has to be sent.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Success! All reminders have been sent." </returns>
        public string BulkInvoiceReminder(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/paymentreminder";
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Gets the mail content of the payment reminder.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>Email object.</returns>
        public Email GetPaymentReminder(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/paymentreminder";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ContactParser.getEmailContent(responce);
        }

        /// <summary>
        /// Maximum of 25 invoices can be exported in a single pdf.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which conatins the following mandatory pameter in the key value pair format.<br></br>
        /// <table><tr><td>invoice_ids*</td><td>Array of invoice ids for which the reminder has to be sent.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "the selected invoices are exported "</returns>
        public string BulkExport(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/pdf";
            ZohoHttpClient.getFile(url, getQueryParameters(parameters));
            return "the selected invoices are exported ";
            
        }

        /// <summary>
        /// Export invoices as pdf and print them. Maximum of 25 invoices can be printed.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which conatins the following mandatory pameter in the key value pair format.<br></br>
        /// <table><tr><td>invoice_ids*</td><td>Array of invoice ids for which the reminder has to be sent.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "the selected invoices are printed "</returns>
        public string BulkPrint(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/print";
             ZohoHttpClient.getFile(url, getQueryParameters(parameters));
                return "the selected invoices are printed ";
        }

        /// <summary>
        /// Disables automated payment reminders for an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Reminders stopped."</returns>
        public string DisablePaymentReminder(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/paymentreminder/disable";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Enables automated payment reminders for an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Reminders enabled." </returns>
        public string EnablePaymentReminder(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/paymentreminder/enable";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Write off the invoice balance amount of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Invoice has been written off."</returns>
        public string WriteoffInvoice(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/writeoff";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Cancel the write off amount of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "The write off done for this invoice has been cancelled." </returns>
        public string CancelWriteoff(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/writeoff/cancel";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Updates the billing address for this invoice alone. You can set this address as default billing address for your customer by specifying 'is_update_customer' param as true.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="update_info">The update_info ois the Address object which contains the updation information.</param>
        /// <returns>System.String<br></br> The success message is "Billing address updated"</returns>
        public string UpdateBillingAddress(string invoice_id, Address update_info)
        {
            string url = baseAddress + "/" + invoice_id + "/address/billing";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Updates the shipping address for this invoice. You can set this address as default shipping address for your customer by specifying 'is_update_customer' param as true.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="update_info">The update_info ois the Address object which contains the updation information.</param>
        /// <returns>System.String<br></br> The success message is "Shipping address updated"</returns>
        public string UpdateShippingAddress(string invoice_id, Address update_info)
        {
            string url = baseAddress + "/" + invoice_id + "/address/shipping";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Get all invoice pdf templates.
        /// </summary>
        /// <returns>List of Template objects.</returns>
        public TemplateList GetTemplates()
        {
            string url = baseAddress + "/templates" ;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getTemplateList(responce);
        }

        /// <summary>
        /// Update the pdf template associated with the invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="template_id">The template_id is the identifer of the template .</param>
        /// <returns>System.String<br></br> The success message is "Invoice information has been updated." </returns>
        public string UpdateTemplate(string invoice_id, string template_id)
        {
            string url = baseAddress +"/"+ invoice_id+"/templates/"+template_id ;
            var responce = ZohoHttpClient.put(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }
//-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the list of payments made for an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>List of InvoicePayment objects.</returns>
        public PaymentList GetPayments(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/payments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return InvoiceParser.getPaymentsList(responce);
        }

        /// <summary>
        /// Get the list of credits applied for an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>List of Creditnote objects.</returns>
        public CreditNoteList GetCreditsApplied(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/creditsapplied";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return InvoiceParser.getCredits(responce);
        }

        /// <summary>
        /// Apply the customer credits either from credit notes or excess customer payments to an invoice. Multiple credits can be applied at once.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="credits_to_apply">The credits_to_apply is the UseCredits object which contains the credits information to apply.</param>
        /// <returns>UseCredits object.</returns>
        public UseCredits AddCredits(string invoice_id, UseCredits credits_to_apply)
        {
            string url = baseAddress + "/" + invoice_id + "/credits";
            var json = JsonConvert.SerializeObject(credits_to_apply);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return InvoiceParser.getUseCredits(responce);
        }

        /// <summary>
        /// Deletes a payment made to an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="payment_id">The payment_id is the identifier of the payment.</param>
        /// <returns>System.String<br></br> The success message is "The payment has been deleted."</returns>
        public string DeletePayment(string invoice_id, string payment_id)
        {
            string url = baseAddress + "/" + invoice_id+"/payments/"+payment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Deltes the applied credit.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="creditnote_id">The creditnote_id is the identifier of the creditnote which applied for the specified invoice.</param>
        /// <returns>System.String<br></br> The success message is "Credits applied to an invoice have been deleted." </returns>
        public string DelteAppliedCredit(string invoice_id, string creditnote_id)
        {
            string url = baseAddress + "/" + invoice_id + "/creditsapplied/" + creditnote_id;;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }
//----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the complete history and comments of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>List of Comment objects</returns>
        public CommentList GetComments(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/comments";;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }

        /// <summary>
        /// Add a comment for an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="new_comment_info">The new_comment_info is the Comment object which contains the information to add a new comment.</param>
        /// <returns>Comment object.</returns>
        public Comment AddComment(string invoice_id, Comment new_comment_info)
        {
            string url = baseAddress + "/" + invoice_id + "/comments";
            var json = JsonConvert.SerializeObject(new_comment_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getComment(responce);
        }

        /// <summary>
        /// Update an existing comment of an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment of specified invoice.</param>
        /// <param name="update_info">The update_info is the Comment object which contains the updation information.</param>
        /// <returns>Comment object.</returns>
        public Comment UpdateComment(string invoice_id, string comment_id, Comment update_info)
        {
            string url = baseAddress + "/" + invoice_id + "/comments/"+comment_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getComment(responce);
        }

        /// <summary>
        /// Delete an invoice comment.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment of specified invoice.</param>
        /// <returns>System.String<br></br> The success message is "The comment has been deleted." </returns>
        public string DeleteComment(string invoice_id, string comment_id)
        {
            string url = baseAddress + "/" + invoice_id + "/comments/"+comment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }
//--------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns the file attached to the invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "the selected expense receipt is saved at home directory" </returns>
        public string GetAttachment(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/attachment";
            ZohoHttpClient.getFile(url, getQueryParameters());
            return "the selected expense receipt is saved at home directory";
        }


        /// <summary>
        /// Attach a file to an invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="attachment_Path">The attachment_ path is the file information which is going to be attached to thr invoice.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following optional parameter in the form of key,value pair.<br></br>
        /// <table><tr><td>can_send_in_mail</td><td>True to send the attachment with the invoice when emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Your file has been successfully attached to the invoice." </returns>
        public string AddAttachment(string invoice_id, string attachment_Path, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id + "/attachment";
            var attachment = new string[] { attachment_Path };
            var file = new KeyValuePair<string, string[]>("attachment", attachment);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters),null, file);
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Set whether you want to send the attached file while emailing the invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following mandatory parameter in the form of key,value pair.<br></br>
        /// <table><tr><td>can_send_in_mail*</td><td>True to send the attachment with the invoice when emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String<br></br> The success message is "Invoice information has been updated." </returns>
        public string UpdateAttachment(string invoice_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + invoice_id + "/attachment";
            var responce = ZohoHttpClient.put(url, getQueryParameters(parameters));
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Delete the file attached to the invoice.
        /// </summary>
        /// <param name="invoice_id">The invoice_id is the identifier of the invoice.</param>
        /// <returns>System.String<br></br> The success message is "Your file is no longer attached to the invoice." </returns>
        public string DeleteAttachment(string invoice_id)
        {
            string url = baseAddress + "/" + invoice_id + "/attachment";
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }

        /// <summary>
        /// Delete the expense receipts attached to an invoice which is raised from an expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <returns>System.String<br></br> The success message is "The attached expense receipt has been deleted."</returns>
        public string DeleteExpenseReceipt(string expense_id)
        {
            string url = baseAddress + "/expenses/" + expense_id + "/receipt";
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return InvoiceParser.getMessage(responce);
        }
    }
}
