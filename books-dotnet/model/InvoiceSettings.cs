namespace zohobooks.model
{
    /// <summary>
    ///     Class InvoiceSettings.
    /// </summary>
    public class InvoiceSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is auto_generate.
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
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_discount_before_tax.
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
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_shipping_charge_required.
        /// </summary>
        /// <value><c>true</c> if is_shipping_charge_required; otherwise, <c>false</c>.</value>
        public bool is_shipping_charge_required { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_adjustment_required.
        /// </summary>
        /// <value><c>true</c> if is_adjustment_required; otherwise, <c>false</c>.</value>
        public bool is_adjustment_required { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_open_invoice_editable.
        /// </summary>
        /// <value><c>true</c> if is_open_invoice_editable; otherwise, <c>false</c>.</value>
        public bool is_open_invoice_editable { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is warn_convert_to_open.
        /// </summary>
        /// <value><c>true</c> if warn_convert_to_open; otherwise, <c>false</c>.</value>
        public bool warn_convert_to_open { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is warn_create_creditnotes.
        /// </summary>
        /// <value><c>true</c> if warn_create_creditnotes; otherwise, <c>false</c>.</value>
        public bool warn_create_creditnotes { get; set; }

        /// <summary>
        ///     Gets or sets the attach_expense_receipt_to_invoice.
        /// </summary>
        /// <value>The attach_expense_receipt_to_invoice.</value>
        public string attach_expense_receipt_to_invoice { get; set; }

        /// <summary>
        ///     Gets or sets the invoice_item_type.
        /// </summary>
        /// <value>The invoice_item_type.</value>
        public string invoice_item_type { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_sales_person_required.
        /// </summary>
        /// <value><c>true</c> if is_sales_person_required; otherwise, <c>false</c>.</value>
        public bool is_sales_person_required { get; set; }

        /// <summary>
        ///     Gets or sets the discount_enabled.
        /// </summary>
        /// <value>The discount_enabled.</value>
        public string discount_enabled { get; set; }

        /// <summary>
        ///     Gets or sets the default_template_id.
        /// </summary>
        /// <value>The default_template_id.</value>
        public string default_template_id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is warn_attach_expense_receipt.
        /// </summary>
        /// <value><c>true</c> if warn_attach_expense_receipt; otherwise, <c>false</c>.</value>
        public bool warn_attach_expense_receipt { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="InvoiceSettings" /> is is_show_invoice_setup.
        /// </summary>
        /// <value><c>true</c> if is_show_invoice_setup; otherwise, <c>false</c>.</value>
        public bool is_show_invoice_setup { get; set; }
    }
}