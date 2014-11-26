using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    /// Class VendorCreditParser.
    /// </summary>
    class VendorCreditParser
    {
        /// <summary>
        /// Gets the vendor creditlist.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>VendorCreditList.</returns>
        internal static VendorCreditList getVendorCreditlist(HttpResponseMessage response)
        {
            var vendorCreditList = new VendorCreditList();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("vendor_credits"))
            {
                var vendorCreditsArray = JsonConvert.DeserializeObject<List<object>>(jsonObject["vendor_credits"].ToString());
                foreach(var vendorCreditObj in vendorCreditsArray)
                {
                    var vendorCredit = new VendorCredit();
                    vendorCredit = JsonConvert.DeserializeObject<VendorCredit>(vendorCreditObj.ToString());
                    vendorCreditList.Add(vendorCredit);
                }
            }
            if (jsonObject.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObject["page_context"].ToString());
                vendorCreditList.page_context = pageContext;
            }
            return vendorCreditList;
        }

        /// <summary>
        /// Gets the vendor credit.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>VendorCredit.</returns>
        internal static VendorCredit getVendorCredit(HttpResponseMessage response)
        {
            var vendorCredit = new VendorCredit();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if(jsonObject.ContainsKey("vendor_credit"))
            {
                vendorCredit = JsonConvert.DeserializeObject<VendorCredit>(jsonObject["vendor_credit"].ToString());
            }
            return vendorCredit;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>System.String.</returns>
        internal static string getMessage(HttpResponseMessage response)
        {
            string message = "";
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("message"))
                message = jsonObject["message"].ToString();
            return message;
        }

        /// <summary>
        /// Gets the bills credited.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>BillList.</returns>
        internal static BillList getBillsCredited(HttpResponseMessage response)
        {
            var billList = new BillList();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if(jsonObject.ContainsKey("bills"))
            {
                var billsArray = JsonConvert.DeserializeObject<List<object>>(jsonObject["bills"].ToString());
                foreach(var billObject in billsArray)
                {
                    var bill = new Bill();
                    bill = JsonConvert.DeserializeObject<Bill>(billObject.ToString());
                    billList.Add(bill);
                }
            }
            return billList;
        }

        /// <summary>
        /// Gets the refund list.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>VendorCreditRefundList.</returns>
        internal static VendorCreditRefundList getRefundList(HttpResponseMessage response)
        {
            var refundList = new VendorCreditRefundList();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("vendor_credit_refunds"))
            {
                var refundsArray = JsonConvert.DeserializeObject<List<object>>(jsonObject["vendor_credit_refunds"].ToString());
                foreach(var refundObj in refundsArray)
                {
                    var refund = new VendorCreditRefund();
                    refund = JsonConvert.DeserializeObject<VendorCreditRefund>(refundObj.ToString());
                    refundList.Add(refund);
                }
            }
            if (jsonObject.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObject["page_context"].ToString());
                refundList.page_context = pageContext;
            }
            return refundList;
        }

        /// <summary>
        /// Gets the refund.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>VendorCreditRefund.</returns>
        internal static VendorCreditRefund getRefund(HttpResponseMessage response)
        {
            var refund = new VendorCreditRefund();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("vendor_credit_refund"))
            {
                refund = JsonConvert.DeserializeObject<VendorCreditRefund>(jsonObject["vendor_credit_refund"].ToString());
            }
            return refund;
        }

        /// <summary>
        /// Gets the comment list.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>CommentList.</returns>
        internal static CommentList getCommentList(HttpResponseMessage responce)
        {
            var commentList = new CommentList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("comments"))
            {
                var commentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["comments"].ToString());
                foreach (var commentObj in commentsArray)
                {
                    var comment = new Comment();
                    comment = JsonConvert.DeserializeObject<Comment>(commentObj.ToString());
                    commentList.Add(comment);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                commentList.page_context = pageContext;
            }
            return commentList;
        }

        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>Comment.</returns>
        internal static Comment getComment(HttpResponseMessage responce)
        {
            var comment = new Comment();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("comment"))
            {
                comment = JsonConvert.DeserializeObject<Comment>(jsonObj["comment"].ToString());
            }
            return comment;
        }
    }
}
