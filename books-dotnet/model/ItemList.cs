using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class ItemsList.
    /// </summary>
    public class ItemList:List<LineItem>
    {
        /// <summary>
        /// Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}
