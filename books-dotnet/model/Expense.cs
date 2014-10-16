using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Expense.
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Gets or sets the expense_id.
        /// </summary>
        /// <value>The expense_id.</value>
        public string expense_id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the account_name.
        /// </summary>
        /// <value>The account_name.</value>
        public string account_name { get; set; }
        /// <summary>
        /// Gets or sets the paid_through_account_name.
        /// </summary>
        /// <value>The paid_through_account_name.</value>
        public string paid_through_account_name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }
        /// <summary>
        /// Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }
        /// <summary>
        /// Gets or sets the bcy_total.
        /// </summary>
        /// <value>The bcy_total.</value>
        public double bcy_total { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Expense" /> is is_billable.
        /// </summary>
        /// <value><c>true</c> if is_billable; otherwise, <c>false</c>.</value>
        public bool is_billable { get; set; }
        /// <summary>
        /// Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
        /// <summary>
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }
        /// <summary>
        /// Gets or sets the vendor_id.
        /// </summary>
        /// <value>The vendor_id.</value>
        public string vendor_id { get; set; }
        /// <summary>
        /// Gets or sets the vendor_name.
        /// </summary>
        /// <value>The vendor_name.</value>
        public string vendor_name { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the expense_receipt_name.
        /// </summary>
        /// <value>The expense_receipt_name.</value>
        public string expense_receipt_name { get; set; }
        /// <summary>
        /// Gets or sets the expense_item_id.
        /// </summary>
        /// <value>The expense_item_id.</value>
        public string expense_item_id { get; set; }
        /// <summary>
        /// Gets or sets the account_id.
        /// </summary>
        /// <value>The account_id.</value>
        public string account_id { get; set; }
        /// <summary>
        /// Gets or sets the paid_through_account_id.
        /// </summary>
        /// <value>The paid_through_account_id.</value>
        public string paid_through_account_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_id.
        /// </summary>
        /// <value>The tax_id.</value>
        public string tax_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_name.
        /// </summary>
        /// <value>The tax_name.</value>
        public string tax_name { get; set; }
        /// <summary>
        /// Gets or sets the tax_percentage.
        /// </summary>
        /// <value>The tax_percentage.</value>
        public double tax_percentage { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets the tax_amount.
        /// </summary>
        /// <value>The tax_amount.</value>
        public double tax_amount { get; set; }
        /// <summary>
        /// Gets or sets the sub_total.
        /// </summary>
        /// <value>The sub_total.</value>
        public double sub_total { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Expense" /> is is_inclusive_tax.
        /// </summary>
        /// <value><c>true</c> if is_inclusive_tax; otherwise, <c>false</c>.</value>
        public bool is_inclusive_tax { get; set; }
        /// <summary>
        /// Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
        /// <summary>
        /// Gets or sets the invoice_id.
        /// </summary>
        /// <value>The invoice_id.</value>
        public string invoice_id { get; set; }
        /// <summary>
        /// Gets or sets the invoice_number.
        /// </summary>
        /// <value>The invoice_number.</value>
        public string invoice_number { get; set; }
        /// <summary>
        /// Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
        /// <summary>
        /// Gets or sets the project_name.
        /// </summary>
        /// <value>The project_name.</value>
        public string project_name { get; set; }
        /// <summary>
        /// Gets or sets the recurring_expense_id.
        /// </summary>
        /// <value>The recurring_expense_id.</value>
        public string recurring_expense_id { get; set; }
    }
}
