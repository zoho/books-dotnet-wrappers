namespace zohobooks.model
{
    /// <summary>
    ///     Class TaxExemption.
    /// </summary>
    public class TaxExemption
    {
        /// <summary>
        ///     Gets or sets the tax_exemption_id.
        /// </summary>
        /// <value>The tax_exemption_id.</value>
        public string tax_exemption_id { get; set; }

        /// <summary>
        ///     Gets or sets the tax_exemption_code.
        /// </summary>
        /// <value>The tax_exemption_code.</value>
        public string tax_exemption_code { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string type { get; set; }
    }
}