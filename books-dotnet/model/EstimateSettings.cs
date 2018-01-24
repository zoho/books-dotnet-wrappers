namespace zohobooks.model
{
    /// <summary>
    ///     Class EstimateSettings.
    /// </summary>
    public class EstimateSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is auto_generate.
        /// </summary>
        /// <value><c>true</c> if auto_generate; otherwise, <c>false</c>.</value>
        public bool auto_generate { get; set; }

        /// <summary>
        ///     Gets or sets the prefix_string.
        /// </summary>
        /// <value>The prefix_string.</value>
        public string prefix_string { get; set; }

        /// <summary>
        ///     Gets or sets the start_at.
        /// </summary>
        /// <value>The start_at.</value>
        public int start_at { get; set; }

        /// <summary>
        ///     Gets or sets the next_number.
        /// </summary>
        /// <value>The next_number.</value>
        public string next_number { get; set; }

        /// <summary>
        ///     Gets or sets the quantity_precision.
        /// </summary>
        /// <value>The quantity_precision.</value>
        public int quantity_precision { get; set; }

        /// <summary>
        ///     Gets or sets the discount_type.
        /// </summary>
        /// <value>The discount_type.</value>
        public string discount_type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is is_discount_before_tax.
        /// </summary>
        /// <value><c>true</c> if is_discount_before_tax; otherwise, <c>false</c>.</value>
        public bool is_discount_before_tax { get; set; }

        /// <summary>
        ///     Gets or sets the reference_text.
        /// </summary>
        /// <value>The reference_text.</value>
        public string reference_text { get; set; }

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

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is terms_to_invoice.
        /// </summary>
        /// <value><c>true</c> if terms_to_invoice; otherwise, <c>false</c>.</value>
        public bool terms_to_invoice { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is notes_to_invoice.
        /// </summary>
        /// <value><c>true</c> if notes_to_invoice; otherwise, <c>false</c>.</value>
        public bool notes_to_invoice { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is warn_estimate_to_invoice.
        /// </summary>
        /// <value><c>true</c> if warn_estimate_to_invoice; otherwise, <c>false</c>.</value>
        public bool warn_estimate_to_invoice { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is is_sales_person_required.
        /// </summary>
        /// <value><c>true</c> if is_sales_person_required; otherwise, <c>false</c>.</value>
        public bool is_sales_person_required { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="EstimateSettings" /> is convert_to_invoice.
        /// </summary>
        /// <value><c>true</c> if convert_to_invoice; otherwise, <c>false</c>.</value>
        public bool convert_to_invoice { get; set; }
    }
}