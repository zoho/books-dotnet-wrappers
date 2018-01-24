using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of Rule.
    /// </summary>
    public class Rule
    {
        /// <summary>
        ///     Gets or sets the rule_id.
        /// </summary>
        /// <value>The rule_id.</value>
        public string rule_id { get; set; }

        /// <summary>
        ///     Gets or sets the rule_name.
        /// </summary>
        /// <value>The rule_name.</value>
        public string rule_name { get; set; }

        /// <summary>
        ///     Gets or sets the target_account_id.
        /// </summary>
        /// <value>The target_account_id.</value>
        public string target_account_id { get; set; }

        /// <summary>
        ///     Gets or sets the rule_order.
        /// </summary>
        /// <value>The rule_order.</value>
        public int rule_order { get; set; }

        /// <summary>
        ///     Gets or sets the apply_to.
        /// </summary>
        /// <value>The apply_to.</value>
        public string apply_to { get; set; }

        /// <summary>
        ///     Gets or sets the criteria_type.
        /// </summary>
        /// <value>The criteria_type.</value>
        public string criteria_type { get; set; }

        /// <summary>
        ///     Gets or sets the record_as.
        /// </summary>
        /// <value>The record_as.</value>
        public string record_as { get; set; }

        /// <summary>
        ///     Gets or sets the account_id.
        /// </summary>
        /// <value>The account_id.</value>
        public string account_id { get; set; }

        /// <summary>
        ///     Gets or sets the account_name.
        /// </summary>
        /// <value>The account_name.</value>
        public string account_name { get; set; }

        /// <summary>
        ///     Gets or sets the criterion.
        /// </summary>
        /// <value>The criterion.</value>
        public List<Criterion> criterion { get; set; }

        /// <summary>
        ///     Gets or sets the tax_id.
        /// </summary>
        /// <value>The tax_id.</value>
        public string tax_id { get; set; }

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
        ///     Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
    }
}