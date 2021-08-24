using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.CarRace
{
    /// <summary>
    /// A class representing the weather. Advances its state by each call
    /// to <see cref="Weather"/>
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Chance that it will rain in a new time-step.
        /// </summary>
        private const int CHANCE_OF_RAIN = 30;

        /// <summary>
        /// Gets a value indicating whether it is raining in the current time-step.
        /// </summary>
        public bool IsRaining { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weather"/> class.
        /// Sets the state of the rain in the constructor.
        /// </summary>
        public Weather()
        {
            Randomize();
        }

        /// <summary>
        /// Calculate the new state of the weather.
        /// </summary>
        public void Randomize()
        {
            IsRaining = RandomHelper.EventWithChance(CHANCE_OF_RAIN);
        }
    }
}
