using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class ExpensesApi is used to <br></br>
    ///     Create a new expense,<br></br>
    ///     List the all Expenses and their history,<br></br>
    ///     Get the details of the expense or expense receipt,<br></br>
    ///     update the details of the expense,<br></br>
    ///     Add the reciept to the expense,<br></br>
    ///     Delete the specified expense or receipt.<br></br>
    /// </summary>
    public class ExpensesApi : Api
    {
        private static readonly string baseAddress = baseurl + "/expenses";

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpensesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public ExpensesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     List expenses with pagination.
        /// </summary>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which contains the filters in the form of key,value pairs to refine the
        ///     list.<br></br>The possible filters are listed below <br></br>
        ///     <table>
        ///         <tr>
        ///             <td>description</td>
        ///             <td>
        ///                 Search expenses by description.<br></br>Variants: <i>description_startswith</i> and
        ///                 <i>description_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>reference_number</td>
        ///             <td>
        ///                 Search expenses by reference number.<br></br>Variants: <i>reference_number_startswith</i> and
        ///                 <i>reference_number_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>date</td>
        ///             <td>
        ///                 Search expenses by expense date.<br></br>Variants: <i>date_start, date_end, date_before</i> and
        ///                 <i>date_after</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>status</td>
        ///             <td>
        ///                 Search expenses by expense status.<br></br>Allowed Values:
        ///                 <i>unbilled, invoiced, reimbursed, non-billable</i> and <i>billable</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>account_name</td>
        ///             <td>
        ///                 Search expenses by expense account name.<br></br>Variants: <i>account_name_startswith</i> and
        ///                 <i>account_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>amount</td>
        ///             <td>
        ///                 Search expenses by amount.<br></br>Variants:
        ///                 <i>amount_less_than, amount_less_equals, amount_greater_than</i> and <i>amount_greater_equals</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>customer_name</td>
        ///             <td>
        ///                 Search expenses by customer name.<br></br>Variants: <i>customer_name_startswith</i> and
        ///                 <i>customer_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>vendor_name</td>
        ///             <td>
        ///                 Search expenses by vendor name.<br></br>Variants: <i>vendor_name_startswith</i> and
        ///                 <i>vendor_name_contains</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>customer_id</td><td>Search expenses by customer id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>vendor_id</td><td>Search expenses by vendor id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>recurring_expense_id</td><td>Search expenses by recurring expense id.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>paid_through_account_id</td><td>Search expenses by paid through account id.</td>
        ///         </tr>
        ///         <tr>
        ///             filter_by<td></td>
        ///             <td>
        ///                 Filter expenses by expense status.<br></br>Allowed Values:
        ///                 <i>Status.All, Status.Billable, Status.Nonbillable, Status.Reimbursed, Status.Invoiced</i> and
        ///                 <i>Status.Unbilled</i>
        ///             </td>
        ///         </tr>
        ///         <tr>
        ///             <td>search_text</td>
        ///             <td>Search expenses by category name or description or customer name or vendor name.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>sort_column</td>
        ///             <td>
        ///                 ort expenses.<br></br>Allowed Values:
        ///                 <i>
        ///                     date, account_name, paid_through_account_name, total, bcy_total, reference_number, customer_name,
        ///                     vendor_name
        ///                 </i>
        ///                 and <i>created_time</i>
        ///             </td>
        ///         </tr>
        ///     </table>
        /// </param>
        /// <returns>ExpenseList object.</returns>
        public ExpenseList GetExpenses(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return ExpenseParser.getExpenseList(responce);
        }

        /// <summary>
        ///     Get the details of an expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <returns>Expense object.</returns>
        public Expense Get(string expense_id)
        {
            var url = baseAddress + "/" + expense_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return ExpenseParser.getExpense(responce);
        }

        /// <summary>
        ///     Create a billable or non-billable expense.
        /// </summary>
        /// <param name="new_expense">
        ///     The new_expense is the Expense object which contains the new expense information with
        ///     account_id and amount as mandatory attributes.
        /// </param>
        /// <param name="receipt_path">
        ///     The receipt_path is the path of the file which is going to be attaches as a receipt to the
        ///     expense.
        /// </param>
        /// <returns>Expense object.</returns>
        public Expense Create(Expense new_expense, string receipt_path)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(new_expense);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var attachments = new[] {receipt_path};
            var file = new KeyValuePair<string, string[]>("receipt", attachments);
            var responce = ZohoHttpClient.post(url, getQueryParameters(), jsonstring, file);
            return ExpenseParser.getExpense(responce);
        }

        /// <summary>
        ///     Update an existing expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <param name="update_info">The update_info is the Expense object which contains the update information.</param>
        /// <param name="receipt_path">
        ///     The receipt_path is the path of the file which is going to be attaches as a receipt to the
        ///     expense.
        /// </param>
        /// <returns>Expense object.</returns>
        public Expense Update(string expense_id, Expense update_info, string receipt_path)
        {
            var url = baseAddress + "/" + expense_id;

            var file = new KeyValuePair<string, string>("receipt", receipt_path);
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(), jsonstring, file);
            return ExpenseParser.getExpense(responce);
        }

        /// <summary>
        ///     Deletes an existing expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <returns>System.String.<br></br>The success message is "The expense has been deleted."</returns>
        public string Delete(string expense_id)
        {
            var url = baseAddress + "/" + expense_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return ExpenseParser.getMessage(responce);
        }

        /// <summary>
        ///     Get history and comments of an expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <returns>List of Comment object.</returns>
        public CommentList GetComments(string expense_id)
        {
            var url = baseAddress + "/" + expense_id + "/comments";
            ;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return CreditNoteParser.getCommentList(responce);
        }

//---------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Returns the receipt attached to the expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <param name="parameters">
        ///     The parameters is the dictionary object which contains the preview(bool value) parameter as a
        ///     key,value pair.
        /// </param>
        /// <returns>System.String.<br></br>The success message is "the selected expense receipt is saved at home directory"</returns>
        public string GetReceipt(string expense_id, Dictionary<object, object> parameters)
        {
            var url = baseAddress + "/" + expense_id + "/receipt";
            ZohoHttpClient.getFile(url, getQueryParameters(parameters));
            return "the selected expense receipt is saved at home directory";
        }

        /// <summary>
        ///     Attach a receipt to an expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <param name="receipt_path">
        ///     The receipt_path is the path of the file which is going to be attaches as a receipt to the
        ///     expense.
        /// </param>
        /// <returns>System.String.<br></br>The success message is "The expense receipt has been attached."</returns>
        public string AddReceipt(string expense_id, string receipt_path)
        {
            var url = baseAddress + "/" + expense_id + "/receipt";
            var attachments = new[] {receipt_path};
            var file = new KeyValuePair<string, string[]>("receipt", attachments);
            var responce = ZohoHttpClient.post(url, getQueryParameters(), null, file);
            return ExpenseParser.getMessage(responce);
        }

        /// <summary>
        ///     Deletes the receipt attached to the expense.
        /// </summary>
        /// <param name="expense_id">The expense_id is the identifier of the expense.</param>
        /// <returns>System.String.<br></br>The success message is "The attached expense receipt has been deleted."</returns>
        public string DeleteReceipt(string expense_id)
        {
            var url = baseAddress + "/" + expense_id + "/receipt";
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return ExpenseParser.getMessage(responce);
        }
    }
}