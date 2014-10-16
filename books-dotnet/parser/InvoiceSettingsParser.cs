using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.Parser
{
    /// <summary>
    /// Used to define the parser object of InvoiceSettingsApi.
    /// </summary>
    class InvoiceSettingsParser
    {
        
        internal static InvoiceSettings getInvoiceSettings(HttpResponseMessage response)
        {
            var invoiceSettings = new InvoiceSettings();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("invoice_settings"))
            {
                invoiceSettings = JsonConvert.DeserializeObject<InvoiceSettings>(jsonObj["invoice_settings"].ToString());
            }
            return invoiceSettings;
        }
    }
}
