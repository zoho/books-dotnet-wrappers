using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Bill.
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// Gets or sets the bill_id.
        /// </summary>
        /// <value>The bill_id.</value>
        public string bill_id { get; set; }
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
        /// Gets or sets the bill_number.
        /// </summary>
        /// <value>The bill_number.</value>
        public string bill_number { get; set; }
        /// <summary>
        /// Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the due_date.
        /// </summary>
        /// <value>The due_date.</value>
        public string due_date { get; set; }
        /// <summary>
        /// Gets or sets the due_days.
        /// </summary>
        /// <value>The due_days.</value>
        public string due_days { get; set; }
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
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public double balance { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the unused_credits_payable_amount.
        /// </summary>
        /// <value>The unused_credits_payable_amount.</value>
        public double unused_credits_payable_amount { get; set; }
        /// <summary>
        /// Gets or sets the due_by_days.
        /// </summary>
        /// <value>The due_by_days.</value>
        public int due_by_days { get; set; }
        /// <summary>
        /// Gets or sets the due_in_days.
        /// </summary>
        /// <value>The due_in_days.</value>
        public string due_in_days { get; set; }
        /// <summary>
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets the line_items.
        /// </summary>
        /// <value>The line_items.</value>
        public List<LineItem> line_items { get; set; }
        /// <summary>
        /// Gets or sets the sub_total.
        /// </summary>
        /// <value>The sub_total.</value>
        public double sub_total { get; set; }
        /// <summary>
        /// Gets or sets the tax_total.
        /// </summary>
        /// <value>The tax_total.</value>
        public double tax_total { get; set; }
        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<Tax> taxes { get; set; }
        /// <summary>
        /// Gets or sets the payment_made.
        /// </summary>
        /// <value>The payment_made.</value>
        public double payment_made { get; set; }
        /// <summary>
        /// Gets or sets the billing_address.
        /// </summary>
        /// <value>The billing_address.</value>
        public Address billing_address { get; set; }
        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        public List<Payment> payments { get; set; }
        /// <summary>
        /// Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
        /// <summary>
        /// Gets or sets the reference_id.
        /// </summary>
        /// <value>The reference_id.</value>
        public string reference_id { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }
        /// <summary>
        /// Gets or sets the terms.
        /// </summary>
        /// <value>The terms.</value>
        public string terms { get; set; }
        /// <summary>
        /// Gets or sets the attachment_name.
        /// </summary>
        /// <value>The attachment_name.</value>
        public string attachment_name { get; set; }
        /// <summary>
        /// Gets or sets the amount_applied.
        /// </summary>
        /// <value>The amount_applied.</value>
        public double amount_applied { get; set; }

        /// <summary>
        /// Gets or sets the recurring_bill_id.
        /// </summary>
        /// <value>The recurring_bill_id.</value>
        public string recurring_bill_id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Bill" /> is is_item_level_tax_calc.
        /// </summary>
        /// <value><c>true</c> if is_item_level_tax_calc; otherwise, <c>false</c>.</value>
        public bool is_item_level_tax_calc { get; set; }
        /// <summary>
        /// Gets or sets the vendor_credit_bill_id.
        /// </summary>
        /// <value>The vendor_credit_bill_id.</value>
        public string vendor_credit_bill_id { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the vendor_credit_id.
        /// </summary>
        /// <value>The vendor_credit_id.</value>
        public string vendor_credit_id { get; set; }
        /// <summary>
        /// Gets or sets the vendor_credit_number.
        /// </summary>
        /// <value>The vendor_credit_number.</value>
        public string vendor_credit_number { get; set; }
    }
}
