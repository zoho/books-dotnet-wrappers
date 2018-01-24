using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class PlaceHolders.
    /// </summary>
    public class PlaceHolders
    {
        /// <summary>
        ///     Gets or sets the invoice.
        /// </summary>
        /// <value>The invoice.</value>
        public List<Invoice> Invoice { get; set; }

        /// <summary>
        ///     Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public List<Customer> Customer { get; set; }

        /// <summary>
        ///     Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        public List<Organization> Organization { get; set; }
    }
}