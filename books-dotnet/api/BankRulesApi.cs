using System.Collections.Generic;
using Newtonsoft.Json;
using zohobooks.model;
using zohobooks.parser;
using zohobooks.util;

namespace zohobooks.api
{
    /// <summary>
    ///     Class BankRulesApi is used to get or todefine the bank rules to the bank accounts.
    ///     This Api is used to get <br>The bank rules list</br><br>The details of the specified Rule</br>
    ///     It is used to either update or delete the specified Bank Rule
    /// </summary>
    public class BankRulesApi : Api
    {
        private static readonly string baseAddress = baseurl + "/bankaccounts/rules";

        /// <summary>
        ///     Initializes a new instance of the <see cref="BankRulesApi" /> class.
        /// </summary>
        /// <param name="auth_token">The auth_token is used for the authentication purpose.</param>
        /// <param name="organization_Id">The organization_ identifier is used to define the current working organisation.</param>
        public BankRulesApi(string auth_token, string organization_Id)
            : base(auth_token, organization_Id)
        {
        }

        /// <summary>
        ///     Fetch all the rules created for a specified bank or credit card account.
        /// </summary>
        /// <param name="parameters">The parameters is the query parameters which is having account_id as a mandatory parameter.</param>
        /// <returns>RuleList object.</returns>
        public RuleList GetRules(Dictionary<object, object> parameters)
        {
            var url = baseAddress;
            var responce = ZohoHttpClient.get(url, getQueryParameters(parameters));
            return BankRuleParser.getRuleList(responce);
        }

        /// <summary>
        ///     Gets the details of a specific rule.
        /// </summary>
        /// <param name="rule_id">The rule_id is the identifier of the rule which we are going to get the details.</param>
        /// <returns>Rule object.</returns>
        public Rule Get(string rule_id)
        {
            var url = baseAddress + "/" + rule_id;
            var responce = ZohoHttpClient.get(url, getQueryParameters());
            return BankRuleParser.getRule(responce);
        }

        /// <summary>
        ///     Creates a rule and apply it on deposit/withdrawal for bank accounts and on refund/charges for credit card accounts.
        /// </summary>
        /// <param name="rule_info">
        ///     The rule_info is the rule object which contains the
        ///     rule_name,target_account_id,apply_to,criteria_type,field,comparator and record_as parameters as the mandatory.
        ///     <br></br>
        ///     The allowed values for apply_to are <i>withdrawals, deposits, refunds</i> and <i>charges</i>.<br></br>
        ///     The allowed values for criteria_type are <i>or </i> and <i>and</i>.<br></br>
        ///     The allowed values for field<i>payee, description, reference_number</i> and <i>amount</i>.<br></br>
        ///     The allowed values for comparator are
        ///     <i>is, contains, starts_with, is_empty, greater_than, greater_than_or_equals, less_than</i>and
        ///     <i>less_than_or_equals</i>.<br></br>
        ///     The allowed values for record_as are
        ///     <i>
        ///         expense, deposit, refund, transfer_fund, card_payment, sales_without_invoices, expense_refund, interest_income,
        ///         other_income
        ///     </i>
        ///     and <i>owner_drawings</i>
        /// </param>
        /// <returns>Rule object.</returns>
        public Rule Create(Rule rule_info)
        {
            var url = baseAddress;
            var json = JsonConvert.SerializeObject(rule_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.post(url, getQueryParameters(jsonstring));
            return BankRuleParser.getRule(responce);
        }

        /// <summary>
        ///     Makes changes to the rule by adding,deleting or modifying the properties.
        /// </summary>
        /// <param name="rule_id">The rule_id is the rule identifier on which the updation has to be done.</param>
        /// <param name="update_info">The update_info is the rule object which is having the required updation properties.</param>
        /// <returns>Rule object.</returns>
        public Rule Update(string rule_id, Rule update_info)
        {
            var url = baseAddress + "/" + rule_id;
            var json = JsonConvert.SerializeObject(update_info);
            var jsonstring = new Dictionary<object, object>();
            jsonstring.Add("JSONString", json);
            var responce = ZohoHttpClient.put(url, getQueryParameters(jsonstring));
            return BankRuleParser.getRule(responce);
        }

        /// <summary>
        ///     Deletes the rule from the account such that the rule will be nolonger applicable on transactions.
        /// </summary>
        /// <param name="rule_id">The rule_id is the rule identifer which we are going to be delete.</param>
        /// <returns>
        ///     System.String.
        ///     The success message is "The rule has been deleted."
        /// </returns>
        public string Delete(string rule_id)
        {
            var url = baseAddress + "/" + rule_id;
            var responce = ZohoHttpClient.delete(url, getQueryParameters());
            return BankRuleParser.getMessage(responce);
        }
    }
}