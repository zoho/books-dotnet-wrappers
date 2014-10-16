using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the project_id.
        /// </summary>
        /// <value>The project_id.</value>
        public string project_id { get; set; }
        /// <summary>
        /// Gets or sets the project_name.
        /// </summary>
        /// <value>The project_name.</value>
        public string project_name { get; set; }
        /// <summary>
        /// Gets or sets the customer_id.
        /// </summary>
        /// <value>The customer_id.</value>
        public string customer_id { get; set; }
        /// <summary>
        /// Gets or sets the customer_name.
        /// </summary>
        /// <value>The customer_name.</value>
        public string customer_name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string description { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string status { get; set; }
        /// <summary>
        /// Gets or sets the billing_type.
        /// </summary>
        /// <value>The billing_type.</value>
        public string billing_type { get; set; }
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>The rate.</value>
        public double rate { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }
        /// <summary>
        /// Gets or sets the budget_type.
        /// </summary>
        /// <value>The budget_type.</value>
        public string budget_type { get; set; }
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
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>The tasks.</value>
        public List<ProjectTask> tasks { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public List<User> users { get; set; }
        /// <summary>
        /// Gets or sets the budget_hours.
        /// </summary>
        /// <value>The budget_hours.</value>
        public string budget_hours { get; set; }
        /// <summary>
        /// Gets or sets the budget_amount.
        /// </summary>
        /// <value>The budget_amount.</value>
        public string budget_amount { get; set; }
    }
}
