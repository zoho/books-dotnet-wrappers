using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zohobooks.model
{
    /// <summary>
    /// Class TaxGroup.
    /// </summary>
    public class TaxGroup
    {
        /// <summary>
        /// Gets or sets the tax_group_id.
        /// </summary>
        /// <value>The tax_group_id.</value>
        public string tax_group_id { get; set; }
        /// <summary>
        /// Gets or sets the tax_group_name.
        /// </summary>
        /// <value>The tax_group_name.</value>
        public string tax_group_name { get; set; }
        /// <summary>
        /// Gets or sets the tax_group_percentage.
        /// </summary>
        /// <value>The tax_group_percentage.</value>
        public double tax_group_percentage { get; set; }
        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<Tax> taxes { get; set; }
        
    }
}
