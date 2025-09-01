// <copyright file="IGenericRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Listopotamus.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Listopotamus.ApplicationCore.Interfaces
{
    /// <summary>
    /// Represents a generic repository for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">The key type.</typeparam>
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        /// <summary>
        /// Gets an entity or entities from the database based on the specified filter, order, and included properties.
        /// </summary>
        /// <param name="filter">The expression used to filter entities.</param>
        /// <param name="orderBy">The order by queryable.</param>
        /// <param name="include">The properties to include in the query.</param>
        /// <param name="asNoTracking">A value indicating whether or not to use tracking.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The entity or list of entities.</returns>
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an entity by its primary key.
        /// </summary>
        /// <returns>The entity.</returns>
        Task<TEntity> GetByIDAsync(TKey id);

        /// <summary>
        /// Inserts an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of a new entity.</returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// Inserts a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of a list of new entities.</returns>
        Task<List<TEntity>> InsertAsync(List<TEntity> entities);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>A <see cref="Task"/> representing the deletion of the entity.</returns>
        Task DeleteAsync(TKey id);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        /// <returns>A <see cref="Task"/> representing the deletion of the entity.</returns>
        Task DeleteAsync(TEntity entityToDelete);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        /// <returns>A <see cref="Task"/> representing the update for the entity.</returns>
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
    }
}
