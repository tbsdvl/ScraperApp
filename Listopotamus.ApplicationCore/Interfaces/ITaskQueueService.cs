// <copyright file="ITaskQueueService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents the interface for the task queue service.
    /// </summary>
    public interface ITaskQueueService
    {
        /// <summary>
        /// Queues a job.
        /// </summary>
        /// <param name="scrapeJobId">The scrape job id.</param>
        /// <returns>A <see cref="Task"/> representing the queuing of a job.</returns>
        Task QueueAsync(long scrapeJobId);

        /// <summary>
        /// Dequeues a job.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The id of the dequeued job.</returns>
        Task<long> DequeueAsync(CancellationToken ct);
    }
}
