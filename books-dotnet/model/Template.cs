using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Template.
    /// </summary>
    public class Template
    {
        /// <summary>
        /// Gets or sets the template_name.
        /// </summary>
        /// <value>The template_name.</value>
        public string template_name { get; set; }
        /// <summary>
        /// Gets or sets the template_id.
        /// </summary>
        /// <value>The template_id.</value>
        public string template_id { get; set; }
        /// <summary>
        /// Gets or sets the template_type.
        /// </summary>
        /// <value>The template_type.</value>
        public string template_type { get; set; }
    }
}
