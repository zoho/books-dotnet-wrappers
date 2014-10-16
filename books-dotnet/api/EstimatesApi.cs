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
using zohobooks.Util;
using zohobooks.Parser;


namespace zohobooks.api
{
    /// <summary>
    /// Class EstimatesApi is used to <br></br>
    ///     Create a new estimate for the customer,<br></br>
    ///     Get the list of all estimates,its templates and comments.<br></br>
    ///     Get the estimate in a pdf and pdf with print option.
    ///     Get the details of the specified estimate.
    ///     Update the details,template,comment,billing and shipping addresses of the estimate.
    ///     Marks the status as sent,accepted or declined.
    ///     Delete the specified estimate or its comment.
    /// </summary>
    public class EstimatesApi:Api
    {
       
        static string baseAddress =baseurl + "/estimates";
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimatesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public EstimatesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List all estimates with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters in the form of key,value pairs to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>estimate_number</td><td>Search estimates by estimate number.<br></br>Variants: <i>estimate_number_startswith</i> and <i>estimate_number_contains</i></td></tr>
        /// <tr><td>reference_number</td><td>Search estimates by reference number.<br></br>Variants: <i>reference_number_startswith</i> and <i>reference_number_contains</i></td></tr>
        /// <tr><td>customer_name</td><td>Search estimates by customer name.<br></br>Variants: <i>customer_name_startswith</i> and <i>customer_name_contains</i></td></tr>
        /// <tr><td>total</td><td>Search estimates by estimate total.<br></br>Variants: <i>total_less_than, total_less_equals, total_greater_than</i> and <i>total_greater_equals</i></td></tr>
        /// <tr><td>customer_id</td><td>Search estimates by customer id.</td></tr>
        /// <tr><td>item_id</td><td>Search estimates by item id.</td></tr>
        /// <tr><td>item_name</td><td>Search estimates by item name.<br></br>Variants: <i>item_name_startswith</i> and <i>item_name_contains</i></td></tr>
        /// <tr><td>item_description</td><td>Search estimates by item description.><br></br>Variants: <i>item_description_startswith</i> and <i>item_description_contains</i></td></tr>
        /// <tr><td>custom_field</td><td>Search estimates by custom field.<br></br>Variants: <i>custom_field_startswith</i> and <i>custom_field_contains</i></td></tr>
        /// <tr><td>expiry_date</td><td>Search estimates by expiry date.<br></br>Variants: <i>expiry_date_start, expiry_date_end, expiry_date_before</i> and <i>expiry_date_after</i></td></tr>
        /// <tr><td>date</td><td>Search estimates by estimate date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date_after</i></td></tr>
        /// <tr><td>status</td><td>Search estimates by status.<br></br>Allowed Values: <i>draft, sent, invoiced, accepted, declined</i> and <i>expired</i></td></tr>
        /// <tr><td>filter_by</td><td>Filter estimates by status.<br></br>Allowed Values: <i>Status.All, Status.Sent, Status.Draft, Status.Invoiced, Status.Accepted, Status.Declined</i> and <i>Status.Expired</i></td></tr>
        /// <tr><td>search_text</td><td>Search estimates by estimate number or reference or customer name.</td></tr>
        /// <tr><td>sort_column</td><td>Sort estimates.<br></br>Allowed Values: <i>customer_name, estimate_number, date, total</i> and <i>created_time</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>EstimateList object.</returns>
        public EstimateList GetEstimates(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return EstimateParser.getEstimateList(responce);
        }

        /// <summary>
        /// Gets the deatails of thr specified estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the parameters in the key,value pairs.<br></br>The possible parameters are listed below<br></br>
        /// <table>
        /// <tr><td>print</td><td>Print the exported pdf.</td></tr>
        /// <tr><td>accept</td><td>Get the details of a particular estimate in formats such as json/ pdf/ html. Default format is json.<br></br>Allowed Values: <i>json, pdf</i> and <i>html</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>Estimate object.</returns>
        public Estimate Get(string estimate_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress+"/"+estimate_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return EstimateParser.getEstimate(responce);
        }

