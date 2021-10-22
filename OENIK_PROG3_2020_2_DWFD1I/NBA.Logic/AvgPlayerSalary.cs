// <copyright file="AvgPlayerSalary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class that expresses the calculation of the average salary of the players belonguing to each conference.
    /// </summary>
    public class AvgPlayerSalary
    {
        /// <summary>
        /// Gets or Sets the property conference used to group the salary of thr players.
        /// </summary>
        public string Conference { get; set; }

        /// <summary>
        /// Gets or Sets the property to store the average of the salary of the players.
        /// </summary>
        public double AveragePlayerSal { get; set; }

        /// <summary>
        /// The overidden equals method so that we can compare the AvgPlayerSalary by their contents.
        /// </summary>
        /// <param name="obj">The object that we want to compaare with.</param>
        /// <returns>A boolean result on the result of the equality.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AvgPlayerSalary)
            {
                AvgPlayerSalary other = obj as AvgPlayerSalary;
                return this.Conference == other.Conference &&
                       this.AveragePlayerSal == other.AveragePlayerSal;
            }

            return false;
        }

        /// <summary>
        /// The overriden GetHAshCode in order to be able to use a specific number of the instance for hash calculations.
        /// </summary>
        /// <returns>A specific code for the class.</returns>
        public override int GetHashCode()
        {
            return this.Conference.GetHashCode(System.StringComparison.Ordinal) + (int)this.AveragePlayerSal;
        }

        /// <summary>
        /// Writes the content of the class as a nicely formatted string.
        /// </summary>
        /// <returns>the string that we want to see as a result of the call for the class instance.</returns>
        public override string ToString()
        {
            return $"Conference: {this.Conference} - AVG salary of the player: {this.AveragePlayerSal}";
        }
    }
}
