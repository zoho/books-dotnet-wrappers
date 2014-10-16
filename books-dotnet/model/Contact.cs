using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the contact_id.
        /// </summary>
        /// <value>The contact_id.</value>
        public string contact_id { get; set; }
        /// <summary>
        /// Gets or sets the contact_name.
        /// </summary>
        /// <value>The contact_name.</value>
        public string contact_name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is has_transaction.
        /// </summary>
        /// <value><c>true</c> if has_transaction; otherwise, <c>false</c>.</value>
        public bool has_transaction { get; set; }
        /// <summary>
        /// Gets or sets the contact_type.
        /// </summary>
        /// <value>The contact_type.</value>
        public string contact_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is is_crm_customer.
        /// </summary>
        /// <value><c>true</c> if is_crm_customer; otherwise, <c>false</c>.</value>
        public bool is_crm_customer { get; set; }
        /// <summary>
        /// Gets or sets the primary_contact_id.
        /// </summary>
        /// <value>The primary_contact_id.</value>
        public string primary_contact_id { get; set; }
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
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the outstanding_receivable_amount.
        /// </summary>
        /// <value>The outstanding_receivable_amount.</value>
        public double outstanding_receivable_amount { get; set; }
        /// <summary>
        /// Gets or sets the outstanding_receivable_amount_bcy.
        /// </summary>
        /// <value>The outstanding_receivable_amount_bcy.</value>
        public double outstanding_receivable_amount_bcy { get; set; }
        /// <summary>
        /// Gets or sets the outstanding_payable_amount.
        /// </summary>
        /// <value>The outstanding_payable_amount.</value>
        public double outstanding_payable_amount { get; set; }
        /// <summary>
        /// Gets or sets the outstanding_payable_amount_bcy.
        /// </summary>
        /// <value>The outstanding_payable_amount_bcy.</value>
        public double outstanding_payable_amount_bcy { get; set; }
        /// <summary>
        /// Gets or sets the unused_credits_receivable_amount.
        /// </summary>
        /// <value>The unused_credits_receivable_amount.</value>
        public double unused_credits_receivable_amount { get; set; }
        /// <summary>
        /// Gets or sets the unused_credits_receivable_amount_bcy.
        /// </summary>
        /// <value>The unused_credits_receivable_amount_bcy.</value>
        public double unused_credits_receivable_amount_bcy { get; set; }
        /// <summary>
        /// Gets or sets the unused_credits_payable_amount.
        /// </summary>
        /// <value>The unused_credits_payable_amount.</value>
        public double unused_credits_payable_amount { get; set; }
        /// <summary>
        /// Gets or sets the unused_credits_payable_amount_bcy.
        /// </summary>
        /// <value>The unused_credits_payable_amount_bcy.</value>
        public double unused_credits_payable_amount_bcy { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is payment_reminder_enabled.
        /// </summary>
        /// <value><c>true</c> if payment_reminder_enabled; otherwise, <c>false</c>.</value>
        public bool payment_reminder_enabled { get; set; }
        /// <summary>
        /// Gets or sets the custom_fields.
        /// </summary>
        /// <value>The custom_fields.</value>
        public List<CustomField> custom_fields { get; set; }
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
        /// Gets or sets the contact_persons.
        /// </summary>
        /// <value>The contact_persons.</value>
        public List<ContactPerson> contact_persons { get; set; }
        /// <summary>
        /// Gets or sets the default_templates.
        /// </summary>
        /// <value>The default_templates.</value>
        public DefaultTemplates default_templates { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }
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
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is track_1099.
        /// </summary>
        /// <value><c>true</c> if track_1099; otherwise, <c>false</c>.</value>
        public bool track_1099 { get; set; }
        /// <summary>
        /// Gets or sets the tax_id_type.
        /// </summary>
        /// <value>The tax_id_type.</value>
        public string tax_id_type { get; set; }
        /// <summary>
        /// Gets or sets the tax_id_value.
        /// </summary>
        /// <value>The tax_id_value.</value>
        public string tax_id_value { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Contact" /> is snail_mail.
        /// </summary>
        /// <value><c>true</c> if snail_mail; otherwise, <c>false</c>.</value>
        public bool snail_mail { get; set; }
    }
}
