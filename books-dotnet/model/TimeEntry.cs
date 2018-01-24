namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of TimeEntry.
    /// </summary>
    public class TimeEntry
    {
        /// <summary>
        ///     Gets or sets the time_entry_id.
        /// </summary>
        /// <value>The time_entry_id.</value>
        public string time_entry_id { get; set; }

        /// <summary>
        ///     Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }

        /// <summary>
        ///     Gets or sets the project_name.
        /// </summary>
        /// <value>The project_name.</value>
        public string project_name { get; set; }

        /// <summary>
        ///     Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }

        /// <summary>
        ///     Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }

        /// <summary>
        ///     Gets or sets the task_id.
        /// </summary>
        /// <value>The task_id.</value>
        public string task_id { get; set; }

        /// <summary>
        ///     Gets or sets the task_name.
        /// </summary>
        /// <value>The task_name.</value>
        public string task_name { get; set; }

        /// <summary>
        ///     Gets or sets the user_id.
        /// </summary>
        /// <value>The user_id.</value>
        public string user_id { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TimeEntry" /> is is_current_user.
        /// </summary>
        /// <value><c>true</c> if is_current_user; otherwise, <c>false</c>.</value>
        public bool is_current_user { get; set; }

        /// <summary>
        ///     Gets or sets the user_name.
        /// </summary>
        /// <value>The user_name.</value>
        public string user_name { get; set; }

        /// <summary>
        ///     Gets or sets the log_date.
        /// </summary>
        /// <value>The log_date.</value>
        public string log_date { get; set; }

        /// <summary>
        ///     Gets or sets the log_date_in_millis.
        /// </summary>
        /// <value>The log_date_in_millis.</value>
        public string log_date_in_millis { get; set; }

        /// <summary>
        ///     Gets or sets the log_time.
        /// </summary>
        /// <value>The log_time.</value>
        public string log_time { get; set; }

        /// <summary>
        ///     Gets or sets the billed_status.
        /// </summary>
        /// <value>The billed_status.</value>
        public string billed_status { get; set; }

        /// <summary>
        ///     Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }

        /// <summary>
        ///     Gets or sets the timer_started_at.
        /// </summary>
        /// <value>The timer_started_at.</value>
        public string timer_started_at { get; set; }

        /// <summary>
        ///     Gets or sets the timer_duration_in_minutes.
        /// </summary>
        /// <value>The timer_duration_in_minutes.</value>
        public object timer_duration_in_minutes { get; set; }

        /// <summary>
        ///     Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }

        /// <summary>
        ///     Gets or sets the start_timer.
        /// </summary>
        /// <value>The start_timer.</value>
        public string start_timer { get; set; }

        /// <summary>
        ///     Gets or sets the begin_time.
        /// </summary>
        /// <value>The begin_time.</value>
        public string begin_time { get; set; }

        /// <summary>
        ///     Gets or sets the end_time.
        /// </summary>
        /// <value>The end_time.</value>
        public string end_time { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TimeEntry" /> is is_billable.
        /// </summary>
        /// <value><c>true</c> if is_billable; otherwise, <c>false</c>.</value>
        public bool is_billable { get; set; }
    }
}