using System;

namespace FindMaximum
{
    public static class RecursiveApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console App 'Find max using recursion'\r");
            Console.WriteLine("-------------------------------------");
            bool endApp = false;
            int arraySize;

            while (!endApp)
            {
                try
                {
                    GetArraySize(out arraySize);
                    if (arraySize <= 0)
                    {
                        ShowFirstExeption();
                        continue;
                    }
                    if (arraySize > 1000)
                    {
                        ShowSecondExeption();
                        continue;
                    }
                }
                catch (Exception)
                {
                    ShowThirdExeption();
                    continue;
                }

                int[] currentArray = new int[arraySize];
                int startIndex = 0;

                CreateRandomArray(currentArray);
                ShowGeneratedArray(currentArray);
                AskUser();

                int maxValue = FindMaxUsingRecursion(currentArray, startIndex);
                Console.WriteLine($"Your result is: {maxValue}");
                Console.WriteLine("-------------------------------------");

                TryExit();
            }
        }
        static void GetArraySize(out int size)
        {
            Console.WriteLine("\nEnter the size of the array (natural number): ");
            size = int.Parse(Console.ReadLine());
        }
        static void ShowFirstExeption()
        {
            Console.WriteLine("\nExeption. Size can't be less or equal zero.\nPress Enter to continue.");
            Console.ReadLine();
        }
        private static void ShowSecondExeption()
        {
            Console.WriteLine("\nExeption. For ease of display, the size is limited. Size cannot be greater than 1000.\nPress Enter to continue.");
            Console.ReadLine();
        }
        static void ShowThirdExeption()
        {
            Console.WriteLine("\nExeption. Size isn't a natural number.\nPress Enter to continue.");
            Console.ReadLine();
        }
        static void CreateRandomArray(int[] array)
        {
            Random randomValue = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomValue.Next(0, 1000);
            }
        }
        static void ShowGeneratedArray(int[] array)
        {
            Console.WriteLine("Success! Your array includes the following randomly generated values from 0 to 1000:");

            foreach (var item in array)
            {
                Console.WriteLine($" {item}");
            }
            Console.WriteLine();
        }
        private static void AskUser()
        {
            string keyWord = "0";
            string enterWord;
            Console.WriteLine("Do you want to find the maximum?");
            Console.WriteLine("Press any key to find the maximum or \"0\" to quit");
            enterWord = Console.ReadLine();

            if (keyWord == enterWord)
            {
                Environment.Exit(0);
            }
        }
        static int FindMaxUsingRecursion(int[] array, int startIndex)
        {
            if (startIndex == array.Length - 1)
            {
                return array[startIndex];
            }

            int current = array[startIndex];
            int max = FindMaxUsingRecursion(array, startIndex + 1);
            return max > current ? max : current;
        }
        static void TryExit()
        {
            string keyWord = "0";
            string enterWord;

            Console.WriteLine("\nDo you want to continue?");
            Console.WriteLine("Press \"0\" to quit or any other key to continue");
            enterWord = Console.ReadLine();

            if (keyWord == enterWord)
            {
                Environment.Exit(0);
            }
        }
    }
}