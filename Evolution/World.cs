using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public static class World
    {
        public const int wrldDimensions = 30;
        public static int numCreatures = 200;

        public static bool[,] map = new bool[wrldDimensions, wrldDimensions];


        public static int GetDims()
        {
            return wrldDimensions;
        }
    }

}
