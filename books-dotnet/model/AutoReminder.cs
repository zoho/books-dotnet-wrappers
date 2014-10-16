using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Class AutoReminder.
    /// </summary>
    public class AutoReminder
    {
        /// <summary>
        /// Gets or sets the payment_reminder_id.
        /// </summary>
        /// <value>The payment_reminder_id.</value>
        public string payment_reminder_id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AutoReminder"/> is is_enabled.
        /// </summary>
        /// <value><c>true</c> if is_enabled; otherwise, <c>false</c>.</value>
        public bool is_enabled { get; set; }
        /// <summary>
        /// Gets or sets the notification_type.
        /// </summary>
        /// <value>The notification_type.</value>
        public string notification_type { get; set; }
        /// <summary>
        /// Gets or sets the notification_type_formatted.
        /// </summary>
        /// <value>The notification_type_formatted.</value>
        public string notification_type_formatted { get; set; }
        /// <summary>
        /// Gets or sets the address_type.
        /// </summary>
        /// <value>The address_type.</value>
        public string address_type { get; set; }
        /// <summary>
        /// Gets or sets the address_type_formatted.
        /// </summary>
        /// <value>The address_type_formatted.</value>
        public string address_type_formatted { get; set; }
        /// <summary>
        /// Gets or sets the number_of_days.
        /// </summary>
        /// <value>The number_of_days.</value>
        public int number_of_days { get; set; }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string subject { get; set; }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string body { get; set; }
        /// <summary>
        /// Gets or sets the autoreminder_id.
        /// </summary>
        /// <value>The autoreminder_id.</value>
        public string autoreminder_id { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string type { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int order { get; set; }
    }
}