        /// <summary>
        /// Create an estimate for your customer.
        /// </summary>
        /// <param name="new_estimate_info">The new_estimate_info is the Estimate object with contact_id and item_name are mandatory attributes.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the parameters in the key,value pairs.<br></br>The parameters are listed below<br></br>
        /// <table>
        /// <tr><td>send</td><td>Send the estimate to the contact person(s) associated with the estimate.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr>
        /// <tr><td>ignore_auto_number_generation</td><td>Ignore auto estimate number generation for this estimate. This mandates the estimate number.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>Estimate object.</returns>
        public Estimate Create(Estimate new_estimate_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_estimate_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            string responceContent = responce.Content.ReadAsStringAsync().Result;
            return EstimateParser.getEstimate(responce);
        }

        /// <summary>
        /// Update an existing estimate. To delete a line item just remove it from the line_items list.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="update_info">The update_info is the Estimate object which contains the update details.</param>
        /// <param name="parameters">The parameters is the Dictionary object.<br></br>The possible parameters are <br></br>
        /// <table><tr><td>ignore_auto_number_generation</td><td>Ignore auto estimate number generation for this estimate. This mandates the estimate number.<br></br>Allowed Values: <i>true</i> and <i>false</i></td></tr></table>
        /// </param>
        /// <returns>Estimate object.</returns>
        public Estimate Update(string estimate_id, Estimate update_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + estimate_id;
            var json = JsonConvert.SerializeObject(update_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(parameters));
            string responceContent = responce.Content.ReadAsStringAsync().Result;
            return EstimateParser.getEstimate(responce);
        }

