using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.CarRace.Vehicles
{
    /// <summary>
    /// Base class for all vehicles. It is an abstract class meaning
    /// <list type="bullet">
    ///   <item>Instances of this class can't be created.</item>
    ///   <item>Methods can be left unimplemented.</item>
    /// </list>
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// The speed this vehicle usually travels with.
        /// </summary>
        protected readonly int NormalSpeed;

        /// <summary>
        /// The name of this vehicle.
        /// </summary>
        protected readonly string Name;

        /// <summary>
        /// The speed of this vehicle for the given hour.
        /// <para>
        /// Will be set in the implementing classes.
        /// </para>
        /// </summary>
        protected int ActualSpeed;

        /// <summary>
        /// A variable accumulating the total of distance this vehicle has
        /// travelled.
        /// </summary>
        protected int DistanceTravelled;

        /// <summary>
        /// Prepare for the next hour: take the special events into consideration (broken truck etc)
        /// Implemented per subclass
        /// </summary>
        /// <param name="race">instance of the currently ongoing race</param>
        public abstract void PrepareForLap(Race race);

        /// <summary>
        /// Simulate the vehicle for one hour. Only updates the travelled distance,
        /// actual speed should be updated before calling this method
        /// </summary>
        public void MoveForAnHour()
        {
            DistanceTravelled += ActualSpeed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// Create a vehicle with the given name and normal speed.
        /// NOTE: normalSpeed could also have a setter method like GenerateName(),
        /// that would have been a good solution too
        /// </summary>
        /// <param name="normalSpeed">normal travelling speed of this vehicle.</param>
        protected Vehicle(int normalSpeed)
        {
            Name = GenerateName();
            NormalSpeed = normalSpeed;
        }

        /// <summary>
        /// The textual representation of this vehicle.
        /// </summary>
        /// <returns>The textual representation of this vehicle</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{type: ")
            .Append(GetType().Name)
            .Append(", ")
            .Append("name: ")
            .Append(Name)
            .Append(", ")
            .Append("distance travelled: ")
            .Append(DistanceTravelled)
            .Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// Child classes should implement naming inside this method
        /// </summary>
        /// <returns>a good name for the vehicle.</returns>
        protected abstract string GenerateName();
    }
}
