// <copyright file="TeamManagerLogicTests.cs" company="PlaceholderCompany">
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
    /// The testing class responsible for testing the operations implemented on the business logic TeamMAnager.
    /// </summary>
    [TestFixture]
    public class TeamManagerLogicTests
    {
        /// <summary>
        /// The CRUD testing for get all players method.
        /// </summary>
        [Test]
        public void TestGetAllPlayers()
        {
            // Arrange
            Mock<IPLayerRepository> playerRepo = new Mock<IPLayerRepository>();
            Mock<ICoachRepository> coachRepo = new Mock<ICoachRepository>();
            List<Player> playerList = new List<Player>()
            {
                new Player() { PlayerId = 1, PlayerName = "Michael Jordan", PlayerPosition = "SG" },
                new Player() { PlayerId = 2, PlayerName = "Stephen Curry", PlayerPosition = "PG" },
                new Player() { PlayerId = 3, PlayerName = "Lebron James", PlayerPosition = "PF" },
            };
            List<Player> expectedList = new List<Player>() { playerList[0], playerList[1], playerList[2] };

            playerRepo.Setup(repo => repo.GetAll()).Returns(playerList.AsQueryable());

            TeamManagerLogic teamManagerLogic = new TeamManagerLogic(playerRepo.Object, coachRepo.Object);

            // Act
            var result = teamManagerLogic.GetAllPlayers();

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result, Is.EquivalentTo(expectedList));

            playerRepo.Verify(repo => repo.GetAll(), Times.Once);
            coachRepo.Verify(repo => repo.GetAll(), Times.Exactly(0));
            playerRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// The CRUD testing for get one player method.
        /// </summary>
        [Test] // CRUD Test => Get one player
        public void TestGetOnePlayer()
        {
            // Assert
            Mock<IPLayerRepository> playerRepo = new Mock<IPLayerRepository>();
            Mock<ICoachRepository> coachRepo = new Mock<ICoachRepository>();

            Player playerExpected = new Player() { PlayerId = 3, PlayerName = "Lebron James", PlayerPosition = "PF" };
            playerRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(playerExpected);

            TeamManagerLogic teamManagerLogic = new TeamManagerLogic(playerRepo.Object, coachRepo.Object);

            // Act
            var result = teamManagerLogic.GetOnePlayer(It.IsAny<int>());

            // Assert
            Assert.That(result, Is.EqualTo(playerExpected));

            // Verify
            playerRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Exactly(1));
            coachRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Exactly(0));
            playerRepo.Verify(repo => repo.GetAll(), Times.Never);
        }
    }
}
