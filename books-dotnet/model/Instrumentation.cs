namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of Instrumentation.
    /// </summary>
    public class Instrumentation
    {
        /// <summary>
        ///     Gets or sets the query_execution_time.
        /// </summary>
        /// <value>The query_execution_time.</value>
        public int query_execution_time { get; set; }

        /// <summary>
        ///     Gets or sets the request_handling_time.
        /// </summary>
        /// <value>The request_handling_time.</value>
        public int request_handling_time { get; set; }

        /// <summary>
        ///     Gets or sets the response_write_time.
        /// </summary>
        /// <value>The response_write_time.</value>
        public int response_write_time { get; set; }

        /// <summary>
        ///     Gets or sets the page_context_write_time.
        /// </summary>
        /// <value>The page_context_write_time.</value>
        public int page_context_write_time { get; set; }
    }
}