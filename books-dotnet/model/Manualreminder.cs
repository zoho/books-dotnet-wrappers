using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class Manualreminder.
    /// </summary>
    public class ManualReminder
    {
        /// <summary>
        /// Gets or sets the manualreminder_id.
        /// </summary>
        /// <value>The manualreminder_id.</value>
        public string manualreminder_id { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string type { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string subject { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string body { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ManualReminder"/> is cc_me.
        /// </summary>
        /// <value><c>true</c> if cc_me; otherwise, <c>false</c>.</value>
        public bool cc_me { get; set; }
    }
}
