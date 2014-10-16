using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Account.
    /// </summary>
    public class Account
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
        /// Gets or sets the bcy_balance.
        /// </summary>
        /// <value>The bcy_balance.</value>
        public double bcy_balance { get; set; }
        /// <summary>
        /// Gets or sets the bcy_balance_formatted.
        /// </summary>
        /// <value>The bcy_balance_formatted.</value>
        public string bcy_balance_formatted { get; set; }
        /// <summary>
        /// Gets or sets the fcy_balance.
        /// </summary>
        /// <value>The fcy_balance.</value>
        public double fcy_balance { get; set; }
        /// <summary>
        /// Gets or sets the fcy_balance_formatted.
        /// </summary>
        /// <value>The fcy_balance_formatted.</value>
        public string fcy_balance_formatted { get; set; }
        /// <summary>
        /// Gets or sets the adjusted_balance.
        /// </summary>
        /// <value>The adjusted_balance.</value>
        public double adjusted_balance { get; set; }
        /// <summary>
        /// Gets or sets the adjusted_balance_formatted.
        /// </summary>
        /// <value>The adjusted_balance_formatted.</value>
        public string adjusted_balance_formatted { get; set; }
        /// <summary>
        /// Gets or sets the gain_or_loss.
        /// </summary>
        /// <value>The gain_or_loss.</value>
        public double gain_or_loss { get; set; }
        /// <summary>
        /// Gets or sets the gain_or_loss_formatted.
        /// </summary>
        /// <value>The gain_or_loss_formatted.</value>
        public string gain_or_loss_formatted { get; set; }
        /// <summary>
        /// Gets or sets the gl_specific_type.
        /// </summary>
        /// <value>The gl_specific_type.</value>
        public int gl_specific_type { get; set; }
        /// <summary>
        /// Gets or sets the account_split_id.
        /// </summary>
        /// <value>The account_split_id.</value>
        public string account_split_id { get; set; }
        /// <summary>
        /// Gets or sets the debit_or_credit.
        /// </summary>
        /// <value>The debit_or_credit.</value>
        public string debit_or_credit { get; set; }
        /// <summary>
        /// Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }
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
        /// Gets or sets the bcy_amount.
        /// </summary>
        /// <value>The bcy_amount.</value>
        public double bcy_amount { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double amount { get; set; }       
    }
}
