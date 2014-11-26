using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Class VendorCredit.
    /// </summary>
    public class VendorCredit
    {
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
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
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
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public List<Comment> comments { get; set; }
        /// <summary>
        /// Gets or sets the vendor_credit_refunds.
        /// </summary>
        /// <value>The vendor_credit_refunds.</value>
        public List<VendorCreditRefund> vendor_credit_refunds { get; set; }
        /// <summary>
        /// Gets or sets the bills_credited.
        /// </summary>
        /// <value>The bills_credited.</value>
        public List<Bill> bills_credited { get; set; }
    }
}
