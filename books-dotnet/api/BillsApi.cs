using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using zohobooks.util;
using zohobooks.api;
using zohobooks.parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class BillsApi is used to <br></br>
    /// Create a Bill for the vendor.<br></br>
    /// Get the list of bills<br></br>
    /// Get the details of the specified bill.<br></br>
    /// Get the List of bill payments.<br></br>
    /// Get the bill attachment(receipt).<br></br>
    /// Get the comments list of the bill.<br></br>
    /// Apply credits to a bill.<br></br>
    /// Attach a receipt to a bill.<br></br>
    /// Add a comment to the bill.<br></br>
    /// Update the bill details.<br></br>
    /// Update the billing and shipping addresses of the bill.<br></br>
    /// Delete the specified bill,payment or bill comment.<br></br>
    /// </summary>
    public class BillsApi:Api
    {
        static string baseAddress =baseurl + "/bills";
        /// <summary>
        /// Initializes a new instance of the <see cref="BillsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public BillsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// Gets the List of bills with pagination.
        /// </summary>
        /// <param name="parameters">The parameters contains the fiters to refine the bills list in the form of key value pairs.<br></br>The possible filter keys and the corespondent allowed values is listed below\
        /// <table>
        /// <tr><td>reference_number</td><td>Search bills by reference number.<br></br>Variants: <i>reference_number_startswith</i> and <i>reference_number_contains</i></td></tr>
        /// <tr><td>bill_number</td><td>Search bills by bill number.<br></br>Variants: <i>bill_number_startswith</i> and <i>bill_number_contains</i></td></tr>
        /// <tr><td>date</td><td>Search bills by bill date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date.after</i></td></tr>
        /// <tr><td>status</td><td>Search bills by bill status.<br></br>Allowed Values: <i>paid, open, overdue, void</i> and <i>partially_paid</i></td></tr>
        /// <tr><td>description</td><td>Search bills by description.<br></br>Variants: <i>description_startswith</i> and <i>description_contains</i></td></tr>
        /// <tr><td>vendor_name</td><td>Search bills by vendor name.<br></br>Variants: <i>vendor_name_startswith</i> and <i>vendor_name_contains</i></td></tr>
        /// <tr><td>total</td><td>Search bills by bill total.<br></br>Variants: <i>total_less_than, total_less_equals, total_greater_than</i> and <i>total_greater_equals</i></td></tr>
        /// <tr><td>vendor_id</td><td>Search bills by bill vendor id.</td></tr>
        /// <tr><td>item_id</td><td>Search bills by bill item id.</td></tr>
        /// <tr><td>filter_by</td><td>Filter bills by any status.<br></br>Allowed Values: <i>Status.All, Status.PartiallyPaid, Status.Paid, Status.Overdue, Status.Void </i>and <i>Status.Open</i></td></tr>
        /// <tr><td>search_text</td><td>Search bills by bill number or reference number or vendor name.</td></tr>
        /// <tr><td>sort_coloumn</td><td>Sort bills.<br></br>Allowed Values: <i>vendor_name, bill_number, date, due_date, total, balance</i> and <i>created_time</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>BillList object.</returns>
        public BillList GetBills(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BillParser.getBillList(responce);
        }
        /// <summary>
        /// Gets the specified bill details.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill for which the details has to be get.</param>
        /// <returns>Bill object.</returns>
        public Bill Get(string bill_id)
        {
            string url = baseAddress + "/" + bill_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BillParser.getBill(responce);
        }
        /// <summary>
        /// Creates the bill for the vendor specified information.
        /// </summary>
        /// <param name="new_bill_info">The new_bill_info is the bill object which contains the vendor_id,account_id and bill_number as mandatory parameters.</param>
        /// <param name="attachment_path">The attachment_path is the receipt file to the bill.</param>
        /// <returns>Bill object.</returns>
        public Bill Create(Bill new_bill_info, string attachment_path)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_bill_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var attachments = new string[] { attachment_path };
            var file = new KeyValuePair<string, string[]>("attachment", attachments);
            var responce = ZohoHttpClient.post(url, getQueryParameters(),jsonstring,file);
            return BillParser.getBill(responce);
        }
        /// <summary>
        /// Updates the specified bill information.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill on which the changes are going to be applied.</param>
        /// <param name="update_info">The update_info is the bill object which contains the vendor_id,account_id and bill_number as mandatory parameters..</param>
        /// <param name="attachment_path">The attachment_path is the reciept path for the bill.</param>
        /// <returns>Bill object.</returns>
        public Bill Update(string bill_id, Bill update_info, string attachment_path)
        {
            string url = baseAddress + "/" + bill_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var file = new KeyValuePair<string, string>("attachment", attachment_path);
            var responce = ZohoHttpClient.put(url, getQueryParameters(),jsonstring ,file);
            return BillParser.getBill(responce);
        }

        /// <summary>
        /// Deletes the specified bill(Bills which have payments applied cannot be deleted.).
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill which is going to be deleted.</param>
        /// <returns>System.String.<br></br>The success message is "The bill has been deleted."</returns>
        public string Delete(string bill_id)
        {
            string url = baseAddress + "/" + bill_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
        /// <summary>
        /// Marks the bill status as void. 
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill for which the status has to be changed.</param>
        /// <returns>System.String.<br></br>The success message is "The bill has been marked as void."</returns>
        public string VoidABill(string bill_id)
        {
            string url = baseAddress + "/" + bill_id + "/status/void";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
        /// <summary>
        /// Mark a void bill as open.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the void bill.</param>
        /// <returns>System.String.<br></br>The success message is "The status of the bill has been changed from void to open."</returns>
        public string MarkBillAsOpen(string bill_id)
        {
            string url = baseAddress + "/" + bill_id + "/status/open";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
        /// <summary>
        /// Updates the billing address for this bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill .</param>
        /// <param name="update_info">The update_info is the Address object which contains the information to be update.</param>
        /// <returns>System.String.<br></br>The success message is "Billing address updated."</returns>
        public string UpdateBillingAddress(string bill_id, Address update_info)
        {
            string url = baseAddress + "/" + bill_id + "/address/billing";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return BillParser.getMessage(responce);
        }
        //--------------------------------------------------------------------------------
        /// <summary>
        /// Get the list of payments made for a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the bill identifier for which the payments have to get.</param>
        /// <returns>List of Payment object.</returns>
        public PaymentList GetPayments(string bill_id)
        {
            string url = baseAddress + "/" + bill_id + "/payments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BillParser.getPaymentList(responce);
        }
        /// <summary>
        /// Apply the vendor credits from excess vendor payments to a bill. Multiple credits can be applied at once.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill for which the credits are going to be applied.</param>
        /// <param name="credits_info">The credits_info is the UseCredits object which is having the credits info with amount_applied as mandatory parameter.</param>
        /// <returns>System.String.<br></br>The success message is "Credits have been applied to the bill(s)."</returns>
        public string ApplyCredits(string bill_id, UseCredits credits_info)
        {
            string url = baseAddress + "/" + bill_id + "/credits";
            var json = JsonConvert.SerializeObject(credits_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BillParser.getMessage(responce);
        }

        /// <summary>
        /// Deletes a payment made to a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <param name="bill_payment_id">The bill_payment_id is the identifier of the payment made for the specified bill.</param>
        /// <returns>System.String.<br></br>The success message is "The payment has been deleted."</returns>
        public string DeletePayment(string bill_id, string bill_payment_id)
        {
            string url = baseAddress + "/" + bill_id + "/payments" + "/" + bill_payment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
        //---------------------------------------------------------------------------------------------------

        /// <summary>
        /// Returns the file attached to the bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <param name="parameters">The parameters is the dictionary object which is optionally having the boolean value of preview as key,value pair.</param>
        /// <returns>System.String.<br></br>The success message is "the selected expense receipt is saved at home directory." </returns>
        public string GetAttachment(string bill_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + bill_id + "/attachment";
            ZohoHttpClient.getFile(url, getQueryParameters(parameters));
            return "the selected expense receipt is saved in current directory";
            
        }

        /// <summary>
        /// Attach a file to a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill for which the file is going to be attached.</param>
        /// <param name="attachment_path">The attachment_path is the file information.</param>
        /// <returns>System.String.<br></br>The success message is "The document has been attached."</returns>
        public string AddAttachment(string bill_id, string attachment_path)
        {
            string url = baseAddress + "/" + bill_id + "/attachment";
            var attachment = new string[] { attachment_path };
            var file = new KeyValuePair<string, string[]>("attachment",attachment);
            var responce = ZohoHttpClient.post(url, getQueryParameters(),null ,file);
            return BillParser.getMessage(responce);
        }

        /// <summary>
        /// Deletes the file attached to a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <returns>System.String.<br></br>The success message is "The attachment has been deleted."</returns>
        public string DeleteAttachment(string bill_id)
        {
            string url = baseAddress + "/" + bill_id + "/attachment";
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
        //---------------------------------------------------------------------------

        /// <summary>
        /// Gets the complete history and comments of a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <returns>List of Comment objects.</returns>
        public CommentList GetComments(string bill_id)
        {
            string url = baseAddress + "/" + bill_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BillParser.getCommentsList(responce);
        }

        /// <summary>
        /// Adds the comment to a bill.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <param name="new_comment_info">The new_comment_info is the Comment object which is having the comment information.</param>
        /// <returns>System.String.<br></br>The success message is "Comments added." </returns>
        public string AddComment(string bill_id, Comment new_comment_info)
        {
            string url = baseAddress + "/" + bill_id + "/comments";
            var json = JsonConvert.SerializeObject(new_comment_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BillParser.getMessage(responce);
        }

        /// <summary>
        /// Deletes the bill comment.
        /// </summary>
        /// <param name="bill_id">The bill_id is the identifier of the bill.</param>
        /// <param name="comment_id">The comment_id is the identifier of the comment of the specified bill.</param>
        /// <returns>System.String.<br></br>The success message is "The comment has been deleted."</returns>
        public string DeleteComment(string bill_id, string comment_id)
        {
            string url = baseAddress + "/" + bill_id + "/comments/" + comment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BillParser.getMessage(responce);
        }
    }
}
