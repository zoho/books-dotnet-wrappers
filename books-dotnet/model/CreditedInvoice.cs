namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of CreditedInvoice.
    /// </summary>
    public class CreditedInvoice
    {
        /// <summary>
        ///     Gets or sets the creditnote_id.
        /// </summary>
        /// <value>The creditnote_id.</value>
        public string creditnote_id { get; set; }

        /// <summary>
        ///     Gets or sets the invoice_id.
        /// </summary>
        /// <value>The invoice_id.</value>
        public string invoice_id { get; set; }

        /// <summary>
        ///     Gets or sets the creditnote_invoice_id.
        /// </summary>
        /// <value>The creditnote_invoice_id.</value>
        public string creditnote_invoice_id { get; set; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string date { get; set; }

        /// <summary>
        ///     Gets or sets the invoice_number.
        /// </summary>
        /// <value>The invoice_number.</value>
        public string invoice_number { get; set; }

        /// <summary>
        ///     Gets or sets the creditnote_number.
        /// </summary>
        /// <value>The creditnote_number.</value>
        public string creditnote_number { get; set; }

        /// <summary>
        ///     Gets or sets the credited_amount.
        /// </summary>
        /// <value>The credited_amount.</value>
        public double credited_amount { get; set; }

        /// <summary>
        ///     Gets or sets the amount_applied.
        /// </summary>
        /// <value>The amount_applied.</value>
        public double amount_applied { get; set; }
    }
}