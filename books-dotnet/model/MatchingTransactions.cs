using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of MatchingTransactions.
    /// </summary>
    public class MatchingTransactions : List<Transaction>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }

        /// <summary>
        ///     Gets or sets the instrumentation.
        /// </summary>
        /// <value>The instrumentation.</value>
        public Instrumentation instrumentation { get; set; }
    }
}