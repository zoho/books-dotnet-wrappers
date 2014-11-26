using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.model;
using zohobooks.service;

namespace VendorCreditsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var vendorCreditsApi = service.GetVendorCreditsApi();
                Console.WriteLine("--------------------VendorCreditList--------------");
                var vendorCredits = vendorCreditsApi.GetVendorCredits(null);
                foreach (var tempVendorCredit in vendorCredits)
                    Console.WriteLine("Id:{0},Vendor name:{1},Status:{2}",tempVendorCredit.vendor_credit_id,tempVendorCredit.vendor_name,tempVendorCredit.status);
                Console.WriteLine("----------------------------------Specified Vendor Credit-----------------------");
                var vendorCredit = vendorCreditsApi.Get(vendorCredits[0].vendor_credit_id,null);
                Console.WriteLine("Id:{0},Vendor name:{1},Status:{2}", vendorCredit.vendor_credit_id, vendorCredit.vendor_name, vendorCredit.status);
                Console.WriteLine("Line items:");
                var lineitems = vendorCredit.line_items;
                foreach (var tempLineItem in lineitems)
                    Console.WriteLine("name:{0},desc:{1},rate:{2}", tempLineItem.name, tempLineItem.description, tempLineItem.rate);
                Console.WriteLine("------------------New Vendor Credit---------");
                var newCreditInfo = new VendorCredit()
                {
                    vendor_id=vendorCredit.vendor_id,
                    line_items = new List<LineItem>()
                    {
                        new LineItem(){
                            item_id=lineitems[0].item_id,
                            rate=360,
                        },
                    },
                };
                var newVendorCredit = vendorCreditsApi.Create(newCreditInfo, null);
                Console.WriteLine("Id:{0},Vendor name:{1},Status:{2},amount:{3}", newVendorCredit.vendor_credit_id, newVendorCredit.vendor_name, newVendorCredit.status,newVendorCredit.total);
                Console.WriteLine("-------------------------Update Vendor Credit------------");
                var creditUpdateInfo = new VendorCredit()
                {
                    
                    line_items = new List<LineItem>()
                    {
                        new LineItem(){
                            item_id=lineitems[0].item_id,
                            rate=560,
                        },
                    },
                };
                var updatedVendorCredit = vendorCreditsApi.Update(newVendorCredit.vendor_credit_id, creditUpdateInfo);
                Console.WriteLine("Id:{0},Vendor name:{1},Status:{2},amount:{3}", updatedVendorCredit.vendor_credit_id, updatedVendorCredit.vendor_name, updatedVendorCredit.status, updatedVendorCredit.total);
                Console.WriteLine("-----------------------Delete Vendor Credit----------------");
                var deleteVendorcredit = vendorCreditsApi.Delete(updatedVendorCredit.vendor_credit_id);
                Console.WriteLine(deleteVendorcredit);
                Console.WriteLine("------------------Statuses----------------");
                var convertToOpen = vendorCreditsApi.ConvertToOpen(vendorCredits[0].vendor_credit_id);
                Console.WriteLine(convertToOpen);
                var markAsVoid = vendorCreditsApi.MarkAsVoid(vendorCredits[1].vendor_credit_id);
                Console.WriteLine(markAsVoid);
                Console.WriteLine("---------------------------------Bills credited-------------------------------");
                var bills = vendorCreditsApi.GetBillsCredited(vendorCredits[0].vendor_credit_id);
                foreach (var tempBill in bills)
                    Console.WriteLine("Bill id:{0},vendor credit bill id:{1},amount:{2}",tempBill.bill_id,tempBill.vendor_credit_bill_id,tempBill.amount);
                var billsToApply = new ApplyToBills()
                {
                    bills = new List<Bill>()
                    {
                        new Bill(){
                            bill_id=bills[0].bill_id,
                            amount_applied=100
                         },
                    }
                };
                var applyCredits = vendorCreditsApi.ApplyCreditsToBill(vendorCredits[0].vendor_credit_id, billsToApply);
                Console.WriteLine(applyCredits);
                var deleteBillsCredited = vendorCreditsApi.DeleteBillsCredited(vendorCredits[0].vendor_credit_id, bills[0].vendor_credit_bill_id);
                Console.WriteLine(deleteBillsCredited);
                Console.WriteLine("------------------------------------Refunds------------------------");
                var allRefunds = vendorCreditsApi.GetRefunds(null);
                foreach (var tempRefund in allRefunds)
                    Console.WriteLine("Refund id:{0},vendor name:{1},amount:{2}",tempRefund.vendor_credit_refund_id,tempRefund.vendor_name,tempRefund.amount_fcy);
                var refundsOfCredit = vendorCreditsApi.GetRefundsOfVendorCredit(vendorCredits[0].vendor_credit_id);
                foreach (var tempRefund in refundsOfCredit)
                    Console.WriteLine("Refund id:{0},vendor name:{1},amount:{2}", tempRefund.vendor_credit_refund_id, tempRefund.vendor_name, tempRefund.amount_fcy);
                var refund = vendorCreditsApi.GetVendorCreditRefund(vendorCredits[0].vendor_credit_id, refundsOfCredit[0].vendor_credit_refund_id);
                Console.WriteLine("Specified Refund \n Refund id:{0},vendor name:{1},amount:{2}", refund.vendor_credit_refund_id, refund.vendor_name, refund.amount);
                var newRefundInfo = new VendorCreditRefund()
                {
                    date="2014-11-25",
                    account_id=refund.account_id,
                    amount=20
                };
                var newRefund = vendorCreditsApi.AddRefund(vendorCredits[0].vendor_credit_id, newRefundInfo);
                Console.WriteLine("New Refund \n Refund id:{0},vendor name:{1},amount:{2}", newRefund.vendor_credit_refund_id, newRefund.vendor_name, newRefund.amount);
                var updateInfo = new VendorCreditRefund()
                {
                    amount = 25
                };
                var updatedRefund = vendorCreditsApi.UpdateRefund(vendorCredits[0].vendor_credit_id, newRefund.vendor_credit_refund_id, updateInfo);
                Console.WriteLine("Updated Refund \n Refund id:{0},vendor name:{1},amount:{2}", updatedRefund.vendor_credit_refund_id, updatedRefund.vendor_name, updatedRefund.amount);
                var deleteRefund = vendorCreditsApi.DeleteRefund(vendorCredits[0].vendor_credit_id, updatedRefund.vendor_credit_refund_id);
                Console.WriteLine(deleteRefund);
                Console.WriteLine("--------------------------Comments-------------------");
                var comments = vendorCreditsApi.GetComments(vendorCredits[0].vendor_credit_id);
                foreach (var comment in comments)
                    Console.WriteLine("id:{0},description:{1},commented by:{2}", comment.comment_id, comment.description, comment.commented_by);
                var newCommentInfo = new Comment()
                {
                    description="test comment",
                };
                var newComment = vendorCreditsApi.AddComment(vendorCredits[0].vendor_credit_id, newCommentInfo);
                Console.WriteLine("New comment \nid:{0},description:{1},commented by:{2}", newComment.comment_id, newComment.description, newComment.commented_by);
                var deleteComment = vendorCreditsApi.DeleteComment(newComment.vendor_credit_id, newComment.comment_id);
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
