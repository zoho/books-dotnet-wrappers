using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of MatchingTransactions.
    /// </summary>
    public class MatchingTransactions:List<Transaction>
    {
        /// <summary>
        /// Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
        /// <summary>
        /// Gets or sets the instrumentation.
        /// </summary>
        /// <value>The instrumentation.</value>
        public Instrumentation instrumentation { get; set; }
    }
}
