using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class VendorCreditsApi.
    /// </summary>
    public class VendorCreditsApi : Api
    {
        /// <summary>
        ///     The base address
        /// </summary>
        private static readonly string baseAddress = baseurl + "/vendorcredits";

        /// <summary>
        ///     Initializes a new instance of the <see cref="VendorCreditsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token.</param>
        /// <param name="organization_Id">The organization_ identifier.</param>
        public VendorCreditsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     Gets the vendor credits.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>VendorCreditList.</returns>
        public VendorCreditList GetVendorCredits(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return VendorCreditParser.getVendorCreditlist(response);
        }

        /// <summary>
        ///     Gets the specified vendor_credit_id.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>VendorCredit.</returns>
        public VendorCredit Get(string vendor_credit_id, Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/" + vendor_credit_id;
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return VendorCreditParser.getVendorCredit(response);
        }

        /// <summary>
        ///     Creates the specified new_vendor_credit_info.
        /// </summary>
        /// <param name="new_vendor_credit_info">The new_vendor_credit_info.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>VendorCredit.</returns>
        public VendorCredit Create(VendorCredit new_vendor_credit_info, Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(new_vendor_credit_info);
            if (parameters == null)
                parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return VendorCreditParser.getVendorCredit(response);
        }

        /// <summary>
        ///     Updates the specified vendor_credit_id.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="update_info">The update_info.</param>
        /// <returns>VendorCredit.</returns>
        public VendorCredit Update(string vendor_credit_id, VendorCredit update_info)
        {
            var url = baseAddress + "/" + vendor_credit_id;
            var json = JsonConvert.SerializeObject(update_info);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(parameters));
            return VendorCreditParser.getVendorCredit(response);
        }

        /// <summary>
        ///     Deletes the specified vendor_credit_id.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>System.String.</returns>
        public string Delete(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }

        /// <summary>
        ///     Converts to open.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>System.String.</returns>
        public string ConvertToOpen(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/status/open";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }

        /// <summary>
        ///     Marks as void.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>System.String.</returns>
        public string MarkAsVoid(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/status/void";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }

//-------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Billses the credited.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>BillList.</returns>
        public BillList GetBillsCredited(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/applytobills";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return VendorCreditParser.getBillsCredited(response);
        }

        /// <summary>
        ///     Applies the credits to bill.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="bills_info">The bills_info.</param>
        /// <returns>System.String.</returns>
        public string ApplyCreditsToBill(string vendor_credit_id, ApplyToBills bills_info)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/bills";
            var json = JsonConvert.SerializeObject(bills_info);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return VendorCreditParser.getMessage(response);
        }

        /// <summary>
        ///     Deletes the bills credited.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="vendor_credit_bill_id">The vendor_credit_bill_id.</param>
        /// <returns>System.String.</returns>
        public string DeleteBillsCredited(string vendor_credit_id, string vendor_credit_bill_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/bills/" + vendor_credit_bill_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }

//-----------------------------------------------------------------------------------------------

        /// <summary>
        ///     Gets the refunds.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>VendorCreditRefundList.</returns>
        public VendorCreditRefundList GetRefunds(Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/refunds";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return VendorCreditParser.getRefundList(response);
        }

        /// <summary>
        ///     Gets the refunds of vendor credit.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>VendorCreditRefundList.</returns>
        public VendorCreditRefundList GetRefundsOfVendorCredit(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/refunds";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return VendorCreditParser.getRefundList(response);
        }

        /// <summary>
        ///     Gets the vendor credit refund.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="vendor_credit_refund_id">The vendor_credit_refund_id.</param>
        /// <returns>VendorCreditRefund.</returns>
        public VendorCreditRefund GetVendorCreditRefund(string vendor_credit_id, string vendor_credit_refund_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/refunds/" + vendor_credit_refund_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return VendorCreditParser.getRefund(response);
        }

        /// <summary>
        ///     Adds the refund.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="new_refund_info">The new_refund_info.</param>
        /// <returns>VendorCreditRefund.</returns>
        public VendorCreditRefund AddRefund(string vendor_credit_id, VendorCreditRefund new_refund_info)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/refunds";
            var json = JsonConvert.SerializeObject(new_refund_info);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return VendorCreditParser.getRefund(response);
        }

        /// <summary>
        ///     Updates the refund.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="vendor_credit_refund_id">The vendor_credit_refund_id.</param>
        /// <param name="update_info">The update_info.</param>
        /// <returns>VendorCreditRefund.</returns>
        public VendorCreditRefund UpdateRefund(string vendor_credit_id, string vendor_credit_refund_id,
            VendorCreditRefund update_info)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/refunds/" + vendor_credit_refund_id;
            var json = JsonConvert.SerializeObject(update_info);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(parameters));
            return VendorCreditParser.getRefund(response);
        }

        /// <summary>
        ///     Deletes the refund.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="vendor_credit_refund_id">The vendor_credit_refund_id.</param>
        /// <returns>System.String.</returns>
        public string DeleteRefund(string vendor_credit_id, string vendor_credit_refund_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/refunds/" + vendor_credit_refund_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }

//-------------------------------------------Comments and history-----------------------------------------

        /// <summary>
        ///     Gets the comments.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <returns>CommentList.</returns>
        public CommentList GetComments(string vendor_credit_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/comments";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return VendorCreditParser.getCommentList(response);
        }

        /// <summary>
        ///     Adds the comment.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="new_comment_description">The new_comment_description.</param>
        /// <returns>Comment.</returns>
        public Comment AddComment(string vendor_credit_id, Comment new_comment_description)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/comments";
            var json = JsonConvert.SerializeObject(new_comment_description);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return VendorCreditParser.getComment(response);
        }

        /// <summary>
        ///     Deletes the comment.
        /// </summary>
        /// <param name="vendor_credit_id">The vendor_credit_id.</param>
        /// <param name="comment_id">The comment_id.</param>
        /// <returns>System.String.</returns>
        public string DeleteComment(string vendor_credit_id, string comment_id)
        {
            var url = baseAddress + "/" + vendor_credit_id + "/comments/" + comment_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return VendorCreditParser.getMessage(response);
        }
    }
}