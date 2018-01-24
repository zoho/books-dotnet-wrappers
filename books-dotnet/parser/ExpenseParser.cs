using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of ExpensesApi.
    /// </summary>
    internal class ExpenseParser
    {
        internal static ExpenseList getExpenseList(HttpResponseMessage responce)
        {
            var expenseList = new ExpenseList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("expenses"))
            {
                var expensesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["expenses"].ToString());
                foreach (var expenseObj in expensesArray)
                {
                    var expense = new Expense();
                    expense = JsonConvert.DeserializeObject<Expense>(expenseObj.ToString());
                    expenseList.Add(expense);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                expenseList.page_context = pageContext;
            }
            return expenseList;
        }

        internal static Expense getExpense(HttpResponseMessage responce)
        {
            var expense = new Expense();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("expense"))
                expense = JsonConvert.DeserializeObject<Expense>(jsonObj["expense"].ToString());
            return expense;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }
    }
}