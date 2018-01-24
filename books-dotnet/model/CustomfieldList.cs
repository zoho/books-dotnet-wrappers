using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class Customfields.
    /// </summary>
    public class CustomFieldList
    {
        /// <summary>
        ///     Gets or sets the invoice.
        /// </summary>
        /// <value>The invoice.</value>
        public List<CustomField> invoice { get; set; }

        /// <summary>
        ///     Gets or sets the contact.
        /// </summary>
        /// <value>The contact.</value>
        public List<CustomField> contact { get; set; }

        /// <summary>
        ///     Gets or sets the estimate.
        /// </summary>
        /// <value>The estimate.</value>
        public List<CustomField> estimate { get; set; }
    }
}