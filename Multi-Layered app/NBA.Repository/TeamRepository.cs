// <copyright file="TeamRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data;

    /// <summary>
    /// This class implements the non generic CRUD methods specific for the entity Team.
    /// </summary>
    public class TeamRepository : Repo<Team>, ITeamRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// gets the DbCOntext that allows us to work on the database.
        /// </summary>
        /// <param name="ctx">its the dbcontext present on the mother class.</param>
        public TeamRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Implementation of the CRUD method to get one team.
        /// We will execute the 2 method calls with a single query statement.
        /// </summary>
        /// <param name="id">is the id of the Team that we want to find.</param>
        /// <returns>a single Team.</returns>
        public override Team GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.TeamId == id);
        }

        /// <summary>
        /// Implements the non generic CRUD method decalred on the mother interface.
        /// </summary>
        /// <param name="id">The id of the Team that we wish to make the update.</param>
        /// <param name="newNumber">The new value of the championships won by this team.</param>
        public void ChangeTeamNumOfChamps(int id, int newNumber)
        {
            var team = this.GetOne(id);
            if (team == null)
            {
                throw new InvalidOperationException("Team not found");
            }

            team.TeamChampionshipsWon = newNumber;
            this.Ctx.SaveChanges();
        }
    }
}
