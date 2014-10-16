using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of EmailStatementData.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string body { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Email" /> is gateways_configured.
        /// </summary>
        /// <value><c>true</c> if gateways_configured; otherwise, <c>false</c>.</value>
        public bool gateways_configured { get; set; }
        /// <summary>
        /// Gets or sets the deprecated_placeholders_used.
        /// </summary>
        /// <value>The deprecated_placeholders_used.</value>
        public List<object> deprecated_placeholders_used { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Email" /> is gateways_associated.
        /// </summary>
        /// <value><c>true</c> if gateways_associated; otherwise, <c>false</c>.</value>
        public bool gateways_associated { get; set; }
        /// <summary>
        /// Gets or sets the error_list.
        /// </summary>
        /// <value>The error_list.</value>
        public List<string> error_list { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string subject { get; set; }
        /// <summary>
        /// Gets or sets the emailtemplates.
        /// </summary>
        /// <value>The emailtemplates.</value>
        public List<EmailTemplate> emailtemplates { get; set; }
        /// <summary>
        /// Gets or sets the to_contacts.
        /// </summary>
        /// <value>The to_contacts.</value>
        public List<ToContact> to_contacts { get; set; }
        /// <summary>
        /// Gets or sets the attachment_name.
        /// </summary>
        /// <value>The attachment_name.</value>
        public string attachment_name { get; set; }
        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>The file_name.</value>
        public string file_name { get; set; }
        /// <summary>
        /// Gets or sets the from_emails.
        /// </summary>
        /// <value>The from_emails.</value>
        public List<FromEmail> from_emails { get; set; }
        /// <summary>
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
        /// <summary>
        /// Gets or sets the contact_id.
        /// </summary>
        /// <value>The contact_id.</value>
        public string contact_id { get; set; }
        /// <summary>
        /// Gets or sets the __invalid_name__subject.
        /// </summary>
        /// <value>The __invalid_name__subject.</value>
        public string __invalid_name__subject { get; set; }
    }
}
