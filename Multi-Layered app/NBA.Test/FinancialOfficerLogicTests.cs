// <copyright file="FinancialOfficerLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NBA.Data;
    using NBA.Logic;
    using NBA.Repository;
    using NUnit.Framework;

    /// <summary>
    /// The testing class responsible for testing the operations implemented on the business logic FinancialLogic.
    /// </summary>
    [TestFixture]
    public class FinancialOfficerLogicTests
    {
        /// <summary>
        /// The CRUD testing for the update of one coach.
        /// </summary>
        [Test]
        public void TestCoachSalChange()
        {
            Mock<IPLayerRepository> playerRepo = new Mock<IPLayerRepository>();
            Mock<ICoachRepository> coachRepo = new Mock<ICoachRepository>();

            FinancialOfficerLogic financialOfficerLogic = new FinancialOfficerLogic(playerRepo.Object, coachRepo.Object);

            Coach sampleCoach = new Coach() { CoachId = 1, CoachName = "Charles", CoachSalary = 2000 };
            int newSalary = 3000;

            Player samplePlayer = new Player() { PlayerId = 1, PlayerName = "Charles", PlayerFieldGoal = 60 };
            int newFG = 61;
            financialOfficerLogic.ChangeCoachSalary(sampleCoach.CoachId, newSalary);

            coachRepo.Verify(repo => repo.ChangeCoachSalary(sampleCoach.CoachId, newSalary), Times.Once);
            playerRepo.Verify(repo => repo.ChangePlayerFieldGoal(samplePlayer.PlayerId, newFG), Times.Never);
        }

        // NON-CRUD Test => Get AVG FG from each team
        private Mock<IPLayerRepository> playerRepo;
        private Mock<ICoachRepository> coachRepo;
        private List<AvgPlayerSalary> expectedAvgSalary;

        private FinancialOfficerLogic CreateFinancialOfficerLogic()
        {
            this.playerRepo = new Mock<IPLayerRepository>();
            this.coachRepo = new Mock<ICoachRepository>();

            Team lakers = new Team() { TeamId = 1, TeamName = "Lakers", TeamConference = "Western" };
            Team celtics = new Team() { TeamId = 2, TeamName = "Celtics", TeamConference = "Eastern" };
            Team chicago = new Team() { TeamId = 3, TeamName = "Chicago", TeamConference = "Eastern" };
            Team warriors = new Team() { TeamId = 4, TeamName = "warriors", TeamConference = "Western" };

            List<Team> teams = new List<Team> { lakers, celtics };

            List<Coach> coaches = new List<Coach>() { new Coach() { CoachName = "Charles" } };

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerName = "Lebron James",  PlayerSalary = 1000, PlayerTeamNavigation = lakers, PlayerTeam = lakers.TeamId },
                new Player() { PlayerName = "Anthony Davis", PlayerSalary = 1000, PlayerTeamNavigation = celtics, PlayerTeam = celtics.TeamId },
                new Player() { PlayerName = "Jayson Tatum",  PlayerSalary = 2000, PlayerTeamNavigation = chicago, PlayerTeam = chicago.TeamId },
                new Player() { PlayerName = "Jayson Tatum",  PlayerSalary = 2000, PlayerTeamNavigation = warriors, PlayerTeam = warriors.TeamId },
            };
            this.expectedAvgSalary = new List<AvgPlayerSalary>()
            {
                new AvgPlayerSalary() { Conference = "Western", AveragePlayerSal = 1500 },
                new AvgPlayerSalary() { Conference = "Eastern", AveragePlayerSal = 1500 },
            };
            this.coachRepo.Setup(repo => repo.GetAll()).Returns(coaches.AsQueryable);
            this.playerRepo.Setup(repo => repo.GetAll()).Returns(players.AsQueryable);
            return new FinancialOfficerLogic(this.playerRepo.Object, this.coachRepo.Object);
        }

        /// <summary>
        /// The NON-CRUD testing to get the average salary of each conference.
        /// </summary>
        [Test]
        public void TestGetAvgPlayerSalary()
        {
            // Arrange
            var financialOfficerLogic = this.CreateFinancialOfficerLogic();

            // Act
            var actualAverages = financialOfficerLogic.GetAvgPlayerSalaries();

            // Assert
            Assert.That(actualAverages, Is.EquivalentTo(this.expectedAvgSalary));

            // Verify
            this.playerRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.coachRepo.Verify(repo => repo.GetAll(), Times.Never);
        }
    }
}
