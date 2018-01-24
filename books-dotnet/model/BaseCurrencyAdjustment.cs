using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of BaseCurrencyAdjustment.
    /// </summary>
    public class BaseCurrencyAdjustment
    {
        /// <summary>
        ///     Gets or sets the base_currency_adjustment_id.
        /// </summary>
        /// <value>The base_currency_adjustment_id.</value>
        public string base_currency_adjustment_id { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment_date.
        /// </summary>
        /// <value>The adjustment_date.</value>
        public string adjustment_date { get; set; }

        /// <summary>
        ///     Gets or sets the exchange_rate.
        /// </summary>
        /// <value>The exchange_rate.</value>
        public double exchange_rate { get; set; }

        /// <summary>
        ///     Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }

        /// <summary>
        ///     Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }

        /// <summary>
        ///     Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }

        /// <summary>
        ///     Gets or sets the gain_or_loss.
        /// </summary>
        /// <value>The gain_or_loss.</value>
        public double gain_or_loss { get; set; }

        /// <summary>
        ///     Gets or sets the adjustment_date_formatted.
        /// </summary>
        /// <value>The adjustment_date_formatted.</value>
        public string adjustment_date_formatted { get; set; }

        /// <summary>
        ///     Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public List<Account> accounts { get; set; }

        /// <summary>
        ///     Gets or sets the exchange_rate_formatted.
        /// </summary>
        /// <value>The exchange_rate_formatted.</value>
        public string exchange_rate_formatted { get; set; }
    }
}