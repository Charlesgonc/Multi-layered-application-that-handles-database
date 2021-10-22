// <copyright file="Team.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Its the entity class Team.
    /// </summary>
    [Table("Team")]
    public partial class Team
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        public Team()
        {
            this.ConnCoachTeam = new HashSet<ConnCoachTeam>();
            this.Player = new HashSet<Player>();
        }

        /// <summary>
        /// Gets or sets the Primary key id of the entity class Team.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Name for the Entity class Team.
        /// </summary>
        [MaxLength(50)]
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Team Conference for the Entity class Team.
        /// </summary>
        [MaxLength(50)]
        public string TeamConference { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Team Foundation for the Entity class Team.
        /// </summary>
        public DateTime? TeamFoundationDate { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Championships won for the Entity class Team.
        /// </summary>
        public int? TeamChampionshipsWon { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Arena for the Entity class Team.
        /// </summary>
        [MaxLength(50)]
        public string TeamArena { get; set; }

        /// <summary>
        /// Gets the collection of the coaches that work for the team.
        /// </summary>
        public virtual ICollection<ConnCoachTeam> ConnCoachTeam { get; }

        /// <summary>
        /// Gets the collection of the Players that play for the team.
        /// </summary>
        public virtual ICollection<Player> Player { get; }
    }
}
