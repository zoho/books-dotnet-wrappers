using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Class VendorPaymentList.
    /// </summary>
    public class VendorPaymentList:List<VendorPayment>
    {
        /// <summary>
        /// Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}
