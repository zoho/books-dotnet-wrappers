using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of TransactionsToBeMatched.
    /// </summary>
    public class TransactionsToBeMatched
    {
        /// <summary>
        ///     Gets or sets the transactions_to_be_matched.
        /// </summary>
        /// <value>The transactions_to_be_matched.</value>
        public List<Transaction> transactions_to_be_matched { get; set; }
    }
}