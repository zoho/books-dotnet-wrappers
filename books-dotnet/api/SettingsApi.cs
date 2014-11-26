using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using zohobooks.util;
using zohobooks.model;
using zohobooks.parser;

namespace zohobooks.api
{
    /// <summary>
    /// Class SettingsApi is used to <br></br>
    /// Get and update the preference and to create or delete the unit,<br></br>
    /// Get the invoice,estimate and creditnote settings and their notes and terms,<br></br>
    /// Get the list of currencies,exchange rates,taxes,auto and manual reminders,<br></br>
    /// Get and update the details of the specified currency,tax,exchange rate,taxgroup,opening balence and an auto and manual reminder,<br></br>
    /// Create a cuurency,exchange rate,tax and tax group and opening balence.
    /// Enable or disable auto reminders,
    /// Update the details of invoice,estimate and creditnote settings and their notes and terms,<br></br>
    /// delete the existing currency,exchange rate, tax, tax group, opening balence.<br></br>
    /// </summary>
    public class SettingsApi:Api
    {
        /// <summary>
        /// The base address
        /// </summary>
        static string baseAddress = baseurl + "/settings";
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ id is used to define the current working organisation.</param>
        public SettingsApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {

        }

        /// <summary>
        /// List of preferences that are configured.
        /// </summary>
        /// <returns>Preferences object.</returns>
        public Preferences GetPreferences()
        {
            string url = baseAddress + "/preferences";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            
            return SettingsParser.getPreferences(response);
        }

        /// <summary>
        /// Update the preferences that has been configured.
        /// </summary>
        /// <param name="update_info">The update_info is the Preferences object which contains the updation information.</param>
        /// <returns>System.String.<br></br>The success message is "Preferences have been saved."</returns>
        public Preferences UpdatePreferences(Preferences update_info)
        {
            string url = baseAddress + "/preferences";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getPreferences(response);
        }

