using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of PaymentOptions.
    /// </summary>
    public class PaymentOptions
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int code { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public int message { get; set; }

        /// <summary>
        ///     Gets or sets the payment_gateways.
        /// </summary>
        /// <value>The payment_gateways.</value>
        public List<PaymentGateway> payment_gateways { get; set; }
    }
}