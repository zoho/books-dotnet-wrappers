using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class BankTransactionsApi is used to create a transaction for an account.
    ///     It is used to get:<br></br>The list of all transactions.<br></br>The details of a transaction.<br></br>The matching
    ///     transactions.<br></br>The list of all associated transactions.<br></br>
    ///     It is used to update the details of a transaction.<br></br>
    ///     It is used to:<br></br>Match a transaction.<br></br>Unmatch a matched transaction.<br></br>Exclude a transaction.
    ///     <br></br>Restore an excluded transaction.<br></br>Categorize an uncategorized transaction.<br></br>	Categorize as
    ///     credit note refunds.<br></br>Categorize as vendor payment.<br></br>Categorize as customer payment.<br></br>
    ///     Categorize as expense.<br></br>Uncategorize a categorized transaction.<br></br>
    ///     It is used to delete a transaction.
    /// </summary>
    public class BankTransactionsApi : Api
    {
        private static readonly string baseAddress = baseurl + "/banktransactions";

        /// <summary>
        ///     Initializes a new instance of the <see cref="BankTransactionsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public BankTransactionsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     Gets all the transactions involved in an account.
        /// </summary>
        /// <param name="parameters">
        ///     The parameters is used to pass the filters to refine the transactions.
        ///     The parameters is a dictionary object which contains the key value pairs.<br></br>
        ///     The possible filter key and possible values are listed below <br></br>
        ///     <table>
        ///         <tr>
        ///             <td>
        ///                 <b>Filter key</b>
        ///             </td>
        ///             <td>Allowed values</td>
        ///         </tr>
        ///         <tr>
        ///             <td>account_id*</td><td>For which transactions are to be listed.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>filter_by</td>
        ///             <td>
        ///                 <i>Status.All, Status.Uncategorized, Status.Categorized, Status.ManuallyAdded, Status.Excluded</i> and
        ///                 <i> Status.Matched</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>transaction_type</td><td>Transaction type to group the list view</td>
        ///         </tr>
        ///         <tr>
        ///             <td>date</td><td><i>date_start </i> and <i>date_end</i></td>
        ///         </tr>
        ///         <tr>
        ///             <td>amount</td>
        ///             <td>
        ///                 Start and end amount, to provide a range within which the transaction amount exist Variants:
        ///                 <i>amount_start </i>and <i>amount_end</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>status</td>
        ///             <td>Transaction status wise list view - All, uncategorized, manually_added, matched, excluded, categorized</td>
        ///         </tr>
        ///         <tr>
        ///             <td>reference_number</td><td>Reference Number of the transaction.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>sort_column</td>
        ///             <td>
        ///                 <i>date</i>
        ///             </td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>TransactionList object.</returns>
        public TransactionList GetTransactions(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BankTransactionParser.getTransactionList(responce);
        }

        /// <summary>
        ///     Gets the details of the specified transaction.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the transaction.</param>
        /// <returns>Transaction object.</returns>
        public Transaction Get(string transaction_id)
        {
            var url = baseAddress + "/" + transaction_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BankTransactionParser.getTransaction(responce);
        }

        /// <summary>
        ///     Creates the transaction based on the information provided.
        /// </summary>
        /// <param name="new_transaction_info">
        ///     The new_transaction_info is the Transaction object which provides the info to create
        ///     a transaction as a transaction_type parameter is mandatory.
        /// </param>
        /// <returns>Transaction object.</returns>
        public Transaction Create(Transaction new_transaction_info)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(new_transaction_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getTransaction(responce);
        }

        /// <summary>
        ///     Makes changes in the applicable fields of a specified transaction.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the transaction identifier on which changes has to applied.</param>
        /// <param name="update_info">
        ///     The update_info is the Transaction object which is having the information to update the
        ///     transaction with transaction_type parameter as mandatory.
        /// </param>
        /// <returns>Transaction object.</returns>
        public Transaction Update(string transaction_id, Transaction update_info)
        {
            var url = baseAddress + "/" + transaction_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getTransaction(responce);
        }

        /// <summary>
        ///     Deletes the specified transaction from the account.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is transaction identifier on which deletion is going to apply.</param>
        /// <returns>
        ///     System.String.<br></br>If the transaction has been deleted it returns the success message.<br></br>The success
        ///     message is "The transaction has been deleted."
        /// </returns>
        public string Delete(string transaction_id)
        {
            var url = baseAddress + "/" + transaction_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Gets the matching transactions based on the provided criteria.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the transaction identifier to get the matching transactions of it.</param>
        /// <param name="parameters">
        ///     The parameters is the dictionary object,it contains the match criteria in the form of key value pairs.<br></br>
        ///     The parameters contains the below listed possible keys and the corespondent values
        ///     <table>
        ///         <tr>
        ///             <td>transaction_type</td>
        ///             <td>
        ///                 The type of transaction.<br></br>Allowed Values:
        ///                 <i>
        ///                     expense, deposit, refund, transfer_fund, card_payment, sales_without_invoices, expense_refund,
        ///                     owner_contribution, interest_income, other_income, owner_drawings, invoice, bill, credit_notes,
        ///                     creditnote_refund, customer_payment
        ///                 </i>
        ///                 and <i>vendor_payment</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>date</td>
        ///             <td>
        ///                 Start and end date, to provide a range within which the transaction date exist.<br></br>Variants:
        ///                 date_start and date_end
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>amount</td>
        ///             <td>
        ///                 Initial and final amount range within which the search amount exists.<br></br>Variants: amount_start
        ///                 and amount_end
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>contact</td><td>Contact person name, involved in the transaction.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>reference_number</td><td>Reference Number of the transaction.</td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>MatchingTransactions object.</returns>
        public MatchingTransactions GetMatchingTransactions(string transaction_id,
            Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/match";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BankTransactionParser.getMatchingTransactions(responce);
        }

        /// <summary>
        ///     Match an uncategorized transaction with an existing transaction in the account.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the existing transaction.</param>
        /// <param name="transactions_to_be_matched">
        ///     The transactions_to_be_matched is the list of transactions objects with
        ///     transaction_id and transaction_type as mandatory.
        /// </param>
        /// <returns>
        ///     System.String.<br></br>The success message is "The Uncategorized transaction is linked to the selected
        ///     transaction(s) in Zoho Books."
        /// </returns>
        public string MatchATransaction(string transaction_id, TransactionsToBeMatched transactions_to_be_matched)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/match";
            var json = JsonConvert.SerializeObject(transactions_to_be_matched);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Unmatches the transaction that was previously matched and make it uncategorized..
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifer of the transaction which is going to be uncatogirised.</param>
        /// <returns>System.String.<br></br>The success message is "The transaction has been unmatched."</returns>
        public string UnmatchTransaction(string transaction_id)
        {
            var url = baseAddress + "/" + transaction_id + "/unmatch";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            ;
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Gets a list of all the associated transactions that were matched or categorized to the given imported transaction.
        /// </summary>
        /// <param name="transaction_id">
        ///     The transaction_id is the identifier of the transaction for which going to be list the
        ///     associated transactions.
        /// </param>
        /// <param name="parameters">
        ///     The parameters contains sort_coloumn with allowed value <i>statement_date</i> which helps to
        ///     get associated transactions
        /// </param>
        /// <returns>AssociatedTransaction object.</returns>
        public Transaction GetAssociatedTransactions(string transaction_id, Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/" + transaction_id + "/associated";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BankTransactionParser.getAssociatedTransaction(responce);
        }

        /// <summary>
        ///     Excludes a transaction from the account.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the transaction identifier which is going to be excluded.</param>
        /// <returns>
        ///     System.String.<br></br>If the transaction has been excluded it returns the success message.<br></br>The
        ///     success message is "The transaction has been excluded."
        /// </returns>
        public string ExcludeATransaction(string transaction_id)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/exclude";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Restores a excluded transaction into the account.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of excluded transaction.</param>
        /// <returns>
        ///     System.String object.<br></br>If the transaction has been restored it returns the success message.<br></br>The
        ///     success message is "The excluded transaction has been restored."
        /// </returns>
        public string RestoreATransaction(string transaction_id)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/restore";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Categorizes an uncategorized transaction by creating a new transaction.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the uncatogorised transaction.</param>
        /// <param name="transaction_info">
        ///     The transaction_info is the information which requires to create a transaction to
        ///     catogarise with transaction_type as mandatory parameter.
        /// </param>
        /// <returns>System.String.<br></br>The success message is "The transaction is now categorized."</returns>
        public string CategorizeAnUncategorizedTransaction(string transaction_id, Transaction transaction_info)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize";
            var json = JsonConvert.SerializeObject(transaction_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Categorizes an uncategorized transaction as credit note refunds.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the uncategorized transaction .</param>
        /// <param name="refund_details">The refund_details is the Creditnote object which is having the details of the refund.</param>
        /// <returns>System.String.<br></br>The success message is "The transaction is now categorized."</returns>
        public string CategorizeAsCreditNoteRefunds(string transaction_id, CreditNote refund_details)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize/creditnoterefunds";
            var json = JsonConvert.SerializeObject(refund_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Categorizes an uncatogerized transaction as vendorpayment.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the uncategorize transaction.</param>
        /// <param name="payment_details">
        ///     The payment_details is the vendor payment object with vendor_id and amount are the
        ///     mandatory parameters.
        /// </param>
        /// <returns>System.String.<br></br>The success message is "The transaction is now categorized."</returns>
        public string CategorizeAsVendorpayment(string transaction_id, VendorPayment payment_details)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize/vendorpayments";
            var json = JsonConvert.SerializeObject(payment_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Categorizes as customer payments.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the uncatogerized ttransaction.</param>
        /// <param name="payment_details">
        ///     The payment_details is the Customerpayment object to catogerize the transaction with date
        ///     and amount are the mandatory parameters.
        /// </param>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which is having the parameter contact_ids as key value
        ///     pair.
        /// </param>
        /// <returns>System.String.<br></br>The success message is "The transaction is now categorized."</returns>
        public string CategorizeAsCustomerPayments(string transaction_id, CustomerPayment payment_details,
            Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize/customerpayments";
            var json = JsonConvert.SerializeObject(payment_details);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Categorizes an uncategorised transaction as expense.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the uncategorized transaction.</param>
        /// <param name="expense_details">
        ///     The expense_details is the Expoense object with account_id,paid_through_account_id and
        ///     date are mandatory parameters.
        /// </param>
        /// <param name="receipt_path">The receipt_path is the reciept for the expense .</param>
        /// <returns>System.String.<br></br> The success message is "The transaction is now categorized."</returns>
        public string CategorizeAsExpense(string transaction_id, Expense expense_details, string receipt_path)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize/expense";
            var json = JsonConvert.SerializeObject(expense_details);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var attachment = new[] {receipt_path};
            var file = new KeyValuePair<string, string[]>("receipt", attachment);
            var responce = ZohoHttpClient.post(url, getQueryParameters(), jsonstring, file);
            return BankTransactionParser.getMessage(responce);
        }

        /// <summary>
        ///     Reverts a categorized transaction as uncategorized.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the categorized transaction id.</param>
        /// <returns>System.String.<br></br>The success message is"The transaction has been uncategorized."</returns>
        public string UncategorizeACategorizedTransaction(string transaction_id)
        {
            var url = baseAddress + "/" + transaction_id + "/uncategorize";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return BankTransactionParser.getMessage(responce);
        }

        public string CategorizeAsVendorCreditRefund(string transaction_id, VendorCreditRefund refund_details)
        {
            var url = baseAddress + "/uncategorized/" + transaction_id + "/categorize/vendorcreditrefunds";
            var json = JsonConvert.SerializeObject(refund_details);
            var parameters = new Dictionary<object, object>();
            parameters.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return BankTransactionParser.getMessage(response);
        }
    }
}