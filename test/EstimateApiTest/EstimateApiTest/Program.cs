using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;
namespace EstimateApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organisation id}");
                EstimatesApi estimateApi = service.GetEstimatesApi();
                var parameters = new Dictionary<object, object>();
                 var estimatesList = estimateApi.GetEstimates(parameters);
                 var estimates = estimatesList;
                 var estimateId = estimates[0].estimate_id;
                 var customerId = estimates[0].customer_id;
                 var contactPersns = estimates[0].contact_persons;
                 if (estimates != null)
                     foreach (var estimate in estimates)
                         Console.WriteLine("{0},{1},{2}", estimate.estimate_id, estimate.customer_name, estimate.estimate_number);
                 var parameters1 = new Dictionary<object, object>();
                  parameters1.Add("send",true);
                  var newEstmt = new Estimate()
                  {
                      customer_id = customerId,
                      template_id = "{template id}",
                      reference_number = "QRT-",
                      date = "2014-03-10",
                      expiry_date = "2014-03-24",
                      exchange_rate = 1.0,
                      discount = 0.0,
                      is_discount_before_tax = true,
                      discount_type = "item_level",
                      salesperson_name = "John Michael",
                      line_items = new List<LineItem>()
                          {
                                  new LineItem(){
                                  name="Premium Plan - Web hosting",
                                  description="10 GB Space, 300 GB Transfer 100 Email Accounts 10 MySQL Databases",
                                  rate=2500,
                                  item_order=0,
                                  quantity=1.0,
                                  discount="0.0",
                                  
                                  },
                          },
                      notes = "Looking forward for your business.",
                      terms = "Terms and conditions apply.",
                      shipping_charge = 0.0,
                      adjustment = 0.0,
                      adjustment_description = "Adjustment"
                  };
                  var newEstimate = estimateApi.Create(newEstmt, parameters1);
                  if(newEstimate!=null)
                  {
                      Console.WriteLine("The new Estimate is created with the api call for the amount {0} which is having the following properties\n",newEstimate.total);
                      Console.WriteLine("Estimate Id:{0}\n,Estimate number:{1},\n status:{2},\n",newEstimate.estimate_id,newEstimate.estimate_number,newEstimate.status);
                      var billto = newEstimate.billing_address;
                      Console.WriteLine("To:{0},{1},{2},{3},{4}", newEstimate.customer_name, billto.address, billto.city, billto.country, billto.zip);
                      var items = newEstimate.line_items;
                      Console.WriteLine("\n Items details:\n");
                      foreach (var item in items)
                          Console.WriteLine("\n name: {0},\nCost: {1},\n Quantity :{2}", item.name, item.rate, item.quantity);

                  }
                  var parameters2 = new Dictionary<object, object>();
                var updateInfo = new Estimate()
                {
                          
                     reference_number="2197",
                 
               };
                 var updatedEst =estimateApi.Update(estimateId, updateInfo,parameters2);
                if(updatedEst!=null)
                    Console.WriteLine("{0},{1},{2}", updatedEst.estimate_number, updatedEst.reference_number, updatedEst.exchange_rate);
                var delmsg = estimateApi.Delete(estimates[2].estimate_id);
                Console.WriteLine(delmsg);
                var status = estimateApi.MarkAsSent(estimateId);
                Console.WriteLine(status);
                var status1 = estimateApi.MarkAsAccepted(estimateId);
                Console.WriteLine(status);
                var status2 = estimateApi.MarkAsDeclined(estimateId);
                Console.WriteLine(status);
                var emailDetails = new EmailNotification()
                {
                    to_mail_ids = new List<string>(){
                    "mail@host.com",},
                    subject = "estimate email",
                    body = "est"
                };
                var emailEst = estimateApi.SendEmail(estimateId, emailDetails, new string[] { @"F:\error.png", @"F:\error.png" });
                Console.WriteLine(emailEst);
                var estIds = new Dictionary<object, object>();
                estIds.Add("estimate_ids", estimates[1].estimate_id + "," + estimates[2]);
                var emailests = estimateApi.EmailEstimates(estIds);
                Console.WriteLine(emailests);
                var emailContent = estimateApi.GetEmailContent(estimateId, null);
                Console.WriteLine("{0},{1},{2}", emailContent.body, emailContent.file_name, emailContent.subject);
                var export = estimateApi.BulkExport(estIds);
                Console.WriteLine(export);
                var print = estimateApi.BulkPrint(estIds);
                Console.WriteLine(print);
                var updateinfo3 = new Address()
                {
                    address = "31",
                    city = "chennai"
                };
                var update = estimateApi.UpdateBillingAddress(estimateId, updateinfo3);
                Console.WriteLine(update);
                var updateinfo2 = new Address()
                {
                    state="TamilNadu"
                };
                var shipaddrUpdate = estimateApi.UpdateShippingAddress(estimateId, updateinfo2);
                Console.WriteLine(shipaddrUpdate);
                var estTemplatesList = estimateApi.GetTemplates();
                var templates = estTemplatesList;
                foreach (var estTemplate in templates)
                    Console.WriteLine("{0},{1},{2}", estTemplate.template_id, estTemplate.template_name, estTemplate.template_type);

                var updateTemplate = estimateApi.UpdateTemplate(estimateId, templates[1].template_id);
                Console.WriteLine(updateTemplate);
                var commentsList = estimateApi.GetComments(estimateId);
                var comments = commentsList;
                foreach (var comment in comments)
                    Console.WriteLine("{0},{1},{2}",comment.comment_id,comment.description,comment.commented_by);
                var newCommentInfo = new Comment()
                {
                    description = "added manually"
                };
                var newComment = estimateApi.AddComment(estimateId, newCommentInfo);
                Console.WriteLine(newComment);
                var updateInfo1 = new Comment()
                {
                    description = "edited comment"
                };
                var updated = estimateApi.UpdateComment(estimateId, comments[2].comment_id, updateInfo1);
                Console.WriteLine("{0},{1},{2}", updated.comment_id, updated.description, updated.commented_by);
                var deleteMsg = estimateApi.DeleteComment(estimateId, comments[4].comment_id);
                Console.WriteLine(deleteMsg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
