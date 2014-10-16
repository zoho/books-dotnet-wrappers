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
                service.initialize("66328a2f80405be002f43119f3e5f16b", "33074688");
                var rulesApi = service.GetBankRulesApi();
                var parameters = new Dictionary<object, object>();
                /*parameters.Add("account_id", "71917000000087341");
                var rules = rulesApi.GetRules(parameters);
                foreach (var rule in rules)
                {
                    Console.WriteLine("{0},{1},{2}", rule.rule_id, rule.rule_name, rule.account_name);
                    var criterions = rule.criterion;
                    Console.WriteLine("criterions");
                    foreach (var criterion in criterions)
                        Console.WriteLine("{0},{1}", criterion.criteria_id, criterion.value);
                }
                var rule = rulesApi.Get("71917000000091667");
                Console.WriteLine("{0},{1},{2}", rule.rule_id, rule.rule_name, rule.account_name);
                var criterions = rule.criterion;
                Console.WriteLine("criterions");
                foreach (var criterion in criterions)
                    Console.WriteLine("{0},{1}", criterion.criteria_id, criterion.value);*/
                var ruleInfo = new Rule()
                {
                    rule_name = "hari",
                    target_account_id = "71917000000087341",
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
                    account_id = "71917000000084145"
                };
                var newRule = rulesApi.Create(ruleInfo);
                Console.WriteLine("{0},{1},{2}", newRule.rule_id, newRule.rule_name, newRule.account_name);
                var criterions = newRule.criterion;
                Console.WriteLine("criterions");
                foreach (var criterion in criterions)
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
                var updatedRule = rulesApi.Update(newRule.rule_id, updateInfo);
                Console.WriteLine("{0},{1},{2}", updatedRule.rule_id, updatedRule.rule_name, updatedRule.account_name);
                var criterions1 = updatedRule.criterion;
                Console.WriteLine("criterions");
                foreach (var criterion in criterions1)
                    Console.WriteLine("{0},{1}", criterion.criteria_id, criterion.value);
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
