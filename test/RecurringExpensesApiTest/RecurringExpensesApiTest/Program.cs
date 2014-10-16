using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace RecurringExpensesApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                RecurringExpensesApi recurringExpensesApi = service.GetRecurringExpensesApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("recurrence_name_startswith", "h");
                var recurringExpenses = recurringExpensesApi.GetRecurringExpenses(parameters);
                var recExpId = recurringExpenses[0].recurring_expense_id;
                if (recurringExpenses != null)
                    foreach (var recurringExpense in recurringExpenses)
                        Console.WriteLine("{0},{1},{2}", recurringExpense.account_name, recurringExpense.total, recurringExpense.recurrence_name);
                var recurringExpense1 = recurringExpensesApi.Get(recExpId);
                if (recurringExpense1 != null)
                    Console.WriteLine("{0},{1},{2}", recurringExpense1.account_name, recurringExpense1.total, recurringExpense1.recurrence_name);
                var newRecurringExpenseInfo = new RecurringExpense()
                {
                    account_id = "{account id}",
                    paid_through_account_id = "{account id from which going to pay}",
                    recurrence_name = "rec name",
                    start_date = "2014-02-03",
                    recurrence_frequency = "months",
                    repeat_every = 2,
                    amount = 1000,
                };
                var newRecurringExpense = recurringExpensesApi.Create(newRecurringExpenseInfo);
                if (newRecurringExpense != null)
                    Console.WriteLine("{0},{1},{2}", newRecurringExpense.account_name, newRecurringExpense.total, newRecurringExpense.recurrence_name);
                var updateInfo = new RecurringExpense()
                {
                    recurrence_frequency = "weeks",
                    repeat_every = 4,

                };
                var updatedExpense = recurringExpensesApi.Update(recExpId, updateInfo);
                if (updatedExpense != null)
                    Console.WriteLine("{0},{1},{2}", updatedExpense.account_name, updatedExpense.total, updatedExpense.recurrence_name);
                var delRecurringExpense = recurringExpensesApi.Delete(recurringExpenses[3].recurring_expense_id);
                Console.WriteLine(delRecurringExpense);
                var stopRecurringExpense = recurringExpensesApi.Stop(recExpId);
                Console.WriteLine(stopRecurringExpense);
                var resumeRecurringExpense = recurringExpensesApi.Resume(recExpId);
                Console.WriteLine(resumeRecurringExpense);
                var childExpenses = recurringExpensesApi.GetExpensesCreated(recExpId, parameters);
                if (childExpenses != null)
                    foreach (var childExpense in childExpenses)
                        Console.WriteLine("{0},{1},{2}", childExpense.account_name, childExpense.total, childExpense.date);
                var comments = recurringExpensesApi.GetComments(recExpId);
                if (comments != null)
                    foreach (var comment in comments)
                        Console.WriteLine("{0},{1},{2}", comment.comment_id, comment.description, comment.commented_by);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