        /// <summary>
        /// Deletes an existing estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the Estimate.</param>
        /// <returns>System.String.<br></br>The success message is "The estimate has been deleted."</returns>
        public string Delete(string estimate_id)
        {
            string url = baseAddress + "/" + estimate_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Marks a draft estimate as sent.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <returns>System.String.<br></br>The success message is "Estimate status has been changed to Sent."</returns>
        public string MarkAsSent(string estimate_id)
        {
            string url = baseAddress + "/" + estimate_id + "/status/sent";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            var responceContent = responce.Content.ReadAsStringAsync().Result;
            return EstimateParser.getMessage(responce);
        }


        /// <summary>
        /// Mark a sent estimate as accepted if the customer has accepted it.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <returns>System.String.<br></br>The success message is "Estimate status has been changed to Accepted."</returns>
        public string MarkAsAccepted(string estimate_id)
        {
            string url = baseAddress + "/" + estimate_id + "/status/accepted";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            var responceContent = responce.Content.ReadAsStringAsync().Result;
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        ///  Mark a sent estimate as declined if the customer has rejected it.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <returns>System.String.<br></br>The success message is "Estimate status has been changed to Declined."</returns>
        public string MarkAsDeclined(string estimate_id)
        {
            string url = baseAddress + "/" + estimate_id + "/status/declined";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            var responceContent = responce.Content.ReadAsStringAsync().Result;
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Email an estimate to the customer. Input json string is not mandatory. If input json string is empty, mail will be send with default mail content.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="email_details">The email_details is the EmailNotification object with to_mail_ids as mandatory attribute.</param>
        /// <param name="attachment_paths">The attachment_paths are the file paths which are going to be attached with the mail.</param>
        /// <returns>System.String.<br></br>The success message is "Your estimate has been sent."</returns>
        public string SendEmail(string estimate_id, EmailNotification email_details, string[] attachment_paths)
        {
            string url = baseAddress + "/" + estimate_id + "/email";
            var json = JsonConvert.SerializeObject(email_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var files = new KeyValuePair<string, string[]>("attachments",attachment_paths);
            var responce = ZohoHttpClient.post(url, getQueryParameters(),jsonstring,files);
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Send estimates to your customers by email. Maximum of 10 estimates can be sent at once.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which contains the key,value pair parameters.<br></br>The parameters are<br></br>
        /// <table><tr>estimate_ids*<td></td><td>Comma separated estimate ids which are to be emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String.<br></br>The success message is "Mission accomplished! We've sent all the estimates."</returns>
        public string EmailEstimates(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/email";
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Get the email content of an estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="parameters">The parameters is the dictionary object which contains the key,value pair parameters.<br></br>The parameters are<br></br>
        /// <table><tr><td>email_template_id</td><td>Get the email content based on a specific email template. If this param is not inputted, then the content will be based on the email template associated with the customer. If no template is associated with the customer, then default template will be used.</td></tr></table>
        /// </param>
        /// <returns>Email object.</returns>
        public Email GetEmailContent(string estimate_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + estimate_id + "/email";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ContactParser.getEmailContent(responce);
        }

        /// <summary>
        ///  Exports the bulk estimates into pdf.<br></br>Maximum of 25 estimates can be exported in a single pdf.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which contains the key,value pair parameters.<br></br>The parameters are<br></br>
        /// <table><tr>estimate_ids*<td></td><td>Comma separated estimate ids which are to be emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String.<br></br>The success message is "the selected estimates are exported "</returns>
        public string BulkExport(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/pdf";
            ZohoHttpClient.getFile(url, getQueryParameters(parameters));
            return "the selected estimates are exported " ;
        }

        /// <summary>
        /// Export estimates as pdf and print them. Maximum of 25 estimates can be printed.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which contains the key,value pair parameters.<br></br>The parameters are<br></br>
        /// <table><tr>estimate_ids*<td></td><td>Comma separated estimate ids which are to be emailed.</td></tr></table>
        /// </param>
        /// <returns>System.String.<br></br>The success message is "the selected estimates are printed to pdf "</returns>
        public string BulkPrint(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/print";
            ZohoHttpClient.getFile(url, getQueryParameters(parameters));
            return "the selected estimates are printed to pdf ";
        }

        /// <summary>
        /// Updates the billing address for this estimate alone. You can set this address as default billing address for your customer by specifying 'is_update_customer' param as true.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="update_info">The update_info is the Address object which contains the change details.</param>
        /// <returns>System.String.<br></br>The success message is "Billing address updated."</returns>
        public string UpdateBillingAddress(string estimate_id, Address update_info)
        {
            string url = baseAddress + "/" + estimate_id + "/address/billing";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Update the shipping address for an existing estimate alone (You can set this address as default shipping address for your customer by specifying 'is_update_customer' param as true).
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="update_info">The update_info is the Address object which contains the change details.</param>
        /// <returns>System.String.<br></br>The success message is "Shipping address updated"</returns>
        public string UpdateShippingAddress(string estimate_id, Address update_info)
        {
            string url = baseAddress + "/" + estimate_id + "/address/shipping";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return EstimateParser.getMessage(responce);
        }

        /// <summary>
        /// Get all estimate pdf templates.
        /// </summary>
        /// <returns>List of Template objects.</returns>
        public TemplateList GetTemplates()
        {
            string url = baseAddress + "/templates";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getTemplateList(responce);
        }

        /// <summary>
        /// Update the pdf template associated with the estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="template_id">The template_id is the identifier of the template.</param>
        /// <returns>System.String.<br></br>The success message is "Estimate information has been updated."</returns>
        public string UpdateTemplate(string estimate_id, string template_id)
        {
            string url = baseAddress + "/" + estimate_id + "/templates/"+template_id;
            var responce = ZohoHttpClient.put(url, getQueryParameters());
            return EstimateParser.getMessage(responce);
        }
//--------------------------------------------------------------------------------------------------
        /// <summary>
        /// Get the complete history and comments of an estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <returns>List of Comment object.</returns>
        public CommentList GetComments(string estimate_id)
        {
            string url = baseAddress + "/" + estimate_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }

        /// <summary>
        /// Adds a comment for an estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="new_comment_info">The new_comment_info is the Comment object which contains the information to add a new comment.</param>
        /// <returns>Comment object.</returns>
        public Comment AddComment(string estimate_id, Comment new_comment_info)
        {
            string url = baseAddress + "/" + estimate_id + "/comments";
            var json = JsonConvert.SerializeObject(new_comment_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getComment(responce);
        }

        /// <summary>
        /// Update an existing comment of an estimate.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment.</param>
        /// <param name="update_info">The update_info is the Comment object with show_comment_to_clients as requsted attribute.</param>
        /// <returns>Comment object.</returns>
        public Comment UpdateComment(string estimate_id, string comment_id, Comment update_info)
        {
            string url = baseAddress + "/" + estimate_id + "/comments/"+comment_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditNoteParser.getComment(responce);
        }

        /// <summary>
        /// Deletes an estimate comment.
        /// </summary>
        /// <param name="estimate_id">The estimate_id is the identifier of the estimate.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment.</param>
        /// <returns>System.String.<br></br>The success message is "The comment has been deleted."</returns>
        public string DeleteComment(string estimate_id, string comment_id)
        {
            string url = baseAddress + "/" + estimate_id + "/comments/"+comment_id;;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            StringBuilder queryString = new StringBuilder();
            return EstimateParser.getMessage(responce);
        }
    }
}