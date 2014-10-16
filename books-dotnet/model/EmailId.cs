using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class EmailId.
    /// </summary>
    public class EmailId
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EmailId"/> is is_selected.
        /// </summary>
        /// <value><c>true</c> if is_selected; otherwise, <c>false</c>.</value>
        public bool is_selected { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }
    }

}
