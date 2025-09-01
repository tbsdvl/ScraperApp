// <copyright file="GenericRepository.cs" company="Psybersimian LLC">
// Copyright (c) Psybersimian LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Listopotamus.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Listopotamus.Infrastructure.Data.Repositories.Generic
{
    /// <summary>
    /// Represes a generic repository for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">The key type.</typeparam>
    public class GenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        /// <summary>
        /// The application database context.
        /// </summary>
        private ApplicationDbContext Context;

        /// <summary>
        /// The DbSet for the entity type.
        /// </summary>
        private DbSet<TEntity> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public GenericRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

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
        public virtual async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = this.Context.Set<TEntity>();

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Gets an entity by its primary key.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The entity.</returns>
        public async Task<TEntity> GetByIDAsync(TKey id)
        {
            return await this.Context.Set<TEntity>().AsNoTracking().Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Inserts an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of a new entity.</returns>
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            this.Context.Add(entity);
            await this.Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Inserts a list of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>A <see cref="Task"/> representing the insertion of a list of new entities.</returns>
        public async Task<List<TEntity>> InsertAsync(List<TEntity> entities)
        {
            this.Context.AddRange(entities);
            await this.Context.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>A <see cref="Task"/> representing the deletion of the entity.</returns>
        public async Task DeleteAsync(TKey id)
        {
            var entityToDelete = await this.GetByIDAsync(id);
            await this.DeleteAsync(entityToDelete);
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        /// <returns>A <see cref="Task"/> representing the deletion of the entity.</returns>
        public async Task DeleteAsync(TEntity entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }

            this.Context.Remove(entityToDelete);
            await this.Context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        /// <returns>A <see cref="Task"/> representing the update for the entity.</returns>
        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            this.Context.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
            return entityToUpdate;
        }
    }
}