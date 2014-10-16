using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace CreditnoteApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                CreditNotesApi creditnoteApi = service.GetCreditNoteApi();

                var parameters = new Dictionary<object, object>();
                parameters.Add("creditnote_number_startswith", "CN");
                parameters.Add("status", "open");
                parameters.Add("total_less_than", "5000");
                var creditnotesList = creditnoteApi.GetCreditnotes(parameters);
                var creditnotes = creditnotesList;
                var creditnoteId = creditnotes[0].creditnote_id;
                if (creditnotes != null)
                {
                    foreach (var creditnote in creditnotes)
                        Console.WriteLine("{0},{1},{2}", creditnote.creditnote_number, creditnote.total_credits_used, creditnote.total);
                }
                var parameters1 = new Dictionary<object, object>();
                parameters1.Add("print", "false");

                var creditnote1 = creditnoteApi.Get(creditnoteId, parameters1);
                if (creditnote1 != null)
                    Console.WriteLine("{0},{1},{2}", creditnote1.creditnote_number, creditnote1.total_credits_used, creditnote1.total);
                var newCreditnote = new CreditNote()
                {
                    customer_id = "{customer id}",
                    creditnote_number = "CN-0008",
                    line_items = new List<LineItem>(){
                    new LineItem(){
                      item_id="{item id}",
                      
                      name="Hard Drive",
                      description="500GB, USB 2.0 interface 1400 rpm, protective hard case.",
                      unit="",
                      rate=120.00,
                      quantity= 1.00,
                     
                    },
                }

                };
                var parameters2 = new Dictionary<object, object>();
                parameters2.Add("ignore_auto_number_generation", "true");
                
                var createdCreditnote = creditnoteApi.Create(newCreditnote, parameters2);
                if (createdCreditnote != null)
                    Console.WriteLine("{0},{1},{2}", createdCreditnote.creditnote_number, createdCreditnote.total_credits_used, createdCreditnote.total);
                CreditNote updateInf = new CreditNote()
                {
                    customer_id = "{customer id}",
                    creditnote_number = "CN-00000",

                };
                var parameters3 = new Dictionary<object, object>();
                parameters3.Add("ignore_auto_number_generation", "true");
                var updatedCreditnote = creditnoteApi.Update(creditnoteId, updateInf, parameters3);
                if (updatedCreditnote != null)
                    Console.WriteLine("{0},{1},{2}", updatedCreditnote.creditnote_number, updatedCreditnote.total_credits_used, updatedCreditnote.total);
                var delstr = creditnoteApi.Delete(creditnotes[2].creditnote_id);
                Console.WriteLine(delstr);
                var convToOpen = creditnoteApi.ConvertToOpen(creditnoteId);
                Console.WriteLine(convToOpen);
                var voidstr = creditnoteApi.ConvertToVoid(creditnoteId);
                Console.WriteLine(voidstr);
                var parameters4 = new Dictionary<object, object>();
                var emaildata = new EmailNotification()
                {

                    send_from_org_email_id = false,
                    to_mail_ids = new List<string>(){
                    "mail@host.com"
                  },

                    subject = "Credit Note from Zillium Inc ",
                    body = "Dear Customer,           <br><br><br><br>The credit note  is attached with this email.           <br><br><br><br>Credit Note Overview:           \n"

                };
                var emailstr = creditnoteApi.SendEmail(creditnoteId, emaildata, parameters4);
                Console.WriteLine(emailstr);
                var emailhstrs = creditnoteApi.GetEmailHistory(creditnoteId);
                if (emailhstrs != null)
                    foreach (var emailhstr in emailhstrs)
                        Console.WriteLine("{0},{1},{2}", emailhstr.from, emailhstr.mailhistory_id, emailhstr.to_mail_ids);
                var parameters5 = new Dictionary<object, object>();
                var emailstmt = creditnoteApi.GetEmailContent(creditnoteId, parameters5);
                if (emailstmt != null)
                {
                    Console.WriteLine("{0},{1},{2}", emailstmt.body, emailstmt.subject, emailstmt.file_name);
                }
                var addr = new Address()
                {
                    city = "guntur",
                    state = "AP"
                };
                var upbilladdrstr = creditnoteApi.UpdateBillingAddress(creditnoteId, addr);
                Console.WriteLine(upbilladdrstr);
                var address = new Address()
                {
                    city = "guntur",
                    state = "AP"
                };
                var upshipp = creditnoteApi.UpdateShippingAddress(creditnoteId, address);
                Console.WriteLine(upshipp);
                var templatesList = creditnoteApi.GetTemplates();
                var templates = templatesList;
                if (templates != null)
                    foreach (var template in templates)
                        Console.WriteLine("{0},{1},{2}", template.template_id, template.template_name, template.template_type);
                var updtemplatestr = creditnoteApi.UpdateTemplate(creditnoteId, templates[0].template_id);
                Console.WriteLine(updtemplatestr);
                var invoicescreditedList = creditnoteApi.GetInvoicesCredited(creditnoteId);
                var invoicescredited = invoicescreditedList;
                if (invoicescredited != null)
                    foreach (var invoicecredited in invoicescredited)
                        Console.WriteLine("{0},{1},{2}", invoicecredited.creditnote_invoice_id, invoicecredited.credited_amount, invoicecredited.invoice_id);
                var applytoinvoice = new ApplyToInvoices()
                {
                    invoices = new List<CreditedInvoice>(){
                    new CreditedInvoice(){
                        invoice_id="{invoice id}",
                        amount_applied=55.00,
                    },
                }
                };
                var creditedinvoicesInfoList = creditnoteApi.CreditToInvoices(creditnoteId, applytoinvoice);
                var creditedinvoicesInfo = creditedinvoicesInfoList;
                if (creditedinvoicesInfo != null)
                    foreach (var creditedinvoiceInfo in creditedinvoicesInfo)
                        Console.WriteLine("{0},{1}", creditedinvoiceInfo.invoice_id, creditedinvoiceInfo.amount_applied);
                var delcreditinvapplied = creditnoteApi.DeleteInvoiceCredited(creditnoteId, creditedinvoicesInfo[1].creditnote_id);
                Console.WriteLine(delcreditinvapplied);
                var parameters6 = new Dictionary<object, object>();
                var creditrefunds = creditnoteApi.GetCreditnoteRefunds(parameters6);
                if (creditrefunds != null)
                    foreach (var creditrefund in creditrefunds)
                        Console.WriteLine("{0},{1},{2}", creditrefund.creditnote_refund_id, creditrefund.creditnote_number, creditrefund.amount_bcy);
                var creditrefundsofcrednote = creditnoteApi.GetRefundsOfCrreditnote(creditnoteId);
                foreach (var creditrefund in creditrefundsofcrednote)
                    Console.WriteLine("{0},{1},{2}", creditrefund.creditnote_refund_id, creditrefund.creditnote_number, creditrefund.amount_bcy);
                var creditnoterefund = creditnoteApi.GetCreditnoteRefund(creditnoteId, creditrefundsofcrednote[0].creditnote_refund_id);
                if (creditnoterefund != null)
                    Console.WriteLine("{0},{1},{2}", creditnoterefund.creditnote_refund_id, creditnoterefund.from_account_name, creditnoterefund.amount);
                var refunddetails = new CreditNote()
                {
                    date = "2014-01-30",
                    from_account_id = "{account id}",
                    amount = 10,
                };
                var refundedcredit = creditnoteApi.AddRefund(creditnoteId, refunddetails);
                if (refundedcredit != null)
                    Console.WriteLine("{0},{1},{2}", refundedcredit.creditnote_refund_id, refundedcredit.from_account_name, refundedcredit.amount);
                var creditrefundupdateinfo = new CreditNote()
                {
                    date = "2014-01-30",
                    from_account_id = "{account id}",
                    amount = 5,
                };
                var updatedCreditrefund = creditnoteApi.UpdateRefund(creditnoteId, creditrefundsofcrednote[0].creditnote_refund_id, creditrefundupdateinfo);
                if (updatedCreditrefund != null)
                    Console.WriteLine("{0},{1},{2}", updatedCreditrefund.creditnote_refund_id, updatedCreditrefund.from_account_name, updatedCreditrefund.amount);
                var delcrdrefstr = creditnoteApi.DeleteRefund(creditnoteId, creditrefundsofcrednote[1].creditnote_refund_id);
                Console.WriteLine(delcrdrefstr);
                var commentsList = creditnoteApi.GetcreditnoteComments(creditnoteId);
                var comments = commentsList;
                if (comments != null)
                    foreach (var comment in comments)
                        Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by);

                var newcommentinfo = new Comment()
                {
                    description = "nothing"
                };
                var newcomment = creditnoteApi.AddComment(creditnoteId, newcommentinfo);
                if (newcomment != null)
                    Console.WriteLine("{0},{1},{2}", newcomment.comment_id, newcomment.description, newcomment.commented_by);
                var delcommentstr = creditnoteApi.DeleteComment(creditnoteId, comments[1].comment_id);
                Console.WriteLine(delcommentstr);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
