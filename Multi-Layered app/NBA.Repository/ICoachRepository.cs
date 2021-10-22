// <copyright file="ICoachRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data;

    /// <summary>
    /// The interface that declarates the non generic CRUD method-update, specific for the entity Coach.
    /// </summary>
    public interface ICoachRepository : IRepository<Coach>
    {
        /// <summary>
        /// The declaration of the non generic CRUD method  to update the entity Coach.
        /// </summary>
        /// <param name="id">The Id of the Coach that we wish to make updates on.</param>
        /// <param name="newSalary">The new value the salary we wish to modify to.</param>
        void ChangeCoachSalary(int id, int newSalary);
    }
}
