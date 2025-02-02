// See https://aka.ms/new-console-template for more information
// using System.Drawing;
// using Pastel;

// Console.WriteLine("Hello, World!".Pastel(Color.Green));

using System;
using System.Linq;

namespace SortAndAverageAndAgeValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example list of integers
            int[] numbers = { 5, 2, 8, 3, 1, 4, 7, 6 };

            // Prompt user for choice
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Sort the list");
            Console.WriteLine("2. Calculate the average");
            Console.WriteLine("3. Both");
            Console.WriteLine("4. Validate age");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SortList(numbers);
                    break;
                case "2":
                    CalculateAverage(numbers);
                    break;
                case "3":
                    SortList(numbers);
                    CalculateAverage(numbers);
                    break;
                case "4":
                    ValidateAge();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please select 1, 2, 3, or 4.");
                    break;
            }
        }

        static void SortList(int[] numbers)
        {
            Array.Sort(numbers);
            Console.WriteLine("Sorted List:");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static void CalculateAverage(int[] numbers)
        {
            double average = numbers.Average();
            Console.WriteLine($"Average: {average}");
        }

        static void ValidateAge()
        {
            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Please enter your age: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out age) && age >= 1 && age <= 120)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 120.");
                }
            }

            Console.WriteLine($"Thank you! Your age is {age}.");
        }
    }
}
