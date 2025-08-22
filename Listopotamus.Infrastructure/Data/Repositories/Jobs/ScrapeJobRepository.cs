// <copyright file="ScrapeJobRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Listopotamus.ApplicationCore.Interfaces;
using Listopotamus.Core.Entities.Jobs;
using Listopotamus.Infrastructure.Data.Repositories.Generic;

namespace Listopotamus.Infrastructure.Data.Repositories.Jobs
{
    /// <summary>
    /// Represents the scrape job repository.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ScrapeJobRepository"/> class.
    /// </remarks>
    /// <param name="context">The application database context.</param>
    public class ScrapeJobRepository(ApplicationDbContext context) : GenericRepository<ScrapeJob, long?>(context), IScrapeJobRepository
    {
    }
}
