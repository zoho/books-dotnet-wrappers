using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Gets or sets the invoice_id.
        /// </summary>
        /// <value>The invoice_id.</value>
        public string invoice_id { get; set; }
        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }
        /// <summary>
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the invoice_number.
        /// </summary>
        /// <value>The invoice_number.</value>
        public string invoice_number { get; set; }
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
        /// Gets or sets the invoiced_estimate_id.
        /// </summary>
        /// <value>The invoiced_estimate_id.</value>
        public string invoiced_estimate_id { get; set; }
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
        /// Gets or sets a value indicating whether this <see cref="Invoice" /> is is_emailed.
        /// </summary>
        /// <value><c>true</c> if is_emailed; otherwise, <c>false</c>.</value>
        public string is_emailed { get; set; }
        /// <summary>
        /// Gets or sets the reminders_sent.
        /// </summary>
        /// <value>The reminders_sent.</value>
        public int reminders_sent { get; set; }
        /// <summary>
        /// Gets or sets the payment_expected_date.
        /// </summary>
        /// <value>The payment_expected_date.</value>
        public string payment_expected_date { get; set; }
        /// <summary>
        /// Gets or sets the last_payment_date.
        /// </summary>
        /// <value>The last_payment_date.</value>
        public string last_payment_date { get; set; }
        /// <summary>
        /// Gets or sets the payment_terms.
        /// </summary>
        /// <value>The payment_terms.</value>
        public int payment_terms { get; set; }
        /// <summary>
        /// Gets or sets the payment_terms_label.
        /// </summary>
        /// <value>The payment_terms_label.</value>
        public string payment_terms_label { get; set; }
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
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public string discount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Invoice" /> is is_discount_before_tax.
        /// </summary>
        /// <value><c>true</c> if is_discount_before_tax; otherwise, <c>false</c>.</value>
        public bool is_discount_before_tax { get; set; }
        /// <summary>
        /// Gets or sets the discount_type.
        /// </summary>
        /// <value>The discount_type.</value>
        public string discount_type { get; set; }
        /// <summary>
        /// Gets or sets the recurring_invoice_id.
        /// </summary>
        /// <value>The recurring_invoice_id.</value>
        public string recurring_invoice_id { get; set; }
        /// <summary>
        /// Gets or sets the line_items.
        /// </summary>
        /// <value>The line_items.</value>
        public List<LineItem> line_items { get; set; }
        /// <summary>
        /// Gets or sets the shipping_charge.
        /// </summary>
        /// <value>The shipping_charge.</value>
        public double shipping_charge { get; set; }
        /// <summary>
        /// Gets or sets the adjustment.
        /// </summary>
        /// <value>The adjustment.</value>
        public double adjustment { get; set; }
        /// <summary>
        /// Gets or sets the adjustment_description.
        /// </summary>
        /// <value>The adjustment_description.</value>
        public string adjustment_description { get; set; }
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
        /// Gets or sets a value indicating whether this <see cref="Invoice" /> is payment_reminder_enabled.
        /// </summary>
        /// <value><c>true</c> if payment_reminder_enabled; otherwise, <c>false</c>.</value>
        public bool payment_reminder_enabled { get; set; }
        /// <summary>
        /// Gets or sets the payment_made.
        /// </summary>
        /// <value>The payment_made.</value>
        public double payment_made { get; set; }
        /// <summary>
        /// Gets or sets the credits_applied.
        /// </summary>
        /// <value>The credits_applied.</value>
        public double credits_applied { get; set; }
        /// <summary>
        /// Gets or sets the tax_amount_withheld.
        /// </summary>
        /// <value>The tax_amount_withheld.</value>
        public double tax_amount_withheld { get; set; }
        /// <summary>
        /// Gets or sets the write_off_amount.
        /// </summary>
        /// <value>The write_off_amount.</value>
        public double write_off_amount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Invoice" /> is allow_partial_payments.
        /// </summary>
        /// <value><c>true</c> if allow_partial_payments; otherwise, <c>false</c>.</value>
        public bool allow_partial_payments { get; set; }
        /// <summary>
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the payment_options.
        /// </summary>
        /// <value>The payment_options.</value>
        public PaymentOptions payment_options { get; set; }
        /// <summary>
        /// Gets or sets the last_reminder_sent_date.
        /// </summary>
        /// <value>The last_reminder_sent_date.</value>
        public string last_reminder_sent_date { get; set; }
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
        /// Gets or sets the custom_fields.
        /// </summary>
        /// <value>The custom_fields.</value>
        public List<CustomField> custom_fields { get; set; }
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
        /// Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
        /// <summary>
        /// Gets or sets the attachment_name.
        /// </summary>
        /// <value>The attachment_name.</value>
        public string attachment_name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Invoice" /> is can_send_in_mail.
        /// </summary>
        /// <value><c>true</c> if can_send_in_mail; otherwise, <c>false</c>.</value>
        public bool can_send_in_mail { get; set; }
        /// <summary>
        /// Gets or sets the salesperson_id.
        /// </summary>
        /// <value>The salesperson_id.</value>
        public string salesperson_id { get; set; }
        /// <summary>
        /// Gets or sets the salesperson_name.
        /// </summary>
        /// <value>The salesperson_name.</value>
        public string salesperson_name { get; set; }
        /// <summary>
        /// Gets or sets the custom_body.
        /// </summary>
        /// <value>The custom_body.</value>
        public string custom_body { get; set; }
        /// <summary>
        /// Gets or sets the custom_subject.
        /// </summary>
        /// <value>The custom_subject.</value>
        public string custom_subject { get; set; }
        /// <summary>
        /// Gets or sets the invoice_payment_id.
        /// </summary>
        /// <value>The invoice_payment_id.</value>
        public string invoice_payment_id { get; set; }
        /// <summary>
        /// Gets or sets the amount_applied.
        /// </summary>
        /// <value>The amount_applied.</value>
        public double amount_applied { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
    }
}
