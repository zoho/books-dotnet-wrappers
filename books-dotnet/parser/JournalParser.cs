using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;

namespace zohobooks.parser
{
    /// <summary>
    ///     Used to define the parser object of JournalsApiParser.
    /// </summary>
    internal class JournalParser
    {
        internal static string getMessage(HttpResponseMessage responce)
        {
            var message = "";
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }

        internal static JournalList getJournalList(HttpResponseMessage responce)
        {
            var journalList = new JournalList();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("journals"))
            {
                var journalsArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["journals"].ToString());
                foreach (var journalObj in journalsArray)
                {
                    var journal = new Journal();
                    journal = JsonConvert.DeserializeObject<Journal>(journalObj.ToString());
                    journalList.Add(journal);
                }
            }
            if (jsonObj.ContainsKey("page_context"))
            {
                var pageContext = new PageContext();
                pageContext = JsonConvert.DeserializeObject<PageContext>(jsonObj["page_context"].ToString());
                journalList.page_context = pageContext;
            }
            return journalList;
        }

        internal static Journal getJournal(HttpResponseMessage responce)
        {
            var journal = new Journal();
            var jsonObj =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("journal"))
                journal = JsonConvert.DeserializeObject<Journal>(jsonObj["journal"].ToString());
            return journal;
        }
    }
}