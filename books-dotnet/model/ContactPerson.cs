namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of ContactPerson.
    /// </summary>
    public class ContactPerson
    {
        /// <summary>
        ///     Gets or sets the contact_id.
        /// </summary>
        /// <value>The contact_id.</value>
        public string contact_id { get; set; }

        /// <summary>
        ///     Gets or sets the contact_person_id.
        /// </summary>
        /// <value>The contact_person_id.</value>
        public string contact_person_id { get; set; }

        /// <summary>
        ///     Gets or sets the salutation.
        /// </summary>
        /// <value>The salutation.</value>
        public string salutation { get; set; }

        /// <summary>
        ///     Gets or sets the first_name.
        /// </summary>
        /// <value>The first_name.</value>
        public string first_name { get; set; }

        /// <summary>
        ///     Gets or sets the last_name.
        /// </summary>
        /// <value>The last_name.</value>
        public string last_name { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string email { get; set; }

        /// <summary>
        ///     Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string phone { get; set; }

        /// <summary>
        ///     Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public string mobile { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ContactPerson" /> is is_primary_contact.
        /// </summary>
        /// <value><c>true</c> if is_primary_contact; otherwise, <c>false</c>.</value>
        public bool is_primary_contact { get; set; }
    }
}