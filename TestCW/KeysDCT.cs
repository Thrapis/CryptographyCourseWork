
using System;

namespace TestCW
{
    /// <summary>
    /// Рассчитаные значения для дискретного косинусного преобразования
    /// </summary>
    public static class KeysDCT
    {
        /*public static double[,] cos_t = { {1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0},
                            {0.9807853, 0.8314696, 0.5555702, 0.1950903, -0.1950903,-0.5555702,-0.8314696,-0.9807853},
                            {0.9238795, 0.3826834,-0.3826834,-0.9238795, -0.9238795,-0.3826834, 0.3826834, 0.9238795},
                            {0.8314696,-0.1950903,-0.9807853,-0.5555702, 0.5555702, 0.9807853, 0.1950903,-0.8314696},
                            {0.7071068,-0.7071068,-0.7071068, 0.7071068, 0.7071068,-0.7071068,-0.7071068, 0.7071068},
                            {0.5555702,-0.9807853, 0.1950903, 0.8314696, -0.8314696,-0.1950903, 0.9807853,-0.5555702},
                            {0.3826834,-0.9238795, 0.9238795,-0.3826834, -0.3826834, 0.9238795,-0.9238795, 0.3826834},
                            {0.1950903,-0.5555702, 0.8314696,-0.9807853, 0.9807853,-0.8314696, 0.5555702,-0.1950903} };


        public static double[,] e = { {0.125, 0.176777777, 0.176777777, 0.176777777, 0.176777777, 0.176777777, 0.176777777, 0.176777777},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25},
                        {0.176777777, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25} };*/


        private static double[,] cos_t;
        private static double[,] e;

        public static double[,] Сos_t   // cos⁡((π⋅v(2x+1))/2N) and cos⁡((π⋅u(2y+1))/2N)
        {
            get
            {
                if (cos_t == null)
                    GenerateKeysDCT();
                return cos_t;
            }
            private set
            {
                cos_t = value;
            }
        }

        public static double[,] E       // ξ(u)⋅ξ(v))/√2N
        {
            get
            {
                if (e == null)
                    GenerateKeysDCT();
                return e;
            }
            private set
            {
                e = value;
            }
        }

        /// <summary>
        /// Рассчёт значений для дискретного косинусного преобразования
        /// </summary>
        private static void GenerateKeysDCT()
        {
            int n = 8;

            cos_t = new double[n, n];
            e = new double[n, n];

            double U, V;
            for (int v = 0; v < n; v++)
            {
                for (int u = 0; u < n; u++)
                {
                    if (v == 0) V = 1.0 / Math.Sqrt(2);
                    else V = 1;
                    if (u == 0) U = 1.0 / Math.Sqrt(2);
                    else U = 1;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Сos_t[v, i] = Math.Cos(Math.PI * v * (2 * i + 1) / (2 * n));
                        }
                    }

                    E[v, u] = U * V / Math.Sqrt(2 * n);
                }
            }
        }

    }
}
