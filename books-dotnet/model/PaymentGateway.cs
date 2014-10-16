using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of PaymentGateway.
    /// </summary>
    public class PaymentGateway
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PaymentGateway" /> is configured.
        /// </summary>
        /// <value><c>true</c> if configured; otherwise, <c>false</c>.</value>
        public bool configured { get; set; }
        /// <summary>
        /// Gets or sets the additional_field1.
        /// </summary>
        /// <value>The additional_field1.</value>
        public string additional_field1 { get; set; }
        /// <summary>
        /// Gets or sets the gateway_name.
        /// </summary>
        /// <value>The gateway_name.</value>
        public string gateway_name { get; set; }
    }
}
