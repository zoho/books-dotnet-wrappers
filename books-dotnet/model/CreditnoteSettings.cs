namespace zohobooks.model
{
    /// <summary>
    ///     Class CreditnoteSettings.
    /// </summary>
    public class CreditNoteSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="CreditNoteSettings" /> is auto_generate.
        /// </summary>
        /// <value><c>true</c> if auto_generate; otherwise, <c>false</c>.</value>
        public bool auto_generate { get; set; }

        /// <summary>
        ///     Gets or sets the prefix_string.
        /// </summary>
        /// <value>The prefix_string.</value>
        public string prefix_string { get; set; }

        /// <summary>
        ///     Gets or sets the reference_text.
        /// </summary>
        /// <value>The reference_text.</value>
        public string reference_text { get; set; }

        /// <summary>
        ///     Gets or sets the next_number.
        /// </summary>
        /// <value>The next_number.</value>
        public string next_number { get; set; }

        /// <summary>
        ///     Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }

        /// <summary>
        ///     Gets or sets the terms.
        /// </summary>
        /// <value>The terms.</value>
        public string terms { get; set; }
    }
}