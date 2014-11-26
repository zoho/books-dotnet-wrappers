using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace ExpensesApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organisation id}");
                var expensesApi = service.GetExpensesApi();
                var parameters2 = new Dictionary<object, object>();
                var expensesList = expensesApi.GetExpenses(parameters2);
                var expenses = expensesList;
                var expenseId = expenses[1].expense_id;
                var accountId = expenses[0].account_id;
                var paidAccId = expenses[0].paid_through_account_id;
                if (expenses != null)
                    foreach (var expense in expenses)
                        Console.WriteLine("{0},{1},{2}", expense.expense_id, expense.total, expense.account_name);
                var parameters = new Dictionary<object, object>();
                var receiptstr = expensesApi.GetReceipt(expenseId, parameters);
                Console.WriteLine(receiptstr);
                var delreceipt = expensesApi.DeleteReceipt(expenseId);
                Console.WriteLine(delreceipt);
                var addreceipt = expensesApi.AddReceipt(expenseId, @"attachment path");
                Console.WriteLine(addreceipt);

                var expense1 = expensesApi.Get(expenseId);
                Console.WriteLine("{0},{1},{2}", expense1.expense_id, expense1.total, expense1.account_name);
                var newExpenseInfo = new Expense()
                {
                    account_id = accountId,
                    paid_through_account_id = paidAccId,
                    amount = 24567.00
                };
                var newExpense = expensesApi.Create(newExpenseInfo, @"C:\Users\....\.png");
                if (newExpense != null)
                    Console.WriteLine("{0},{1},{2}", newExpense.expense_id, newExpense.total, newExpense.account_name);
                var updateInfo = new Expense
                {
                    amount = 2456
                };
                var updatedExpense = expensesApi.Update(expenseId, updateInfo, @"attachment path");
                if (updatedExpense != null)
                {
                    Console.WriteLine("{0},{1},{2}", updatedExpense.expense_id, updatedExpense.total, updatedExpense.account_name);
                }
                var delexpense = expensesApi.Delete(expenses[3].expense_id);
                Console.WriteLine(delexpense);
                var commentsList = expensesApi.GetComments(expenseId);
                var comments = commentsList;
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
