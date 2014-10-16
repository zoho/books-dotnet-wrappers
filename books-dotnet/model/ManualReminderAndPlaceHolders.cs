using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class ManualReminderAndPlaceHolders.
    /// </summary>
    public class ManualReminderAndPlaceHolders
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int code { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string message { get; set; }
        /// <summary>
        /// Gets or sets the manualreminder.
        /// </summary>
        /// <value>The manualreminder.</value>
        public ManualReminder manualreminder { get; set; }
        /// <summary>
        /// Gets or sets the placeholders.
        /// </summary>
        /// <value>The placeholders.</value>
        public PlaceHolders placeholders { get; set; }
    }
}
