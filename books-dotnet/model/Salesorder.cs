using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class Salesorder.
    /// </summary>
    public class Salesorder
    {
        /// <summary>
        ///     Gets or sets the salesorder_id.
        /// </summary>
        /// <value>The salesorder_id.</value>
        public string salesorder_id { get; set; }

        /// <summary>
        ///     Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }

        /// <summary>
        ///     Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }

        /// <summary>
        ///     Gets or sets the salesorder_number.
        /// </summary>
        /// <value>The salesorder_number.</value>
        public string salesorder_number { get; set; }

        /// <summary>
        ///     Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the shipment_date.
        /// </summary>
        /// <value>The shipment_date.</value>
        public string shipment_date { get; set; }

        /// <summary>
        ///     Gets or sets the shipment_days.
        /// </summary>
        /// <value>The shipment_days.</value>
        public string shipment_days { get; set; }

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
        ///     Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }

        /// <summary>
        ///     Gets or sets the bcy_total.
        /// </summary>
        /// <value>The bcy_total.</value>
        public double bcy_total { get; set; }

        /// <summary>
        ///     Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }

        /// <summary>
        ///     Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Salesorder" /> is is_emailed.
        /// </summary>
        /// <value><c>true</c> if is_emailed; otherwise, <c>false</c>.</value>
        public bool is_emailed { get; set; }

        /// <summary>
        ///     Gets or sets the contact_persons.
        /// </summary>
        /// <value>The contact_persons.</value>
        public List<ContactPerson> contact_persons { get; set; }

        /// <summary>
        ///     Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }

        /// <summary>
        ///     Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }

        /// <summary>
        ///     Gets or sets the discount_amount.
        /// </summary>
        /// <value>The discount_amount.</value>
        public double discount_amount { get; set; }

        /// <summary>
        ///     Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double discount { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Salesorder" /> is is_discount_before_tax.
        /// </summary>
        /// <value><c>true</c> if is_discount_before_tax; otherwise, <c>false</c>.</value>
        public bool is_discount_before_tax { get; set; }

        /// <summary>
        ///     Gets or sets the discount_type.
        /// </summary>
        /// <value>The discount_type.</value>
        public string discount_type { get; set; }

        /// <summary>
        ///     Gets or sets the estimate_id.
        /// </summary>
        /// <value>The estimate_id.</value>
        public string estimate_id { get; set; }

        /// <summary>
        ///     Gets or sets the delivery_method.
        /// </summary>
        /// <value>The delivery_method.</value>
        public string delivery_method { get; set; }

        /// <summary>
        ///     Gets or sets the delivery_method_id.
        /// </summary>
        /// <value>The delivery_method_id.</value>
        public string delivery_method_id { get; set; }

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
        ///     Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<Tax> taxes { get; set; }

        /// <summary>
        ///     Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }

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
        ///     Gets or sets the custom_fields.
        /// </summary>
        /// <value>The custom_fields.</value>
        public List<CustomField> custom_fields { get; set; }

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
        ///     Gets or sets the template_type.
        /// </summary>
        /// <value>The template_type.</value>
        public string template_type { get; set; }

        /// <summary>
        ///     Gets or sets the attachment_name.
        /// </summary>
        /// <value>The attachment_name.</value>
        public string attachment_name { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Salesorder" /> is can_send_in_mail.
        /// </summary>
        /// <value><c>true</c> if can_send_in_mail; otherwise, <c>false</c>.</value>
        public bool can_send_in_mail { get; set; }

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
    }
}