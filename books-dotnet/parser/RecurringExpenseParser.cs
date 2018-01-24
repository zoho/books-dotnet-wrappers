using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of RecurringExpensesApi.
    /// </summary>
    internal class RecurringExpenseParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static RecurringExpenseList getRecurringExpenseList(HttpResponseMessage responce)
        {
            var recExpList = new RecurringExpenseList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("recurring_expenses"))
            {
                var recExpArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["recurring_expenses"].ToString());
                foreach (var recExpObj in recExpArray)
                {
                    var recExp = new RecurringExpense();
                    recExp = JsonConvert.DeserializeObject<RecurringExpense>(recExpObj.ToString());
                    recExpList.Add(recExp);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                recExpList.page_context = pageContext;
            }
            return recExpList;
        }

        internal static RecurringExpense getRecurringExpense(HttpResponseMessage responce)
        {
            var recExp = new RecurringExpense();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("recurring_expense"))
                recExp = JsonConvert.DeserializeObject<RecurringExpense>(jsonObj["recurring_expense"].ToString());
            return recExp;
        }

        internal static ExpenseList getExpenseHistory(HttpResponseMessage responce)
        {
            var expenseList = new ExpenseList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("expensehistory"))
            {
                var expenseArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["expensehistory"].ToString());
                foreach (var expObj in expenseArray)
                {
                    var expense = new Expense();
                    expense = JsonConvert.DeserializeObject<Expense>(expObj.ToString());
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
    }
}