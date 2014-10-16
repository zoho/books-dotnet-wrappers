using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class OpeningBalance.
    /// </summary>
    public class OpeningBalance
    {
        /// <summary>
        /// Gets or sets the opening_balance_id.
        /// </summary>
        /// <value>The opening_balance_id.</value>
        public string opening_balance_id { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public List<Account> accounts { get; set; }
    }
}
