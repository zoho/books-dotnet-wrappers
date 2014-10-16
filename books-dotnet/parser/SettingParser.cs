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
    /// Used to define the parser object of SettingsApi.
    /// </summary>
    class SettingsParser
    {

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static Preferences getPreferences(HttpResponseMessage response)
        {
            var preferences = new Preferences();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("preferences"))
            {
                preferences = JsonConvert.DeserializeObject<Preferences>(jsonObj["preferences"].ToString());
            }
            return preferences;
        }

        internal static NotesAndTerms getNotesAndTerms(HttpResponseMessage response)
        {
            var notesAndTerms = new NotesAndTerms();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("notes_and_terms"))
            {
                notesAndTerms = JsonConvert.DeserializeObject<NotesAndTerms>(jsonObj["notes_and_terms"].ToString());
            }
            return notesAndTerms;
        }

        internal static TaxList getTaxList(HttpResponseMessage response)
        {
            var taxList = new TaxList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("taxes"))
            {
                var taxArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["taxes"].ToString());
                foreach(var taxObj in taxArray)
                {
                    var tax = new Tax();
                    tax = JsonConvert.DeserializeObject<Tax>(taxObj.ToString());
                    taxList.Add(tax);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                taxList.page_context = pageContext;
            }
            return taxList;
        }

        internal static Tax getTax(HttpResponseMessage response)
        {
            var tax = new Tax();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("tax"))
            {
                tax = JsonConvert.DeserializeObject<Tax>(jsonObj["tax"].ToString());
            }
            return tax;
        }

        internal static TaxGroup getTaxGroup(HttpResponseMessage response)
        {
            var taxgroup = new TaxGroup();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("tax_group"))
            {
                taxgroup = JsonConvert.DeserializeObject<TaxGroup>(jsonObj["tax_group"].ToString());
            }
            return taxgroup;
        }

        internal static OpeningBalance getOpeningBalance(HttpResponseMessage response)
        {
            var openingBalance = new OpeningBalance();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("opening_balance"))
            {
                openingBalance = JsonConvert.DeserializeObject<OpeningBalance>(jsonObj["opening_balance"].ToString());
            }
            return openingBalance;
        }

        internal static AutoReminderList getAutoReminderList(HttpResponseMessage response)
        {
            var reminderList = new AutoReminderList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("autoreminders"))
            {
                var reminderArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["autoreminders"].ToString());
                foreach(var reminderObj in reminderArray)
                {
                    var reminder = new AutoReminder();
                    reminder = JsonConvert.DeserializeObject<AutoReminder>(reminderObj.ToString());
                    reminderList.Add(reminder);
                }
            }
            return reminderList;
        }

        internal static AutoReminderAndPlaceHolders getAutoReminderAndPlaceHolders(HttpResponseMessage response)
        {
            var reminderAndPlaceHolders = new AutoReminderAndPlaceHolders();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("autoreminder"))
            {
                var reminder = new AutoReminder();
                reminder = JsonConvert.DeserializeObject<AutoReminder>(jsonObj["autoreminder"].ToString());
                reminderAndPlaceHolders.autoreminder = reminder;
            }
            if (jsonObj.ContainsKey("placeholders"))
            {
                var placeHolders = new PlaceHolders();
                placeHolders = JsonConvert.DeserializeObject<PlaceHolders>(jsonObj["placeholders"].ToString());
                reminderAndPlaceHolders.placeholders = placeHolders;
            }
            return reminderAndPlaceHolders;
        }

        internal static ManualReminderList getManualReminderList(HttpResponseMessage response)
        {
            var reminderList = new ManualReminderList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("manualreminders"))
            {
                var reminderArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["manualreminders"].ToString());
                foreach (var reminderObj in reminderArray)
                {
                    var reminder = new ManualReminder();
                    reminder = JsonConvert.DeserializeObject<ManualReminder>(reminderObj.ToString());
                    reminderList.Add(reminder);
                }
            }
            return reminderList;
        }

        internal static ManualReminderAndPlaceHolders getManualReminderAndPlaceHolders(HttpResponseMessage response)
        {
            var reminderAndPlaceHolders = new ManualReminderAndPlaceHolders();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("manualreminder"))
            {
                var reminder = new ManualReminder();
                reminder = JsonConvert.DeserializeObject<ManualReminder>(jsonObj["manualreminder"].ToString());
                reminderAndPlaceHolders.manualreminder = reminder;
            }
            if (jsonObj.ContainsKey("placeholders"))
            {
                var placeHolders = new PlaceHolders();
                placeHolders = JsonConvert.DeserializeObject<PlaceHolders>(jsonObj["placeholders"].ToString());
                reminderAndPlaceHolders.placeholders = placeHolders;
            }
            return reminderAndPlaceHolders;
        }
    }
}
