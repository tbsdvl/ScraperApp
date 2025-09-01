// <copyright file="Result.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.Core
{
    /// <summary>
    /// Represents the outcome of an operation, with success/failure state and optional content.
    /// </summary>
    /// <typeparam name="T">The type of the content value.</typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="isSuccess">True if the operation succeeded; otherwise false.</param>
        /// <param name="error">The error information for a failed result, or <see cref="Error.None"/> on success.</param>
        /// <param name="content">The content value produced by the operation.</param>
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
        /// Gets a value indicating whether the operation completed successfully.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating whether the operation failed.
        /// </summary>
        public bool IsFailure => !this.IsSuccess;

        /// <summary>
        /// Gets the error information associated with the result.
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Gets the content value returned by the operation.
        /// </summary>
        public T Content { get; init; } = default!;

        /// <summary>
        /// Creates a successful result with the specified content value.
        /// </summary>
        /// <param name="content">The content to include in the result.</param>
        /// <returns>A successful <see cref="Result{T}"/> containing the content.</returns>
        public static Result<T> Success(T content) => new (true, Error.None, content);

        /// <summary>
        /// Creates a failure result with the specified error.
        /// </summary>
        /// <param name="error">The error that caused the failure.</param>
        /// <returns>A failed <see cref="Result{T}"/> with no content.</returns>
        public static Result<T> Failure(Error error) => new (false, error, default!);
    }
}