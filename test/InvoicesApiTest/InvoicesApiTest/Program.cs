using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace InvoicesApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var invoicesApi = service.GetInvoicesApi();
                var parameters = new Dictionary<object, object>();
                var invoicesList = invoicesApi.GetInvoices(parameters);
                var invoices = invoicesList;
                var invoiceId = invoices[1].invoice_id;
                var custId = invoices[0].customer_id;
                var contactId=invoices[0].contact_persons[1];
                 foreach (var invoice in invoices)
                     Console.WriteLine("Id:{0},Name:{1},due date:{2},total:{3}",invoice.invoice_id,invoice.name,invoice.due_date,invoice.total);
                 var parameters1 = new Dictionary<object, object>();
                 var invoice1 = invoicesApi.Get(invoiceId, parameters1);
                 Console.WriteLine("Id:{0},Name:{1},status:{2},total:{3}", invoice1.invoice_id, invoice1.name, invoice1.status, invoice1.total);
                 var newInvoiceInfo = new Invoice()
                 {
                     customer_id = custId,
                     reference_number = "jwqjjkw",
                     payment_terms = 15,
                     payment_terms_label = "Net 15",
                     
         
                     allow_partial_payments = false,
                     custom_fields = { },
                     exchange_rate = 1,
                     template_id = "{template id}",
                     is_discount_before_tax = true,
                     discount = "",
                     discount_type = "item_level",
                     shipping_charge = 50,
                     adjustment = -100,
                     adjustment_description = " adjustment",
                     salesperson_name = "John Michael"
                 };
                 var parameters8 = new Dictionary<object, object>();
                 var newinvoice = invoicesApi.Create(newInvoiceInfo,parameters8);
                 Console.WriteLine("Id:{0},Name:{1},status:{2},total:{3}", newinvoice.invoice_id, newinvoice.name, newinvoice.status, newinvoice.total);
                 var updateinfo = new Invoice()
                 {
                     salesperson_name="ha",
                 };
                
                 var updatedInvoice = invoicesApi.Update(invoiceId, updateinfo, parameters8);
                 Console.WriteLine("Id:{0},Name:{1},status:{2},salesPerson:{3}", updatedInvoice.invoice_id, updatedInvoice.name, updatedInvoice.status, updatedInvoice.salesperson_name);
                 var deletemsg = invoicesApi.Delete(invoices[3].invoice_id);
                 Console.WriteLine(deletemsg);
                 var statusMsg = invoicesApi.MarkAsSent(invoiceId);
                 Console.WriteLine(statusMsg);
                 var status = invoicesApi.MarkAsVoid(invoiceId);
                Console.WriteLine(status);
                var statusmsg = invoicesApi.MarkAsDraft(invoiceId);
                Console.WriteLine(statusmsg);
                var emaildata=new EmailNotification(){
                    to_mail_ids=new List<string>(){"mail@host.com"},
                    subject="invoice mail",
                    body="hi"
                };
                var parameters9 = new Dictionary<object, object>();
                var emailInvoice = invoicesApi.SendEmail(invoiceId, emaildata, new string[] { @"attachment path", @"attachment path" }, parameters9);
                Console.WriteLine(emailInvoice);
                var parameters2 = new Dictionary<object, object>();
                parameters2.Add("invoice_ids", invoices[2].invoice_id+","+invoices[0].invoice_id);
                var contactsToSend=new Contacts(){
                    contacts=new List<Contact>(){
                    new Contact(){
                        contact_id=contactId,
                        email="true",
                        snail_mail=true
                    },
                    }
                };
                var emailInvoices=invoicesApi.EmailInvoices(contactsToSend,parameters2);
                Console.WriteLine(emailInvoices);
                var parameters3 = new Dictionary<object, object>();
                parameters3.Add("invoice_ids", invoices[2].invoice_id + "," + invoices[0].invoice_id);
                var emailcontent = invoicesApi.GetEmailContent(invoiceId, parameters3);
                Console.WriteLine("{0},{1},{2}", emailcontent.body, emailcontent.file_name, emailcontent.gateways_configured);
                var notifydetails = new EmailNotification()
                {
                    to_mail_ids = new List<string>() { "{mail id 1}", "{mail id 2}" },
                    subject="payment reminder",
                    body="dear "
                };
                var parameters4 = new Dictionary<object, object>();
                
                var remindMsg = invoicesApi.RemindCustomer(invoiceId, notifydetails, parameters4);
                Console.WriteLine(remindMsg);
                var parameters5 = new Dictionary<object, object>();
                
                parameters5.Add("invoice_ids", invoices[2].invoice_id + "," + invoices[0].invoice_id);
                var bulkReminderMsg = invoicesApi.BulkInvoiceReminder(parameters5);
                Console.WriteLine(bulkReminderMsg);
                var reminderContent = invoicesApi.GetPaymentReminder(invoiceId);
                Console.WriteLine("{0},{1},{2}", reminderContent.body, reminderContent.file_name, reminderContent.gateways_configured);
                var parameters6 = new Dictionary<object, object>();
                parameters6.Add("invoice_ids", invoices[2].invoice_id + "," + invoices[0].invoice_id);
                var bulkExport = invoicesApi.BulkExport(parameters6);
                Console.WriteLine(bulkExport);
                var disableReminderMsg = invoicesApi.DisablePaymentReminder(invoiceId);
                Console.WriteLine(disableReminderMsg);
                var enableReminderMsg = invoicesApi.EnablePaymentReminder(invoiceId);
                Console.WriteLine(enableReminderMsg);
                var writeoff = invoicesApi.WriteoffInvoice(invoiceId);
                Console.WriteLine(writeoff);
                var cancleWriteoff = invoicesApi.CancelWriteoff(invoiceId);
                Console.WriteLine(cancleWriteoff);
                var updateInfo = new Address()
                {
                    address = "addr",
                    is_update_customer = false
                };
                var billingdAddrUpdate = invoicesApi.UpdateBillingAddress(invoiceId, updateInfo);
                Console.WriteLine(billingdAddrUpdate);
                var updateInfo1 = new Address()
                {
                    address = "addr",
                    is_update_customer = false
                };
                var shippingdAddrUpdate = invoicesApi.UpdateShippingAddress(invoiceId, updateInfo);
                Console.WriteLine(shippingdAddrUpdate);
                var invoicetemplatesList = invoicesApi.GetTemplates();
                var invoicetemplates = invoicetemplatesList;
                foreach (var template in invoicetemplates)
                    Console.WriteLine("Templates\n{0},{1},{2}", template.template_id, template.template_name, template.template_type);
                var updateTemplate = invoicesApi.UpdateTemplate(invoiceId, invoicetemplates[0].template_id);
                Console.WriteLine(updateTemplate);
                var invoicePaymentsList = invoicesApi.GetPayments(invoiceId);
                var invoicePayments = invoicePaymentsList;
                var paymentId=invoicePayments[1].payment_id;
                foreach (var payment in invoicePayments)
                    Console.WriteLine("payment:{0},{1},{2}", payment.payment_id, payment.description, payment.invoice_id);
                var appliedCreditsList = invoicesApi.GetCreditsApplied(invoiceId);
                var appliedCredits = appliedCreditsList;
                var creditnoteId=appliedCredits[1].creditnote_id;
                
                foreach (var credit in appliedCredits)
                    Console.WriteLine("credit note:{0},{1},{2}", credit.creditnote_id, credit.amount_applied, credit.creditnotes_number);
                var creditstoapplly = new UseCredits()
                {

                    apply_creditnotes = new List<CreditNote>()
                     {
                         new CreditNote(){
                             creditnote_id=creditnoteId,
                             amount_applied=40.00
                         }
                     }
                };
                var appliedCredits1 = invoicesApi.AddCredits(invoiceId, creditstoapplly);
                var creditnotes = appliedCredits1.apply_creditnotes;
                foreach(var credit in creditnotes)
                Console.WriteLine("credit note:{0},{1}", credit.creditnote_id, credit.amount_applied);
                var deletePaymentmsg = invoicesApi.DeletePayment(invoiceId,paymentId);
                Console.WriteLine(deletePaymentmsg);
                var deleteAppliedcredit = invoicesApi.DelteAppliedCredit(invoiceId, creditnoteId);
                Console.WriteLine(deleteAppliedcredit);
                var commentsList = invoicesApi.GetComments(invoiceId);
                var comments = commentsList;
                foreach (var comment in comments)
                    Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by);
                var newCommentInfo = new Comment()
                {
                    description = "new comment",
                    show_comment_to_clients = true
                };
                var newComment = invoicesApi.AddComment(invoiceId, newCommentInfo);
                Console.WriteLine(newComment);
                var updateInfo2 = new Comment()
                {
                    description = "updated comment",
                    show_comment_to_clients = true
                };
                var updatedComment = invoicesApi.UpdateComment(invoiceId, comments[1].comment_id, updateInfo2);
                Console.WriteLine("{0},{1},{2}", updatedComment.comment_id, updatedComment.description, updatedComment.commented_by);
                var deleteMsg = invoicesApi.DeleteComment(invoiceId, comments[3].comment_id);
                Console.WriteLine(deleteMsg);
                var attachment = invoicesApi.GetAttachment(invoiceId);
                Console.WriteLine(attachment);
                var parameters7 = new Dictionary<object, object>();
                parameters7.Add("can_send_in_mail",true);
                var attachPreference = invoicesApi.UpdateAttachment(invoiceId, parameters7);
                Console.WriteLine(attachPreference);
                var deleteAttach = invoicesApi.DeleteAttachment(invoiceId);
                Console.WriteLine(deleteAttach);
                var deleteExpenceRecipt = invoicesApi.DeleteExpenseReceipt(invoiceId);
                Console.WriteLine(deleteExpenceRecipt);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
