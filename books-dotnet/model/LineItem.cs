using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of LineItem.
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Gets or sets the item_id.
        /// </summary>
        /// <value>The item_id.</value>
        public string item_id { get; set; }
        /// <summary>
        /// Gets or sets the line_item_id.
        /// </summary>
        /// <value>The line_item_id.</value>
        public string line_item_id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the item_order.
        /// </summary>
        /// <value>The item_order.</value>
        public double item_order { get; set; }
        /// <summary>
        /// Gets or sets the bcy_rate.
        /// </summary>
        /// <value>The bcy_rate.</value>
        public double bcy_rate { get; set; }
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double rate { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double quantity { get; set; }
        /// <summary>
        /// Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
        /// <summary>
        /// Gets or sets the time_entry_ids.
        /// </summary>
        /// <value>The time_entry_ids.</value>
        public string time_entry_ids { get; set; }
        /// <summary>
        /// Gets or sets the expense_id.
        /// </summary>
        /// <value>The expense_id.</value>
        public string expense_id { get; set; }
        /// <summary>
        /// Gets or sets the expense_receipt_name.
        /// </summary>
        /// <value>The expense_receipt_name.</value>
        public string expense_receipt_name { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string unit { get; set; }
        /// <summary>
        /// Gets or sets the discount_amount.
        /// </summary>
        /// <value>The discount_amount.</value>
        public double discount_amount { get; set; }
        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public string discount { get; set; }
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
        /// Gets or sets the tax_type.
        /// </summary>
        /// <value>The tax_type.</value>
        public string tax_type { get; set; }
        /// <summary>
        /// Gets or sets the tax_percentage.
        /// </summary>
        /// <value>The tax_percentage.</value>
        public double tax_percentage { get; set; }
        /// <summary>
        /// Gets or sets the item_total.
        /// </summary>
        /// <value>The item_total.</value>
        public double item_total { get; set; }
        /// <summary>
        /// Gets or sets the account_id.
        /// </summary>
        /// <value>The account_id.</value>
        public string account_id { get; set; }
        /// <summary>
        /// Gets or sets the account_name.
        /// </summary>
        /// <value>The account_name.</value>
        public string account_name { get; set; }
        /// <summary>
        /// Gets or sets the line_id.
        /// </summary>
        /// <value>The line_id.</value>
        public string line_id { get; set; }
        /// <summary>
        /// Gets or sets the debit_or_credit.
        /// </summary>
        /// <value>The debit_or_credit.</value>
        public string debit_or_credit { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the tax_authority_id.(US Edition only)
        /// </summary>
        /// <value>The tax_authority_id.</value>
        public string tax_authority_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_exemption_id.(US Edition only)
        /// </summary>
        /// <value>The tax_exemption_id.</value>
        public string tax_exemption_id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LineItem"/> is is_invoiced.
        /// </summary>
        /// <value><c>true</c> if is_invoiced; otherwise, <c>false</c>.</value>
        public bool is_invoiced { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public List<string> tags { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string source { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LineItem"/> is is_linked_with_zohocrm.
        /// </summary>
        /// <value><c>true</c> if is_linked_with_zohocrm; otherwise, <c>false</c>.</value>
        public bool is_linked_with_zohocrm { get; set; }
        /// <summary>
        /// Gets or sets the pricebook_rate.
        /// </summary>
        /// <value>The pricebook_rate.</value>
        public double pricebook_rate { get; set; }
        /// <summary>
        /// (US edition only)
        /// Gets or sets a value indicating whether this <see cref="LineItem" /> is is_taxable.
        /// </summary>
        /// <value><c>true</c> if is_taxable; otherwise, <c>false</c>.</value>
        public bool is_taxable { get; set; }
        /// <summary>
        /// Gets or sets the stock_on_hand.
        /// </summary>
        /// <value>The stock_on_hand.</value>
        public string stock_on_hand { get; set; }
        public List<CustomField> custom_fields { get; set; }
    }
}
