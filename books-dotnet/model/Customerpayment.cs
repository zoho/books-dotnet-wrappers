using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Customerpayment.
    /// </summary>
    public class CustomerPayment
    {
        /// <summary>
        /// Gets or sets the payment_id.
        /// </summary>
        /// <value>The payment_id.</value>
        public string payment_id { get; set; }
        /// <summary>
        /// Gets or sets the payment_number.
        /// </summary>
        /// <value>The payment_number.</value>
        public string payment_number { get; set; }
        /// <summary>
        /// Gets or sets the invoice_numbers.
        /// </summary>
        /// <value>The invoice_numbers.</value>
        public string invoice_numbers { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the payment_mode.
        /// </summary>
        /// <value>The payment_mode.</value>
        public string payment_mode { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the bcy_amount.
        /// </summary>
        /// <value>The bcy_amount.</value>
        public double bcy_amount { get; set; }
        /// <summary>
        /// Gets or sets the unused_amount.
        /// </summary>
        /// <value>The unused_amount.</value>
        public double unused_amount { get; set; }
        /// <summary>
        /// Gets or sets the bcy_unused_amount.
        /// </summary>
        /// <value>The bcy_unused_amount.</value>
        public double bcy_unused_amount { get; set; }
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
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
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets the bank_charges.
        /// </summary>
        /// <value>The bank_charges.</value>
        public double bank_charges { get; set; }
        /// <summary>
        /// Gets or sets the tax_account_id.
        /// </summary>
        /// <value>The tax_account_id.</value>
        public string tax_account_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_account_name.
        /// </summary>
        /// <value>The tax_account_name.</value>
        public string tax_account_name { get; set; }
        /// <summary>
        /// Gets or sets the tax_amount_withheld.
        /// </summary>
        /// <value>The tax_amount_withheld.</value>
        public double tax_amount_withheld { get; set; }
        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>The invoices.</value>
        public List<Invoice> invoices { get; set; }
        /// <summary>
        /// Custom fields to send for payment
        /// </summary>
        public List<CustomField> custom_fields { get; set; }

    }

}
