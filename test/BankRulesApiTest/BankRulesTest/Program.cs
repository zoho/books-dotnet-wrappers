using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.service;
using zohobooks.model;

namespace BankRulesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organizationId}");
                var rulesApi = service.GetBankRulesApi();
                var parameters = new Dictionary<object, object>();
                var accountsApi = service.GetBankAccountsApi();
                var accounts = accountsApi.GetBankAccounts(null);
                var chartOfAccountsApi = service.GetChartOfAccountsApi();
                var chartOfAccounts = chartOfAccountsApi.GetChartOfAcounts(null);
                parameters.Add("account_id", accounts[1].account_id);
                Console.WriteLine("--------------------------Rules List---------------");
                var rules = rulesApi.GetRules(parameters);
                foreach (var tempRule in rules)
                {
                    Console.WriteLine("{0},{1},{2}", tempRule.rule_id, tempRule.rule_name, tempRule.account_name);
                    var tempCriterions = tempRule.criterion;
                    Console.WriteLine("criterions");
                    foreach (var tempCriterion in tempCriterions)
                        Console.WriteLine("{0},{1}", tempCriterion.criteria_id, tempCriterion.value);
                }
                Console.WriteLine("--------------------------------------Specified Rule ----------------------------");
                var rule = rulesApi.Get(rules[0].rule_id);
                Console.WriteLine("{0},{1},{2}", rule.rule_id, rule.rule_name, rule.account_name);
                
                var ruleInfo = new Rule()
                {
                    rule_name = "hari",
                    target_account_id = accounts[0].account_id,
                    apply_to = "withdrawals",
                    criteria_type = "or",
                    criterion = new List<Criterion>(){
                         new Criterion(){
                             field="payee",
                             comparator="contains",
                             value="9"
                            }     
                     },
                    record_as = "expense",
                    account_id = chartOfAccounts[41].account_id
                };
                Console.WriteLine("----------------------------New Rule-----------------------");
                var newRule = rulesApi.Create(ruleInfo);
                Console.WriteLine("{0},{1},{2}", newRule.rule_id, newRule.rule_name, newRule.account_name);
                var newcriterions = newRule.criterion;
                Console.WriteLine("criterions");
                foreach (var criterion in newcriterions)
                    Console.WriteLine("{0},{1}", criterion.criteria_id, criterion.value);
                var updateInfo = new Rule()
                {
                    rule_name = "krishna",
                    apply_to = "withdrawals",
                    criteria_type = "or",
                    criterion = new List<Criterion>(){
                         new Criterion(){
                             field="payee",
                             comparator="contains",
                             value="8"
                            }     
                     },
                    record_as = "expense",
                };
                Console.WriteLine("----------------------------Updated Rule----------------------");
                var updatedRule = rulesApi.Update(newRule.rule_id, updateInfo);
                Console.WriteLine("{0},{1},{2}", updatedRule.rule_id, updatedRule.rule_name, updatedRule.account_name);
                var criterions1 = updatedRule.criterion;
                Console.WriteLine("criterions");
                foreach (var criterion in criterions1)
                    Console.WriteLine("{0},{1}", criterion.criteria_id, criterion.value);
                Console.WriteLine("-------------------------------Delete Rule--------------------------------------");
                var delRule = rulesApi.Delete(updatedRule.rule_id);
                Console.WriteLine(delRule);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        
    }
}
