using System;
using System.Windows.Forms;

namespace Matrix_Operations
{
    internal class MatrixMath
    {

        public static double[,] AddMatrices(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
            {
                MessageBox.Show("Matrices must be of the same size to perform addition");
                //Console.WriteLine("Matrices must be of the same size to perform addition");
                return null; // Returning null as matrices cannot be added
            }
            else
            {
                int rows = m1.GetLength(0);
                int columns = m1.GetLength(1);
                double[,] result = new double[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                displayMatrix(result);
                return result;
            }
        }

        public static double[,] SubtractMatrices(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
            {
                MessageBox.Show("Matrices must be of the same size to perform subtraction");
               // Console.WriteLine("Matrices must be of the same size to perform subtraction");
                return null; // Returning null as matrices cannot be added
            }
            else
            {
                int rows = m1.GetLength(0);
                int columns = m1.GetLength(1);
                double[,] result = new double[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = m1[i, j] - m2[i, j];
                    }
                }
                displayMatrix(result);
                return result;
            }
        }

        public static double[,] MultiplyMatrices(double[,] m1, double[,] m2)
        {

            int m1Rows = m1.GetLength(0);
            int m1Columns = m1.GetLength(1);
            int m2Rows = m2.GetLength(0);
            int m2Columns = m2.GetLength(1);


            if (m1Columns != m2Rows)
            {
                MessageBox.Show("Number of columns in the 1st matrix must be equal to the rows in the 2nd matrix for multiplication.");
               // Console.WriteLine("Number of columns in the 1st matrix must be equal to the rows in the 2nd matrix for multiplication.");
                return null;
            }

            double[,] result = new double[m1Rows, m2Columns];

            for (int i = 0; i < m1Rows; i++)
            {
                for (int j = 0; j < m2Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m1Columns; k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            displayMatrix(result);
            return result;
        }

        public static double[,] ScaleMatrix(double[,] m1, double Scalar)
        {
            if (m1 == null) return null;

            int rows = m1.GetLength(0);
            int columns = m1.GetLength(1);

            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = m1[i, j] * Scalar;
                }
            }
            displayMatrix(result);
            return result;
        }

        private static void displayMatrix(double[,] resultMatrix)
        {
            if (resultMatrix == null) return;
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }

}

