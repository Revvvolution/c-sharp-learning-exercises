﻿using System;
using System.Collections.Generic;
using System.Linq;                       
                        
                        /****************** PRACTICE: LINQed LIST ******************/


// *** SEE Using Custom Types (Line 191)
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        };

        
        public class Bank
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
        }

        public class ReportItem
        {
            public string CustomerName { get; set; }
            public string BankName { get; set; }
        }

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

            // Also a .Max() function that gets the highest value

            double highDollar = dollarSort.Last();

            Console.WriteLine("\n\n\t\tMost Expensive Product:");

            Console.WriteLine(highDollar);


    //*********************************************************************************************************************************


                                                // Partitioning Operations

            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */

            List<int> imperfectSquares = new List<int>();

/*             wheresSquaredo.ForEach(currentInt => {
            double theSquare = Math.Sqrt(currentInt); */


/*             if (theSquare % 1 != 0) {
                imperfectSquares.Add(currentInt);
            }
            else
            {
                return;
            }

            }); */

            Console.WriteLine("\n\n\t\tList Up To (excluding) First Perfect Square:\n");

            for (int i = 0; i < wheresSquaredo.Count; i++) 
            {
            double theSquare = Math.Sqrt(wheresSquaredo[i]);
            if (theSquare % 1 == 0) 
            {
                break;
            }
            imperfectSquares.Add(wheresSquaredo[i]);
            }

            imperfectSquares.ForEach(n => {
                
                Console.Write(n + " ");
            
            });
            

    //*********************************************************************************************************************************


                                                // Using Custom Types

            // Build a collection of customers who are millionaires
/*         
        *** ADDED TO TOP (had to be outside of Program class) ***
        
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }; */


        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        /*
            Given the same customer set, display how many millionaires per bank.
            Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

            Example Output:
            WF 2
            BOA 1
            FTB 1
            CITI 1
        */
        
        var bankCustomersGroup = customers.Where(c => c.Balance >= 1000000.00).GroupBy(c => c.Bank);

        Console.WriteLine("\n\n\t\tMillionaire Count Grouped by Bank:\n");

        foreach (var group in bankCustomersGroup)
        {
            Console.WriteLine($"Bank: {group.Key}  -  Millionaires: {group.Count()}");
        };


        //*********************************************************************************************************************************


                                                // *** CHALLENGE ***


        /*
            TASK:
            As in the previous exercise, you're going to output the millionaires,
            but you will also display the full name of the bank. You also need
            to sort the millionaires' names, ascending by their LAST name.

            Example output:
                Tina Fey at Citibank
                Joe Landy at Wells Fargo
                Sarah Ng at First Tennessee
                Les Paul at Wells Fargo
                Peg Vale at Bank of America
        */

        // Define a bank  *** ADDED TO TOP (had to be outside of Program class) ***

        // Define a customer  *** ADDED TO TOP (had to be outside of Program class) ***

                // Create some banks and store in a List
                List<Bank> banks = new List<Bank>() {
                    new Bank(){ Name="First Tennessee", Symbol="FTB"},
                    new Bank(){ Name="Wells Fargo", Symbol="WF"},
                    new Bank(){ Name="Bank of America", Symbol="BOA"},
                    new Bank(){ Name="Citibank", Symbol="CITI"},
                };

                // Create some customers and store in a List
                List<Customer> allCustomers = new List<Customer>() {
                    new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                    new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                    new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                    new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                    new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                    new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                    new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                    new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                    new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                    new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                };

                /*
                    You will need to use the `Where()`
                    and `Select()` methods to generate
                    instances of the following class.

                    public class ReportItem
                    {
                        public string CustomerName { get; set; }
                        public string BankName { get; set; }
                    }
                */
                List<ReportItem> millionaireReport = ...

                foreach (var item in millionaireReport)
                {
                    Console.WriteLine($"{item.CustomerName} at {item.BankName}");
                }



    }
}