        /// <summary>
        /// Create a unit the can be associated to a line item.
        /// </summary>
        /// <param name="new_unit">The new_unit is the Unit object with unit* as mandatory attribute.</param>
        /// <returns>System.String.<br></br>The success message is "Unit added."</returns>
        public string CreateUnit(Unit new_unit)
        {
            string url = baseAddress + "/units";
            var json = JsonConvert.SerializeObject(new_unit);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Delete a unit that has been associated to an item.
        /// </summary>
        /// <param name="unit_id">The unit_id.</param>
        /// <returns>System.String.<br></br>The success message is "You have successfully deleted the unit."</returns>
        public string DeleteUnit(string unit_id)
        {
            string url = baseAddress + "/units/"+unit_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }
        //----------------------------------Invoice Settings--------------------------

        /// <summary>
        /// Get the details of invoice settings.
        /// </summary>
        /// <returns>InvoiceSettings object.</returns>
        public InvoiceSettings GetInvoiceSettings()
        {
            string url = baseAddress + "/invoices";
            var queryParameters = new Dictionary<object, object>();
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return InvoiceSettingsParser.getInvoiceSettings(response);
        }

        /// <summary>
        /// Update the settings information for invoices.
        /// </summary>
        /// <param name="update_info">The update_info is the InvoiceSettings object which is having the settings updation information.</param>
        /// <returns>InvoiceSettings object.</returns>
        public InvoiceSettings UpdateInvoiceSettings(InvoiceSettings update_info)
        {
            string url = baseAddress + "/invoices";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return InvoiceSettingsParser.getInvoiceSettings(response);
        }

        /// <summary>
        /// Get the details of invoice notes and terms.
        /// </summary>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms GetInvoiceNotesAndTerms()
        {
            string url = baseAddress + "/invoices/notesandterms";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getNotesAndTerms(response);
        }

        /// <summary>
        /// Updates the invoice notes and terms.
        /// </summary>
        /// <param name="update_info">The update_info is the NotesAndTerms object which contains the invoice notes and terms updation information.</param>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms UpdateInvoiceNotesAndTerms(NotesAndTerms update_info)
        {
            string url = baseAddress + "/invoices/notesandterms";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getNotesAndTerms(response);
        }
        //-----------------------------------------------------------------------------

        //----------------------------EstimateSettings----------------------------------

        /// <summary>
        /// Get the details of estimate settings.
        /// </summary>
        /// <returns>EstimateSettings object.</returns>
        public EstimateSettings GetEstimateSettings()
        {
            string url = baseAddress + "/estimates";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return EstimateSettingsParser.getEstimateSettings(response);
        }

        /// <summary>
        /// Update the settings that are configured for estimates.
        /// </summary>
        /// <param name="update_info">The update_info is the EstimateSettings object which contains the settings upadation information.</param>
        /// <returns>EstimateSettings object.</returns>
        public EstimateSettings UpdateEstimateSettings(EstimateSettings update_info)
        {
            string url = baseAddress + "/estimates";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return EstimateSettingsParser.getEstimateSettings(response);
        }

        /// <summary>
        /// Get the details of estimate notes and terms.
        /// </summary>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms GetEstimateNotesAndTerms()
        {
            string url = baseAddress + "/estimates/notesandterms";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getNotesAndTerms(response);
        }

        /// <summary>
        /// Update the details of the estimate notes and terms.
        /// </summary>
        /// <param name="update_info">The update_info is the NotesAndTerms object which contains the updation information.</param>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms UpdateEstimateNotesAndTerms(NotesAndTerms update_info)
        {
            string url = baseAddress + "/estimates/notesandterms";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getNotesAndTerms(response);
        }
        //------------------------------------------------------------------------------

        //-------------------------Creditnote Settings----------------------------------

        /// <summary>
        /// List of settings applied for creditnotes.
        /// </summary>
        /// <returns>CreditnoteSettings object.</returns>
        public CreditNoteSettings GetCreditnoteSettings()
        {
            string url = baseAddress + "/creditnotes";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return CreditnoteSettingsParser.getCreditNoteSettings(response);
        }

        /// <summary>
        /// Update the settings associated to creditnotes.
        /// </summary>
        /// <param name="update_info">The update_info is the CreditnoteSettings object which is having the settings updation information.</param>
        /// <returns>CreditnoteSettings object.</returns>
        public CreditNoteSettings UpdateCreditnoteSettings(CreditNoteSettings update_info)
        {
            string url = baseAddress + "/creditnotes";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CreditnoteSettingsParser.getCreditNoteSettings(response);
        }

        /// <summary>
        /// Get the contents of creditnote notes and terms.
        /// </summary>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms GetCreditnoteNotesAndTerms()
        {
            string url = baseAddress + "/creditnotes/notesandterms";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getNotesAndTerms(response);
        }

        /// <summary>
        /// Update the notes and terms field for creditnotes.
        /// </summary>
        /// <param name="update_info">The update_info is the NotesAndTerms object which contains the updation information.</param>
        /// <returns>NotesAndTerms object.</returns>
        public NotesAndTerms UpdateCreditnoteNotesAndTerms(NotesAndTerms update_info)
        {
            string url = baseAddress + "/creditnotes/notesandterms";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getNotesAndTerms(response);
        }
        //-------------------------------------------------------------------------------

        /// <summary>
        /// List of configured currencies with pagination.
        /// </summary>
        /// <param name="parameters">The parameters is the Dictionary object which conrains the filters in the form of key,value pair to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table><tr><td>filter_by</td><td>Filter list of configured currencies excluding the base currency<br></br>Allowed Values: <i>Currencies.ExcludeBaseCurrency</i></td></tr></table></param>
        /// <returns>CurrenciesList object.</returns>
        public CurrencyList GetCurrencies(Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/currencies";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return CurrencyParser.getCurrencyList(response);
        }

        /// <summary>
        /// Get the details of a currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <returns>Currency object.</returns>
        public Currency GetACurrency(string currency_id)
        {
            string url = baseAddress + "/currencies/" + currency_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return CurrencyParser.getCurrency(response);
        }

        /// <summary>
        /// Creates a currency for transactions.
        /// </summary>
        /// <param name="new_currency_info">The new_currency_info is the currency info with the currency_code,currency_symbol and currency_format as the mandatory attributes.</param>
        /// <returns>Currency object.</returns>
        public Currency CreateCurrency(Currency new_currency_info)
        {
            string url = baseAddress + "/currencies";
            var json = JsonConvert.SerializeObject(new_currency_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CurrencyParser.getCurrency(response);
        }

        /// <summary>
        /// Update the details of a currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <param name="update_info">The update_info is the currency object which contains the updation information.</param>
        /// <returns>Currency object.</returns>
        public Currency UpdateCurrency(string currency_id, Currency update_info)
        {
            string url = baseAddress + "/currencies/" + currency_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CurrencyParser.getCurrency(response);
        }

        /// <summary>
        /// Delete a currency. Currency that is associated to transactions cannot be deleted.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <returns>System.String.<br></br>The success message is "The currency has been deleted."</returns>
        public string DeleteCurrency(string currency_id)
        {
            string url = baseAddress + "/currencies/" + currency_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// List of exchange rates configured for the currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency which is configuered with the exchange rates.</param>
        /// <param name="parameters">The parameters is the Dictionary object which conrains the filters in the form of key,value pair to refine the list.<br></br>The possible filters are listed below<br></br>
        /// <table>
        /// <tr><td>from_date</td><td>Returns the exchange rate details from the given date or from previous closest match in the absence of the exchange rate on the given date.</td></tr>
        /// <tr><td>is_current_date</td><td>To return the exchange rate only if available for current date.</td></tr>
        /// </table></param>
        /// <returns>List of ExchangeRate objects.</returns>
        public ExchangeRateList GetExchangeRates(string currency_id, Dictionary<object, object> parameters)
        {
            string url = baseAddress + "/currencies/" + currency_id + "/exchangerates";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return CurrencyParser.getExchangeRateList(response);
        }

        /// <summary>
        /// Get the details of an exchange rate that has been associated to the currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <param name="exchange_rate_id">The exchange_rate_id is the exchange rate identifier which associated with the specified currency.</param>
        /// <returns>ExchangeRate object.</returns>
        public ExchangeRate GetAnExchangeRate(string currency_id, string exchange_rate_id)
        {
            string url = baseAddress + "/currencies/" + currency_id + "/exchangerates/" + exchange_rate_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return CurrencyParser.getExchangeRate(response);
        }

        /// <summary>
        /// Create an exchange rate for the specified currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <param name="new_exchange_rate_info">The new_exchange_rate_info is the ExchangeRate object with effective_date and rate as mandatory attributes.</param>
        /// <returns>ExchangeRate object.</returns>
        public ExchangeRate CreateAnExchangeRate(string currency_id, ExchangeRate new_exchange_rate_info)
        {
            string url = baseAddress + "/currencies/" + currency_id + "/exchangerates";
            var json = JsonConvert.SerializeObject(new_exchange_rate_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return CurrencyParser.getExchangeRate(response);
        }

        /// <summary>
        /// Update the details of exchange rate for a currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <param name="exchange_rate_id">The exchange_rate_id is the identifier of the exchange rate which is configured for the specified currency.</param>
        /// <param name="update_info">The update_info is the ExchangeRate object which contains the updation information.</param>
        /// <returns>ExchangeRate object.</returns>
        public ExchangeRate UpdateAnExchangeRate(string currency_id, string exchange_rate_id, ExchangeRate update_info)
        {
            string url = baseAddress + "/currencies/" + currency_id + "/exchangerates/" + exchange_rate_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return CurrencyParser.getExchangeRate(response);
        }

        /// <summary>
        /// Delete an exchange rate for the specified currency.
        /// </summary>
        /// <param name="currency_id">The currency_id is the identifier of the currency.</param>
        /// <param name="exchange_rate_id">The exchange_rate_id is the identifier of the exchange rate which is configured for the specified currency.</param>
        /// <returns>System.String.<br></br>The success message is "Exchange rate successfully deleted"</returns>
        public string DeleteAnExchangeRate(string currency_id, string exchange_rate_id)
        {
            string url = baseAddress + "/currencies/" + currency_id + "/exchangerates/" + exchange_rate_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }
        //-------------------------------------------------------------------------------

        /// <summary>
        /// List of simple tax, compound tax and tax groups with pagination.
        /// </summary>
        /// <returns>TaxesList object.</returns>
        public TaxList GetTaxes()
        {
            string url = baseAddress+"/taxes";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxList(response);
        }

        /// <summary>
        /// Get the details of a simple tax, compound tax or tax group.
        /// </summary>
        /// <param name="tax_id">The tax_id is the identifier of the tax.</param>
        /// <returns>Tax object.</returns>
        public Tax GetTax(string tax_id)
        {
            string url = baseAddress+"/taxes/"+tax_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTax(response);
        }

        /// <summary>
        /// Create a simple or compound tax that can be associated with an item.
        /// </summary>
        /// <param name="new_tax_info">The new_tax_info is the Tax object with tax_name and tax_percentage as mandatory attributes.</param>
        /// <returns>Tax object.</returns>
        public Tax CreateTax(Tax new_tax_info)
        {
            string url = baseAddress + "/taxes";
            var json = JsonConvert.SerializeObject(new_tax_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return SettingsParser.getTax(response);
        }

        /// <summary>
        /// Update the details of a simple or compound tax.
        /// </summary>
        /// <param name="tax_id">The tax_id is the identifier of the tax.</param>
        /// <param name="update_info">The update_info is the Tax object which contains the updation information.</param>
        /// <returns>Tax.</returns>
        public Tax UpdateTax(string tax_id,Tax update_info)
        {
            string url = baseAddress + "/taxes/"+tax_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getTax(response);
        }

        /// <summary>
        /// Delete a simple or compound tax.
        /// </summary>
        /// <param name="tax_id">The tax_id is the identifier of the tax.</param>
        /// <returns>System.String.<br></br>The success message is "The record has been deleted."</returns>
        public string DeleteTax(string tax_id)
        {
            string url = baseAddress + "/taxes/" + tax_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Gets the details of a tax group with associated taxes.
        /// </summary>
        /// <param name="tax_group_id">The tax_group_id is the identifier of the tax group.</param>
        /// <returns>TaxGroup object.</returns>
        public TaxGroup GetTaxGroup(string tax_group_id)
        {
            string url = baseAddress + "/taxgroups/" + tax_group_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxGroup(response);
        }

        /// <summary>
        /// Create a tax group associating multiple taxes.A tax group should contain minimum of 2 taxes.Only one compund tax can be associated to a tax group along with other taxes.
        /// </summary>
        /// <param name="new_tax_group_info">The new_tax_group_info is the TaxGroup object with tax_group_name,taxes are mandatory attributes.</param>
        /// <returns>TaxGroup object.</returns>
        public TaxGroup CreateTaxGroup(TaxGroupToCreate new_tax_group_info)
        {
            string url = baseAddress + "/taxgroups";
            var json = JsonConvert.SerializeObject(new_tax_group_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return SettingsParser.getTaxGroup(response);
        }

        /// <summary>
        /// Update the details of a tax group.
        /// </summary>
        /// <param name="tax_group_id">The tax_group_id is the identifier of the tax group.</param>
        /// <param name="update_info">The update_info is the TaxGroup .</param>
        /// <returns>System.String.<br></br>The success message is "Tax Group information has been saved."</returns>
        public TaxGroup UpdateTaxGroup(string tax_group_id,TaxGroupToCreate update_info)
        {
            string url = baseAddress + "/taxgroups/"+tax_group_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getTaxGroup(response);
        }

        /// <summary>
        /// Delete a created tax group.
        /// </summary>
        /// <param name="tax_group_id">The tax_group_id is the identifier of the tax group.</param>
        /// <returns>System.String.<br></br>The success message is "The tax group has been deleted."</returns>
        public string DeleteTaxGroup(string tax_group_id)
        {
            string url = baseAddress + "/taxgroups/" + tax_group_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Gets the tax authorites.
        /// </summary>
        /// <returns>TaxAuthorityList.</returns>
        public TaxAuthorityList GetTaxAuthorites()
        {
            string url = baseAddress + "/taxauthorities";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxAuthorityList(response);
        }

        /// <summary>
        /// Gets the tax authority.
        /// </summary>
        /// <param name="tax_authority_id">The tax_authority_id.</param>
        /// <returns>TaxAuthority.</returns>
        public TaxAuthority GetTaxAuthority(string tax_authority_id)
        {
            string url = baseAddress + "/taxauthorities/" + tax_authority_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxAuthority(response);
        }

        /// <summary>
        /// Updates the tax authority.
        /// </summary>
        /// <param name="tax_authority_id">The tax_authority_id.</param>
        /// <param name="update_tax_authoriry_info">The update_tax_authoriry_info.</param>
        /// <returns>TaxAuthority.</returns>
        public TaxAuthority UpdateTaxAuthority(string tax_authority_id,TaxAuthority update_tax_authoriry_info)
        {
            string url = baseAddress + "/taxauthorities/" + tax_authority_id;
            var json = JsonConvert.SerializeObject(update_tax_authoriry_info);
            var jsonParams = new Dictionary<object, object>();
            jsonParams.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonParams));
            return SettingsParser.getTaxAuthority(response);
        }

        /// <summary>
        /// Deletes the tax authority.
        /// </summary>
        /// <param name="tax_authority_id">The tax_authority_id.</param>
        /// <returns>System.String.</returns>
        public string DeleteTaxAuthority(string tax_authority_id)
        {
            string url = baseAddress + "/taxauthorities/" + tax_authority_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Gets the tax exemptions.
        /// </summary>
        /// <returns>TaxExemptionList.</returns>
        public TaxExemptionList GetTaxExemptions()
        {
            string url = baseAddress + "/taxexemptions";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxExemptionList(response);
        }

        /// <summary>
        /// Gets the tax exemption.
        /// </summary>
        /// <param name="tax_exemption_id">The tax_exemption_id.</param>
        /// <returns>TaxExemption.</returns>
        public TaxExemption GetTaxExemption(string tax_exemption_id)
        {
            string url = baseAddress + "/taxexemption/" + tax_exemption_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getTaxExemption(response);
        }

        /// <summary>
        /// Updates the tax exemption.
        /// </summary>
        /// <param name="tax_exemption_id">The tax_exemption_id.</param>
        /// <param name="update_info">The update_info.</param>
        /// <returns>TaxExemption.</returns>
        public TaxExemption UpdateTaxExemption(string tax_exemption_id,TaxExemption update_info)
        {
            string url = baseAddress + "/taxexemptions/" + tax_exemption_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonParams = new Dictionary<object, object>();
            jsonParams.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonParams));
            return SettingsParser.getTaxExemption(response);
        }

        /// <summary>
        /// Deletes the tax exemption.
        /// </summary>
        /// <param name="tax_exemption_id">The tax_exemption_id.</param>
        /// <returns>System.String.</returns>
        public string DeleteTaxExemption(string tax_exemption_id)
        {
            string url = baseAddress + "/taxexemptions/" + tax_exemption_id;
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        //----------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the opening balance.
        /// </summary>
        /// <returns>OpeningBalance object.</returns>
        public OpeningBalance GetOpeningBalance()
        {
            string url = baseAddress + "/openingbalances";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getOpeningBalance(response);
        }

        /// <summary>
        /// Creates opening balance with the given information.
        /// </summary>
        /// <param name="new_opening_balance_info">The new_opening_balance_info is the OpeningBalance object with date and debit_or_credit are mandatory attributes.</param>
        /// <returns>OpeningBalance object.</returns>
        public OpeningBalance CreateOpeningBalance(OpeningBalance new_opening_balance_info)
        {
            string url = baseAddress + "/openingbalances";
            var json = JsonConvert.SerializeObject(new_opening_balance_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return SettingsParser.getOpeningBalance(response);
        }

        /// <summary>
        /// Updates the existing opening balance information.
        /// </summary>
        /// <param name="update_info">The update_info is the OpeningBalance object which contains the updation information.</param>
        /// <returns>OpeningBalance object.</returns>
        public OpeningBalance UpdateOpeningBalance(OpeningBalance update_info)
        {
            string url = baseAddress + "/openingbalances";
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getOpeningBalance(response);
        }

        /// <summary>
        /// Delete the entered opening balance.
        /// </summary>
        /// <returns>System.String.<br></br>The success message is "The entered opening balance has been deleted."</returns>
        public string DeleteOpeningBalance()
        {
            string url = baseAddress + "/openingbalances";
            var response = ZohoHttpClient.delete(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        //---------------------------------------------------------------------------------------------


        /// <summary>
        /// List of automated payment reminders.
        /// </summary>
        /// <returns>List of AutoReminder object.</returns>
        public AutoReminderList GetAutoPaymentReminders()
        {
            string url = baseAddress + "/autoreminders";
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getAutoReminderList(response);
        }

        /// <summary>
        /// Get the details of an automated payment reminder.
        /// </summary>
        /// <param name="template_id">The template_id is the identifier of the template in which format it the reminder is going to send to the customer.</param>
        /// <returns>AutoReminderAndPlaceHolders object.</returns>
        public AutoReminderAndPlaceHolders GetAnAutoPaymentReminder(string template_id)
        {
            string url = baseAddress + "/autoreminders/"+template_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getAutoReminderAndPlaceHolders(response);
        }

        /// <summary>
        /// Enables an automated payment reminder.
        /// </summary>
        /// <param name="reminder_id">The reminder_id is the identifier of the auto reminder.</param>
        /// <returns>System.String.<br></br>The success message is "Payment reminder has been enabled."</returns>
        public string EnableAutoReminder(string reminder_id)
        {
            string url = baseAddress + "/autoreminders/" + reminder_id+"/enable";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Disable an automated payment reminder.
        /// </summary>
        /// <param name="reminder_id">The reminder_id is the identifier of the auto reminder.</param>
        /// <returns>System.String.<br></br>The success message is "Payment reminder has been disabled."</returns>
        public string DisableAutoReminder(string reminder_id)
        {
            string url = baseAddress + "/autoreminders/" + reminder_id + "/disable";
            var response = ZohoHttpClient.post(url, getQueryParameters());
            return SettingsParser.getMessage(response);
        }

        /// <summary>
        /// Update the details of an automated payment reminder.
        /// </summary>
        /// <param name="reminder_id">The reminder_id is the identifier of the auto reminder.</param>
        /// <param name="update_info">The update_info is the AutoReminder object which contains the updation details.</param>
        /// <returns>System.String.<br></br>The success message is "Your payment reminder preferences have been saved."</returns>
        public AutoReminder UpdateAnAutoReminder(string reminder_id,AutoReminder update_info)
        {
            string url = baseAddress + "/autoreminders/" + reminder_id ;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getAutoReminder(response);
        }

        /// <summary>
        /// List of manual reminders.
        /// </summary>
        /// <param name="parameters">The parameters is the dictionary object which contains the following filter in the form of key,value pair.<br></br>
        /// <table><tr><td>type</td><td>Type to select between open or overdue reminder.<br></br>Allowed Values: <i>overdue_reminder</i> and <i>open_reminder</i></td></tr></table></param>
        /// <returns>List of Manualreminder object.</returns>
        public ManualReminderList GetManualReminders(Dictionary<object,object> parameters)
        {
            string url = baseAddress + "/manualreminders";
            var response = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return SettingsParser.getManualReminderList(response);
        }

        /// <summary>
        /// Get the details of a manual reminder.
        /// </summary>
        /// <param name="reminder_id">The reminder_id is the identifier of the existing manual reminder.</param>
        /// <returns>ManualReminderAndPlaceHolders object.</returns>
        public ManualReminderAndPlaceHolders GetManualReminder(string reminder_id)
        {
            string url = baseAddress + "/manualreminders/"+reminder_id;
            var response = ZohoHttpClient.get(url, getQueryParameters());
            return SettingsParser.getManualReminderAndPlaceHolders(response);
        }

        /// <summary>
        /// Update the details of a manual reminder.
        /// </summary>
        /// <param name="reminder_id">The reminder_id is the identifier of the existing manual reminder.</param>
        /// <param name="update_info">The update_info is the Manualreminder object which contains the updation information.</param>
        /// <returns>System.String.<br></br>The success message is "Your payment reminder preferences have been saved."</returns>
        public ManualReminder UpdateManualReminder(string reminder_id,ManualReminder update_info)
        {
            string url = baseAddress + "/manualreminders/" + reminder_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var response = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return SettingsParser.getManualReminder(response);
        }
    }
}
