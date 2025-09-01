// <copyright file="Error.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.Core
{
    /// <summary>
    /// Represents an error.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="description">The error description.</param>
    public sealed record Error(string code, string description)
    {
        /// <summary>
        /// The none error (no error).
        /// </summary>
        public static readonly Error None = new (string.Empty, string.Empty);

        /// <summary>
        /// Gets the code.
        /// </summary>
        public string Code { get; } = code;

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; } = description;
    }
}
