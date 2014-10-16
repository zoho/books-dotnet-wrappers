using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of ApplyToInvoices.
    /// </summary>
    public class ApplyToInvoices
    {
        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>The invoices.</value>
        public List<CreditedInvoice> invoices { get; set; }
    }
}
