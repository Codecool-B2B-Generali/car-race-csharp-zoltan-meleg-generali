using System;

/// <summary>
///  A wrapper around the built-in <see cref="Random"/>
///  <para>
///  Has only static methods which all use the same pseudorandom number
///  generator. In a real project it might be more finely controlled
///  which usecases share PRNGs.
///  </para>
///  Another approach would be to extend Random instead of a wrapping it.
/// </summary>
public class RandomHelper
{
    /// <summary>
    /// An instance of a pseudorandom number generator shared for all
    /// uses of methods.
    /// </summary>
    private static readonly Random _random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="RandomHelper"/> class.
    /// No point in making instances of this class.
    /// </summary>
    private RandomHelper()
    {
    }

    /// <summary>
    /// Generate a random integer from a given range.
    /// </summary>
    /// <param name="upper">upper limit of the range.</param>
    /// <returns>A random number between 0 and an upper bound.</returns>
    public static int NextInt(int upper)
    {
        return _random.Next(upper);
    }

    /// <summary>
    /// Choose a random element from an array of strings.
    /// </summary>
    /// <param name="possibilities">array of strings to choose from.</param>
    /// <returns>The chosen string.</returns>
    public static string ChooseOne(string[] possibilities)
    {
        if (possibilities == null || possibilities.Length < 1)
        {
            const string msg =
                "Possibilities should be a non-empty array of strings.";
            throw new ArgumentException(msg);
        }

        return possibilities[_random.Next(possibilities.Length)];
    }

    /// <summary>
    /// Generate a random integer from a given range.
    /// </summary>
    /// <param name="lower">lower limit of the range.</param>
    /// <param name="upper">upper limit of the range.</param>
    /// <returns>A random number between lower and an upper bound.</returns>
    public static int NextInt(int lower, int upper)
    {
        return _random.Next(lower, upper);
    }

    /// <summary>
    /// Determine whether an event has occured given the chance for it.
    /// </summary>
    /// <param name="chance">The chance of the event happening in percents.</param>
    /// <returns>true if the event has happened.</returns>
    public static bool EventWithChance(int chance)
    {
        return _random.Next(100) < chance;
    }
}
