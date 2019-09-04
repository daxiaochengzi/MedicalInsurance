using System;
using System.Collections.Generic;
using System.Text;

namespace Quote.Core.Exceptions
{
    public interface IStandardError
    {
        /// <summary>
        /// Gets or sets the code for this error.
        /// </summary>
        /// <value>
        /// The code for this error.
        /// </value>
        string Code { get; set; }
        /// <summary>
        /// Gets or sets the message for this error.
        /// </summary>
        /// <value>
        /// The message for this error.
        /// </value>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the target of the particular error (e.g., the name of the property in error).
        /// </summary>
        /// <value>The target of the particular error.</value>
        string Target { get; set; }
        /// <summary>
        /// An object containing more specific information than the current object about the error.
        /// </summary>
        /// <value>The inner error.</value>
        IStandardError InnerError { get; set; }
        /// <summary>
        /// Gets or sets the details for this error.
        /// </summary>
        /// <value>The details for this error.</value>
        IEnumerable<IStandardError> Details { get; set; }
    }
}
