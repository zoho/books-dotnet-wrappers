using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the payment_id.
        /// </summary>
        /// <value>The payment_id.</value>
        public string payment_id { get; set; }
        /// <summary>
        /// Gets or sets the bill_id.
        /// </summary>
        /// <value>The bill_id.</value>
        public string bill_id { get; set; }
        /// <summary>
        /// Gets or sets the bill_payment_id.
        /// </summary>
        /// <value>The bill_payment_id.</value>
        public string bill_payment_id { get; set; }
        /// <summary>
        /// Gets or sets the payment_mode.
        /// </summary>
        /// <value>The payment_mode.</value>
        public string payment_mode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the paid_through_account_id.
        /// </summary>
        /// <value>The paid_through_account_id.</value>
        public string paid_through_account_id { get; set; }
        /// <summary>
        /// Gets or sets the paid_through_account_name.
        /// </summary>
        /// <value>The paid_through_account_name.</value>
        public string paid_through_account_name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Payment" /> is is_single_bill_payment.
        /// </summary>
        /// <value><c>true</c> if is_single_bill_payment; otherwise, <c>false</c>.</value>
        public bool is_single_bill_payment { get; set; }
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
        /// Gets or sets the paid_through.
        /// </summary>
        /// <value>The paid_through.</value>
        public string paid_through { get; set; }
        /// <summary>
        /// Gets or sets the amount_applied.
        /// </summary>
        /// <value>The amount_applied.</value>
        public double amount_applied { get; set; }
        /// <summary>
        /// Gets or sets the payment_number.
        /// </summary>
        /// <value>The payment_number.</value>
        public string payment_number { get; set; }
        /// <summary>
        /// Gets or sets the invoice_id.
        /// </summary>
        /// <value>The invoice_id.</value>
        public string invoice_id { get; set; }
        /// <summary>
        /// Gets or sets the invoice_payment_id.
        /// </summary>
        /// <value>The invoice_payment_id.</value>
        public string invoice_payment_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_amount_withheld.
        /// </summary>
        /// <value>The tax_amount_withheld.</value>
        public double tax_amount_withheld { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Payment" /> is is_single_invoice_payment.
        /// </summary>
        /// <value><c>true</c> if is_single_invoice_payment; otherwise, <c>false</c>.</value>
        public bool is_single_invoice_payment { get; set; }
    }
}
