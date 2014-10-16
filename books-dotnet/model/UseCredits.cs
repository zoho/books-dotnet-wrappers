using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of UseCredits.
    /// </summary>
    public class UseCredits
    {
        /// <summary>
        /// Gets or sets the invoice_payments.
        /// </summary>
        /// <value>The invoice_payments.</value>
        public List<Payment> invoice_payments { get; set; }
        /// <summary>
        /// Gets or sets the apply_creditnotes.
        /// </summary>
        /// <value>The apply_creditnotes.</value>
        public List<CreditNote> apply_creditnotes { get; set; }
        /// <summary>
        /// Gets or sets the bill_payments.
        /// </summary>
        /// <value>The bill_payments.</value>
        public List<Payment> bill_payments { get; set; }
    }
}
