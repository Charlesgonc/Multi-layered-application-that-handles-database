// <copyright file="FGAveragesResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Logic
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class that expresses the calculation of the field goal that we want to get for a determined team.
    /// </summary>
    public class FGAveragesResult
    {
        // will have all the CRUD methods meaning that using repositories you should be able to add, modify, delete entities,
        //  and also will containi the NON-CRUD methods that are 3 that require group by and join.
        // so whenever we have a gorup by result, if its temporary result then we canuse a annonimous instance,
        //  but if its something that the logic returns we have to create a clss for it.

        // so for eg I will have team field goal average considering the field goal of each player,
        // for every player I want to see the team FG averages so i will create the team average class
        // and the result will be obtained by using the averageResult class

        // Note that the NON-CRUD methods will be using the Average calss, which means that we will have unitTests dealing w Avgs as well
        // If u have a uNit test for a class u must have appropriate mathods (namely toString-will be only used by me, Equals and GetHashCode-the imptt ones)
        // the uNit test result will use those to check the equality of two average results instances
        // I should have some register papers or something operation...and then I have register and something logic, stablish the operation between them(?).

        /// <summary>
        /// Gets or Sets the name of the team.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or Sets the property where we will store the average field goal of the team.
        /// </summary>
        public double AverageFG { get; set; }

        /// <summary>
        /// Checks the equality of the FGAverageResults.
        /// </summary>
        /// <param name="obj">the field goal result that we want to compare to.</param>
        /// <returns>A boolean result on the result of the equality.</returns>
        public override bool Equals(object obj)
        {
            if (obj is FGAveragesResult)
            {
                FGAveragesResult other = obj as FGAveragesResult;
                return this.TeamName == other.TeamName &&
                       this.AverageFG == other.AverageFG;
            }

            return false;
        }

        /// <summary>
        /// gets the hash code of this field goal average result that can be used for the calculation.
        /// </summary>
        /// <returns>an integer that can be used for the avg calculations.</returns>
        public override int GetHashCode()
        {
            // return 0 in case that u want to force the execution of the equals method all the time
            // in case we want to get an integer that can be used to make some hash calculations
            return this.TeamName.GetHashCode(System.StringComparison.Ordinal) + (int)this.AverageFG;
        }

        /// <summary>
        /// Puts the content of the class into string containing the name of the team and the avg fg of the team.
        /// </summary>
        /// <returns>the team name and the average FG of the team whenever the class is called.</returns>
        public override string ToString()
        {
            return $"Team: {this.TeamName} - AVG feild goal: {this.AverageFG}";
        }
    }
}
