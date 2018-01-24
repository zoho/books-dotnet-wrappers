using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Class ExpenseList.
    /// </summary>
    public class ExpenseList : List<Expense>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}