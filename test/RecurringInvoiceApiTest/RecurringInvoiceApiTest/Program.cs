using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace RecurringInvoiceApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                RecurringInvoicesApi recinvapi = service.GetRecurringInvoicesApi();
                var paramets = new Dictionary<object, object>();
                paramets.Add("recurrence_name_contains", "r");

                var recinvcs = recinvapi.GetRecurringInvoices(paramets);
                if (recinvcs != null)
                {
                    foreach (var x in recinvcs)
                    {
                        Console.WriteLine("{0},{1},{2}", x.recurrence_name, x.recurring_invoice_id, x.created_time);

                    }
                }
                var recinvId = recinvcs[0].recurring_invoice_id;
                var recinv = recinvapi.Get(recinvId);
                var customerId = recinv.customer_id;
                var templateId = recinv.template_id;
                var itemId = recinv.line_items[0].item_id;
                if (recinv != null)
                    Console.WriteLine("{0},{1},{2}", recinv.recurrence_name, recinv.recurring_invoice_id, recinv.created_time);
                var newRecurInv = new RecurringInvoice()
                {
                    recurrence_name = "Premium2",
                    customer_id = customerId,
                    contact_persons = new List<string> { },
                    template_id = templateId,
                    start_date = "2013-10-03",
                    end_date = "2014-11-04",
                    recurrence_frequency = "months",
                    repeat_every = 1,
                    payment_terms = 15,
                    payment_terms_label = "Net 15",
                    exchange_rate = 1.00,
                    payment_options = new PaymentOptions()
                    {
                        payment_gateways = new List<PaymentGateway>()
                        {

                        }
                    },
                    discount = 0.00,
                    is_discount_before_tax = true,
                    discount_type = "item_level",
                    allow_partial_payments = true,
                    line_items = new List<LineItem>{
                 new LineItem() {
                   item_id=itemId,
                   name="Premium Pla",
                   description="10 GB Space, 300 GB Transfer 100 Email Accounts 10 MySQL Databases",
                   item_order= 1,
               
                   quantity=1.00,
                   unit="Nos",
                   discount="10.60%",
                 
                 },
               },
                    notes = "Thanks for your business.",
                    terms = "",
                    salesperson_name = "John Michael",
                    shipping_charge = 10.00,
                    adjustment = 2.00,
                    adjustment_description = "Adjustment"

                };
                var createdrecinv = recinvapi.Create(newRecurInv);
                if (createdrecinv != null)
                    Console.WriteLine("{0},{1},{2}", createdrecinv.recurrence_name, createdrecinv.recurring_invoice_id, createdrecinv.created_time);
                var updatInfo = new RecurringInvoice()
                {
                    recurrence_name = "rec name",

                    template_id = templateId,
                    start_date = "2013-10-03",
                    end_date = "2013-11-04",
                    recurrence_frequency = "months",
                    repeat_every = 1,
                    payment_terms = 15,

                    discount = 2.00,
                    is_discount_before_tax = false,
                    discount_type = "item_level",
                    allow_partial_payments = true,


                    salesperson_name = "",
                };
                var updatedinfo = recinvapi.Update(recinvId, updatInfo);
                if (updatedinfo != null)
                {
                    Console.WriteLine("{0},{1},{2}", updatedinfo.recurrence_name, updatedinfo.recurring_invoice_id, updatedinfo.created_time);
                }
                var delresp = recinvapi.Delete(recinvcs[2].recurring_invoice_id);
                Console.WriteLine(delresp);
                var stopres = recinvapi.Stop(recinvId);
                Console.WriteLine(stopres);
                var resumeres = recinvapi.Resume(recinvId);
                Console.WriteLine(resumeres);
                var templatechang = recinvapi.UpdateTemplate(recinvId, templateId);
                Console.WriteLine(templatechang);
                var comments = recinvapi.GetComments(recinvId);
                if (comments != null)
                {
                    foreach (var comment in comments)
                    {
                        Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by_id);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
