﻿using System;
using System.Threading.Tasks;

namespace CSharp_LAB_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 907");
            Console.ResetColor();
            Task907();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 914");
            Console.ResetColor();
            Task914();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 933");
            Console.ResetColor();
            Task933();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 970");
            Console.ResetColor();
            Task970();

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

            int rows = matrix.GetLength(0);//возвращает количество строк
            int cols = matrix.GetLength(1);//возвращает количество столбцов
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
        ///     [Задание дублируеться] 
        ///     914. Найти номер столбца Двумерного массива целых чисел,
        ///          для которого среднеарифметическое значение его элементов максимально.
        /// </summary>
        static void Task914()
        {
            int[,] matrix = GenerateRandomMatrix(3, 3, -100, 100);

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double maxAverage = double.MinValue; //самое маленькое значение для типа double, чтобы кореккно работать с отрицательными среднеарифметическими значениями столбцов масива
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

        /// <summary>
        ///     933. Отсортировать нечетные столбцы массива по возрастанию.
        /// </summary>
        static void Task933()
        {
            int[,] matrix = GenerateRandomMatrix(10, 10);

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
               
                if (j % 2 != 0) // Проверяка нечетности
                {
                    int[] columnToSort = new int[rows];
                    
                    for (int i = 0; i < rows; i++)  // Копирование столбец в массив для дальнейшей сортировки
                    {
                        columnToSort[i] = matrix[i, j];
                    }
                    
                    Array.Sort(columnToSort); //сортировкf

                    
                    for (int i = 0; i < rows; i++) // Заменяем значения в столбце отсортированными значениями
                    {
                        matrix[i, j] = columnToSort[i];
                    }
                }
            }
            
            Console.WriteLine("Sorted array by odd columns:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        ///     970. В Двумерном массиве хранится информация о зарплате 18 человек за каждый месяц года
        ///          (в первом столбце — зарплата за январь, во втором — за февраль и т. д.).
        ///          Составить программу для расчета средней зарплаты за любой месяц.
        /// </summary>
        static void Task970()
        {
            int[,] salaryData = GenerateRandomMatrix(18,12,1000,4000);// 18 человек, 12 месяцев

            int totalSalaries = 0;
            int monthIndex = 2; // (0 - янврь, 1 - февраль...)

            for (int i = 0; i < salaryData.GetLength(0); i++)
            {
                totalSalaries += salaryData[i, monthIndex];
            }

            double averageSalary = (double)totalSalaries / salaryData.GetLength(0);

            Console.WriteLine("Average monthly salary: " + averageSalary);
        }
    }
}