using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of VendorPayment.
    /// </summary>
    public class VendorPayment
    {
        /// <summary>
        /// Gets or sets the payment_id.
        /// </summary>
        /// <value>The payment_id.</value>
        public string payment_id { get; set; }
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
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public double balance { get; set; }
        /// <summary>
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the bills.
        /// </summary>
        /// <value>The bills.</value>
        public List<Bill> bills { get; set; }
    }
}
