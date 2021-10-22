// <copyright file="CoachRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using NBA.Data;

    /// <summary>
    /// This class implements the non generic CRUD methods specific for the entity Caoch.
    /// </summary>
    public class CoachRepository : Repo<Coach>, ICoachRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoachRepository"/> class.
        /// gets the DbCOntext that allows us to work on the database.
        /// </summary>
        /// <param name="ctx">its the dbcontext present on the mother class.</param>
        public CoachRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Implementation of the CRUD method to get one coach.
        /// We will execute the 2 method calls with a single query statement.
        /// </summary>
        /// <param name="id">is the id of the Coach that we want to find.</param>
        /// <returns>a single Coach.</returns>
        public override Coach GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CoachId == id);
        }

        /// <summary>
        /// The implementation of the non generic CRUD method  to update the entity Coach.
        /// </summary>
        /// <param name="id">the id of the coach that we wish to make the update.</param>
        /// <param name="newSalary">the value of the salary that we wish to change for the coach.</param>
        public void ChangeCoachSalary(int id, int newSalary)
        {
            var coach = this.GetOne(id);
            if (coach == null)
            {
                throw new InvalidOperationException("Coach not found");
            }

            coach.CoachSalary = newSalary;
            this.Ctx.SaveChanges();
        }
    }
}
