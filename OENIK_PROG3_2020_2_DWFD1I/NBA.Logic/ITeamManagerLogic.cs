// <copyright file="ITeamManagerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NBA.Data;

    /// <summary>
    /// Declares the methods that we want to use.
    /// </summary>
    public interface ITeamManagerLogic
    {
        /// <summary>
        /// The declaration of the CRUD method to get one player.
        /// </summary>
        /// <param name="id">the id of the player that we want to get.</param>
        /// <returns>the player that has the id reffered to in the argument.</returns>
        Player GetOnePlayer(int id);

        /// <summary>
        /// The declaration of the CRUD method to change the field goal of one player.
        /// </summary>
        /// <param name="playerId">The id of the player that we want to make changes in its FG.</param>
        /// <param name="fg">The value of the new FG that we want to apply on the player.</param>
        void ChangePlayerFG(int playerId, float fg);

        // in the logic the return type of the get all is not Iqueriable but Ilist

        /// <summary>
        /// The declaration of the CRUD method to get all players.
        /// </summary>
        /// <returns>The list of all players.</returns>
        IList<Player> GetAllPlayers();

        /// <summary>
        /// The declaration of the CRUD method to add a new player to the list of players.
        /// </summary>
        /// <param name="player">Its the new player that we plan to inseert into the list of players.</param>
        void InsertPlayer(Player player);

        /// <summary>
        /// The declaration of the CRUD method to remove the player to the list of players.
        /// </summary>
        /// <param name="player">the player that we plan to remove from the list of players.</param>
        void RemovePlayer(Player player);

        /// <summary>
        /// The declaration of the CRUD method to get one coach from the list of coaches.
        /// </summary>
        /// <param name="id">The id of the coach that we want to get.</param>
        /// <returns>The coach refferenced by the id as parameter.</returns>
        Coach GetOneCoach(int id);

        /// <summary>
        /// The declaration of the CRUD method to get all the coaches from the list of coaches.
        /// </summary>
        /// <returns>The list of all the coaches.</returns>
        IList<Coach> GetAllCoaches();

        /// <summary>
        /// The declaration of the CRUD method to add a new caoch to the list of coaches.
        /// </summary>
        /// <param name="coach">Its the new caoch that we plan to inseert into the list of coaches.</param>
        void InsertCoach(Coach coach);

        /// <summary>
        /// The declaration of the CRUD method to remove the coach to the list of coaches.
        /// </summary>
        /// <param name="coach">the caoch that we plan to remove from the list of coaches.</param>
        void RemoveCoach(Coach coach);
    }
}
