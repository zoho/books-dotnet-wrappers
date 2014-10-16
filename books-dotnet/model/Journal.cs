using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.model
{
    /// <summary>
    /// Used to define the model object of Journal.
    /// </summary>
    public class Journal
    {
        /// <summary>
        /// Gets or sets the journal_id.
        /// </summary>
        /// <value>The journal_id.</value>
        public string journal_id { get; set; }
        /// <summary>
        /// Gets or sets the journal_date.
        /// </summary>
        /// <value>The journal_date.</value>
        public string journal_date { get; set; }
        /// <summary>
        /// Gets or sets the entry_number.
        /// </summary>
        /// <value>The entry_number.</value>
        public string entry_number { get; set; }
        /// <summary>
        /// Gets or sets the reference_number.
        /// </summary>
        /// <value>The reference_number.</value>
        public string reference_number { get; set; }
        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string notes { get; set; }
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public double total { get; set; }
        /// <summary>
        /// Gets or sets the currency_id.
        /// </summary>
        /// <value>The currency_id.</value>
        public string currency_id { get; set; }
        /// <summary>
        /// Gets or sets the currency_code.
        /// </summary>
        /// <value>The currency_code.</value>
        public string currency_code { get; set; }
        /// <summary>
        /// Gets or sets the currency_symbol.
        /// </summary>
        /// <value>The currency_symbol.</value>
        public string currency_symbol { get; set; }
        /// <summary>
        /// Gets or sets the line_items.
        /// </summary>
        /// <value>The line_items.</value>
        public List<LineItem> line_items { get; set; }
        /// <summary>
        /// Gets or sets the line_item_total.
        /// </summary>
        /// <value>The line_item_total.</value>
        public double line_item_total { get; set; }
        /// <summary>
        /// Gets or sets the price_precision.
        /// </summary>
        /// <value>The price_precision.</value>
        public int price_precision { get; set; }
        /// <summary>
        /// Gets or sets the taxes.
        /// </summary>
        /// <value>The taxes.</value>
        public List<object> taxes { get; set; }
        /// <summary>
        /// Gets or sets the created_time.
        /// </summary>
        /// <value>The created_time.</value>
        public string created_time { get; set; }
        /// <summary>
        /// Gets or sets the last_modified_time.
        /// </summary>
        /// <value>The last_modified_time.</value>
        public string last_modified_time { get; set; }
    }
}
