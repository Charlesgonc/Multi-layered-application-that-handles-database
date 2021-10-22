// <copyright file="PlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data;

    /// <summary>
    /// This class implements the non generic CRUD methods specific for the entity Player.
    /// </summary>
    public class PlayerRepository : Repo<Player>, IPLayerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// gets the DbCOntext that allows us to work on the database.
        /// </summary>
        /// <param name="ctx">its the dbcontext present on the mother class.</param>
        public PlayerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Implementation of the CRUD method to get one player.
        /// We will execute the 2 method calls with a single query statement.
        /// </summary>
        /// <param name="id">is the id of the Player that we want to find.</param>
        /// <returns>a single Player.</returns>
        public override Player GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.PlayerId == id);
        }

        /// <summary>
        /// The implementation of the non generic CRUD method  to update the entity Player.
        /// </summary>
        /// <param name="id">The id of  the player tha we wish to make the update.</param>
        /// <param name="newFieldGoal">The value of the new fiel goal that we wish to assign to the player.</param>
        public void ChangePlayerFieldGoal(int id, float newFieldGoal)
        {
            var player = this.GetOne(id);
            if (player == null)
            {
                throw new InvalidOperationException("PLayer not found");
            }

            player.PlayerFieldGoal = newFieldGoal;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// The implementation of the non generic CRUD method  to update the entity Player.
        /// </summary>
        /// <param name="id">The Id of the Player that we wish to cahnge his salary.</param>
        /// <param name="salary">The value of the new salary.</param>
        public void ChangePlayerSalary(int id, int salary)
        {
            var player = this.GetOne(id);
            if (player == null)
            {
                throw new InvalidOperationException("PLayer not found");
            }

            player.PlayerSalary = salary;
            this.Ctx.SaveChanges();
        }
    }
}
