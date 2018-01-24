using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of InvoiceSettingsApi.
    /// </summary>
    internal class InvoiceSettingsParser
    {
        internal static InvoiceSettings getInvoiceSettings(HttpResponseMessage response)
        {
            var invoiceSettings = new InvoiceSettings();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("invoice_settings"))
                invoiceSettings =
                    JsonConvert.DeserializeObject<InvoiceSettings>(jsonObj["invoice_settings"].ToString());
            return invoiceSettings;
        }
    }
}