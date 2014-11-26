using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.service;
using zohobooks.model;

namespace SalesOrdersApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var salesOrdersApi = service.GetSalesordersApi();
                Console.WriteLine("------------------ SalesOrders -------------");
                var salesOrders = salesOrdersApi.GetSalesorders(null);
                foreach(var tempSalesOrder in salesOrders)
                    Console.WriteLine("Id:{0},date:{1},customerName:{2},status:{3},Amount:{4}",tempSalesOrder.salesorder_id,tempSalesOrder.date,tempSalesOrder.customer_name,tempSalesOrder.status,tempSalesOrder.total);
                Console.WriteLine("--------------------Specified SalesOrder----------------------");
                var salesOrder = salesOrdersApi.Get(salesOrders[0].salesorder_id,null);
                Console.WriteLine("Id:{0},date:{1},customerName:{2},status:{3},Amount:{4}", salesOrder.salesorder_id, salesOrder.date, salesOrder.customer_name, salesOrder.status, salesOrder.total);
                Console.WriteLine("Line Items");
                var lineitems = salesOrder.line_items;
                foreach(var tempLineitem in lineitems)
                {
                    Console.WriteLine("Id:{0},name:{1},rate:{2}", tempLineitem.line_item_id, tempLineitem.name, tempLineitem.rate);
                }
               Console.WriteLine("--------------------New SalesOrder----------------------");
                var newSalesOrderInfo=new Salesorder()
                {
                    customer_id=salesOrders[0].customer_id,
                    line_items = new List<LineItem> { new LineItem{
                            item_id=lineitems[0].item_id,
                        },
                    },
                    
                };
                var newSalesOrder = salesOrdersApi.Create(newSalesOrderInfo, null);
                Console.WriteLine("Id:{0},date:{1},customerName:{2},status:{3},Amount:{4}", newSalesOrder.salesorder_id, newSalesOrder.date, salesOrder.customer_name, newSalesOrder.status, newSalesOrder.total);
                Console.WriteLine("Line Items");
                var newLineitems = salesOrder.line_items;
                foreach (var tempLineitem in newLineitems)
                {
                    Console.WriteLine("Id:{0},name:{1},rate:{2}", tempLineitem.line_item_id, tempLineitem.name, tempLineitem.rate);
                }
                Console.WriteLine("--------------------Updated SalesOrder----------------------");
                var updateInfo = new Salesorder()
                {
                    line_items = new List<LineItem> { new LineItem{
                            item_id=lineitems[0].item_id,
                            rate=150,
                        },
                    },

                };
                var updatedSalesOrder = salesOrdersApi.Update(newSalesOrder.salesorder_id,updateInfo,null);
                Console.WriteLine("Id:{0},date:{1},customerName:{2},status:{3},Amount:{4}", updatedSalesOrder.salesorder_id, updatedSalesOrder.date, updatedSalesOrder.customer_name, updatedSalesOrder.status, updatedSalesOrder.total);
                Console.WriteLine("Line Items");
                var updatedLineitems = salesOrder.line_items;
                foreach (var tempLineitem in updatedLineitems)
                {
                    Console.WriteLine("Id:{0},name:{1},rate:{2}", tempLineitem.line_item_id, tempLineitem.name, tempLineitem.rate);
                }
                Console.WriteLine("--------------------Delete SalesOrder----------------------");
                var deleteMsg = salesOrdersApi.Delete(updatedSalesOrder.salesorder_id);
                Console.WriteLine(deleteMsg);
                Console.WriteLine("--------------------Mark SalesOrder as Open----------------------");
                var markAsOpen = salesOrdersApi.MarkAsOpen(salesOrders[0].salesorder_id);
                Console.WriteLine(markAsOpen);
                Console.WriteLine("--------------------Mark SalesOrder as Void----------------------");
                var markAsVoid = salesOrdersApi.MarkAsVoid(salesOrders[0].salesorder_id);
                Console.WriteLine(markAsVoid);
                Console.WriteLine("--------------------Email A SalesOrder----------------------");
                var emailDetails = new EmailNotification()
                {
                    to_mail_ids = new List<string>(){"harikrishna.t@zohocorp.com",},
                    subject="test sub",
                    body="body-test"
                };
                var emailOrder=salesOrdersApi.SendEmail(salesOrders[1].salesorder_id,emailDetails,null);
                Console.WriteLine(emailOrder);
                Console.WriteLine("--------------------Email Content of SalesOrder----------------------");
                var emailData = salesOrdersApi.GetEmailContent(salesOrders[1].salesorder_id, null);
                Console.WriteLine("Body:{0}\nSub:{1}\nTemplate Id{2}",emailData.body,emailData.subject,emailData.emailtemplates[0].email_template_id);
                Console.WriteLine("--------------------Bulk Export----------------------------");
                var salesorderIds = new List<string> { salesOrders[0].salesorder_id,};
                var bulkExport = salesOrdersApi.BulkExportSalesorders(salesorderIds);
                Console.WriteLine(bulkExport);
                Console.WriteLine("--------------------Bulk Print----------------------------");
                var bulkPrint = salesOrdersApi.BulkExportSalesorders(salesorderIds);
                Console.WriteLine(bulkPrint);
                var addr_info = new Address()
                {
                    city="test-city",
                    country="test-country"
                };
                Console.WriteLine("--------------------Update BillingAddress----------------------------");
                var updatedBillingAddr = salesOrdersApi.UpdateBillingAddress(salesOrders[0].salesorder_id, addr_info);
                Console.WriteLine("city:{0},state:{1}",updatedBillingAddr.city,updatedBillingAddr.country);
                Console.WriteLine("--------------------Update ShippingAddress----------------------------");
                var updatedShippingAddr = salesOrdersApi.UpdateShippingAddress(salesOrders[0].salesorder_id, addr_info);
                Console.WriteLine("city:{0},state:{1}", updatedShippingAddr.city, updatedShippingAddr.country);
                Console.WriteLine("---------------------Templates-------------------");
                var templates = salesOrdersApi.GetTemplates();
                foreach (var template in templates)
                    Console.WriteLine("id:{0},name:{1}", template.template_id, template.template_name);
                Console.WriteLine("-----------------------Update Template----------------");
                var updatedTemplate = salesOrdersApi.UpdateTemplate(salesOrders[0].salesorder_id, templates[0].template_id);
                Console.WriteLine(updatedTemplate);
                Console.WriteLine("-------------------------Attachments-----------------");
                var getAttachment = salesOrdersApi.GetAttachment(salesOrders[1].salesorder_id,null);
                Console.WriteLine(getAttachment);
                var addAttachment=salesOrdersApi.AddAttachment(salesOrders[0].salesorder_id,@"C:\Users\hari-2197\Desktop\h.jpg",null);
                Console.WriteLine(addAttachment);
                var attachPreference = new Dictionary<object, object>();
                attachPreference.Add("can_send_in_mail", true);
                var updatedAttachPreference = salesOrdersApi.UpdateAttachmentPreference(salesOrders[0].salesorder_id, attachPreference);
                Console.WriteLine(updatedAttachPreference);
                var delAttachment = salesOrdersApi.DeleteAnAttachment(salesOrders[0].salesorder_id);
                Console.WriteLine(delAttachment);
                Console.WriteLine("-------------------------Comments-----------------");
                var comments = salesOrdersApi.GetComments(salesOrders[0].salesorder_id);
                Console.WriteLine("All Comments");
                foreach (var comment in comments)
                    Console.WriteLine("id:{0},description:{1},commented by:{2}",comment.comment_id,comment.description,comment.commented_by);
                var newCommentInfo=new Comment()
                {
                    description="new test comment",
                };
                var newComment = salesOrdersApi.AddComment(salesOrders[0].salesorder_id, newCommentInfo);
                Console.WriteLine("id:{0},description:{1},commented by:{2}", newComment.comment_id, newComment.description, newComment.commented_by);
                var commentUpdateInfo=new Comment(){
                    description="updated-test"
                };
                var updatedComment = salesOrdersApi.UpdateComment(salesOrders[0].salesorder_id, newComment.comment_id, commentUpdateInfo);
                Console.WriteLine("id:{0},description:{1},commented by:{2}", updatedComment.comment_id, updatedComment.description, updatedComment.commented_by);
                var deleteComment = salesOrdersApi.DeleteComment(salesOrders[0].salesorder_id, updatedComment.comment_id);
                Console.WriteLine(deleteComment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
