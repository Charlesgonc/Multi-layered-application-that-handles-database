// <copyright file="INbaSecretaryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using NBA.Data;

    /// <summary>
    /// Declares the methods that we want to use related to the financial side of the NBA.
    /// </summary>
    public interface INbaSecretaryLogic
    {
        // the non crud method.

        /// <summary>
        /// The declaration of the NON-CRUD method to get the avg field goal from each team.
        /// </summary>
        /// <returns>The list of the average Field Goal of the team.</returns>
        IList<FGAveragesResult> GetFGAveragesResults();

        /// <summary>
        /// The declaration of the Async NON-CRUD method to get the avg field goal from each team on Async version.
        /// </summary>
        /// <returns>The Task list of the average Field Goal of the team.</returns>
        Task<IList<FGAveragesResult>> GetFGAveragesResultsAsync();

        /// <summary>
        /// The declaration of the CRUD method to get all the teams from the list of teams.
        /// </summary>
        /// <returns>The list of all the teams.</returns>
        IList<Team> GetAllTeams();

        /// <summary>
        /// The declaration of the CRUD method to get one team.
        /// </summary>
        /// <param name="id">the id of the team that we want to get.</param>
        /// <returns>the team that has the id reffered to in the argument.</returns>
        Team GetOneTeam(int id);

        /// <summary>
        /// The declaration of the CRUD method to add a new team to the list of coaches.
        /// </summary>
        /// <param name="team">Its the new team that we plan to inseert into the list of teams.</param>
        void InsertOneTeam(Team team);

        /// <summary>
        /// The declaration of the CRUD method to remove a team to the list of coaches.
        /// </summary>
        /// <param name="team">The team that we plan to remove from the list of coaches.</param>
        void RemoveTeam(Team team);

        /// <summary>
        /// The declaration of the CRUD method to change the number of championships.
        /// </summary>
        /// <param name="id">The id of the team where we internd to perform the change.</param>
        /// <param name="champs">The team that we plan to the number of championships won.</param>
        void ChangeNumberOfChampionships(int id, int champs);

        /// <summary>
        /// The declaration of the NON-CRUD method to get the avg height from each team.
        /// </summary>
        /// <returns>The lsit of the average player's height per conference.</returns>
        IList<AvgPLayerHeight> GetAvgPlayerHeight();

        /// <summary>
        /// The declaration of the Async NON-CRUD method to get the avg height from each team on Async version.
        /// </summary>
        /// <returns>The Task list of the average Field Goal of the team.</returns>
        Task<IList<AvgPLayerHeight>> GetAvgPlayerHeightAsync();
    }
}
