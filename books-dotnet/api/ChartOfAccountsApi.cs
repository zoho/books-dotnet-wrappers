using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using zohobooks.util;
using zohobooks.parser;


namespace zohobooks.api
{
    /// <summary>
    /// ChartOfAccountsApi is used to<br></br>
    /// Create a chart of account,<br></br>
    /// List the chart of accounts,<br></br>
    /// Details of the chart of account,<br></br>
    /// List the transactions for an account,<br></br>
    /// Mark an account as active or inactive,<br></br>
    /// Update or delete the chart of account,<br></br>
    /// Delete the specified transaction of the account.<br></br>
    /// </summary>
    public class ChartOfAccountsApi:Api
    {
        
        static string baseAddress =baseurl + "/chartofaccounts";
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartOfAccountsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public ChartOfAccountsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List all chart of accounts along with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object wich is having the filters in the form of key,value pairs to refine the List.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>showbalance</td><td>Boolean to get current balance of accounts.</td></tr>
        /// <tr><td>filter_by</td><td>Filter accounts based on its account type and status.<br></br>Allowed Values: <i>AccountType.All, AccountType.Active, AccountType.Inactive, AccountType.Asset, AccountType.Liability, AccountType.Equity, AccountType.Income</i> and <i>AccountType.Expense</i></td></tr>
        /// <tr><td>sort_column</td><td>Sort accounts<br></br>Allowed Values: <i>account_name</i> and <i>account_type</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>ChartofaccountList object.</returns>
        public ChartOfAccountList GetChartOfAcounts(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ChartofaccountParser.getChartOfAccountList(responce);
        }
        /// <summary>
        /// Gets the details of an account.
        /// </summary>
        /// <param name="account_id">The account_id is the identifier of the chart of account.</param>
        /// <returns>ChartOfAccount object.</returns>
        public ChartOfAccount Get(string account_id)
        {
            string url = baseAddress + "/" + account_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ChartofaccountParser.getChartOfAccount(responce);
        }

        /// <summary>
        /// Creates an account with the given account type.
        /// </summary>
        /// <param name="new_account_info">The new_account_info is the ChartOfAccount object which contains the specified information to create an account with account_type as mandatory parameter.</param>
        /// <returns>ChartOfAccount object.</returns>
        public ChartOfAccount Create(ChartOfAccount new_account_info)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_account_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return ChartofaccountParser.getChartOfAccount(responce);
        }

        /// <summary>
        /// Updates the account information.
        /// </summary>
        /// <param name="account_id">The account_id is the identifier of the account.</param>
        /// <param name="update_info">The update_info is the ChartOfAccount object which contains the information regarding the changes with account_type as a mandatory parameter.</param>
        /// <returns>ChartOfAccount object.</returns>
        public ChartOfAccount Update(string account_id, ChartOfAccount update_info)
        {
            string url = baseAddress + "/" + account_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return ChartofaccountParser.getChartOfAccount(responce);
        }

        /// <summary>
        /// Deletes the given account. Accounts associated in any transaction/products could not be deleted.
        /// </summary>
        /// <param name="account_id">The account_id is the identifier of the account.</param>
        /// <returns>System.String.<br></br>The success message is "The account has been deleted."</returns>
        public string Delete(string account_id)
        {
            string url = baseAddress + "/" +account_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return ChartofaccountParser.getMessage(responce);
        }

        /// <summary>
        /// Updates the account status as active.
        /// </summary>
        /// <param name="account_id">The account_id is the identifier of the object.</param>
        /// <returns>System.String.<br></br>The success message is "The account has been marked as active."</returns>
        public string MarkAsActive(string account_id)
        {
            string url = baseAddress + "/" + account_id + "/active";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ChartofaccountParser.getMessage(responce);
        }

        /// <summary>
        /// Updates the account status as inactive.
        /// </summary>
        /// <param name="account_id">The account_id is the identifier of the object.</param>
        /// <returns>System.String.<br></br>The success message is "The account has been marked as inactive."</returns>
        public string MarkAsInactive(string account_id)
        {
            string url = baseAddress + "/" + account_id + "/inactive";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return ChartofaccountParser.getMessage(responce);
        }

        /// <summary>
        /// List all involved transactions for the given account.
        /// </summary>
        /// <param name="parameters">The parameters is dictionary object which is containg the filters to refine the list in the form of key,value pairs.<br></br>The possible filter keys and  coresponded allowed values are listed below<br></br>
        /// <table>
        /// <tr><td>account_id</td><td>ID of the account. List all transactions involved this account.</td></tr>
        /// <tr><td>date</td><td>Search account transactions with the given date range. Default date format is yyyy-mm-dd.<br></br>Variants: <i>date.start, date.end, date.before</i> and <i>date.after</i></td></tr>
        /// <tr><td>amount</td><td>Search account transactions with given amount range.<br></br>Variants: <i>amount.less_than, amount.less_equals, amount.greater_than</i> and <i>amount.greater_equals</i></td></tr>
        /// <tr><td>filter_by</td><td>Filter transactions based on its type.<br></br>Allowed Values: <i>TransactionType.All, TransactionType.BaseCurrencyAdjustment, TransactionType.Bills, TransactionType.VendorPayment, TransactionType.CardPayment, TransactionType.CreditNotes, TransactionType.CreditNoteRefund, TransactionType.Deposit, TransactionType.Expense, TransactionType.Invoice, TransactionType.Journal, TransactionType.CustomerPayment, TransactionType.TransferFund</i> and <i>TransactionType.OpeningBalance</i></td></tr>
        /// <tr><td>transaction_type</td><td>Search transactions based on the given transaction type.<br></br>Allowed Values: <i>invoice, customer_payment, bills, vendor_payment, credit_notes, creditnote_refund, expense, card_payment, purchase_or_charges, journal, deposit, refund, transfer_fund, base_currency_adjustment, opening_balance, sales_without_invoices, expense_refund, tax_refund, receipt_from_initial_debtors, owner_contribution, interest_income, other_income, owner_drawings</i> and <i>payment_to_initial_creditors</i></td></tr>
        /// <tr><td>sort_column</td><td>Sort transactions.<br></br>Allowed Values: <i>transaction_date, payee, glname, transaction_type_formatted, reconcile_status, debit_amount</i> and <i>credit_amount</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>TransactionList object.</returns>
        public TransactionList GetTransactions(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/transactions";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            return ChartofaccountParser.getTransactionList(responce);
        }

        /// <summary>
        /// Deletes the transaction.
        /// </summary>
        /// <param name="transaction_id">The transaction_id is the identifier of the specified transaction.</param>
        /// <returns>System.String.<br></br>The success message is "The transaction has been deleted."</returns>
        public string DeleteATransaction(string transaction_id)
        {
            string url = baseAddress + "/transactions/" +transaction_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            Console.WriteLine(responce.Content.ReadAsStringAsync().Result);
            return ChartofaccountParser.getMessage(responce);
        }
    }
}
