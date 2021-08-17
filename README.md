# Car Race

## Story

Your task will be to simulate a race. You will need to create 10
cars, 10 trucks, 10 motorcycles, and race them for 50 hours. After
simulating the race, print the results.

!> This is a **guided project**, a regular project with a step-by-step guide
   (see the Background materials). In order to learn the most, try and
   implement it on your own first, and check the solution only when you feel
   your version is ready. However, when you feel completely stuck, feel free
   to check the guide for hints.

## What are you going to learn?

- write a simulation with many objects
- design the way how the objects' states evolve and how they "communicate" with each other
- use inheritance and composition
- use random values

## Tasks

1. Set all the participants, constants, and random elements needed to start the race
    - The race itself, 10 cars, 10 trucks, and 10 motorcycles are created in the main method.

2. Race object has to store all the racers, also let us register them from outside. One race lasts 50 hours.
    - Register a car, truck, or motorcycle into the race with a method called `RegisterRacer()`
    - Race simulation can be done by `SimulateRace()` this will:
  - call `MoveForAnHour()` on every vehicle 50 times
  - set whether it is raining or not for every hour
    - Prints each vehicle's name, distance traveled, and type with `printRaceResults()`
    - It is possible to check if there is an active yellow flag for the current hour of the race with `bool GetBrokenTruckStatus()` returning `true` when there is a broken truck on the track.

3. We can check the weather during the current hour of the race and set a new random weather for the next hour.
    - The `Advance()` method sets the weather with 30% chance to rain
    - The `IsRaining()` method returns `true` if it is currently raining

4. Cars are vehicles with personality so they have imaginative names. Create a list of possible words from here: <http://www.fantasynamegenerators.com/car-names.php> and pick randomly two for each instance. Cars need to be careful and slow down when there is a broken truck on the race tracks.
    - The `Name` property stores the name of the car composed of two random words form the above list.
    - The `NormalSpeed` property stores the normal speed of the car, set to a random number in the constructor between 80 and 110 km/h
    - The actual speed of the car for this hour is stored in `ActualSpeed`. If there is a yellow flag, limit the speed of car to 75 km/h otherwise use the value of `NormalSpeed`
    - The `DistanceTraveled` property holds the summarized distance traveled in the race so far
    - The `PrepareForLap()` method is used to setup the actual speed used for the current lap
    - One hour of racing is simulated with the `MoveForAnHour()` method. One hour of racing is simulated with the `moveForAnHour` method.

5. Motorcycles are pretty fast but making turns in rain is dangerous so they have to slow down in bad weather conditions. They don't care about broken down trucks.
    - The motorcycles are called "Motorcycle 1", "Motorcycle 2", "Motorcycle 3",... This is be a unique value based on the creation order, and stored in the `Name` property
    - The actual speed of the motorcycle for this hour is stored in `ActualSpeed`. Normally the speed is 100 km/h. In rain motorcycles slow down by a random value between 5 and 50 km/h.
    - The `DistanceTraveled` property holds the summarized distance traveled in the race so far
    - The `PrepareForLap()` method is used to setup the actual speed used for the current lap
    - One hour of racing is simulated with the `MoveForAnHour` method. The motorcycle travels for an hour, increasing the distance traveled.

6. Trucks are real powerhouses but their intricate engines are prone to failure. When they break down, they have to stop for a while to repair the engine.
    - The actual speed of the vehicle for this race hour is stored in `ActualSpeed`. The speed of a truck is 100 km/h or 0 when broken down
    - The `Name` property stores the name. Truck drivers are boring, they call their trucks on a random number between 0 and 1000
    - The `DistanceTraveled` property holds the summarized distance traveled in the race so far
    - The `PrepareForLap()` method is used to setup the actual speed used for the current lap. Trucks have a 5% chance of breaking down for 2 hours
    - When a truck is broken down, it cannot break down again during the reparation
    - One hour of racing is simulated with the `MoveForAnHour` method. The truck travels for an hour, increasing the distance traveled.

## General requirements

None

## Hints

- Have you noticed that `Car`, `Motorcycle` and `Truck` share some similarities?
  Use inheritance to abstract away the common parts.
- Use the built-in `Random` class to generate random numbers.
  Implement a custom utility class around it, if you find it useful.
- The actual speed of a vehicle sometimes depends on the state of other vehicles or
  on contextual features like weather. But we cannot set their speed from the outside
  since the speed setting logic should be encapsulated into the vehicle classes.
  How, then, can a specific vehicle get to such contextual information? Think about
  in terms of necessary communication between objects!

## Background materials

- [OOP basics](project/curriculum/materials/pages/csharp/basics-of-object-oriented-programming.md)
- [Collections](project/curriculum/materials/pages/csharp/collections.md)
- [Abstraction, abstract classes and interfaces](project/curriculum/materials/pages/csharp/abstraction.md)
- [A step-by-step solution guide](project/curriculum/materials/pages/csharp/car-race-step-by-step.md)

