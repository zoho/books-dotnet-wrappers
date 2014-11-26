using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Class Purchaseorder.
    /// </summary>
    public class Purchaseorder
    {
        /// <summary>
        /// Gets or sets the purchaseorder_id.
        /// </summary>
        /// <value>The purchaseorder_id.</value>
        public string purchaseorder_id { get; set; }
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
        /// Gets or sets the purchaseorder_number.
        /// </summary>
        /// <value>The purchaseorder_number.</value>
        public string purchaseorder_number { get; set; }
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
        /// Gets or sets the delivery_date.
        /// </summary>
        /// <value>The delivery_date.</value>
        public string delivery_date { get; set; }
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
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }
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
        /// Gets or sets the expected_delivery_date.
        /// </summary>
        /// <value>The expected_delivery_date.</value>
        public string expected_delivery_date { get; set; }
        /// <summary>
        /// Gets or sets the contact_persons.
        /// </summary>
        /// <value>The contact_persons.</value>
        public List<string> contact_persons { get; set; }
        /// <summary>
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Purchaseorder" /> is is_emailed.
        /// </summary>
        /// <value><c>true</c> if is_emailed; otherwise, <c>false</c>.</value>
        public bool is_emailed { get; set; }
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
        /// Gets or sets the billing_address.
        /// </summary>
        /// <value>The billing_address.</value>
        public Address billing_address { get; set; }
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
        /// Gets or sets the ship_via.
        /// </summary>
        /// <value>The ship_via.</value>
        public string ship_via { get; set; }
        /// <summary>
        /// Gets or sets the attention.
        /// </summary>
        /// <value>The attention.</value>
        public string attention { get; set; }
        /// <summary>
        /// Gets or sets the delivery_address.
        /// </summary>
        /// <value>The delivery_address.</value>
        public Address delivery_address { get; set; }
        /// <summary>
        /// Gets or sets the custom_fields.
        /// </summary>
        /// <value>The custom_fields.</value>
        public List<CustomField> custom_fields { get; set; }
        /// <summary>
        /// Gets or sets the attachment_name.
        /// </summary>
        /// <value>The attachment_name.</value>
        public string attachment_name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Purchaseorder" /> is can_send_in_mail.
        /// </summary>
        /// <value><c>true</c> if can_send_in_mail; otherwise, <c>false</c>.</value>
        public bool can_send_in_mail { get; set; }
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
        /// Gets or sets the ship_via_id.
        /// </summary>
        /// <value>The ship_via_id.</value>
        public string ship_via_id { get; set; }
        /// <summary>
        /// Gets or sets the delivery_org_address_id.
        /// </summary>
        /// <value>The delivery_org_address_id.</value>
        public string delivery_org_address_id { get; set; }
        /// <summary>
        /// Gets or sets the delivery_customer_id.
        /// </summary>
        /// <value>The delivery_customer_id.</value>
        public string delivery_customer_id { get; set; }
        /// <summary>
        /// Gets or sets the template_type.
        /// </summary>
        /// <value>The template_type.</value>
        public string template_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Purchaseorder"/> is can_mark_as_bill.
        /// </summary>
        /// <value><c>true</c> if can_mark_as_bill; otherwise, <c>false</c>.</value>
        public bool can_mark_as_bill { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Purchaseorder"/> is can_mark_as_unbill.
        /// </summary>
        /// <value><c>true</c> if can_mark_as_unbill; otherwise, <c>false</c>.</value>
        public bool can_mark_as_unbill { get; set; }
    }
}
