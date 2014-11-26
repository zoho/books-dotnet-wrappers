using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace SettingsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organization id}");
                SettingsApi settingsApi = service.GetSettingsApi();
                Console.WriteLine("----------------Preferences-------------");
                var preferences = settingsApi.GetPreferences();
                var autoreminders = preferences.auto_reminders;
                Console.WriteLine("Auto Reminders");
                foreach (var autoreminder in autoreminders)
                    Console.WriteLine("sub:{0},body:{1},notification Type:{2}", autoreminder.subject, autoreminder.body, autoreminder.notification_type);
                var addrFormat = preferences.address_formats;
                Console.WriteLine("cust addrformat:{0},Organisation Format:{1}", addrFormat.customer_address_format, addrFormat.organization_address_format);
                var updateInfo = new Preferences()
                {
                    convert_to_invoice= false,
                    notify_me_on_online_payment=true,
                    is_show_powered_by=true,
                    is_estimate_enabled=false,
                };
                var updateMsg = settingsApi.UpdatePreferences(updateInfo);
                
                var newUnit = new Unit()
                {
                    unit = "new unit"
                };
                var addUnit = settingsApi.CreateUnit(newUnit);
                Console.WriteLine(addUnit);
                var deleteUnit = settingsApi.DeleteUnit("{Unit id}");
                Console.WriteLine(deleteUnit);
                Console.WriteLine("----------------------------------------------------\n------------------Tax and TaxGroups-----------------");
                var taxeslist = settingsApi.GetTaxes();
                var taxes = taxeslist;
                var taxId = taxes[0].tax_id;
                foreach (var tax in taxes)
                    Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", tax.tax_id, tax.tax_name, tax.tax_percentage, tax.tax_type);
                var tax1 = settingsApi.GetTax(taxId);
                Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", tax1.tax_id, tax1.tax_name, tax1.tax_percentage, tax1.tax_type);
                var newTaxInfo = new Tax()
                {
                    tax_name="VAT1",
                    tax_percentage=5
                };
                var newTax = settingsApi.CreateTax(newTaxInfo);
                Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", newTax.tax_id, newTax.tax_name, newTax.tax_percentage, newTax.tax_type);
                var updateInfo1 = new Tax()
                {
                    tax_percentage=6,
                    tax_type = "compound_tax",
                   
                };
                var updatedTax = settingsApi.UpdateTax(newTax.tax_id, updateInfo1);
                Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", updatedTax.tax_id, updatedTax.tax_name, updatedTax.tax_percentage, updatedTax.tax_type);
                var deletemsg = settingsApi.DeleteTax(updatedTax.tax_id);
                Console.WriteLine(deletemsg);
                var taxgroup = settingsApi.GetTaxGroup("71917000000259007");
                Console.WriteLine("the tax group {0} contains the taxes",taxgroup.tax_group_name);
                var taxes1 = taxgroup.taxes;
                foreach(var tax in taxes1)
                    Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", tax.tax_id, tax.tax_name, tax.tax_percentage, tax.tax_type);
                var newTaxGroupInfo = new TaxGroupToCreate()
                {
                    tax_group_name="purchase",
                    taxes = taxes[0].tax_id+","+taxes[2].tax_id,
                };
                var newTaxGroup = settingsApi.CreateTaxGroup(newTaxGroupInfo);
                var taxGroupId = newTaxGroup.tax_group_id;
                Console.WriteLine("the tax group {0} contains the taxes of tax percentage{1}", newTaxGroup.tax_group_name,newTaxGroup.tax_group_percentage);
                var taxes2 = newTaxGroup.taxes;
                foreach (var tax in taxes2)
                    Console.WriteLine("taxId:{0},name:{1},percentage:{2},Type:{3}", tax.tax_id, tax.tax_name, tax.tax_percentage, tax.tax_type);
                var updateInfo2 = new TaxGroupToCreate()
                {
                    tax_group_name="purcha",
                    taxes = taxes[0].tax_id + "," + taxes[2].tax_id,
                };
                var updateTaxGroup = settingsApi.UpdateTaxGroup(taxGroupId, updateInfo2);
                Console.WriteLine("the tax group {0} updated as the taxes of tax percentage{1}", updateTaxGroup.tax_group_name, updateTaxGroup.tax_group_percentage);
                var deleteMsg = settingsApi.DeleteTaxGroup(taxGroupId);
                Console.WriteLine(deleteMsg);
                Console.WriteLine("----------------------------------------------------\n------------------Opening balence-----------------");
                var openingbalence = settingsApi.GetOpeningBalance();
                Console.WriteLine("The accounts in opening balance {0}", openingbalence.opening_balance_id);
                var accounts = openingbalence.accounts;
                foreach (var account in accounts)
                    Console.WriteLine("account id:{3},account name:{0},debit/ccredit:{1},amount:{2}", account.account_name, account.debit_or_credit, account.amount,account.account_id);
                var newOpeningbalanceInfo = new OpeningBalance()
                {
                    date="2014-05-06",
                    accounts = new List<Account>()
                    {
                        new Account()
                        {
                            account_id="71917000000000379",
                            debit_or_credit="credit",
                            amount=200,
                            currency_id="71917000000000099",
                
                         },
                    }
                };
                var newOpeningbalance = settingsApi.CreateOpeningBalance(newOpeningbalanceInfo);
                Console.WriteLine("The accounts in opening balance {0}", newOpeningbalance.opening_balance_id);
                var accounts1 = newOpeningbalance.accounts;
                foreach (var account in accounts1)
                    Console.WriteLine("account id:{3},account name:{0},debit/ccredit:{1},amount:{2}", account.account_name, account.debit_or_credit, account.amount, account.account_id);
               var updateInfo3 = new OpeningBalance()
                {
                    date = "2014-05-06",
                    accounts = new List<Account>()
                    {
                        new Account()
                        {
                            account_id="71917000000000379",
                            debit_or_credit="credit",
                            amount=400,
                            currency_id="71917000000000099",
                        },
                    }
                };
                var updatedOpeningbalance = settingsApi.UpdateOpeningBalance(updateInfo3);
                Console.WriteLine("The accounts in opening balance {0}", updatedOpeningbalance.opening_balance_id);
                var accounts2 = updatedOpeningbalance.accounts;
                foreach (var account in accounts2)
                    Console.WriteLine("account id:{3},account name:{0},debit/ccredit:{1},amount:{2}", account.account_name, account.debit_or_credit, account.amount, account.account_id);
                var delmsg = settingsApi.DeleteOpeningBalance();
                Console.WriteLine(delmsg);
                Console.WriteLine("----------------------------------------------------\n------------------Reminders-----------------");
                var reminders = settingsApi.GetAutoPaymentReminders();
                var autoRemindId = reminders[1].autoreminder_id;
                foreach (var reminder in reminders)
                    Console.WriteLine("reminder Id:{0}\n is_enable:{1}\nbody:{2}\n",reminder.autoreminder_id,reminder.is_enabled,reminder.body);
                var reminderAndPlaceholder = settingsApi.GetAnAutoPaymentReminder(autoRemindId);
                var reminder1 = reminderAndPlaceholder.autoreminder;
                Console.WriteLine("reminder Id:{0}\n is_enable:{1}\nbody:{2}\n", reminder1.autoreminder_id, reminder1.is_enabled, reminder1.body);
                var placeholder = reminderAndPlaceholder.placeholders;
                Console.WriteLine("placeholders Invoices are");
                var invoices = placeholder.Invoice;
                foreach (var invoice in invoices)
                    Console.WriteLine("name:{0},value:{1}", invoice.name, invoice.value);
                Console.WriteLine("placeholders Customers are");
                var customers = placeholder.Customer;
                foreach (var customer in customers)
                    Console.WriteLine("name:{0},value:{1}", customer.name, customer.value);
                Console.WriteLine("placeholders Organizations are are");
                var organizations = placeholder.Organization;
                foreach (var organization in organizations)
                    Console.WriteLine("name:{0},value:{1}", organization.name, organization.value);
                var reminderenable = settingsApi.EnableAutoReminder(autoRemindId);
                Console.WriteLine(reminderenable);
                var reminderdisable = settingsApi.DisableAutoReminder(autoRemindId);
                Console.WriteLine(reminderdisable);
                var updateInfo4 = new AutoReminder()
                {
                    is_enabled = true,
                    type = "days_before_due_date",
                    address_type = "remind_customer_and_cc_me"
                };
                var updateMsg1 = settingsApi.UpdateAnAutoReminder(autoRemindId, updateInfo4);
                Console.WriteLine(updateMsg1);
                var parameters = new Dictionary<object, object>();
                parameters.Add("type", "open_reminder");
                var manualreminders = settingsApi.GetManualReminders(parameters);
                var manualRemindId = manualreminders[0].manualreminder_id;
                foreach(var manualreminder in manualreminders)
                    Console.WriteLine("reminder Id:{0}\n is_enable:{1}\nbody:{2}\ncc_me:{3}", manualreminder.manualreminder_id, manualreminder.type, manualreminder.body,manualreminder.cc_me);
                var manualreminder1 = settingsApi.GetManualReminder(manualRemindId);
                var reminder2 = manualreminder1.manualreminder;
                Console.WriteLine("reminder Id:{0}\n is_enable:{1}\nbody:{2}\ncc_me:{3}", reminder2.manualreminder_id, reminder2.type, reminder2.body, reminder2.cc_me);
                var placeholder1 = manualreminder1.placeholders;
                Console.WriteLine("placeholders Invoices are");
                var invoices1 = placeholder.Invoice;
                foreach (var invoice in invoices1)
                    Console.WriteLine("name:{0},value:{1}", invoice.name, invoice.value);
                Console.WriteLine("placeholders Customers are");
                var customers1 = placeholder.Customer;
                foreach (var customer in customers1)
                    Console.WriteLine("name:{0},value:{1}", customer.name, customer.value);
                Console.WriteLine("placeholders Organizations are are");
                var organizations1 = placeholder.Organization;
                foreach (var organization in organizations1)
                    Console.WriteLine("name:{0},value:{1}", organization.name, organization.value);
                var updateInfo5 = new ManualReminder()
                {
                    cc_me=true
                };
                var updatedmsg = settingsApi.UpdateManualReminder(manualRemindId, updateInfo5);
                Console.WriteLine(updatedmsg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
