using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zohobooks.exceptions
{
    /// <summary>
    /// Class InvoiceException is used to throw the exception.
    /// </summary>
    public class BooksException:ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ApplicationException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public BooksException(string message): base(message) {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ApplicationException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public BooksException(string message, Exception innerException) : base(message, innerException) { }
    }
}
