using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using Newtonsoft.Json.Linq;

namespace zohobooks.parser
{
    /// <summary>
    /// Used to define the parser object of BillsApi.
    /// </summary>
    class BillParser
    {
        internal static BillList getBillList(HttpResponseMessage responce)
        {
            var billList = new BillList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("bills"))
            {
                var billsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["bills"].ToString());
                foreach(var billObj in billsArray)
                {
                    var bill = new Bill();
                    bill = JsonConvert.DeserializeObject<Bill>(billObj.ToString());
                    billList.Add(bill);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                billList.page_context = pageContext;
            }
            return billList;
        }

        internal static Bill getBill(HttpResponseMessage responce)
        {
            var bill=new Bill();
            var json = responce.Content.ReadAsStringAsync().Result;
            var jsonObj = JObject.Parse(json).ToObject<Dictionary<string, object>>();
            //var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json.ToString());
            if(jsonObj.ContainsKey("bill"))
            {
                bill = JsonConvert.DeserializeObject<Bill>(jsonObj["bill"].ToString());
            }
            return bill;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var json = responce.Content.ReadAsStringAsync().Result;
            var jsonObj = JObject.Parse(json).ToObject<Dictionary<string, object>>();
            //var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static PaymentList getPaymentList(HttpResponseMessage responce)
        {
            var paymentList = new PaymentList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("payments"))
            {
                var paymentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["payments"].ToString());
                foreach(var paymentObj in paymentsArray)
                {
                    var payment = new Payment();
                    payment = JsonConvert.DeserializeObject<Payment>(paymentObj.ToString());
                    paymentList.Add(payment);
                }
            }
            return paymentList;
        }

        internal static CommentList getCommentsList(HttpResponseMessage responce)
        {
            var commentList = new CommentList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("comments"))
            {
                var commentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["comments"].ToString());
                foreach(var commentObj in commentsArray)
                {
                    var comment = new Comment();
                    comment = JsonConvert.DeserializeObject<Comment>(commentObj.ToString());
                    commentList.Add(comment);
                }
            }

            return commentList;
        }
    }
}
