// <copyright file="Repo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The base abstract class that implements the generic CRUD methods.
    /// </summary>
    /// <typeparam name="T">The entity class that we wich to work on.</typeparam>
    public abstract class Repo<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// the DbContext instance to have access to the database.
        /// </summary>
        private DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repo{T}"/> class.
        /// </summary>
        /// <param name="ctx">The DbContext of the project.</param>
        public Repo(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets or sets to access  and modify the private DbContext.
        /// </summary>
        protected DbContext Ctx { get => this.ctx; set => this.ctx = value; } // this is the ctx that the child classes will be getiing

        /// <summary>
        /// Implementation of the CRUD method on a generic way to get a all the elements from a given entity.
        /// </summary>
        /// <returns>All the enetities of the given type.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Declaration of the absttract class to get one T entity.
        /// </summary>
        /// <param name="id">The id of the entity that we wish to get.</param>
        /// <returns>The entity the specific entity.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Implementation of the CRUD method on a generic way to insert an entity.
        /// </summary>
        /// <param name="entity">The entity that we wish to insert.</param>
        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Implementation of the CRUD method on a generic to remove an entity.
        /// </summary>
        /// <param name="entity">zhzz.</param>
        public void Remove(T entity)
        {
            this.ctx.Set<T>().Remove(entity);
            this.ctx.SaveChanges();
        }
    }
}
