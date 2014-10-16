using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;


namespace BankTransactionApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var transactionApi = service.GetBankTransactionsApi();
                var accounts = service.GetBankAccountsApi().GetBankAccounts(null);
                var parameters = new Dictionary<object, object>();
                 parameters.Add("filter_by", "Status.All");
                 parameters.Add("account_id", accounts[0].account_id);
                 var transactionList = transactionApi.GetTransactions(parameters);
                 var transactions = transactionList;
                 foreach (var trans in transactions)
                     Console.WriteLine("{0},{1},{2}", trans.transaction_id, trans.status, trans.amount);
                var transaction = transactionApi.Get(transactions[0].transaction_id);
                 Console.WriteLine("{0},{1},{2}", transaction.transaction_id, transaction.transaction_type, transaction.amount);
                 var newTransactionInfo = new Transaction()
                 {
                     transaction_type = "transfer_fund",
                     from_account_id = accounts[0].account_id,
                     to_account_id = accounts[2].account_id,
                     amount=10
                 };
                 var newTransaction = transactionApi.Create(newTransactionInfo);
                 Console.WriteLine("{0},{1},{2}", newTransaction.transaction_id, newTransaction.transaction_type, newTransaction.amount);
                 var updateInfo = new Transaction()
                  {
                         amount=50,
                         currency_id="{currency id}",
                         date="2014-02-06",
                         description="",
                         exchange_rate=1,
                         from_account_id = accounts[0].account_id,
                         reference_number= "",
                         to_account_id = accounts[2].account_id,
                         transaction_type = "transfer_fund"
                 };
                 var updatedTrans = transactionApi.Update(transactions[2].transaction_id, updateInfo);
                 Console.WriteLine("{0},{1},{2}", updatedTrans.transaction_id, updatedTrans.transaction_type, updatedTrans.amount);
                 var deltrans = transactionApi.Delete(transactions[2].transaction_id);
                 Console.WriteLine(deltrans);
                 parameters.Add("amount_start", "1");
                 parameters.Add("amount_end", "4000");
                 parameters.Add("date_start", "2014-02-01");
                 parameters.Add("date_end", "2014-02-07");

                 var matchingtrans = transactionApi.GetMatchingTransactions(transactions[0].transaction_id, parameters);
                 
                 foreach(var matchingTran in matchingtrans)
                     Console.WriteLine("{0},{1},{2}", matchingTran.transaction_id, matchingTran.transaction_type, matchingTran.amount);
                 parameters.Add("account_id", accounts[1].account_id);
                 TransactionsToBeMatched transtomatch = new TransactionsToBeMatched()
                 {
                     transactions_to_be_matched = new List<Transaction>(){
                         new Transaction()
                         {
                             transaction_id=transactions[2].transaction_id,
                             transaction_type="vendor_payment"
                         },
                         new Transaction()
                         {
                             transaction_id=transactions[3].transaction_id,
                             transaction_type="transfer_fund"
                         },
                         new Transaction()
                         {
                             transaction_id=transactions[1].transaction_id,
                             transaction_type="expense"
                         }
                     }
                 };
                 var matchtransaction = transactionApi.MatchATransaction(transactions[0].transaction_id, transtomatch);
                 Console.WriteLine(matchtransaction);
                 var unmatch = transactionApi.UnmatchTransaction(transactions[0].transaction_id);
                 Console.WriteLine(unmatch);
                 parameters.Add("sort_column", "statement_date");
                 var associatedTransObj = transactionApi.GetAssociatedTransactions(transactions[0].transaction_id, parameters);
                 var associatedTrans = associatedTransObj.associated_transactions;
                 Console.WriteLine(associatedTransObj.imported_transaction_id);
                 foreach (var asociatedTran in associatedTrans)
                     Console.WriteLine("{0},{1},{2}", asociatedTran.transaction_id, asociatedTran.transaction_type, asociatedTran.amount);
                 var exclude = transactionApi.ExcludeATransaction(transactions[0].transaction_id);
                 Console.WriteLine(exclude);
                 var restore = transactionApi.RestoreATransaction(transactions[0].transaction_id);
                 Console.WriteLine(restore);
                 var transacInfo=new Transaction()
                 {
                         amount=4000,
                         currency_id="{currency id}",
                         date="2013-01-29",
                         description="Insurance payment",
                         exchange_rate=1,
                         from_account_id = accounts[1].account_id,
                         reference_number="Ref-9872",
                         to_account_id = accounts[3].account_id,
                         transaction_type = "expense"
                 };
                 var catogarise = transactionApi.CategorizeAnUncategorizedTransaction(transactions[0].transaction_id, transacInfo);
                 Console.WriteLine(catogarise);
                 var creditrefundInfo = new CreditNote()
                 {
                     creditnote_id = "{credit note id}",
                     date="2014-02-07",
                     from_account_id = "{account id from which account the transaction is going to be done}",
                     amount=4000
                 };
                 var catogasCred = transactionApi.CategorizeAsCreditNoteRefunds(transactions[0].transaction_id, creditrefundInfo);
                 Console.WriteLine(catogasCred);
                 var vendordetails = new VendorPayment()
                 {
                     vendor_id = "{vendor id}",
                     amount=4000,
                     paid_through_account_id = "{account id}"
                 };
                 var vendorcat = transactionApi.CategorizeAsVendorpayment(transactions[0].transaction_id, vendordetails);
                 Console.WriteLine(vendorcat);
                 var customerinfo = new CustomerPayment()
                 {
                     customer_id = "{customer id}",
                     date="2014-02-08",
                     invoices = new List<Invoice>()
                     {
                         new Invoice(){
                             invoice_id="{invoice id}",
                             amount_applied=4000
                            }
                     },
                     amount=4000
                 };
                 var custpaycat = transactionApi.CategorizeAsCustomerPayments(transactions[0].transaction_id, customerinfo, parameters);
                 Console.WriteLine(custpaycat);
                 var expenseInfo=new Expense()
                 {
                     account_id=accounts[3].account_id,
                     date="2013-01-29",
                     paid_through_account_id = accounts[4].account_id,
                     project_id= "",
                     amount=4000,
                     tax_id="",
                     is_inclusive_tax=false,
                     is_billable=false,
                     reference_number="Ref-123",
                     description="Insurance payment",
                 };
                 var catAsExpens = transactionApi.CategorizeAsExpense(transactions[0].transaction_id, expenseInfo, @"F:\error.png");
                 Console.WriteLine(catAsExpens);
                 var uncatogorise = transactionApi.UncategorizeACategorizedTransaction(transactions[0].transaction_id);
                 Console.WriteLine(uncatogorise);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
