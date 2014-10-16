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
using zohobooks.Util;
using zohobooks.Parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class RecurringExpensesApi is used to <br></br>
    ///     Create a new recurring Expense,<br></br>
    ///     Get the list of all recurring expenses or comments for the specified recurring expense,<br></br>
    ///     Get the child expenses created from recurring expense or details of the specified recurring expense,<br></br>
    ///     Update or delete the existing recurring expense,<br></br>
    ///     Change the status as stop or resume the recurring expense.<br></br>
    /// </summary>
    public class RecurringExpensesApi:Api
    {
        /// <summary>
        /// The base uri of the ZohobooksApi
        /// </summary>
        static string baseAddress = baseurl + "/recurringexpenses";
        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringExpensesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public RecurringExpensesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List recurring expenses with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters in the form of key,value pair to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>recurrence_name</td><td>Search recurring expenses by recurring expense name.<br></br>Variants: <i>recurrence_name_startswith</i> and <i>recurrence_name_contains</i></td></tr>
        /// <tr><td>last_created_date</td><td>Search recurring expenses by date on when last expense was generated.<br></br>Variants: <i>last_created_date_start, last_created_date_end, last_created_date_before</i> and <i>last_created_date_after</i></td></tr>
        /// <tr><td>next_expense_date</td><td>Search recurring expenses by date on which next expense will be generated.<br></br>Variants: <i>next_expense_date_start, next_expense_date_end, next_expense_date_before</i> and <i>next_expense_date_after</i></td></tr>
        /// <tr><td>amount</td><td>Search recurring expenses by amount.<br></br>Variants: <i>amount_less_than, amount_less_equals, amount_greater_than</i> and <i>amount_greater_equals</i></td></tr>
        /// <tr><td>account_name</td><td>Search recurring expenses by expense account.<br></br>Variants: <i>account_name_startswith</i> and <i>account_name_contains</i></td></tr>
        /// <tr><td>status</td><td>Search recurring expenses by recurring expense status.<br></br>Allowed Values: <i>active, stopped</i> and <i>expired</i></td></tr>
        /// <tr><td>customer_name</td><td>Search recurring expenses by customer name.<br></br>Variants: <i>customer_name_startswith</i> and <i>customer_name_contains</i></td></tr>
        /// <tr><td>vendor_name</td><td>Search recurring expenses by vendor name.<br></br>Variants: <i>vendor_name_startswith</i> and <i>vendor_name_contains</i></td></tr>
        /// <tr><td>customer_id</td><td>Search recurring expenses by customer id.</td></tr>
        /// <tr><td>vendor_id</td><td>Search recurring expenses by vendor id.</td></tr>
        /// <tr><td>paid_through_account_id</td><td>Search expenses by paid through account id.</td></tr>
        /// <tr><td>description</td><td>Search recurring expenses by description.<br></br>Variants: <i>description_startswith</i> and <i>description_contains</i></td></tr>
        /// <tr><td>filter_by</td><td>Filter recurring expenses by status.<br></br>Allowed Values: <i>RecExpenseStatus.All, RecExpenseStatus.Active, RecExpenseStatus.Stopped</i> and <i>RecExpenseStatus.Expired</i></td></tr>
        /// <tr><td>search_text</td><td>Search recurring expenses by recurrence name or customer name.</td></tr>
        /// <tr><td>sort_column</td><td>Sort recurring expenses.<br></br>Allowed Values: <i>recurrence_name, last_created_date, next_expense_date, account_name, paid_through_account_name, total, customer_name, vendor_name</i> and <i>created_time</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>RecurringExpenseList object.</returns>
        public RecurringExpenseList GetRecurringExpenses(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return RecurringExpenseParser.getRecurringExpenseList(responce);
        }

        /// <summary>
        /// Gets the details of a recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <returns>RecurringExpense object.</returns>
        public RecurringExpense Get(string recurring_expense_id)
        {
            string url = baseAddress + "/" + recurring_expense_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return RecurringExpenseParser.getRecurringExpense(responce);
        }

        /// <summary>
        /// Creates the new recurring expense.
        /// </summary>
        /// <param name="new_recurring_expense">The new_recurring_expense is the recurringExpense object with amount_id,paid_through_id,recurrence_name,star_date,recurrence_frequency,amount and repeat_every as mandatory attributes.</param>
        /// <returns>RecurringExpense object.</returns>
        public RecurringExpense Create(RecurringExpense new_recurring_expense)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_recurring_expense);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return RecurringExpenseParser.getRecurringExpense(responce);
        }

        /// <summary>
        /// Updates the specified existing recurring expense .
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <param name="update_info">The update_info is the RecurringExpense object which contains the updation information.</param>
        /// <returns>RecurringExpense object.</returns>
        public RecurringExpense Update(string recurring_expense_id, RecurringExpense update_info)
        {
            string url = baseAddress + "/" + recurring_expense_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return RecurringExpenseParser.getRecurringExpense(responce);
        }

        /// <summary>
        /// Delete an existing recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring expense has been deleted." </returns>
        public string Delete(string recurring_expense_id)
        {
            string url = baseAddress + "/" + recurring_expense_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return RecurringExpenseParser.getMessage(responce);
        }

        /// <summary>
        /// Stop an active recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring expense has been stopped."</returns>
        public string Stop(string recurring_expense_id)
        {
            string url = baseAddress + "/" + recurring_expense_id+"/status/stop";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return RecurringExpenseParser.getMessage(responce);
        }

        /// <summary>
        /// Resume a stopped recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <returns>System.String.<br></br>The success message is "The recurring expense has been activated."</returns>
        public string Resume(string recurring_expense_id)
        {
            string url = baseAddress + "/" + recurring_expense_id + "/status/resume";
            var responce = ZohoHttpClient.post(url, getQueryParameters());
            return RecurringExpenseParser.getMessage(responce);
        }

        /// <summary>
        /// List child expenses created from recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <param name="parameters">The parameters is the Dictionary object which contains the following optional parameter in the form of key,value pair.<br></br>
        /// <table><tr><td>sort_column</td><td>Sort child expenses created.<br></br>Allowed Values: <i>date, account_name, vendor_name, paid_through_account_name, customer_name</i> and <i>total</i></td></tr></table>
        /// </param>
        /// <returns>List of Expense object.</returns>
        public ExpenseList GetExpensesCreated(string recurring_expense_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/" + recurring_expense_id + "/expenses";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return RecurringExpenseParser.getExpenseHistory(responce);
        }

        /// <summary>
        /// Get history and comments of a recurring expense.
        /// </summary>
        /// <param name="recurring_expense_id">The recurring_expense_id is the identifier of the recurrence expnse.</param>
        /// <returns>List of Comment objects.</returns>
        public CommentList GetComments(string recurring_expense_id)
        {
            string url = baseAddress + "/" + recurring_expense_id + "/comments";
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }
    }
}
