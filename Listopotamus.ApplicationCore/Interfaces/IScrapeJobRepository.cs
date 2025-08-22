// <copyright file="IScrapeJobRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.Core.Entities.Jobs;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents an interface for the scrape job repository.
    /// </summary>
    public interface IScrapeJobRepository : IGenericRepository<ScrapeJob, long?>
    {
    }
}
