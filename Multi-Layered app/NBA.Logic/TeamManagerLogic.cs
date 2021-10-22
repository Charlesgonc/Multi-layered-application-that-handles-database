// <copyright file="TeamManagerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NBA.Data;
    using NBA.Repository;

    /// <summary>
    /// Accesses and implements some of the CRUD and NON-CRUD methods from the repository.
    /// </summary>
    public class TeamManagerLogic : ITeamManagerLogic
    {
        private readonly IPLayerRepository playerRepo;
        private readonly ICoachRepository coachRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamManagerLogic"/> class.
        /// Will allow us to call the methods of the Player repository by creating a IPlayerRepository instance.
        /// </summary>
        /// <param name="playerRepo">The player repository that will be used for the logic calculations.</param>
        /// <param name="coachRepo">The Coach repository that will be used for the logic calculations.</param>
        public TeamManagerLogic(IPLayerRepository playerRepo, ICoachRepository coachRepo)
        {
            this.playerRepo = playerRepo;
            this.coachRepo = coachRepo;
        }

        // to impelement the CRUD methods we just have to forward it to the repository which calls the methods.

        /// <summary>
        /// The implementation of the CRUD method to change the FG of the player.
        /// </summary>
        /// <param name="playerId">The id of the player that we  want to change its FG.</param>
        /// <param name="fg">The value of the new fg that we want to assign to the player.</param>
        public void ChangePlayerFG(int playerId, float fg)
        {
            this.playerRepo.ChangePlayerFieldGoal(playerId, fg);
        }

        /// <summary>
        /// The implementation of the CRUD method to get all the players of the the entity type.
        /// </summary>
        /// <returns>The list of all players.</returns>
        public IList<Player> GetAllPlayers()
        {
            // converrt it into a list because the get all will return a Iquery(which made things easier for the get one-2 method calls in 1 sql statement)
            return this.playerRepo.GetAll().ToList();
        }

        /// <summary>
        /// The implementation of the CRUD method to get one player.
        /// </summary>
        /// <param name="id">The Id of the player that we want to get.</param>
        /// <returns>The plyer that we wanted to get.</returns>
        public Player GetOnePlayer(int id)
        {
            return this.playerRepo.GetOne(id);
        }

        /// <summary>
        /// The implementation of the CRUD method to add one player.
        /// </summary>
        /// <param name="player">The player that we want to add to the list of players.</param>
        public void InsertPlayer(Player player)
        {
            this.playerRepo.Insert(player);
        }

        /// <summary>
        /// The implementation of the CRUD method to remove one player.
        /// </summary>
        /// <param name="player">The player that we want to remove from the list of players.</param>
        public void RemovePlayer(Player player)
        {
            this.playerRepo.Remove(player);
        }

        /// <summary>
        /// The implementation of the CRUD method to get one caoch.
        /// </summary>
        /// <param name="id">The Id of the caoch that we want to get.</param>
        /// <returns>The coach that we wanted to get.</returns>
        public Coach GetOneCoach(int id)
        {
            return this.coachRepo.GetOne(id);
        }

        /// <summary>
        /// The implementation of the CRUD method to  get all the coaches.
        /// </summary>
        /// <returns>The list of all the coaches that we wanted to get.</returns>
        public IList<Coach> GetAllCoaches()
        {
            return this.coachRepo.GetAll().ToList();
        }

        /// <summary>
        /// The implementation of the CRUD method to insert one coach to the list of coaches.
        /// </summary>
        /// <param name="coach">The coach that we want to add to the.</param>
        public void InsertCoach(Coach coach)
        {
            this.coachRepo.Insert(coach);
        }

        /// <summary>
        /// The implementation of the CRUD method to remove one coach from the list of coaches.
        /// </summary>
        /// <param name="coach">The coach that we would like to remove from the list.</param>
        public void RemoveCoach(Coach coach)
        {
            this.coachRepo.Remove(coach);
        }
    }
}
