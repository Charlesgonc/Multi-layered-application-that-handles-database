// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System.Linq;

    /// <summary>
    /// Base Interface of the Iresopitory which has the declaration of all CRUD methods(generic ones).
    /// </summary>
    /// <typeparam name="T">The entity classthat we want to work on.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Declaration of the CRUD method to get a specific element from a given entity.
        /// </summary>
        /// <param name="id">The id of the entity that we wish to get.</param>
        /// <returns>The entity the specific entity.</returns>
        T GetOne(int id);

        /// <summary>
        /// Declaration of the CRUD method to get a all the elements from a given entity.
        /// </summary>
        /// <returns>All the enetities of the given type.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Declaration of the CRUD method to insert an entity.
        /// </summary>
        /// <param name="entity"> The entity that we wish to insert. </param>
        void Insert(T entity);

        /// <summary>
        /// Declaration of the CRUD method to remove an entity.
        /// </summary>
        /// <param name="entity">the id of the entity that we wish to remove.</param>
        void Remove(T entity); // will change from T entity to int id

        // the updates goes into the descendents of this main base class cause it haas thóo be specific to the entity classes
    }
}
