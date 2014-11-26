using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace JournalsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var journalsApi = service.GetJournalsApi();
                var parameters = new Dictionary<object, object>();
                parameters.Add("filter_by", "JournalDate.All");
                Console.WriteLine("---------------Journals List--------------------");
                var journalsList = journalsApi.GetJournals(parameters);
                var journals = journalsList;
                
                foreach(var journal in journals)
                {
                    Console.WriteLine("{0},{1},{2}",journal.journal_id,journal.notes,journal.total);
                }
                var journalId = journals[0].journal_id;
                var accountsApi = service.GetChartOfAccountsApi();
                var accountId = accountsApi.GetChartOfAcounts(null)[0].account_id;
                Console.WriteLine("---------------Specified Journal--------------------");
                var journal1 = journalsApi.Get(journalId);
                Console.WriteLine("{0},{1},{2}", journal1.journal_id, journal1.notes, journal1.total);
                var lineitems = journal1.line_items;
                foreach(var lineitem in lineitems)
                {
                    Console.WriteLine("{0},{1},{2}",lineitem.account_id,lineitem.amount,lineitem.line_id);
                }
                var newJournalInfo = new Journal()
                {
                    journal_date="2014-02-10",
                    line_items = new List<LineItem>()
                    {
                        new LineItem(){
                            account_id=accountId,
                            debit_or_credit="credit",
                            amount=150
                        },
                        new LineItem(){
                            account_id=accountId,
                            debit_or_credit="debit",
                            amount=150
                        }
                    }
                };

                Console.WriteLine("---------------New Journal--------------------");
                var newJournal = journalsApi.Create(newJournalInfo);
                Console.WriteLine("{0},{1},{2}", newJournal.journal_id, newJournal.notes, newJournal.total);
                var lineitems1 = newJournal.line_items;
                foreach (var lineitem in lineitems1)
                {
                    Console.WriteLine("{0},{1},{2}", lineitem.account_id, lineitem.amount, lineitem.line_id);
                }
                var updateInfo = new Journal()
                {
                    journal_date = "2014-11-10",
                    line_items = new List<LineItem>()
                    {
                        new LineItem(){
                            account_id=accountId,
                            debit_or_credit="debit",
                            amount=130
                        },
                        new LineItem(){
                            account_id=accountId,
                            debit_or_credit="credit",
                            amount=130
                        }
                    },
                   notes="hari"
                };
                Console.WriteLine("---------------Updated Journal--------------------");
                var updatedJournal = journalsApi.Update(newJournal.journal_id, updateInfo);
                Console.WriteLine("{0},{1},{2}", updatedJournal.journal_id, updatedJournal.notes, updatedJournal.total);
                Console.WriteLine("---------------Delete Journal--------------------");
                var deljournal = journalsApi.Delete(updatedJournal.journal_id);
                Console.WriteLine(deljournal);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
