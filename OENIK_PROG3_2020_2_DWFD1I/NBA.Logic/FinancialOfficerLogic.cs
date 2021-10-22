// <copyright file="FinancialOfficerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NBA.Data;
    using NBA.Repository;

    /// <summary>
    /// Accesses and implements some of the CRUD and NON-CRUD methods from the repository.
    /// </summary>
    public class FinancialOfficerLogic : IFinancialOfficerLogic
    {
        private readonly IPLayerRepository playerRepo;
        private readonly ICoachRepository coachRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialOfficerLogic"/> class.
        /// Will allow us to call the methods of the Player repository by creating a IPlayerRepository instance.
        /// </summary>
        /// <param name="playerRepo">The player repository that will be used for the logic calculations.</param>
        /// <param name="coachRepo">The Coach repository that will be used for the logic calculations.</param>
        public FinancialOfficerLogic(IPLayerRepository playerRepo, ICoachRepository coachRepo)
        {
            this.playerRepo = playerRepo;
            this.coachRepo = coachRepo;
        }

        /// <summary>
        /// The implementation of the NON-CRUD method to get the average of the salaries per conference.
        /// </summary>
        /// <returns>The list of the average pf the players salaries per conference.</returns>
        public List<AvgPlayerSalary> GetAvgPlayerSalaries()
        {
            var q = from player in this.playerRepo.GetAll()
                    group player by new { player.PlayerTeamNavigation.TeamConference } into grp
                    select new AvgPlayerSalary()
                    {
                        Conference = grp.Key.TeamConference,
                        AveragePlayerSal = grp.Average(x => x.PlayerSalary) ?? 0,

                        // ?? replaces null by 0.
                    };
            return q.ToList();
        }

        /// <summary>
        /// The async implementation of the NON-CRUD method to get the average of the salaries per conference.
        /// </summary>
        /// <returns>The list of tasks containing the average of the salaries per conference.</returns>
        public Task<List<AvgPlayerSalary>> GetAvgPlayerSalariesAsync()
        {
            return Task.Run(() => this.GetAvgPlayerSalaries());
        }

        /// <summary>
        /// The implementation of the CRUD method to update the salary of the coach.
        /// </summary>
        /// <param name="id">The id of the coach we want to change the salary.</param>
        /// <param name="salary">The value of the salary we want to change to.</param>
        public void ChangeCoachSalary(int id, int salary)
        {
            this.coachRepo.ChangeCoachSalary(id, salary);
        }

        /// <summary>
        /// The implementation of the CRUD method to update the salary of the player.
        /// </summary>
        /// <param name="id">The id of the player we want to change the salary.</param>
        /// <param name="salary">The value of the salary we want to change to.</param>
        public void ChangePlayerSalary(int id, int salary)
        {
            this.playerRepo.ChangePlayerSalary(id, salary);
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
        /// The implementation of the CRUD method to get one player.
        /// </summary>
        /// <param name="id">The Id of the player that we want to get.</param>
        /// <returns>The plyer that we wanted to get.</returns>
        public Player GetOnePlayer(int id)
        {
            return this.playerRepo.GetOne(id);
        }
    }
}
