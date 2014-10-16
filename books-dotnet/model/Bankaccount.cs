using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Bankaccount.
    /// </summary>
    public class BankAccount
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
        /// Gets or sets the account_type.
        /// </summary>
        /// <value>The account_type.</value>
        public string account_type { get; set; }
        /// <summary>
        /// Gets or sets the uncategorized_transactions.
        /// </summary>
        /// <value>The uncategorized_transactions.</value>
        public int uncategorized_transactions { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BankAccount" /> is is_active.
        /// </summary>
        /// <value><c>true</c> if is_active; otherwise, <c>false</c>.</value>
        public bool is_active { get; set; }
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public double balance { get; set; }
        /// <summary>
        /// Gets or sets the bank_name.
        /// </summary>
        /// <value>The bank_name.</value>
        public string bank_name { get; set; }
        /// <summary>
        /// Gets or sets the routing_number.
        /// </summary>
        /// <value>The routing_number.</value>
        public string routing_number { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BankAccount" /> is is_primary_account.
        /// </summary>
        /// <value><c>null</c> if [is_primary_account] contains no value, <c>true</c> if [is_primary_account]; otherwise, <c>false</c>.</value>
        public bool? is_primary_account { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BankAccount" /> is is_paypal_account.
        /// </summary>
        /// <value><c>null</c> if [is_paypal_account] contains no value, <c>true</c> if [is_paypal_account]; otherwise, <c>false</c>.</value>
        public bool? is_paypal_account { get; set; }
        /// <summary>
        /// Gets or sets the paypal_email_address.
        /// </summary>
        /// <value>The paypal_email_address.</value>
        public string paypal_email_address { get; set; }
        /// <summary>
        /// Gets or sets the account_number.
        /// </summary>
        /// <value>The account_number.</value>
        public string account_number { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
    }
}
