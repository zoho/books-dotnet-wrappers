using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace EstimateSettingsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                var estimateSettingsApi = service.GetSettingsApi();
                var estimateSettings = estimateSettingsApi.GetEstimateSettings();
                Console.WriteLine("Auto Generarte:{0},\nIs salesperson Required:{1},\nNotes:{2}\n", estimateSettings.auto_generate, estimateSettings.is_sales_person_required, estimateSettings.notes);
                var updateInfo = new EstimateSettings()
                {
                    auto_generate=false,
                    discount_type = "no_discount",
                    is_sales_person_required=false
                };
                var updatedSettings = estimateSettingsApi.UpdateEstimateSettings(updateInfo);
                Console.WriteLine("Auto Generarte:{0},\nIs salesperson Required:{1},\nDiscount:{2}\n", updatedSettings.auto_generate, updatedSettings.is_sales_person_required, updatedSettings.discount_type);
                var notesAndTerms = estimateSettingsApi.GetEstimateNotesAndTerms();
                Console.WriteLine("notes:{0}\nterms:{1}", notesAndTerms.notes, notesAndTerms.terms);
                var updatedInfo = new NotesAndTerms()
                {
                    notes="Thanking for business",
                    terms="terms"
                };
                var updated = estimateSettingsApi.UpdateEstimateNotesAndTerms(updatedInfo);
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
