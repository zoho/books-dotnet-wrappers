using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.service;
using zohobooks.model;

namespace PurchaseordersApitest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var purchaseordersApi = service.GetPurchaseordersApi();
                Console.WriteLine("------------------------All Orders-----------");
                var purchaseorders = purchaseordersApi.GetPurchaseorders(null);
                foreach (var tempOrder in purchaseorders)
                    Console.WriteLine("order id:{0},vendor name:{1},status:{2}",tempOrder.purchaseorder_id,tempOrder.vendor_name,tempOrder.status);
                Console.WriteLine("-------------Specified order-------------------");
                var purchaseorder = purchaseordersApi.Get(purchaseorders[0].purchaseorder_id,null);
                Console.WriteLine("order id:{0},vendor name:{1},status:{2}", purchaseorder.purchaseorder_id, purchaseorder.vendor_name, purchaseorder.status);
                Console.WriteLine("line items");
                var lineitems = purchaseorder.line_items;
                foreach (var tempitem in lineitems)
                    Console.WriteLine("item id:{0},description:{1},rate:{2}",tempitem.item_id,tempitem.description,tempitem.rate);
                Console.WriteLine("-------------New Purchaseorder--------------------");
                var newOrderInfo = new Purchaseorder()
                {
                    vendor_id=purchaseorder.vendor_id,
                    line_items=new List<LineItem>()
                    {
                        new LineItem(){
                            item_id=lineitems[0].item_id,
                            rate=250,
                    },
                    }
                };
                var newPurchaseOrder = purchaseordersApi.Create(newOrderInfo, null, @"C:\Users\hari-2197\Desktop\h.jpg");
                Console.WriteLine("order id:{0},vendor name:{1},status:{2},total:{3}", newPurchaseOrder.purchaseorder_id, newPurchaseOrder.vendor_name, newPurchaseOrder.status,newPurchaseOrder.total);
                Console.WriteLine("line items");
                var newOredrlineitems = newPurchaseOrder.line_items;
                foreach (var tempitem in newOredrlineitems)
                    Console.WriteLine("item id:{0},description:{1},rate:{2}", tempitem.item_id, tempitem.description, tempitem.rate);
                Console.WriteLine("--------------------update order--------------");
                var updateInfo = new Purchaseorder()
                {
                    line_items=new List<LineItem>()
                    {
                        new LineItem(){
                            item_id=lineitems[0].item_id,
                            rate=300,
                        },
                    }
                };
                var updatedOrder = purchaseordersApi.Update(newPurchaseOrder.purchaseorder_id, updateInfo, null,null);
                Console.WriteLine("order id:{0},vendor name:{1},status:{2},total:{3}", updatedOrder.purchaseorder_id, updatedOrder.vendor_name, updatedOrder.status, updatedOrder.total);
                Console.WriteLine("---------------Delete Order------------------");
                var deleteOrder = purchaseordersApi.Delete(updatedOrder.purchaseorder_id);
                Console.WriteLine(deleteOrder);
                Console.WriteLine("---------------Mark Order as open------------------");
                var markAsOpen = purchaseordersApi.MarkAsOpen(purchaseorders[0].purchaseorder_id);
                Console.WriteLine(markAsOpen);
                Console.WriteLine("---------------Mark Order as billed------------------");
                var markAsBilled = purchaseordersApi.MarkAsBilled(purchaseorders[0].purchaseorder_id);
                Console.WriteLine(markAsBilled);
                Console.WriteLine("---------------Cancel purchaseOrder ------------------");
                var cancelOrder = purchaseordersApi.CancelPurchaseorder(purchaseorders[0].purchaseorder_id);
                Console.WriteLine(cancelOrder);
                Console.WriteLine("---------------Email Purchase Order------------------");
                var emailDetails = new EmailNotification()
                {
                    to_mail_ids = new List<string>() { "harikrishna.t@zohocorp.com"},
                    subject="test-sub",
                    body="test-body"
                };
                var emailOrder = purchaseordersApi.SendEmail(purchaseorders[1].purchaseorder_id, emailDetails, null);
                Console.WriteLine(emailOrder);
                Console.WriteLine("---------------Email content of Purchase Order------------------");
                var emailContent = purchaseordersApi.GetEmailContent(purchaseorders[1].purchaseorder_id, null);
                Console.WriteLine("Subject:{0},\n Body:{1}", emailContent.subject, emailContent.body);
                Console.WriteLine("---------------Update Billing Address------------------");
                var updateAddressInfo = new Address()
                {
                    city="test-city",
                    state="test-state",
                };
                var updatedAddress = purchaseordersApi.UpdateBillingAddress(purchaseorders[1].purchaseorder_id, updateAddressInfo);
                Console.WriteLine("city:{0},state:{1}",updatedAddress.city,updatedAddress.state);
                Console.WriteLine("---------------List and update template------------------");
                var templates = purchaseordersApi.GetTemplates();
                foreach (var template in templates)
                    Console.WriteLine("name:{0},type:{1}", template.template_name, template.template_type);
                var updateTemplate = purchaseordersApi.UpdateTemplate(purchaseorders[1].purchaseorder_id, templates[0].template_id);
                Console.WriteLine(updateTemplate);
                Console.WriteLine("-------------------Attachments----------------");
                var getAttachment = purchaseordersApi.GetAttachment(purchaseorders[0].purchaseorder_id, null);
                Console.WriteLine(getAttachment);
                var addAttachment = purchaseordersApi.AddAttachment(purchaseorders[2].purchaseorder_id, @"C:\Users\hari-2197\Desktop\h.jpg");
                Console.WriteLine(addAttachment);
                var attachPreferences=new Dictionary<object,object>();
                attachPreferences.Add("can_send_in_mail",true);
                var updateAttachPreference=purchaseordersApi.UpdateAttachmentPreference(purchaseorders[2].purchaseorder_id,attachPreferences);
                Console.WriteLine(updateAttachPreference);
                var deleteAttachment = purchaseordersApi.DeleteAnAttachment(purchaseorders[2].purchaseorder_id);
                Console.WriteLine(deleteAttachment);
                Console.WriteLine("--------------------------Comments -----------------------");
                var comments = purchaseordersApi.GetComments(purchaseorders[0].purchaseorder_id);
                foreach (var comment in comments)
                    Console.WriteLine("comment id:{0},description:{1},commented by:{2}", comment.comment_id, comment.description, comment.commented_by);
                var newCommentInfo = new Comment()
                {
                    description="test comment",
                };
                var newComment = purchaseordersApi.AddComment(purchaseorders[0].purchaseorder_id, newCommentInfo);
                Console.WriteLine("comment id:{0},description:{1},commented by:{2}", newComment.comment_id, newComment.description, newComment.commented_by);
                var commentUpdateInfo = new Comment()
                {
                    description="updated for test",
                };
                var updatedComment = purchaseordersApi.UpdateComment(purchaseorders[0].purchaseorder_id, newComment.comment_id, commentUpdateInfo);
                Console.WriteLine("comment id:{0},description:{1},commented by:{2}", updatedComment.comment_id, updatedComment.description, updatedComment.commented_by);
                var deleteComment = purchaseordersApi.DeleteComment(purchaseorders[0].purchaseorder_id, updatedComment.comment_id);
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
