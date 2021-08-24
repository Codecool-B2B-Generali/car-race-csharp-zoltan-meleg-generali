using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.CarRace.Vehicles
{
    /// <summary>
    /// truck class
    /// </summary>
    public class Truck : Vehicle
    {
        /// <summary>
        /// Trucks go with a steady 100 km/h.
        /// </summary>
        private const int NORMAL_SPEED = 100;

        /// <summary>
        /// There's a five percent chance a truck will break down.
        /// </summary>
        private const int BREAKDOWN_CHANCE = 5;

        /// <summary>
        /// If a truck breaks down, fixing it takes this many turns
        /// </summary>
        private const int TURNS_NEEDED_TO_FIX_TRUCK = 2;

        /// <summary>
        /// Trucks current state.
        /// </summary>
        private State _state = State.OPERATIONAL;

        /// <summary>
        /// Possible states a truck can be in.
        /// Notice that it is embedded inside the truck class.
        /// </summary>
        private enum State
        {
            OPERATIONAL,
            BROKEN_DOWN,
        }

        /// <summary>
        /// Gets a value indicating whether this truck is operational.
        /// Note: This code uses multiple abbreviations, its equal to this code:
        /// <code>
        /// public bool IsBrokenDown { get => _state != State.OPERATIONAL; }
        /// </code>
        /// and also to this one:
        /// <code>
        /// public bool IsBrokenDown { get { return _state != State.OPERATIONAL; } }
        /// </code>
        /// </summary>
        public bool IsBrokenDown => _state != State.OPERATIONAL;

        /// <summary>
        /// When a truck breaks down we need to count the turns spent with fixing
        /// </summary>
        private int _breakdownTurnsLeft;

        /// <summary>
        /// A state machine implementation.
        /// </summary>
        /// <returns>The state following this state.</returns>
        private State NextState()
        {
            switch (_state)
            {
                case State.OPERATIONAL:
                    if (RandomHelper.EventWithChance(BREAKDOWN_CHANCE))
                    {
                        _breakdownTurnsLeft = TURNS_NEEDED_TO_FIX_TRUCK;
                        return State.BROKEN_DOWN;
                    }

                    break;
                case State.BROKEN_DOWN:
                    if (_breakdownTurnsLeft-- > 0)
                    {
                        return State.BROKEN_DOWN;
                    }

                    break;
            }

            return State.OPERATIONAL;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Truck"/> class.
        /// </summary>
        public Truck()
            : base(NORMAL_SPEED)
        {
        }

        /// <summary>
        /// Calculate the actual speed and also advance the state of the truck.
        /// </summary>
        /// <param name="race">the current race object</param>
        public override void PrepareForLap(Race race)
        {
            if (IsBrokenDown)
            {
                ActualSpeed = 0;
            }
            else
            {
                ActualSpeed = NORMAL_SPEED;
            }

            // change state after setting the speed so it becomes active only from the next turn
            _state = NextState();
        }

        /// <summary>
        /// Generate name by converting a random integer to string
        /// </summary>
        /// <returns>The name of the truck</returns>
        protected override string GenerateName()
        {
            return RandomHelper.NextInt(1001).ToString();
        }
    }
}
