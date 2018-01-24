using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class VendorCreditRefundList.
    /// </summary>
    public class VendorCreditRefundList : List<VendorCreditRefund>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}