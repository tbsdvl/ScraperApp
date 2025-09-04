// <copyright file="JobStatusEnum.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Enums
{
    /// <summary>
    /// Represents the jobs status enums.
    /// </summary>
    public enum JobStatusEnum
    {
        /// <summary>
        /// The Queued job status enum value.
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The Running job status enum value.
        /// </summary>
        Running = 2,

        /// <summary>
        /// The Succeeded job status enum value.
        /// </summary>
        Succeeded = 3,

        /// <summary>
        /// The Failed job status enum value.
        /// </summary>
        Failed = 4,
    }
}
