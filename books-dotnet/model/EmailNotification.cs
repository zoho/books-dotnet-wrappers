using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of EmailNotification.
    /// </summary>
    public class EmailNotification
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EmailNotification" /> is send_from_org_email_id.
        /// </summary>
        /// <value><c>true</c> if send_from_org_email_id; otherwise, <c>false</c>.</value>
        public bool send_from_org_email_id { get; set; }
        /// <summary>
        /// Gets or sets the to_mail_ids.
        /// </summary>
        /// <value>The to_mail_ids.</value>
        public List<string> to_mail_ids { get; set; }
        /// <summary>
        /// Gets or sets the cc_mail_ids.
        /// </summary>
        /// <value>The cc_mail_ids.</value>
        public List<string> cc_mail_ids { get; set; }
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
    }
}
