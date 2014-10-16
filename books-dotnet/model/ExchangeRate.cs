using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class ExchangeRate.
    /// </summary>
    public class ExchangeRate
    {
        /// <summary>
        /// Gets or sets the exchange_rate_id.
        /// </summary>
        /// <value>The exchange_rate_id.</value>
        public string exchange_rate_id { get; set; }
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
        /// Gets or sets the effective_date.
        /// </summary>
        /// <value>The effective_date.</value>
        public string effective_date { get; set; }
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double rate { get; set; }
    }
}
