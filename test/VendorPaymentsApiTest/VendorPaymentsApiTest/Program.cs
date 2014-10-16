using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace VendorPaymentsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var vendorPaymentsApi = service.GetVendorPaymentsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("filter_by", "PaymentMode.BankTransfer");
                var vendorpayments = vendorPaymentsApi.GetVendorPayments(parameters);
                var vendorPaymentId = vendorpayments[1].payment_id;
                if (vendorpayments != null)
                    foreach (var vendorpayment in vendorpayments)
                        Console.WriteLine("{0},{1},{2}", vendorpayment.payment_id, vendorpayment.vendor_id, vendorpayment.amount);
                var vendorpayment1 = vendorPaymentsApi.Get(vendorPaymentId);
                if (vendorpayment1 != null)
                    Console.WriteLine("{0},{1},{2}", vendorpayment1.payment_id, vendorpayment1.vendor_id, vendorpayment1.amount);

                var newVendorPaymentInfo = new VendorPayment()
                {
                    vendor_id="{vendor id}",
                    amount = 1560,
                };
                var newVendorPayment = vendorPaymentsApi.Create(newVendorPaymentInfo);

                if (newVendorPayment != null)
                {
                    Console.WriteLine("{0},{1},{2}", newVendorPayment.payment_id, newVendorPayment.vendor_id, newVendorPayment.amount);
                }
                var updateinfo = new VendorPayment()
                 {
                     amount = 10
                 };
                var updatedVendorPayment = vendorPaymentsApi.Update(vendorPaymentId, updateinfo);
                if (updatedVendorPayment != null)
                    Console.WriteLine("{0},{1},{2}", updatedVendorPayment.payment_id, updatedVendorPayment.vendor_id, updatedVendorPayment.amount);
                var delvendorpayments = vendorPaymentsApi.Delete(vendorpayments[3].payment_id);
                Console.WriteLine(delvendorpayments);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
