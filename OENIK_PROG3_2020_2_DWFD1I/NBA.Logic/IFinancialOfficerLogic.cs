// <copyright file="IFinancialOfficerLogic.cs" company="PlaceholderCompany">
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
    public interface IFinancialOfficerLogic
    {
        /// <summary>
        /// The declaration of the crud mehtod to update/change the salary of the player.
        /// </summary>
        /// <param name="id">The id of the player that we want to change the salary.</param>
        /// <param name="salary">The value of the new salary.</param>
        void ChangePlayerSalary(int id, int salary);

        /// <summary>
        /// The declaration of the crud method to update/change the salary of the coach.
        /// </summary>
        /// <param name="id">The id of the coach we want to change the salary.</param>
        /// <param name="salary">The value of the new salary.</param>
        void ChangeCoachSalary(int id, int salary);

        /// <summary>
        /// The declaration of the non-method to get teh average of the player's salary per conference.
        /// </summary>
        /// <returns>The list of the average player's salary per conference.</returns>
        List<AvgPlayerSalary> GetAvgPlayerSalaries();

        /// <summary>
        /// The declaration of the non-method to get the average of the player's salary per conference on Acyin version.
        /// </summary>
        /// <returns>The list of the average player's salary per conference.</returns>
        Task<List<AvgPlayerSalary>> GetAvgPlayerSalariesAsync();

        // just added the 2 next so that on the main program I could check if the player/coach exists before trying to make changes.

        /// <summary>
        /// The declaration of the crud method to get one player.
        /// </summary>
        /// <param name="id">the id of the player that we want to get.</param>
        /// <returns>the player that has the id reffered to in the argument.</returns>
        Player GetOnePlayer(int id);

        /// <summary>
        /// The declaration of the  crud mehtod to get one coach from the list of coaches.
        /// </summary>
        /// <param name="id">The id of the coach that we want to get.</param>
        /// <returns>The coach refferenced by the id as parameter.</returns>
        Coach GetOneCoach(int id);
    }
}
