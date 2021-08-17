namespace Codecool.CarRace
{
    /// <summary>
    /// This is the main class of your program which contains Main method
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is the entry point of your program.
        /// </summary>
        /// <param name="args">Command line arguments. It is unused for this program.</param>
        public static void Main(string[] args)
        {
            Race race = new Race();
            CreateVehicles(race);

            race.SimulateRace();
            race.PrintRaceResults();
        }

        /// <summary>
        /// Creates all the vehicles that will be part of this race.
        /// </summary>
        /// <param name="race">The race where these vehiles will participate</param>
        private static void CreateVehicles(Race race)
        {
        }
    }
}
