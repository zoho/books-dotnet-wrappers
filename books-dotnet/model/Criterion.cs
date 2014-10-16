using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Criterion.
    /// </summary>
    public class Criterion
    {
        /// <summary>
        /// Gets or sets the criteria_id.
        /// </summary>
        /// <value>The criteria_id.</value>
        public string criteria_id { get; set; }
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public string field { get; set; }
        /// <summary>
        /// Gets or sets the comparator.
        /// </summary>
        /// <value>The comparator.</value>
        public string comparator { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
    }
}
