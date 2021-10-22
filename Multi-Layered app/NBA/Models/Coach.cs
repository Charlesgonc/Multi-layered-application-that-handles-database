// <copyright file="Coach.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Its the entity class Coach.
    /// </summary>
    [Table("Coach")]
    public partial class Coach
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coach"/> class.
        /// </summary>
        public Coach()
        {
            this.ConnCoachTeam = new HashSet<ConnCoachTeam>();
        }

        /// <summary>
        /// Gets or sets the Primary key id of the entity class Coach.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoachId { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Name for the Coach.
        /// </summary>
        [MaxLength(50)]
        public string CoachName { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Type for the Coach.
        /// </summary>
        [MaxLength(50)]
        public string CoachType { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Years of experience for the Coach.
        /// </summary>
        public int? CoachYearsOfExperience { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Hire date for the Coach.
        /// </summary>
        public DateTime? CoachHireDate { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Salary for the Coach.
        /// </summary>
        public int? CoachSalary { get; set; }

        /// <summary>
        /// Gets or Sets the attribute age for the Coach.
        /// </summary>
        public int? CoachAge { get; set; }

        /// <summary>
        /// Gets or Sets the attribute eamil for the Coach.
        /// </summary>
        [MaxLength(100)]
        public string CoachEmail { get; set; }

        /// <summary>
        /// Gets the collection of Teams where the entity caoch works for.
        /// </summary>
        public virtual ICollection<ConnCoachTeam> ConnCoachTeam { get; }
    }
}
