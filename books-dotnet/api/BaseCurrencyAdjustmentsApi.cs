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
using zohobooks.api;
using zohobooks.Parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class BaseCurrencyAdjustmentApi is used <br></br>Create the new base currency adjustments,<br></br>
    /// To get List of base currency adjustments <br></br>
    /// To get the detailed adjustment<br></br>
    /// To get the list of all account details for the base currency adjustment.<br></br>
    /// To delete the base currency adjustment.<br></br>
    /// </summary>
    public class BaseCurrencyAdjustmentsApi:Api
    {
        static string baseAddress =baseurl + "/basecurrencyadjustment";
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseCurrencyAdjustmentsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public BaseCurrencyAdjustmentsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// Gets the list of base currency adjustment.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which contains the filters to refine the list in the form of key,value pairs.<br></br>the possible filter keys and the values are listed below
        /// <table>
        /// <tr><td>filter_by</td><td>Filter base currency adjustment list.<br></br>Allowed Values: <i>Date.All, Date.Today, Date.ThisWeek, Date.ThisMonth, Date.ThisQuarter</i> and <i>Date.ThisYear</i></td></tr>
        /// <tr><td>sort_column</td><td>Sort base currency adjustment list.<br></br>Allowed Values: <i>adjustment_date, exchange_rate, currency_code, debit_or_credit </i>and <i>gain_or_loss</i></td></tr>
        /// </table>
        /// </param>
        /// <returns>BaseCurrencyAdjustmentsList object.</returns>
        public BaseCurrencyAdjustmentsList GetBaseCurrencyAdjustments(Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BaseCurrencyAdjustmentParser.getBaseCurrencyAdjustmentList(responce);
        }
        /// <summary>
        /// Gets the specified base currency adjustment details.
        /// </summary>
        /// <param name="base_currency_adjustment_id">The base_currency_adjustment_id is the identifier of the base currency adjustment.</param>
        /// <returns>BaseCurrencyAdjustment object.</returns>
        public BaseCurrencyAdjustment Get(string base_currency_adjustment_id)
        {
            string url = baseAddress + "/" + base_currency_adjustment_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BaseCurrencyAdjustmentParser.getBaseCurrencyAdjustment(responce);
        }
        /// <summary>
        /// List the accounts having transaction with effect to the given exchange rate.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object to refine the accounts list by passing the filters as key,value pairs.<br></br>
        /// The following list shows the possible filter keys and the corespondent allowed values.<br></br>
        /// <table>
        /// <tr><td>currency_id</td><td>ID of currency for which we need to post adjustment.</td></tr>
        /// <tr><td>adjustment_date</td><td>Date of adjustment.</td></tr>
        /// <tr><td>exchange_rate</td><td>Exchange rate of the currency.</td></tr>
        /// <tr><td>notes</td><td>Notes for the base currency adjustment.</td></tr>
        /// </table>
        /// </param>
        /// <returns>BaseCurrencyAdjustment object.</returns>
        public BaseCurrencyAdjustment GetBaseCurrencyAdjustmentAccounts(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/accounts";
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BaseCurrencyAdjustmentParser.getBaseCurrencyAdjustment(responce);
        }

        /// <summary>
        /// Creates the base currency adjustment for the specified information.
        /// </summary>
        /// <param name="new_base_currency_adjustment_info">The new_base_currency_adjustment_info is the BaseCurrencyAdjustment object which contains the currency_id,adjustment_date,exchange_rate and notes as mandatory parameters.</param>
        /// <param name="parameters">The parameters contains the following key value pair<br></br>
        /// <table>
        /// <tr><td>account_ids*</td><td>ID of the accounts for which base currency adjustments need to be posted.</td></tr>
        /// </table>
        /// </param>
        /// <returns>BaseCurrencyAdjustment.</returns>
        public BaseCurrencyAdjustment Create(BaseCurrencyAdjustment new_base_currency_adjustment_info, Dictionary<object, object> parameters)
        {
            string url = baseAddress;
            var json = JsonConvert.SerializeObject(new_base_currency_adjustment_info);
            parameters.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(parameters));
            return BaseCurrencyAdjustmentParser.getBaseCurrencyAdjustment(responce);
        }
        /// <summary>
        /// Deletes the base currency adjustment.
        /// </summary>
        /// <param name="base_currency_adjustment_id">The base_currency_adjustment_id is the identifier of the base currency adjustment which is going to be deleted.</param>
        /// <returns>System.String.<br></br>The success message is "The selected base currency adjustment has been deleted."</returns>
        public string Delete(string base_currency_adjustment_id)
        {
            string url = baseAddress + "/" + base_currency_adjustment_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BaseCurrencyAdjustmentParser.getMessage(responce);
        }
    }
}
