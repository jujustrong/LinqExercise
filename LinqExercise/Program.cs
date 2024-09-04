using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

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
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum(x => x).ToString()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average(x => x).ToString()}");

            //TODO: Order numbers in ascending order and print to the console
            Console.Write("Ascending: ");
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.Write($"{x} "));
            
            Console.WriteLine();
            

            //TODO: Order numbers in descending order and print to the console
            Console.Write("Descending: ");
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.Write($"{x} "));
            
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            Console.Write("Numbers greater than 6: ");
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.Write($"{x} "));
            
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.Write("Order and Print 4: ");
            numbers.OrderByDescending(x => x).Take(3).ToList().ForEach(x => Console.Write($"{x} "));
            
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.Write("Change Index and Descend: ");
            numbers.Select((x, i) => i == 4 ? 29 : x)
                .OrderByDescending(x=>x).ToList()
                .ForEach(x => Console.Write($"{x} "));
            
            Console.WriteLine();
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees names starting with C or S: ");
            employees.TakeWhile(x => x.FirstName[0] == 'C' || x.FirstName[0] == 'S').ToList().ForEach(x=> Console.WriteLine($"{x.FullName} "));
            
            Console.WriteLine();
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26: ");
            employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age)
                .ThenBy(x => x.FirstName).ToList()
                .ForEach(x => Console.WriteLine($"{x.FullName}, Age: {x.Age} "));
            
            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.Write("Sum of YOE: ");
            var selectorYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"{selectorYOE.Sum(x => x.YearsOfExperience).ToString()}");

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.Write("Average of YOE: ");
            Console.Write($"{selectorYOE.Average(x => x.YearsOfExperience).ToString()} ");

            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Bob", "Bobberson", 65, 30)).ToList();
            employees = employees.Append(new Employee("Sara", "Sarerson", 40, 10)).ToList();
            employees = employees.Append(new Employee("Jeff", "Jefferson", 26, 2)).ToList();
            employees = employees.Append(new Employee("Ken", "Kennerson", 50, 25)).ToList();
            employees = employees.Append(new Employee("Katie", "Katerson", 20, 3)).ToList();

            Console.WriteLine();
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
