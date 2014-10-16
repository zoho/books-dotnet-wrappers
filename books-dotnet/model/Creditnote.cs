using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Creditnote.
    /// </summary>
    public class CreditNote
    {
        /// <summary>
        /// Gets or sets the creditnote_refund_id.
        /// </summary>
        /// <value>The creditnote_refund_id.</value>
        public string creditnote_refund_id { get; set; }
        /// <summary>
        /// Gets or sets the creditnote_id.
        /// </summary>
        /// <value>The creditnote_id.</value>
        public string creditnote_id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the refund_mode.
        /// </summary>
        /// <value>The refund_mode.</value>
        public string refund_mode { get; set; }
        /// <summary>
        /// Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
        /// <summary>
        /// Gets or sets the creditnote_number.
        /// </summary>
        /// <value>The creditnote_number.</value>
        public string creditnote_number { get; set; }
        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the amount_bcy.
        /// </summary>
        /// <value>The amount_bcy.</value>
        public double amount_bcy { get; set; }
        /// <summary>
        /// Gets or sets the amount_fcy.
        /// </summary>
        /// <value>The amount_fcy.</value>
        public double amount_fcy { get; set; }
        /// <summary>
        /// Gets or sets the creditnotes_invoice_id.
        /// </summary>
        /// <value>The creditnotes_invoice_id.</value>
        public string creditnotes_invoice_id { get; set; }
        /// <summary>
        /// Gets or sets the creditnotes_number.
        /// </summary>
        /// <value>The creditnotes_number.</value>
        public string creditnotes_number { get; set; }
        /// <summary>
        /// Gets or sets the credited_date.
        /// </summary>
        /// <value>The credited_date.</value>
        public string credited_date { get; set; }
        /// <summary>
        /// Gets or sets the amount_applied.
        /// </summary>
        /// <value>The amount_applied.</value>
        public double amount_applied { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
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
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
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
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreditNote" /> is is_emailed.
        /// </summary>
        /// <value><c>true</c> if is_emailed; otherwise, <c>false</c>.</value>
        public bool is_emailed { get; set; }
        /// <summary>
        /// Gets or sets the contact_persons.
        /// </summary>
        /// <value>The contact_persons.</value>
        public List<string> contact_persons { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the template_id.
        /// </summary>
        /// <value>The template_id.</value>
        public string template_id { get; set; }
        /// <summary>
        /// Gets or sets the template_name.
        /// </summary>
        /// <value>The template_name.</value>
        public string template_name { get; set; }
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
        /// Gets or sets the total_credits_used.
        /// </summary>
        /// <value>The total_credits_used.</value>
        public double total_credits_used { get; set; }
        /// <summary>
        /// Gets or sets the total_refunded_amount.
        /// </summary>
        /// <value>The total_refunded_amount.</value>
        public double total_refunded_amount { get; set; }
        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<Tax> taxes { get; set; }
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
        /// Gets or sets the billing_address.
        /// </summary>
        /// <value>The billing_address.</value>
        public Address billing_address { get; set; }
        /// <summary>
        /// Gets or sets the shipping_address.
        /// </summary>
        /// <value>The shipping_address.</value>
        public Address shipping_address { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the from_account_id.
        /// </summary>
        /// <value>The from_account_id.</value>
        public string from_account_id { get; set; }
        /// <summary>
        /// Gets or sets the from_account_name.
        /// </summary>
        /// <value>The from_account_name.</value>
        public string from_account_name { get; set; }
    }
}
