// <copyright file="ApplicationDbContext.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

namespace ScraperApp.Infrastructure
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // dbsets go here
    }
}
