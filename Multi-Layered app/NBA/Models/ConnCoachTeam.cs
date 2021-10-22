// <copyright file="ConnCoachTeam.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The connectionn table between the Coach and the Team.
    /// </summary>
    [Table("ConnCoachTeam")]
    public partial class ConnCoachTeam
    {
        /// <summary>
        /// Gets or sets the Primary key id of the Connection class between Coach and Team.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConnId { get; set; }

        /// <summary>
        /// Gets or Sets the attribute coach for the connection table.
        /// </summary>
        public int? ConnCoach { get; set; }

        /// <summary>
        /// Gets or Sets the attribute Team for the connection table.
        /// </summary>
        public int? ConnTeam { get; set; }

        /// <summary>
        /// Gets or Sets the navigational property of the Coach for the connector table.
        /// </summary>
        [NotMapped]
        public virtual Coach ConnCoachNavigation { get; set; }

        /// <summary>
        /// Gets or Sets the navigational property of the Team for the connector table.
        /// </summary>
        [NotMapped]
        public virtual Team ConnTeamNavigation { get; set; }
    }
}
