using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class Matrix
    {
        public Matrix(int[] dimestions)
        {            
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }                       
        }
    }
}
