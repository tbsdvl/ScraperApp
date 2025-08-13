// <copyright file="IGenericRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Listopotamus.Core.Entities;

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
        /// Gets entities based on an optional filter, order, and included properties.
        /// </summary>
        /// <returns>The list of entities.</returns>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        Task<List<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "",
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
            where TEntity : class;

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
