using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of CreditnoteSettingsApi.
    /// </summary>
    internal class CreditnoteSettingsParser
    {
        internal static CreditNoteSettings getCreditNoteSettings(HttpResponseMessage response)
        {
            var creditNoteSettings = new CreditNoteSettings();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("creditnote_settings"))
                creditNoteSettings =
                    JsonConvert.DeserializeObject<CreditNoteSettings>(jsonObj["creditnote_settings"].ToString());
            return creditNoteSettings;
        }
    }
}