using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of CreditNoteApi.
    /// </summary>
    internal class CreditNoteParser
    {
        internal static CreditNoteList getCreditnoteList(HttpResponseMessage responce)
        {
            var creditNoteList = new CreditNoteList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnotes"))
            {
                var creditnotesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["creditnotes"].ToString());
                foreach (var creditnoteObj in creditnotesArray)
                {
                    var creditnote = new CreditNote();
                    creditnote = JsonConvert.DeserializeObject<CreditNote>(creditnoteObj.ToString());
                    creditNoteList.Add(creditnote);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                creditNoteList.page_context = pageContext;
            }
            return creditNoteList;
        }

        internal static CreditNote getCreditnote(HttpResponseMessage responce)
        {
            var creditnote = new CreditNote();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnote"))
                creditnote = JsonConvert.DeserializeObject<CreditNote>(jsonObj["creditnote"].ToString());
            return creditnote;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static EmailHistoryList getEmailHistoryList(HttpResponseMessage responce)
        {
            var emailHistoryList = new EmailHistoryList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("email_history"))
            {
                var emailHistoryArray =
                    JsonConvert.DeserializeObject<List<object>>(jsonObj["email_history"].ToString());
                foreach (var emailHistoryObj in emailHistoryArray)
                {
                    var emailHistory = new EmailHistory();
                    emailHistory = JsonConvert.DeserializeObject<EmailHistory>(emailHistoryObj.ToString());
                    emailHistoryList.Add(emailHistory);
                }
            }
            return emailHistoryList;
        }

        internal static TemplateList getTemplateList(HttpResponseMessage responce)
        {
            var templateList = new TemplateList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
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

        internal static CreditedInvoiceList getCreditedInvoiceList(HttpResponseMessage responce)
        {
            var creditedInvoceList = new CreditedInvoiceList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("invoices_credited"))
            {
                var creditedInvoicesArray =
                    JsonConvert.DeserializeObject<List<object>>(jsonObj["invoices_credited"].ToString());
                foreach (var invoiceObj in creditedInvoicesArray)
                {
                    var creditedInvoice = new CreditedInvoice();
                    creditedInvoice = JsonConvert.DeserializeObject<CreditedInvoice>(invoiceObj.ToString());
                    creditedInvoceList.Add(creditedInvoice);
                }
            }
            return creditedInvoceList;
        }

        internal static CreditedInvoiceList getCreditsAppliedInvoices(HttpResponseMessage responce)
        {
            var creditedInvoiceList = new CreditedInvoiceList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("apply_to_invoices"))
            {
                var applyToInvoiceObj =
                    JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonObj["apply_to_invoices"].ToString());
                if (applyToInvoiceObj.ContainsKey("invoices"))
                {
                    var invoicesArray =
                        JsonConvert.DeserializeObject<List<object>>(applyToInvoiceObj["invoices"].ToString());
                    foreach (var invoiceObj in invoicesArray)
                    {
                        var creditedinvoice = new CreditedInvoice();
                        creditedinvoice = JsonConvert.DeserializeObject<CreditedInvoice>(invoiceObj.ToString());
                        creditedInvoiceList.Add(creditedinvoice);
                    }
                }
            }
            return creditedInvoiceList;
        }

        internal static CreditNoteRefundList getCreditnoteRefundList(HttpResponseMessage responce)
        {
            var creditnoterefundList = new CreditNoteRefundList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnote_refunds"))
            {
                var refundsArray =
                    JsonConvert.DeserializeObject<List<object>>(jsonObj["creditnote_refunds"].ToString());
                foreach (var refundObj in refundsArray)
                {
                    var creditnote = new CreditNote();
                    creditnote = JsonConvert.DeserializeObject<CreditNote>(refundObj.ToString());
                    creditnoterefundList.Add(creditnote);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                creditnoterefundList.page_context = pageContext;
            }
            return creditnoterefundList;
        }

        internal static CreditNote getCreditnoteRefund(HttpResponseMessage responce)
        {
            var creditnote = new CreditNote();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnote_refund"))
                creditnote = JsonConvert.DeserializeObject<CreditNote>(jsonObj["creditnote_refund"].ToString());
            return creditnote;
        }

        internal static CommentList getCommentList(HttpResponseMessage responce)
        {
            var commentList = new CommentList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
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

        internal static Comment getComment(HttpResponseMessage responce)
        {
            var comment = new Comment();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("comment"))
                comment = JsonConvert.DeserializeObject<Comment>(jsonObj["comment"].ToString());
            return comment;
        }
    }
}