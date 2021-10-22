// <copyright file="NbaSecretaryLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using NBA.Data;
    using NBA.Logic;
    using NBA.Repository;
    using NUnit.Framework;

    /// <summary>
    /// The testing class responsible for testing the operations implemented on the business logic NbaSecretary.
    /// </summary>
    [TestFixture]
    public class NbaSecretaryLogicTests
    {
        /// <summary>
        /// The CRUD testing for the insertion/adding of one Team.
        /// </summary>
        [Test]
        public void TestTeamAdd()
        {
            // Arrange
            Mock<IPLayerRepository> playerRepo = new Mock<IPLayerRepository>();
            Mock<ITeamRepository> teamRepo = new Mock<ITeamRepository>();

            NbaSecretaryLogic nbaSecretaryLogic = new NbaSecretaryLogic(teamRepo.Object, playerRepo.Object);

            // Act
            Team sampleTeam = new Team() { TeamId = 1, TeamName = "Gonzalezz", TeamArena = "Charles PLaza" };
            nbaSecretaryLogic.InsertOneTeam(sampleTeam);

            // Assert
            // Verify
            teamRepo.Verify(repo => repo.Insert(sampleTeam), Times.Once);
            teamRepo.Verify(repo => repo.Remove(sampleTeam), Times.Never);
        }

        /// <summary>
        /// The CRUD testing for the deletion/Remotion of one Team.
        /// </summary>
        [Test]
        public void TestRemoveTeam()
        {
            // Arrange
            Mock<IPLayerRepository> playerRepo = new Mock<IPLayerRepository>();
            Mock<ITeamRepository> teamRepo = new Mock<ITeamRepository>();

            NbaSecretaryLogic nbaSecretaryLogic = new NbaSecretaryLogic(teamRepo.Object, playerRepo.Object);

            Team sampleTeam = new Team() { TeamId = 1, TeamName = "Gonzalezz", TeamArena = "Charles PLaza" };

            nbaSecretaryLogic.RemoveTeam(sampleTeam);

            teamRepo.Verify(repo => repo.Remove(sampleTeam), Times.Exactly(1));
            teamRepo.Verify(repo => repo.Insert(sampleTeam), Times.Exactly(0));
        }

        // NON-CRUD Test => Get AVG FG from each team
        private Mock<IPLayerRepository> playerRepo;
        private Mock<ITeamRepository> teamRepo;
        private List<FGAveragesResult> expectedFgAVG;
        private List<AvgPLayerHeight> expectedHeightAVG;

        private NbaSecretaryLogic CreateNbaSecretaryLogic()
        {
            this.playerRepo = new Mock<IPLayerRepository>();
            this.teamRepo = new Mock<ITeamRepository>();

            Team lakers = new Team() { TeamId = 1, TeamName = "Lakers" };
            Team celtics = new Team() { TeamId = 2, TeamName = "Celtics" };

            List<Team> teams = new List<Team> { lakers, celtics };

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerName = "Lebron James", PlayerFieldGoal = 60, PlayerTeamNavigation = lakers, PlayerTeam = lakers.TeamId, PlayerHeight = 2.0 },
                new Player() { PlayerName = "Anthony Davis", PlayerFieldGoal = 60, PlayerTeamNavigation = lakers, PlayerTeam = lakers.TeamId, PlayerHeight = 2.0 },
                new Player() { PlayerName = "Jayson Tatum", PlayerFieldGoal = 75, PlayerTeamNavigation = celtics, PlayerTeam = celtics.TeamId, PlayerHeight = 1.96 },
            };
            this.expectedFgAVG = new List<FGAveragesResult>()
            {
                new FGAveragesResult() { TeamName = "Lakers", AverageFG = 60 },
                new FGAveragesResult() { TeamName = "Celtics", AverageFG = 75 },
            };
            this.expectedHeightAVG = new List<AvgPLayerHeight>()
            {
                new AvgPLayerHeight() { TeamName = "Lakers", AveragePlayerHeight = 2.0 },
                new AvgPLayerHeight() { TeamName = "Celtics", AveragePlayerHeight = 1.96 },
            };
            this.teamRepo.Setup(repo => repo.GetAll()).Returns(teams.AsQueryable);
            this.playerRepo.Setup(repo => repo.GetAll()).Returns(players.AsQueryable);
            return new NbaSecretaryLogic(this.teamRepo.Object, this.playerRepo.Object);
        }

        /// <summary>
        /// The NON-CRUD testing for the obtension of the averages of the field goal from each Team.
        /// </summary>
        [Test] // NON-CRUD Test => Get AVG FG from each team
        public void TestGetFGAveragesResults()
        {
            // Arrange
            var nbaSecretaryLogic = this.CreateNbaSecretaryLogic();

            // Act
            var actualAverages = nbaSecretaryLogic.GetFGAveragesResults();

            // Assert
            Assert.That(actualAverages, Is.EquivalentTo(this.expectedFgAVG));

            // Verify
            this.playerRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.teamRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// The NON-CRUD testing for the obtension of the averages of the height from each Team.
        /// </summary>
        [Test]
        public void TestAvgPlayerHeight()
        {
            // Arrange
            var nbaSecretaryLogic = this.CreateNbaSecretaryLogic();

            // Act
            var actualAverages = nbaSecretaryLogic.GetAvgPlayerHeight();

            // Assert
            Assert.That(actualAverages, Is.EquivalentTo(this.expectedHeightAVG));

            // Verify
            this.playerRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.teamRepo.Verify(repo => repo.GetAll(), Times.Never);
        }
    }
}
