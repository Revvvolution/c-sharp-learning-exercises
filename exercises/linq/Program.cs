using System;
using System.Collections.Generic;
using System.Linq;                       
                        
                        /****************** PRACTICE: LINQed LIST ******************/


class Program
{
    static void Main()
    {

                                                // Restriction/Filtering Operations

            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            IEnumerable<string> LFruits = from fruit in fruits 
                where fruit.StartsWith('L')
                select fruit;

            Console.WriteLine("\n\t\tFruits that start with 'L':\n");

            foreach (string f in LFruits) {
                Console.WriteLine($"{f}");
            }


            // Which of the following numbers are multiples of 4 or 6 ?
            List<int> numbersToFilter = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbersToFilter.Where(number => number % 4 == 0 || number % 6 == 0);

            Console.WriteLine("\n\n\t\tMultiples of 4 or 6:\n");

            foreach (int fsm in fourSixMultiples) {
                Console.WriteLine(fsm);
            }

    //*********************************************************************************************************************************


                                                // Ordering Operations

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(n => n).ToList();

            Console.WriteLine("\n\n\t\tNames in Descending Order:");

            foreach (string d in descend) {
                Console.WriteLine(d);
            }


            // Build a collection of these numbers sorted in ascending order
            List<int> numbersToOrder = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> ascend = numbersToOrder.OrderBy(n => n);

            Console.WriteLine("\n\n\t\tNumbers in Ascending Order:");

            foreach (int n in ascend) {
                Console.WriteLine(n);
            }

    //*********************************************************************************************************************************


                                                // Aggregate Operations

            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            int numCount = numbers.Count;

            Console.WriteLine("\n\n\t\tTotal Count of Previous Number List:");

            Console.WriteLine($"\n\t\t\t\t{numCount}");
            


            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double totalDollars = purchases.Sum(p => p);
            double roundedTotal = Math.Round(totalDollars, 2);

            Console.WriteLine("\n\n\t\tTotal Amount for Purchase List:");
            Console.WriteLine($"List of Purchases:\n");
            foreach (double p in purchases) {
                Console.WriteLine(p);
            }
            Console.Write("\n\n\tTotal:");
            Console.WriteLine($"\t{roundedTotal}");

            

           // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            }; 

            IEnumerable <double> dollarSort = prices.OrderBy(d => d);

            double highDollar = dollarSort.Last();

            Console.WriteLine("\n\n\t\tMost Expensive Product:");

            Console.WriteLine(highDollar);



    }
}