using System;
using System.Collections.Generic;
using Codecool.CarRace.Vehicles;

namespace Codecool.CarRace
{
    /// <summary>
    /// This class has methods with different forms of greetings.
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Duration of a race
        /// </summary>
        private static readonly int NUM_OF_LAPS = 50;

        /// <summary>
        /// Weather can be different for races ongoing parallel so each race has a weather.
        /// </summary>
        private Weather _weather = new Weather();

        /// <summary>
        /// Gets a value indicating whether its raining through the Weather object.
        /// </summary>
        public bool IsRaining => _weather.IsRaining;

        /// <summary>
        /// Gets a value indicating whether there is a broken truck on the track. This boolean gets updated every turn.
        /// </summary>
        public bool IsThereABrokenTruck { get; private set; }

        /// <summary>
        /// All the vehicles participating in the given race.
        /// </summary>
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        /// <summary>
        /// Prints the state of all vehicles. Called at the end of the
        /// race.
        /// </summary>
        public void PrintRaceResults()
        {
            _vehicles.ForEach(e => Console.WriteLine(e));
        }

        /// <summary>
        /// Add a racer to the race
        /// </summary>
        /// <param name="racer">The vehicle we want to add as a racer</param>
        public void RegisterRacer(Vehicle racer)
        {
            _vehicles.Add(racer);
        }

        /// <summary>
        /// Simulates the passing of time by advancing the weather and
        /// moving the vehicles for the duration of a whole race.
        /// </summary>
        public void SimulateRace()
        {
            for (int i = 0; i < NUM_OF_LAPS; i++)
            {
                foreach (Vehicle vehicle in _vehicles)
                {
                    vehicle.PrepareForLap(this);
                    vehicle.MoveForAnHour();
                }

                // change weather and update broken truck status after the movement done
                _weather.Randomize();
                IsThereABrokenTruck = GetBrokenTruckStatus();
            }
        }

        /// <summary>
        /// Update broken truck status through this method only.
        /// </summary>
        /// <returns>true if there is broken down truck on the track</returns>
        private bool GetBrokenTruckStatus()
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle is Truck)
                {
                    Truck truck = (Truck)vehicle;
                    if (truck.IsBrokenDown)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
