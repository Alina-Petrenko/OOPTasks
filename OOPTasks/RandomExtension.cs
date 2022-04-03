using System;

namespace FirstTask
{
    public static class RandomExtension
    {
        public static (int X,int Y) GetRandom (this Random random)
        {
            return (random.Next(0,11),random.Next(0,11));
        }
    }
}
