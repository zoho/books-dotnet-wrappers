using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace CreditnoteSettingsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var creditnoteSettingsApi = service.GetSettingsApi();
                var creditnoteSettings = creditnoteSettingsApi.GetCreditnoteSettings();
                Console.WriteLine("prefix:{0},\nreferencetxt:{1},\nnotes:{2}", creditnoteSettings.prefix_string, creditnoteSettings.reference_text, creditnoteSettings.notes);
                var updateInfo = new CreditNoteSettings()
                {
                    prefix_string="cn",
                    reference_text="hari"
                };
                var updatedSettings = creditnoteSettingsApi.UpdateCreditnoteSettings(updateInfo);
                Console.WriteLine("prefix:{0},\nreferencetxt:{1},\nnotes:{2}", updatedSettings.prefix_string, updatedSettings.reference_text, updatedSettings.notes);
                var notesAndTerms = creditnoteSettingsApi.GetCreditnoteNotesAndTerms();
                Console.WriteLine("notes:{0}\nterms:{1}", notesAndTerms.notes, notesAndTerms.terms);
                var updatedInfo = new NotesAndTerms()
                {
                    notes = "Thanking for business",
                    terms = "terms"
                };
                var updated = creditnoteSettingsApi.UpdateCreditnoteNotesAndTerms(updatedInfo);
                Console.WriteLine("notes:{0}\nterms:{1}", updated.notes, updated.terms);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
