using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class ImportedTransaction.
    /// </summary>
    public class ImportedTransaction
    {
        /// <summary>
        /// Gets or sets the imported_transaction_id.
        /// </summary>
        /// <value>The imported_transaction_id.</value>
        public string imported_transaction_id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }
        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        /// <value>The payee.</value>
        public string payee { get; set; }
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
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the account_id.
        /// </summary>
        /// <value>The account_id.</value>
        public string account_id { get; set; }
    }
}
