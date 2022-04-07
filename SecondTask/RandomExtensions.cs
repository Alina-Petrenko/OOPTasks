using System;

namespace SecondTask
{
    /// <summary>
    /// Provides an extension method for the Random class
    /// </summary>
    /// TODO: renamed from RandomExtension to RandomExtensions
    /// TODO: Here could be more extensions in future.
    public static class RandomExtensions
    {
        /// <summary>
        /// Generates random coordinates
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Returns tuple of coordinates</returns>
        public static (int X,int Y) GetRandomPoint (this Random random)
        {
            return (random.Next(-10,11),random.Next(-10,11));
        }
    }
}
