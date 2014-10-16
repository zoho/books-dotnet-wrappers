using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace InvoiceSettingsApitest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organisation id}");
                var invoiceSettingsApi = service.GetSettingsApi();
                var invoiceSettings = invoiceSettingsApi.GetInvoiceSettings();
                Console.WriteLine("auto_generate:{0},\nis_sales_person_required:{1},\nis_shipping_charge_required:{2},\nnotes:{3}", invoiceSettings.auto_generate, invoiceSettings.is_sales_person_required, invoiceSettings.is_shipping_charge_required, invoiceSettings.notes);
                var updateInfo = new InvoiceSettings()
                {
                    auto_generate=false,
                    notes="from hari"
                };
                var updatedSettings = invoiceSettingsApi.UpdateInvoiceSettings(updateInfo);
                Console.WriteLine("auto_generate:{0},\nis_sales_person_required:{1},\nis_shipping_charge_required:{2},\nnotes:{3}", updatedSettings.auto_generate, updatedSettings.is_sales_person_required, updatedSettings.is_shipping_charge_required, updatedSettings.notes);
                var notesAndTerms = invoiceSettingsApi.GetInvoiceNotesAndTerms();
                Console.WriteLine("notes:{0}\nterms:{1}", notesAndTerms.notes, notesAndTerms.terms);
                var updatedInfo = new NotesAndTerms()
                {
                    notes="Thanking for business",
                    terms="terms"
                };
                var updated = invoiceSettingsApi.UpdateInvoiceNotesAndTerms(updatedInfo);
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
