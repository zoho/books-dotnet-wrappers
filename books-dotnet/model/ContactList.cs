using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class ContactList.
    /// </summary>
    public class ContactList : List<Contact>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}