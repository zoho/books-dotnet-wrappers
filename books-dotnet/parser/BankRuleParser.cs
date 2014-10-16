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
    /// Used to define the parser object of BankRulesApi.
    /// </summary>
    class BankRuleParser
    {
        internal static RuleList getRuleList(HttpResponseMessage responce)
        {
            var ruleList = new RuleList();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if(jsonObj.ContainsKey("rules"))
            {
                var rulesArray = JsonConvert.DeserializeObject<List<object>>(jsonObj["rules"].ToString());
                foreach(var ruleObj in rulesArray)
                {
                    var rule = new Rule();
                    rule = JsonConvert.DeserializeObject<Rule>(ruleObj.ToString());
                    ruleList.Add(rule);
                }
            }
            return ruleList;
        }

        internal static Rule getRule(HttpResponseMessage responce)
        {
            var rule = new Rule();
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("rule"))
            {
                rule = JsonConvert.DeserializeObject<Rule>(jsonObj["rule"].ToString());
            }
            return rule;
        }

        internal static string getMessage(HttpResponseMessage responce)
        {
            string message = "";
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(responce.Content.ReadAsStringAsync().Result);
            if (jsonObj.ContainsKey("message"))
                message = jsonObj["message"].ToString();
            return message;
        }
    }
}
