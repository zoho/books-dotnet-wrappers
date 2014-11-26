using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of ProjectTask.
    /// </summary>
    public class ProjectTask
    {
        /// <summary>
        /// Gets or sets the task_id.
        /// </summary>
        /// <value>The task_id.</value>
        public string task_id { get; set; }
        /// <summary>
        /// Gets or sets the task_name.
        /// </summary>
        /// <value>The task_name.</value>
        public string task_name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double rate { get; set; }
        /// <summary>
        /// Gets or sets the budget_hours.
        /// </summary>
        /// <value>The budget_hours.</value>
        public int budget_hours { get; set; }
        /// <summary>
        /// Gets or sets the total_hours.
        /// </summary>
        /// <value>The total_hours.</value>
        public string total_hours { get; set; }
        /// <summary>
        /// Gets or sets the billed_hours.
        /// </summary>
        /// <value>The billed_hours.</value>
        public string billed_hours { get; set; }
        /// <summary>
        /// Gets or sets the un_billed_hours.
        /// </summary>
        /// <value>The un_billed_hours.</value>
        public string un_billed_hours { get; set; }
        /// <summary>
        /// Gets or sets the billable_hours.
        /// </summary>
        /// <value>The billable_hours.</value>
        public string billable_hours { get; set; }
        /// <summary>
        /// Gets or sets the non_billable_hours.
        /// </summary>
        /// <value>The non_billable_hours.</value>
        public string non_billable_hours { get; set; }
        /// <summary>
        /// Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
        /// <summary>
        /// Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }
        /// <summary>
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
        /// <summary>
        /// Gets or sets the project_name.
        /// </summary>
        /// <value>The project_name.</value>
        public string project_name { get; set; }
        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }
        /// <summary>
        /// Gets or sets the log_time.
        /// </summary>
        /// <value>The log_time.</value>
        public string log_time { get; set; }
    }
}
