namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of Emailtemplate.
    /// </summary>
    public class EmailTemplate
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EmailTemplate" /> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool selected { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }

        /// <summary>
        ///     Gets or sets the email_template_id.
        /// </summary>
        /// <value>The email_template_id.</value>
        public string email_template_id { get; set; }
    }
}