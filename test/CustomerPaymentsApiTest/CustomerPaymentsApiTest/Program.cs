using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace CustomerPaymentsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                CustomerPaymentsApi customerpaymentsApi = service.GetCustomerPaymentsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("customer_name_startswith", "h");
                var customerpaymentsList = customerpaymentsApi.GetCustomerPayments(parameters);
                var customerpayments = customerpaymentsList;
                var paymentId = customerpayments[2].payment_id;
                if (customerpayments != null)
                {
                    foreach (var customerpayment in customerpayments)
                        Console.WriteLine("{0},{1},{2}", customerpayment.account_name, customerpayment.amount, customerpayment.customer_name);
                }
                var customerpayment1 = customerpaymentsApi.Get(paymentId);
                if(customerpayment1!=null)
                    Console.WriteLine("{0},{1},{2}", customerpayment1.account_name, customerpayment1.amount, customerpayment1.customer_name);
                var customerId = customerpayment1.customer_id;
                var newPaymentInfo = new CustomerPayment()
                {
                    customer_id = customerId,
                    date="2014-02-03",
                    amount=1234,
                };
                var newCustomerPayment = customerpaymentsApi.Create(newPaymentInfo);
                if(newCustomerPayment!=null)
                    Console.WriteLine("{0},{1},{2}", newCustomerPayment.account_name, newCustomerPayment.amount, newCustomerPayment.customer_name);
                var updateInfo = new CustomerPayment()
                {
                    amount=100000,
                };
                var updatedCustomerPayment = customerpaymentsApi.Update(paymentId, updateInfo);
                if(updatedCustomerPayment!=null)
                    Console.WriteLine("{0},{1},{2}", updatedCustomerPayment.account_name, updatedCustomerPayment.amount, updatedCustomerPayment.customer_name);
                var delcustpayment = customerpaymentsApi.Delete(customerpayments[1].payment_id);
                Console.WriteLine(delcustpayment);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
