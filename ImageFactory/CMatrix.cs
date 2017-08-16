using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFactory
{
    class CMatrix
    {
        public static bool MatrixMultiply(double[,] a, double[,] b, ref double[,] c)
        {/// 矩阵的乘  double
            if (a.GetLength(1) != b.GetLength(0))
                return false;
            if (a.GetLength(0) != c.GetLength(0) || b.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return true;
        }

        public static double MatrixSurplus(double[,] a)
        {/// 矩阵的行列式的值  
            int i, j, k, p, r, m, n;
            m = a.GetLength(0);
            n = a.GetLength(1);
            double X, temp = 1, temp1 = 1, s = 0, s1 = 0;

            if (n == 2)
            {
                for (i = 0; i < m; i++)
                    for (j = 0; j < n; j++)
                        if ((i + j) % 2 > 0) temp1 *= a[i, j];
                        else temp *= a[i, j];
                X = temp - temp1;
            }
            else
            {
                for (k = 0; k < n; k++)
                {
                    for (i = 0, j = k; i < m && j < n; i++, j++)
                        temp *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - i, r = m - 1; p > 0; p--, r--)
                            temp *= a[r, p - 1];
                    }
                    s += temp;
                    temp = 1;
                }

                for (k = n - 1; k >= 0; k--)
                {
                    for (i = 0, j = k; i < m && j >= 0; i++, j--)
                        temp1 *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - 1, r = i; r < m; p--, r++)
                            temp1 *= a[r, p];
                    }
                    s1 += temp1;
                    temp1 = 1;
                }

                X = s - s1;
            }
            return X;
        }

        public static bool MatrixInver(double[,] a, ref double[,] b)
        {/// 矩阵的转置  double
            if (a.GetLength(0) != b.GetLength(1) || a.GetLength(1) != b.GetLength(0))
                return false;
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    b[i, j] = a[j, i];

            return true;
        }

        public static bool MatrixOpp(double[,] a, ref double[,] b)
        {/// 矩阵的逆  
            double X = MatrixSurplus(a);
            if (X == 0) return false;
            X = 1 / X;

            double[,] B = new double[a.GetLength(0), a.GetLength(1)];
            double[,] SP = new double[a.GetLength(0), a.GetLength(1)];
            double[,] AB = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for (int m = 0; m < a.GetLength(0); m++)
                        for (int n = 0; n < a.GetLength(1); n++)
                            B[m, n] = a[m, n];
                    {
                        for (int x = 0; x < a.GetLength(1); x++)
                            B[i, x] = 0;
                        for (int y = 0; y < a.GetLength(0); y++)
                            B[y, j] = 0;
                        B[i, j] = 1;
                        SP[i, j] = MatrixSurplus(B);
                        AB[i, j] = X * SP[i, j];
                    }
                }
            MatrixInver(AB, ref b);

            return true;
        }

    }
}
