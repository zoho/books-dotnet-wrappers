using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of PageContext.
    /// </summary>
    public class PageContext
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        public int page { get; set; }
        /// <summary>
        /// Gets or sets the per_page.
        /// </summary>
        /// <value>The per_page.</value>
        public int per_page { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PageContext" /> is has_more_page.
        /// </summary>
        /// <value><c>true</c> if has_more_page; otherwise, <c>false</c>.</value>
        public bool has_more_page { get; set; }
        /// <summary>
        /// Gets or sets the applied_filter.
        /// </summary>
        /// <value>The applied_filter.</value>
        public string applied_filter { get; set; }
        /// <summary>
        /// Gets or sets the sort_column.
        /// </summary>
        /// <value>The sort_column.</value>
        public string sort_column { get; set; }
        /// <summary>
        /// Gets or sets the sort_order.
        /// </summary>
        /// <value>The sort_order.</value>
        public string sort_order { get; set; }
        /// <summary>
        /// Gets or sets the report_name.
        /// </summary>
        /// <value>The report_name.</value>
        public string report_name { get; set; }
    }
}
