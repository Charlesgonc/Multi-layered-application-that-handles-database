// <copyright file="AvgPLayerHeight.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The class that expresses the calculation of the average height of a team.
    /// </summary>
    public class AvgPLayerHeight
    {
        /// <summary>
        /// Gets or Sets the property name of the team.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or Sets the property where we will store the height average of the team.
        /// </summary>
        public double AveragePlayerHeight { get; set; }

        /// <summary>
        /// The ovveridden equals method so that we can compare the AvgPLayerHeight by their contents.
        /// </summary>
        /// <param name="obj">The object that we want to compaare with.</param>
        /// <returns>A boolean result on the result of the equality.</returns>
        public override bool Equals(object obj)
        {
            if (obj is AvgPLayerHeight)
            {
                AvgPLayerHeight other = obj as AvgPLayerHeight;
                return this.TeamName == other.TeamName &&
                       this.AveragePlayerHeight == other.AveragePlayerHeight;
            }

            return false;
        }

        /// <summary>
        /// The overriden GetHAshCode in order to be able to use a specific number of the instance for hash calculations.
        /// </summary>
        /// <returns>A specific code for the class.</returns>
        public override int GetHashCode()
        {
            return this.TeamName.GetHashCode(System.StringComparison.Ordinal) + (int)this.AveragePlayerHeight;
        }

        /// <summary>
        /// Writes the content of the class as a nicely formatted string.
        /// </summary>
        /// <returns>the string that we want to see as a result of the call for the class instance.</returns>
        public override string ToString()
        {
            return $"Team: {this.TeamName} - AVG salary of the coach: {this.AveragePlayerHeight}";
        }
    }
}
