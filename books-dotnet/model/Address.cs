namespace zohobooks.model
{
    /// <summary>
    ///     Class Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        ///     Gets or sets the street_address1.
        /// </summary>
        /// <value>The street_address1.</value>
        public string street_address1 { get; set; }

        /// <summary>
        ///     Gets or sets the street_address2.
        /// </summary>
        /// <value>The street_address2.</value>
        public string street_address2 { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string city { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string state { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string country { get; set; }

        /// <summary>
        ///     Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string zip { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string address { get; set; }

        /// <summary>
        ///     Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string fax { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Address" /> is is_update_customer.
        /// </summary>
        /// <value><c>true</c> if is_update_customer; otherwise, <c>false</c>.</value>
        public object is_update_customer { get; set; }

        /// <summary>
        ///     Gets or sets the organization_address_id.
        /// </summary>
        /// <value>The organization_address_id.</value>
        public string organization_address_id { get; set; }

        /// <summary>
        ///     Gets or sets the attention.
        /// </summary>
        /// <value>The attention.</value>
        public string attention { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string phone { get; set; }
    }
}