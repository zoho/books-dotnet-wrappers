using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of ChartOfAccount.
    /// </summary>
    public class ChartOfAccount
    {
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
        /// Gets or sets the account_type.
        /// </summary>
        /// <value>The account_type.</value>
        public string account_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChartOfAccount" /> is is_active.
        /// </summary>
        /// <value><c>true</c> if is_active; otherwise, <c>false</c>.</value>
        public bool is_active { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChartOfAccount" /> is is_user_created.
        /// </summary>
        /// <value><c>true</c> if is_user_created; otherwise, <c>false</c>.</value>
        public bool is_user_created { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChartOfAccount" /> is is_involved_in_transaction.
        /// </summary>
        /// <value><c>true</c> if is_involved_in_transaction; otherwise, <c>false</c>.</value>
        public bool is_involved_in_transaction { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ChartOfAccount" /> is is_system_account.
        /// </summary>
        /// <value><c>true</c> if is_system_account; otherwise, <c>false</c>.</value>
        public bool is_system_account { get; set; }
        /// <summary>
        /// Gets or sets the current_balance.
        /// </summary>
        /// <value>The current_balance.</value>
        public double current_balance { get; set; }
        /// <summary>
        /// Gets or sets the account_type_formatted.
        /// </summary>
        /// <value>The account_type_formatted.</value>
        public string account_type_formatted { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the bank_account_number.
        /// </summary>
        /// <value>The bank_account_number.</value>
        public string bank_account_number { get; set; }
        /// <summary>
        /// Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }
    }
}
