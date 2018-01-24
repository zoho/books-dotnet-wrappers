namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of EmailHistory.
    /// </summary>
    public class EmailHistory
    {
        /// <summary>
        ///     Gets or sets the mailhistory_id.
        /// </summary>
        /// <value>The mailhistory_id.</value>
        public string mailhistory_id { get; set; }

        /// <summary>
        ///     Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public string from { get; set; }

        /// <summary>
        ///     Gets or sets the to_mail_ids.
        /// </summary>
        /// <value>The to_mail_ids.</value>
        public string to_mail_ids { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string subject { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int type { get; set; }
    }
}