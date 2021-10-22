// <copyright file="IPlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Repository
{
    using NBA.Data;

    /// <summary>
    /// The interface that declarates the non generic CRUD method-update, specific for the entity PLayer.
    /// </summary>
    public interface IPLayerRepository : IRepository<Player>
    {
        // this class extends the base class IRepository<T>
        // I will extend the methods present on the base

        /// <summary>
        /// The declaration of the non generic CRUD method  to update the entity PLayer.
        /// </summary>
        /// <param name="id">The Id of the Player that we wish to his field goal.</param>
        /// <param name="newFieldGoal">The new value of the PLayer field goal that we wish to modify to.</param>
        void ChangePlayerFieldGoal(int id, float newFieldGoal);

        /// <summary>
        /// The declaration of the non generic CRUD method  to update the entity PLayer.
        /// </summary>
        /// <param name="id">The Id of the Player that we wish to cahnge his salary.</param>
        /// <param name="salary">The value of the new salary.</param>
        void ChangePlayerSalary(int id, int salary);

        // We can add adictional methods here
        // Once we are done w all repository interfaces, you wil have the
        // list of all functionalities that are required for all different repositories
        // and the list of funct required by specific ones;

        // we can start implementing them by creating a structure of classes
    }
}
