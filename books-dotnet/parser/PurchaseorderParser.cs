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
    /// Class PurchaseorderParser.
    /// </summary>
    class PurchaseorderParser
    {

        /// <summary>
        /// Gets the purchaseorder list.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>PurchaseorderList.</returns>
        internal static PurchaseorderList getPurchaseorderList(HttpResponseMessage response)
        {
            var purchaseorderList = new PurchaseorderList();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("purchaseorders"))
            {
                var purchaseordersArray = JsonConvert.DeserializeObject<List<object>>(jsonObject["purchaseorders"].ToString());
                foreach (var purchaseorderObj in purchaseordersArray)
                {
                    var purchaseorder = new Purchaseorder();
                    purchaseorder = JsonConvert.DeserializeObject<Purchaseorder>(purchaseorderObj.ToString());
                    purchaseorderList.Add(purchaseorder);
                }
            }
            if (jsonObject.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObject["page_context"].ToString());
                purchaseorderList.page_context = pageContext;
            }
            return purchaseorderList;
        }

        /// <summary>
        /// Gets the purchaseorder.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Purchaseorder.</returns>
        internal static Purchaseorder getPurchaseorder(HttpResponseMessage response)
        {
            var purchaseorder = new Purchaseorder();
            var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObject.ContainsKey("purchaseorder"))
            {
                purchaseorder = JsonConvert.DeserializeObject<Purchaseorder>(jsonObject["purchaseorder"].ToString());
            }
            return purchaseorder;
        }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>System.String.</returns>
        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
            {
                message = jsonObj["message"].ToString();
            }
            return message;
        }
        /// <summary>
        /// Gets the content of the email.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>Email.</returns>
        internal static Email getEmailContent(HttpResponseMessage responce)
        {
            var emailContent = new Email();
            var jsonobj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonobj.ContainsKey("data"))
            {
                emailContent = JsonConvert.DeserializeObject<Email>(jsonobj["data"].ToString());
            }
            return emailContent;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Address.</returns>
        internal static Address getAddress(HttpResponseMessage response)
        {
            var address = new Address();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("billing_address"))
            {
                address = JsonConvert.DeserializeObject<Address>(jsonObj["billing_address"].ToString());
            }
            if (jsonObj.ContainsKey("shipping_address"))
            {
                address = JsonConvert.DeserializeObject<Address>(jsonObj["shipping_address"].ToString());
            }
            return address;
        }

        /// <summary>
        /// Gets the template list.
        /// </summary>
        /// <param name="responce">The responce.</param>
        /// <returns>TemplateList.</returns>
        internal static TemplateList getTemplateList(HttpResponseMessage responce)
        {
            var templateList = new TemplateList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("templates"))
            {
                var templatesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["templates"].ToString());
                foreach (var templateObj in templatesArray)
                {
                    var template = new Template();
                    template = JsonConvert.DeserializeObject<Template>(templateObj.ToString());
                    templateList.Add(template);
                }
            }
            return templateList;
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
