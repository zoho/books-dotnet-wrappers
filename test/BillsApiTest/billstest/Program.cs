using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;

namespace BillsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BillsApi billsApi = new BillsApi("{authtoken}", "{organizationId}");
                var parameters = new Dictionary<object, object>();
                var getBillAttach = billsApi.GetAttachment("71917000000088001", parameters);
                Console.WriteLine(getBillAttach);
                var parameters1 = new Dictionary<object, object>();
                var bills = billsApi.GetBills(parameters1);
                if (bills != null)
                {
                    foreach (var bill in bills)
                    {
                        Console.WriteLine("{0},{1},{2}", bill.bill_id, bill.vendor_name, bill.status);
                    }
                }
                var billbyId = billsApi.Get("71917000000216033");
                if (billbyId != null)
                {
                    Console.WriteLine("{0},{1},{2}", billbyId.bill_id, billbyId.vendor_name, billbyId.status);
                    Console.WriteLine("line Items {0}", billbyId.line_items.Count);
                    List<LineItem> lts = billbyId.line_items;
                    if (lts != null)
                        foreach (var lt in lts)
                        {
                            Console.WriteLine("{0},{1},{2}", lt.account_name, lt.rate, lt.line_item_id);
                        }
                }
                var newBillInfo = new Bill()
                {
                    vendor_id = "71917000000020021",
                    bill_number = "130",
                    line_items = new List<LineItem>() {
                      new LineItem{
                          account_id="71917000000000451",
                          rate=1.0
                      }
                  }
                };
                var newBill = billsApi.Create(newBillInfo, @"F:\Personal\hari-2197\Desktop\2.jpg");
                if (newBill != null)
                    Console.WriteLine("{0},{1},{2}", newBill.bill_id, newBill.vendor_name, newBill.status);
                var updateInfo = new Bill()
                {
                    bill_number = "156"
                };
                var updatedBill = billsApi.Update("71917000000088017", updateInfo, @"F:\error.png");
                if (updatedBill != null)
                    Console.WriteLine("{0},{1},{2}", updatedBill.bill_id, updatedBill.vendor_name, updatedBill.attachment_name);
                var delBill = billsApi.Delete("71917000000089001");
                Console.WriteLine(delBill);
                var voidBill = billsApi.VoidABill("71917000000088017");
                Console.WriteLine(voidBill);
                var openBill = billsApi.MarkBillAsOpen("71917000000088017");
                Console.WriteLine(openBill);
                var newBillingaddr = new Address()
                {
                    state = "A.P",
                    zip = "523117"
                };
                var updatedBillindaddr = billsApi.UpdateBillingAddress("71917000000088017", newBillingaddr);
                Console.WriteLine(updatedBillindaddr);
                var billpayments = billsApi.GetPayments("71917000000088001");
                foreach (var billpayment in billpayments)
                {
                    Console.WriteLine("{0},{1}", billpayment.payment_id, billpayment.bill_payment_id);
                }
                UseCredits creditsToApply = new UseCredits()
                {
                    bill_payments = new List<Payment>(){
                    new Payment(){
                        payment_id="71917000000087297",
                        amount_applied=5
                    },
                }
                };
                var applyCredits = billsApi.ApplyCredits("71917000000088001", creditsToApply);
                Console.WriteLine(applyCredits);
                var delbillpay = billsApi.DeletePayment("71917000000088001", "71917000000090031");
                Console.WriteLine(delbillpay);
                var parameters2 = new Dictionary<object, object>();
                parameters2.Add("preview", false);
                var getBillAttach1 = billsApi.GetAttachment("71917000000088017", parameters2);
                Console.WriteLine(getBillAttach1);
                var delAttach = billsApi.DeleteAttachment("71917000000088001");
                Console.WriteLine(delAttach);
                var attachfile = billsApi.AddAttachment("71917000000088001", @"C:\Users\hari-pt117\Downloads\Download Excel Macro Sample.xls");
                Console.WriteLine(attachfile);
                var comments = billsApi.GetComments("71917000000088017");
                if (comments != null)
                    foreach (var comment in comments)
                        Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by);
                var newCommentinfo = new Comment()
                {
                    description = "nothing2"
                };
                var newComment = billsApi.AddComment("71917000000088017", newCommentinfo);
                Console.WriteLine(newComment);
                var delcomment = billsApi.DeleteComment("71917000000088001", "71917000000088005");
                Console.WriteLine(delcomment);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
