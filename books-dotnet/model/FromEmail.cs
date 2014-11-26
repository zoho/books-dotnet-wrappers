using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of FromEmail.
    /// </summary>
    public class FromEmail
    {
        /// <summary>
        /// Gets or sets the user_name.
        /// </summary>
        /// <value>The user_name.</value>
        public string user_name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FromEmail" /> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool selected { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FromEmail"/> is is_org_email_id.
        /// </summary>
        /// <value><c>true</c> if is_org_email_id; otherwise, <c>false</c>.</value>
        public bool is_org_email_id { get; set; }
    }
}
