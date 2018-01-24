using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of ApplyToInvoices.
    /// </summary>
    public class ApplyToInvoices
    {
        /// <summary>
        ///     Gets or sets the invoices.
        /// </summary>
        /// <value>The invoices.</value>
        public List<CreditedInvoice> invoices { get; set; }
    }
}