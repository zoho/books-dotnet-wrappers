using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.model;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;
using zohobooks.Util;
using zohobooks.Parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class JournalsApi is used to <br></br>
    ///     Create a new journal,<br></br>
    ///     Get the List of journal or details of the specified journal,<br></br>
    ///     Update the details of the journal,<br></br>
    ///     Delete the specified journal.<br></br>
    /// </summary>
    public class JournalsApi:Api
    {
        static string baseAddress = baseurl + "/journals";
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public JournalsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// Gets the journal list.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which contains the filters in the form of key,value pairs.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>entry_number</td><td>Search journals by journal entry number.<br></br>Variants: <i>entry_number_startswith</i> and <i>entry_number_contains</i></td></tr>
        /// <tr><td>reference_number</td><td>Search journals by journal reference number.<br></br>Variants: <i>reference_number_startswith</i> and <i>reference_number_contains</i></td></tr>
        /// <tr><td>date</td><td>Search journals by journal date.<br></br>Variants: <i>date_start, date_end, date_before</i> and <i>date_after</i></td></tr>
        /// <tr><td>notes</td><td>Search journals by journal notes.<br></br>Variants: <i>notes_startswith</i> and <i>notes_contains</i></td></tr>
        /// <tr><td>total</td><td>Search journals by journal total.<br></br>Variants: <i>total_less_than, total_less_equals, total_greater_than</i> and <i>total_greater_equals</i></td></tr>
        /// <tr><td>filter_by</td><td>Filter journals by journal date.<br></br>Allowed Values: <i>JournalDate.All, JournalDate.Today, JournalDate.ThisWeek, JournalDate.ThisMonth, JournalDate.ThisQuarter</i> and <i>JournalDate.ThisYear</i></td></tr>
        /// <tr><td>sort_column</td><td>Sort journal list.<br></br>Allowed Values: <i>journal_date, entry_number, reference_number</i> and <i>total</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>JournalsList object.</returns>
        public JournalList GetJournals(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return JournalParser.getJournalList(responce);
        }

        /// <summary>
        /// Gets the details of specified journal.
        /// </summary>
        /// <param name="journal_id">The journal_id is the identifier of the journal.</param>
        /// <returns>Journal object.</returns>
        public Journal Get(string journal_id)
        {
            string url = baseAddress+"/"+journal_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return JournalParser.getJournal(responce);
        }

        /// <summary>
        /// Creates a journal.
        /// </summary>
        /// <param name="new_journal_info">The new_journal_info is the Journal object with journal_date,amount,debit_or_credit as mandatory attributes.</param>
        /// <returns>Journal object.</returns>
        public Journal Create(Journal new_journal_info)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_journal_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return JournalParser.getJournal(responce);
        }

        /// <summary>
        /// Updates the journal with given information.
        /// </summary>
        /// <param name="journal_id">The journal_id is the identifier of the journal.</param>
        /// <param name="update_info">The update_info is the Journal object which contains the updation information of specifed journal.</param>
        /// <returns>Journal object.</returns>
        public Journal Update(string journal_id, Journal update_info)
        {
            string url = baseAddress + "/" + journal_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return JournalParser.getJournal(responce);
        }

        /// <summary>
        /// Deletes the specified journal.
        /// </summary>
        /// <param name="journal_id">The journal_id is the identifier of the journal.</param>
        /// <returns>System.String.<br></br>The success message is "The selected journal entry has been deleted."</returns>
        public string Delete(string journal_id)
        {
            string url = baseAddress + "/" + journal_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return JournalParser.getMessage(responce);
        }
    }
}
