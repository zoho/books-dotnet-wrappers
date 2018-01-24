using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of RecurringInvoice.
    /// </summary>
    public class RecurringInvoice
    {
        /// <summary>
        ///     Gets or sets the recurring_invoice_id.
        /// </summary>
        /// <value>The recurring_invoice_id.</value>
        public string recurring_invoice_id { get; set; }

        /// <summary>
        ///     Gets or sets the recurrence_name.
        /// </summary>
        /// <value>The recurrence_name.</value>
        public string recurrence_name { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }

        /// <summary>
        ///     Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }

        /// <summary>
        ///     Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }

        /// <summary>
        ///     Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }

        /// <summary>
        ///     Gets or sets the start_date.
        /// </summary>
        /// <value>The start_date.</value>
        public string start_date { get; set; }

        /// <summary>
        ///     Gets or sets the end_date.
        /// </summary>
        /// <value>The end_date.</value>
        public string end_date { get; set; }

        /// <summary>
        ///     Gets or sets the last_sent_date.
        /// </summary>
        /// <value>The last_sent_date.</value>
        public string last_sent_date { get; set; }

        /// <summary>
        ///     Gets or sets the next_invoice_date.
        /// </summary>
        /// <value>The next_invoice_date.</value>
        public string next_invoice_date { get; set; }

        /// <summary>
        ///     Gets or sets the recurrence_frequency.
        /// </summary>
        /// <value>The recurrence_frequency.</value>
        public string recurrence_frequency { get; set; }

        /// <summary>
        ///     Gets or sets the repeat_every.
        /// </summary>
        /// <value>The repeat_every.</value>
        public int repeat_every { get; set; }

        /// <summary>
        ///     Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }

        /// <summary>
        ///     Gets or sets the payment_terms.
        /// </summary>
        /// <value>The payment_terms.</value>
        public int payment_terms { get; set; }

        /// <summary>
        ///     Gets or sets the payment_terms_label.
        /// </summary>
        /// <value>The payment_terms_label.</value>
        public string payment_terms_label { get; set; }

        /// <summary>
        ///     Gets or sets the contact_persons.
        /// </summary>
        /// <value>The contact_persons.</value>
        public List<string> contact_persons { get; set; }

        /// <summary>
        ///     Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }

        /// <summary>
        ///     Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }

        /// <summary>
        ///     Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }

        /// <summary>
        ///     Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double discount { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="RecurringInvoice" /> is is_discount_before_tax.
        /// </summary>
        /// <value><c>true</c> if is_discount_before_tax; otherwise, <c>false</c>.</value>
        public bool is_discount_before_tax { get; set; }

        /// <summary>
        ///     Gets or sets the discount_type.
        /// </summary>
        /// <value>The discount_type.</value>
        public string discount_type { get; set; }

        /// <summary>
        ///     Gets or sets the line_items.
        /// </summary>
        /// <value>The line_items.</value>
        public List<LineItem> line_items { get; set; }

        /// <summary>
        ///     Gets or sets the shipping_charge.
        /// </summary>
        /// <value>The shipping_charge.</value>
        public double shipping_charge { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment.
        /// </summary>
        /// <value>The adjustment.</value>
        public double adjustment { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment_description.
        /// </summary>
        /// <value>The adjustment_description.</value>
        public string adjustment_description { get; set; }

        /// <summary>
        ///     Gets or sets the sub_total.
        /// </summary>
        /// <value>The sub_total.</value>
        public double sub_total { get; set; }

        /// <summary>
        ///     Gets or sets the tax_total.
        /// </summary>
        /// <value>The tax_total.</value>
        public double tax_total { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="RecurringInvoice" /> is allow_partial_payments.
        /// </summary>
        /// <value><c>true</c> if allow_partial_payments; otherwise, <c>false</c>.</value>
        public bool allow_partial_payments { get; set; }

        /// <summary>
        ///     Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<Tax> taxes { get; set; }

        /// <summary>
        ///     Gets or sets the payment_options.
        /// </summary>
        /// <value>The payment_options.</value>
        public PaymentOptions payment_options { get; set; }

        /// <summary>
        ///     Gets or sets the billing_address.
        /// </summary>
        /// <value>The billing_address.</value>
        public Address billing_address { get; set; }

        /// <summary>
        ///     Gets or sets the shipping_address.
        /// </summary>
        /// <value>The shipping_address.</value>
        public Address shipping_address { get; set; }

        /// <summary>
        ///     Gets or sets the template_id.
        /// </summary>
        /// <value>The template_id.</value>
        public string template_id { get; set; }

        /// <summary>
        ///     Gets or sets the template_name.
        /// </summary>
        /// <value>The template_name.</value>
        public string template_name { get; set; }

        /// <summary>
        ///     Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }

        /// <summary>
        ///     Gets or sets the terms.
        /// </summary>
        /// <value>The terms.</value>
        public string terms { get; set; }

        /// <summary>
        ///     Gets or sets the salesperson_id.
        /// </summary>
        /// <value>The salesperson_id.</value>
        public string salesperson_id { get; set; }

        /// <summary>
        ///     Gets or sets the salesperson_name.
        /// </summary>
        /// <value>The salesperson_name.</value>
        public string salesperson_name { get; set; }

        /// <summary>
        ///     Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
    }
}