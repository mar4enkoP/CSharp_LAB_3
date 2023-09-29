using System;
using System.Threading.Tasks;

namespace CSharp_LAB_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task914();
        }
        
        /// <summary>
        /// Генерирует случайный двумерный массив целых чисел в указанном диапазоне
        /// </summary>
        /// <param name="rowCount">Количество строк. (по умолчанию 3)</param>
        /// <param name="columnCount">Количество столбцов (по умолчанию 3).</param>
        /// <param name="minValue">Минимальное значение (по умолчанию 1).</param>
        /// <param name="maxValue">Максимальное значение (по умолчанию 100).</param>
        static int[,] GenerateRandomMatrix(int rowCount = 3, int columnCount = 3, int minValue = 1, int maxValue = 100)
        {
            Random random = new Random();

            // Input validation
            if (minValue > maxValue)
            {
                throw new ArgumentException("The minimum value shall be less than or equal to the maximum value");
            }

            if (rowCount <= 0 || columnCount <= 0)
            {
                throw new ArgumentException("Number of rows and columns should be a positive number");
            }

            int[,] matrix = new int[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Array :");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            return matrix;
        }
        
        /// <summary>
        ///     907. Найти суммы элементов Двумерного массива целых чисел, расположенных на линиях,
        ///          параллельных главной диагонали, и ниже нее.
        /// </summary>
        static void Task907()
        {
            int[,] matrix = GenerateRandomMatrix();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int sum = 0;
            
            Console.Write("Element on the parallel main diagonal line and below:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Проверка находиься ли элемент на линии паралельной главной диагонали и ниже
                    if (i >= j)
                    {
                        sum += matrix[i, j];
                        Console.Write("  " + matrix[i, j]);
                    } 
                }
            }

            Console.Write("\nSum: " + sum);
            
        }

        /// <summary>
        ///     914. Найти номер столбца Двумерного массива целых чисел,
        ///          для которого среднеарифметическое значение его элементов максимально.
        /// </summary>
        static void Task914()
        {
            int[,] matrix = GenerateRandomMatrix(3,3,-100, 100);

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double maxAverage = double.MinValue;//самое маленькое значение для типа double, чтобы кореккно работать с отрицательными среднеарифметическими значениями столбцов масива
            int maxAverageColumn = -1;

            for (int j = 0; j < cols; j++)
            {
                double columnSum = 0;

                for (int i = 0; i < rows; i++)
                {
                    columnSum += matrix[i, j];
                }

                double columnAverage = columnSum / rows;

                if (columnAverage > maxAverage)
                {
                    maxAverage = columnAverage;
                    maxAverageColumn = j;
                }
            }

            Console.WriteLine("Column number(index) with maximum arithmetic mean: " + maxAverageColumn);
        }
    }
}