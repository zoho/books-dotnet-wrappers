using System.Collections.Generic;

namespace zohobooks.model
{
    /// <summary>
    ///     Used to define the model object of ProjectsList.
    /// </summary>
    public class ProjectsList : List<Project>
    {
        /// <summary>
        ///     Gets or sets the page_context.
        /// </summary>
        /// <value>The page_context.</value>
        public PageContext page_context { get; set; }
    }
}