// <copyright file="Result.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.Core
{
    /// <summary>
    /// Represents a result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    public class Result<T>
    {
        private Result(bool isSuccess, Error error, T content)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            this.IsSuccess = isSuccess;
            this.Error = error;
            this.Content = content;
        }

        /// <summary>
        /// Gets a value indicating whether the result is successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating whether the result is a failure.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Gets the content.
        /// </summary>
        public T Content { get; init; } = default!;

        /// <summary>
        /// Gets a successful result.
        /// </summary>
        /// <returns>A succcessful result.</returns>
        public static Result<T> Success() => new (true, Error.None);

        /// <summary>
        /// Gets a failure result.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>A failure result.</returns>
        public static Result<T> Failure(Error error) => new (false, error);
    }
}
