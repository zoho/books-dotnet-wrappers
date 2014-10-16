using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Class RecurringInvoiceList.
    /// </summary>
    public class RecurringInvoiceList:List<RecurringInvoice>
    {
        /// <summary>
        /// Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}
