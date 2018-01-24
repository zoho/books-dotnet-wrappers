using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of User.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Gets or sets the user_id.
        /// </summary>
        /// <value>The user_id.</value>
        public string user_id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="User" /> is is_current_user.
        /// </summary>
        /// <value><c>true</c> if is_current_user; otherwise, <c>false</c>.</value>
        public bool is_current_user { get; set; }

        /// <summary>
        ///     Gets or sets the user_name.
        /// </summary>
        /// <value>The user_name.</value>
        public string user_name { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }

        /// <summary>
        ///     Gets or sets the user_role.
        /// </summary>
        /// <value>The user_role.</value>
        public string user_role { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }

        /// <summary>
        ///     Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double rate { get; set; }

        /// <summary>
        ///     Gets or sets the budget_hours.
        /// </summary>
        /// <value>The budget_hours.</value>
        public int budget_hours { get; set; }

        /// <summary>
        ///     Gets or sets the total_hours.
        /// </summary>
        /// <value>The total_hours.</value>
        public string total_hours { get; set; }

        /// <summary>
        ///     Gets or sets the billed_hours.
        /// </summary>
        /// <value>The billed_hours.</value>
        public string billed_hours { get; set; }

        /// <summary>
        ///     Gets or sets the un_billed_hours.
        /// </summary>
        /// <value>The un_billed_hours.</value>
        public string un_billed_hours { get; set; }

        /// <summary>
        ///     Gets or sets the role_id.
        /// </summary>
        /// <value>The role_id.</value>
        public string role_id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }

        /// <summary>
        ///     Gets or sets the email_ids.
        /// </summary>
        /// <value>The email_ids.</value>
        public List<EmailId> email_ids { get; set; }

        /// <summary>
        ///     Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }

        /// <summary>
        ///     Gets or sets the photo_url.
        /// </summary>
        /// <value>The photo_url.</value>
        public string photo_url { get; set; }

        /// <summary>
        ///     Gets or sets the billable_hours.
        /// </summary>
        /// <value>The billable_hours.</value>
        public string billable_hours { get; set; }

        /// <summary>
        ///     Gets or sets the non_billable_hours.
        /// </summary>
        /// <value>The non_billable_hours.</value>
        public string non_billable_hours { get; set; }

        /// <summary>
        ///     Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
    }
}