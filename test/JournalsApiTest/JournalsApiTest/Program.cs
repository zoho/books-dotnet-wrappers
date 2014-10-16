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
                var journalsList = journalsApi.GetJournals(parameters);
                var journals = journalsList;
                
                foreach(var journal in journals)
                {
                    Console.WriteLine("{0},{1},{2}",journal.journal_id,journal.notes,journal.total);
                }
                var journalId = journals[0].journal_id;
                var bankaccountsApi = service.GetBankAccountsApi();
                var parameters2 = new Dictionary<object, object>();
                var accountId = bankaccountsApi.GetBankAccounts(parameters2)[0].account_id;
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
                var newJournal = journalsApi.Create(newJournalInfo);
                Console.WriteLine("{0},{1},{2}", newJournal.journal_id, newJournal.notes, newJournal.total);
                var lineitems1 = newJournal.line_items;
                foreach (var lineitem in lineitems1)
                {
                    Console.WriteLine("{0},{1},{2}", lineitem.account_id, lineitem.amount, lineitem.line_id);
                }
                var updateInfo = new Journal()
                {
                    journal_date = "2014-02-10",
                    line_items = new List<LineItem>()
                    {
                        new LineItem(){
                            account_id=accountId,
                            debit_or_credit="credit",
                            amount=150
                        },
                        
                    },
                   notes="hari"
                };
                var updatedJournal = journalsApi.Update(journalId, updateInfo);
                Console.WriteLine("{0},{1},{2}", updatedJournal.journal_id, updatedJournal.notes, updatedJournal.total);
                var deljournal = journalsApi.Delete(journals[2].journal_id);
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
