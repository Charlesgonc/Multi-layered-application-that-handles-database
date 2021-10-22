// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// its the entity class Player.
    /// </summary>
    [Table("Player")]
    public partial class Player
    {
        /// <summary>
        /// Gets or sets the Primary key id of the entity class Player.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the attribute Name of the entity class Player.
        /// </summary>
        [MaxLength(50)]
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the attribute Age of the entity class Player.
        /// </summary>
        public int? PlayerAge { get; set; }

        /// <summary>
        /// Gets or sets the attribute Position of the entity class Player.
        /// </summary>
        [MaxLength(50)]
        public string PlayerPosition { get; set; }

        /// <summary>
        /// Gets or sets the attribute Height of the entity class Player.
        /// </summary>
        public double? PlayerHeight { get; set; }

        /// <summary>
        /// Gets or sets the attribute Weight of the entity class Player.
        /// </summary>
        public double? PlayerWeight { get; set; }

        /// <summary>
        /// Gets or sets the attribute Salary of the entity class Player.
        /// </summary>
        public int? PlayerSalary { get; set; }

        /// <summary>
        /// Gets or sets the attribute Field Goal of the entity class Player.
        /// </summary>
        public double? PlayerFieldGoal { get; set; }

        /// <summary>
        /// Gets or sets the attribute Draft Date of the entity class Player.
        /// </summary>
        public DateTime? PlayerDraftDate { get; set; }

        /// <summary>
        /// Gets or sets the foreign key Team of the entity class Player.
        /// </summary>
        [ForeignKey(nameof(PlayerTeamNavigation))]
        public int PlayerTeam { get; set; }

        /// <summary>
        /// Gets or sets and Sets the Player navigational properties used for the creation of the database using fluent API.
        /// </summary>
        [NotMapped]
        public virtual Team PlayerTeamNavigation { get; set; }
    }
}
