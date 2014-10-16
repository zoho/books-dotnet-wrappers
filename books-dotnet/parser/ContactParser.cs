using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.Parser
{
    /// <summary>
    /// Used to define the parser object of ContactsApi.
    /// </summary>
    class ContactParser
    {
        
        internal static ContactList getContactList(HttpResponseMessage responce)
        {
            var contactList = new ContactList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("contacts"))
            {
                var contactsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["contacts"].ToString());
                foreach(var contactObj in contactsArray)
                {
                    var contact = new Contact();
                    contact = JsonConvert.DeserializeObject<Contact>(contactObj.ToString());
                    contactList.Add(contact);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                contactList.page_context = pageContext;
            }
            return contactList;
        }

        internal static Contact getContact(HttpResponseMessage responce)
        {
            var contact = new Contact();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("contact"))
            {
                contact = JsonConvert.DeserializeObject<Contact>(jsonObj["contact"].ToString());
            }
            return contact;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static Email getEmailContent(HttpResponseMessage responce)
        {
            var mailContent = new Email();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if(jsonObj.ContainsKey("data"))
            {
                mailContent = JsonConvert.DeserializeObject<Email>(jsonObj["data"].ToString());
            }
            return mailContent;
        }

        internal static CommentList getCommentList(HttpResponseMessage responce)
        {
            var commentList = new CommentList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("contact_comments"))
            {
                var commentsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["contact_comments"].ToString());
                foreach(var commentObj in commentsArray)
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

        internal static CreditNoteRefundList getCreditNoteRefundList(HttpResponseMessage responce)
        {
            var creditnoteRefundList = new CreditNoteRefundList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnote_refunds"))
            {
                var creditNotesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["creditnote_refunds"].ToString());
                foreach(var creditNoteObj in creditNotesArray)
                {
                    var creditNote = new CreditNote();
                    creditNote = JsonConvert.DeserializeObject<CreditNote>(creditNoteObj.ToString());
                    creditnoteRefundList.Add(creditNote);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                creditnoteRefundList.page_context = pageContext;
            }
            return creditnoteRefundList;
        }

        internal static ContactPersonList getContactPersonList(HttpResponseMessage responce)
        {
            var contactPersonList = new ContactPersonList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("contact_persons"))
            {
                var contactPersonsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["contact_persons"].ToString());
                foreach(var contactPersonObj in contactPersonsArray)
                {
                    var contactPerson = new ContactPerson();
                    contactPerson = JsonConvert.DeserializeObject<ContactPerson>(contactPersonObj.ToString());
                    contactPersonList.Add(contactPerson);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                contactPersonList.page_context = pageContext;
            }
            return contactPersonList;
        }

        internal static ContactPerson getContactPerson(HttpResponseMessage responce)
        {
            var contactPerson = new ContactPerson();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("contact_person"))
            {
                contactPerson = JsonConvert.DeserializeObject<ContactPerson>(jsonObj["contact_person"].ToString());
            }
            return contactPerson;
        }
    }
}
