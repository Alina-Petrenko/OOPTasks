using System;

namespace ThirdTask
{
    /// <summary>
    /// Provides an extension method for the Random class
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Generates random animal
        /// </summary>
        /// <param name="random">Instance of <see cref="Random"/></param>
        /// <returns>Returns random animal</returns>
        /// TODO: method refactored
        public static Animal GetRandomAnimal(this Random random)
        {
            var value = random.Next(1, 4);
            var genders = Enum.GetValues(typeof(Gender));

            return value switch
            {
                1 => new Spider("Spider", random.Next(1, 6), (Gender)genders.GetValue(random.Next(0, 2)), random.Next(1, 5)),
                2 => new Lama("Lama", random.Next(1, 21), (Gender)genders.GetValue(random.Next(0, 2)), random.Next(1, 20)),
                3 => new Snake("Snake", random.Next(1, 10), (Gender)genders.GetValue(random.Next(0, 2)), random.Next(1, 10)),
                _ => throw new Exception("Wrong value")
            };
        }
    }
}
