// <copyright file="NbaSecretaryLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NBA.Data;
    using NBA.Repository;

    /// <summary>
    /// Accesses and implements some of the CRUD and NON-CRUD methods from the repository.
    /// </summary>
    public class NbaSecretaryLogic : INbaSecretaryLogic
    {
        private readonly ITeamRepository teamRepo;
        private readonly IPLayerRepository playerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="NbaSecretaryLogic"/> class.
        /// Will allow us to call the methods of the Team repository by creating a ITeamRepository instance.
        /// </summary>
        /// <param name="teamRepo">The Team repository that will be used for the logic calculations.</param>
        /// <param name="playerRepo">The PLayer repository that will be used for the logic calculations.</param>
        public NbaSecretaryLogic(ITeamRepository teamRepo, IPLayerRepository playerRepo)
        {
            this.teamRepo = teamRepo;
            this.playerRepo = playerRepo;
        }

        /// <summary>
        /// The implementation of the mthod to get theaverage of the field goal of the team accordingly to the fg of each player.
        /// </summary>
        /// <returns>the list of the averages.</returns>
        public IList<FGAveragesResult> GetFGAveragesResults()
        {
            var q = from player in this.playerRepo.GetAll()
                    group player by new { player.PlayerTeamNavigation.TeamId, player.PlayerTeamNavigation.TeamName } into grp
                    select new FGAveragesResult()
                    {
                        TeamName = grp.Key.TeamName,
                        AverageFG = grp.Average(x => x.PlayerFieldGoal) ?? 0,

                        // ?? replaces null by 0.
                    };
            return q.ToList();
        }

        /// <summary>
        /// The implementation of the CRUD method to change the number of championships of a team.
        /// </summary>
        /// <param name="id">The id of the team that we  want to change its number of championshis.</param>
        /// <param name="champs">The value of the new number of championships that we want to assign to the player.</param>
        public void ChangeNumberOfChampionships(int id, int champs)
        {
            this.teamRepo.ChangeTeamNumOfChamps(id, champs);
        }

        /// <summary>
        /// The implementation of the CRUD method to get all the teams of the the entity type.
        /// </summary>
        /// <returns>The list of all teams.</returns>
        public IList<Team> GetAllTeams()
        {
            return this.teamRepo.GetAll().ToList();
        }

        /// <summary>
        /// The implementation of the CRUD method to get one team.
        /// </summary>
        /// <param name="id">The Id of the team that we want to get.</param>
        /// <returns>The team that we wanted to get.</returns>
        public Team GetOneTeam(int id)
        {
            return this.teamRepo.GetOne(id);
        }

        /// <summary>
        /// The implementation of the CRUD method to add one team.
        /// </summary>
        /// <param name="team">The team that we want to add to the list of teams.</param>
        public void InsertOneTeam(Team team)
        {
            this.teamRepo.Insert(team);
        }

        /// <summary>
        /// The implementation of the CRUD method to remove one team.
        /// </summary>
        /// <param name="team">The team that we want to remove from the list of teams.</param>
        public void RemoveTeam(Team team)
        {
            this.teamRepo.Remove(team);
        }

        /// <summary>
        /// the implementation of the NON-CRUD method to get the average player's height per team.
        /// </summary>
        /// <returns>The list of the average player's height per team.</returns>
        public IList<AvgPLayerHeight> GetAvgPlayerHeight()
        {
            var q = from player in this.playerRepo.GetAll()
                    group player by new { player.PlayerTeamNavigation.TeamId, player.PlayerTeamNavigation.TeamName } into grp
                    select new AvgPLayerHeight()
                    {
                        TeamName = grp.Key.TeamName,
                        AveragePlayerHeight = grp.Average(x => x.PlayerHeight) ?? 0,

                        // ?? replaces null by 0.
                    };
            return q.ToList();
        }

        /// <summary>
        /// The implementation of the Async NON-CRUD mthod to get the average of the field goal of the team accordingly to the fg of each player on Async version.
        /// </summary>
        /// <returns>The Task list of the averages of the field goal per team.</returns>
        public Task<IList<FGAveragesResult>> GetFGAveragesResultsAsync()
        {
            return Task.Run(() => this.GetFGAveragesResults());
        }

        /// <summary>
        /// The implementation of the Async NON-CRUD method to get theaverage of the average height per team on Async version.
        /// </summary>
        /// <returns>the list of the average height per team.</returns>
        public Task<IList<AvgPLayerHeight>> GetAvgPlayerHeightAsync()
        {
            return Task.Run(() => this.GetAvgPlayerHeight());
        }
    }
}
