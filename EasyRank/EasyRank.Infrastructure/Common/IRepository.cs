// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyRank.Infrastructure.Common
{
    /// <summary>
    /// Abstraction of repository access methods.
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// All records in a table.
        /// </summary>
        /// <returns>Queryable expression tree.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        IQueryable<T> All<T>()
            where T : class;

        /// <summary>
        /// All records in a table.
        /// </summary>
        /// <returns>Queryable expression tree.</returns>
        /// <param name="search">Search expression to be used on the database.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        IQueryable<T> All<T>(Expression<Func<T, bool>> search)
            where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context.
        /// </summary>
        /// <returns>Expression tree.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        IQueryable<T> AllReadonly<T>()
            where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context.
        /// </summary>
        /// <returns>Expression tree.</returns>
        /// <param name="search">Search expression to be used on the database.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search)
            where T : class;

        /// <summary>
        /// Gets specific record from database by primary key.
        /// </summary>
        /// <param name="id">Record identificator.</param>
        /// <returns>Single record.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        Task<T> GetByIdAsync<T>(object id)
            where T : class;

        /// <summary>
        /// Gets specific record from database by primary keys.
        /// </summary>
        /// <param name="id">Record identificators.</param>
        /// <returns>Single record.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        Task<T> GetByIdsAsync<T>(object[] id)
            where T : class;

        /// <summary>
        /// Adds entity to the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Void method.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        Task AddAsync<T>(T entity)
            where T : class;

        /// <summary>
        /// Ads collection of entities to the database.
        /// </summary>
        /// <param name="entities">Enumerable list of entities.</param>
        /// <returns>Void method.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        Task AddRangeAsync<T>(IEnumerable<T> entities)
            where T : class;

        /// <summary>
        /// Updates a record in database.
        /// </summary>
        /// <param name="entity">Entity for record to be updated.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void Update<T>(T entity)
            where T : class;

        /// <summary>
        /// Updates set of records in the database.
        /// </summary>
        /// <param name="entities">Enumerable collection of entities to be updated.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void UpdateRange<T>(IEnumerable<T> entities)
            where T : class;

        /// <summary>
        /// Deletes a record from database.
        /// </summary>
        /// <param name="id">Identificator of record to be deleted.</param>
        /// <returns>Void method.</returns>
        /// <typeparam name="T">Type of the database model.</typeparam>
        Task DeleteAsync<T>(object id)
            where T : class;

        /// <summary>
        /// Deletes a record from database.
        /// </summary>
        /// <param name="entity">Entity representing record to be deleted.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void Delete<T>(T entity)
            where T : class;

        /// <summary>
        /// Deletes a range of records from the database.
        /// </summary>
        /// <param name="entities">Collection of entities representing records to be deleted.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void DeleteRange<T>(IEnumerable<T> entities)
            where T : class;

        /// <summary>
        /// Deletes a range of records from the database (with a where clause).
        /// </summary>
        /// <param name="deleteWhereClause">Expression to be used when deleting entities.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause)
            where T : class;

        /// <summary>
        /// Detaches given entity from the context.
        /// </summary>
        /// <param name="entity">Entity to be detached.</param>
        /// <typeparam name="T">Type of the database model.</typeparam>
        void Detach<T>(T entity)
            where T : class;

        /// <summary>
        /// Saves all made changes in trasaction.
        /// </summary>
        /// <returns>Error code.</returns>
        Task<int> SaveChangesAsync();
    }
}
