// <copyright file="ITeamRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data;

    /// <summary>
    /// The interface that declarates the non generic CRUD method-update, specific for the entity Team.
    /// </summary>
    public interface ITeamRepository : IRepository<Team>
    {
        /// <summary>
        /// The declaration of the non generic CRUD method  to update the entity Team.
        /// </summary>
        /// <param name="id">The Id of the Team that we wish to make updates on.</param>
        /// <param name="newNumber">the new number of campionships won by the team.</param>
        void ChangeTeamNumOfChamps(int id, int newNumber);
    }
}
