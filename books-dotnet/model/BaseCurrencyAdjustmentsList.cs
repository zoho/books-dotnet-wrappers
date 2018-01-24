using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of ListOfBaseCurrencyAdjustments.
    /// </summary>
    public class BaseCurrencyAdjustmentsList : List<BaseCurrencyAdjustment>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}