using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine("sum:");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("Average: ");
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascOrder = numbers.OrderBy(item => item);
            Console.WriteLine("ascending: ");
            foreach (var item in ascOrder)
            {
                Console.WriteLine(item);
            }

            var descOrder = numbers.OrderByDescending(item => item).ToList();
            Console.WriteLine("descending: ");
            descOrder.ForEach(item => Console.WriteLine(item));

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6).ToList();
            greaterThanSix.ForEach(x => Console.WriteLine(x));

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("only 4");
            foreach (var num in ascOrder.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("change to age");
            numbers.SetValue(25, 4);

            var descWithAge = numbers.OrderByDescending(num => num); 
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("employees by first name C or S");
            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName).ToList();

            filtered.ForEach(x => Console.WriteLine(x));

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees by Fullname and Age");
            var twentySix = employees.Where(x => x.Age > 28).OrderByDescending(x => x.Age)
                .ThenBy(x => x.FirstName).ToList();

            twentySix.ForEach(x => Console.WriteLine($"Name: {x.FullName}, Age: {x.Age}"));

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35); 

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Logan", "Maloney", 25, 5)).ToList();

            employees.ForEach(x => Console.WriteLine(x.FullName)); 

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
