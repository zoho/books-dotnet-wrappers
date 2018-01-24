using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of Contacts.
    /// </summary>
    public class Contacts
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public int code { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public int message { get; set; }

        /// <summary>
        ///     Gets or sets the contacts.
        /// </summary>
        /// <value>The contacts.</value>
        public List<Contact> contacts { get; set; }
    }
}