// <copyright file="TaskQueueService.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Threading.Channels;
using Listopotamus.ApplicationCore.Interfaces;

namespace Listopotamus.Infrastructure.Services
{
    /// <summary>
    /// Represents the task queue service.
    /// </summary>
    public sealed class TaskQueueService : ITaskQueueService
    {
        /// <summary>
        /// Gets the channel.
        /// </summary>
        private readonly Channel<long> Channel =
            System.Threading.Channels.Channel.CreateBounded<long>(new BoundedChannelOptions(100) { FullMode = BoundedChannelFullMode.Wait });

        /// <summary>
        /// Queues a job.
        /// </summary>
        /// <param name="scrapeJobId">The scrape job id.</param>
        /// <returns>A <see cref="Task"/> representing the queuing of a job.</returns>
        public async Task QueueAsync(long scrapeJobId)
        {
            await this.Channel.Writer.WriteAsync(scrapeJobId);
        }

        /// <summary>
        /// Dequeues a job.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>The id of the dequeued job.</returns>
        public async Task<long> DequeueAsync(CancellationToken ct)
        {
            return await this.Channel.Reader.ReadAsync(ct);
        }
    }
}
