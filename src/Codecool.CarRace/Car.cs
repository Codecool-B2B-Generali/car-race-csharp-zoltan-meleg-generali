using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.CarRace.Vehicles
{
    /// <summary>
    /// car class
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// Cars can travel with this speed when there is a broken
        /// truck on the tracks.
        /// </summary>
        protected const int YELLOW_FLAG_SPEED = 75;

        /// <summary>
        /// Initializes a new instance of the <see cref="Car"/> class.
        /// Create a car.
        /// <para>
        /// The call to the parent class' constructor has to be the first
        /// thing the constructor does.  But we have to pass data to it.
        /// We solve this by calling two static methods because both values
        /// are calculated per instance.
        /// </para>
        /// </summary>
        public Car()
            : base(CalculateNormalSpeed())
        {
        }

        /// <summary>
        /// The normal speed of the car determined by random.
        /// </summary>
        /// <returns>A value between 80 and 110 inclusive.</returns>
        private static int CalculateNormalSpeed()
        {
            return RandomHelper.NextInt(80, 110 + 1);
        }

        /// <summary>
        /// List of names that cars can choose from.  It is a property of
        /// all cars so it is made static.
        /// </summary>
        private static readonly string[] POSSIBLE_NAMES =
            {
                "Epiphany",
                "Parallel",
                "Blitz",
                "Eos",
                "Evolution",
                "Wolf",
                "Union",
                "Empyrean",
                "Curiosity",
                "Gallop",
            };

        /// <summary>
        /// If there is a broken truck on the track the actual speed is limited
        /// </summary>
        /// <param name="race">instance of the current race from where we can access data
        /// for example weather conditions and broken truck info</param>
        public override void PrepareForLap(Race race)
        {
            if (race.IsThereABrokenTruck)
            {
                ActualSpeed = YELLOW_FLAG_SPEED;
            }
            else
            {
                ActualSpeed = NormalSpeed;
            }
        }

        /// <summary>
        /// Generate a name consisting of a first and last name chosen
        /// from the list of allowed names.
        /// </summary>
        /// <returns>The generated name.</returns>
        protected override string GenerateName()
        {
            string firstName = RandomHelper.ChooseOne(POSSIBLE_NAMES);
            string lastName = RandomHelper.ChooseOne(POSSIBLE_NAMES);
            return firstName + " " + lastName;
        }
    }
}
