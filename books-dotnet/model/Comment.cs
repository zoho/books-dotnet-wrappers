using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the comment_id.
        /// </summary>
        /// <value>The comment_id.</value>
        public string comment_id { get; set; }
        /// <summary>
        /// Gets or sets the contact_id.
        /// </summary>
        /// <value>The contact_id.</value>
        public string contact_id { get; set; }
        /// <summary>
        /// Gets or sets the estimate_id.
        /// </summary>
        /// <value>The estimate_id.</value>
        public string estimate_id { get; set; }
        /// <summary>
        /// Gets or sets the creditnote_id.
        /// </summary>
        /// <value>The creditnote_id.</value>
        public string creditnote_id { get; set; }
        /// <summary>
        /// Gets or sets the contact_name.
        /// </summary>
        /// <value>The contact_name.</value>
        public string contact_name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the commented_by_id.
        /// </summary>
        /// <value>The commented_by_id.</value>
        public string commented_by_id { get; set; }
        /// <summary>
        /// Gets or sets the commented_by.
        /// </summary>
        /// <value>The commented_by.</value>
        public string commented_by { get; set; }
        /// <summary>
        /// Gets or sets the comment_type.
        /// </summary>
        /// <value>The comment_type.</value>
        public string comment_type { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }
        /// <summary>
        /// Gets or sets the date_description.
        /// </summary>
        /// <value>The date_description.</value>
        public string date_description { get; set; }
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public string time { get; set; }
        /// <summary>
        /// Gets or sets the transaction_id.
        /// </summary>
        /// <value>The transaction_id.</value>
        public string transaction_id { get; set; }
        /// <summary>
        /// Gets or sets the transaction_type.
        /// </summary>
        /// <value>The transaction_type.</value>
        public string transaction_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Comment" /> is is_entity_deleted.
        /// </summary>
        /// <value><c>true</c> if is_entity_deleted; otherwise, <c>false</c>.</value>
        public bool is_entity_deleted { get; set; }
        /// <summary>
        /// Gets or sets the operation_type.
        /// </summary>
        /// <value>The operation_type.</value>
        public string operation_type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Comment" /> is show_comment_to_clients.
        /// </summary>
        /// <value><c>true</c> if show_comment_to_clients; otherwise, <c>false</c>.</value>
        public bool show_comment_to_clients { get; set; }
        /// <summary>
        /// Gets or sets the payment_expected_date.
        /// </summary>
        /// <value>The payment_expected_date.</value>
        public string payment_expected_date { get; set; }
        /// <summary>
        /// Gets or sets the expense_id.
        /// </summary>
        /// <value>The expense_id.</value>
        public string expense_id { get; set; }
        /// <summary>
        /// Gets or sets the bill_id.
        /// </summary>
        /// <value>The bill_id.</value>
        public string bill_id { get; set; }
        /// <summary>
        /// Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Comment" /> is is_current_user.
        /// </summary>
        /// <value><c>true</c> if is_current_user; otherwise, <c>false</c>.</value>
        public bool is_current_user { get; set; }
    }
}
