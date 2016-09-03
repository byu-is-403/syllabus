using System;

namespace EmployeeManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee[] employees = new Employee[10];
            int numEmployees = 0;

            Console.WriteLine("Welcome to the employee management system!");

            while (numEmployees < 10) 
            {
                Console.Write("\nWant to enter an employee's information? (y/n) ");
                string choice = Console.ReadLine();
                while (choice != "y" && choice != "n")
                {
                    Console.Write("Please enter y or n: ");
                    choice = Console.ReadLine();
                }

                if (choice == "n") break;

                employees[numEmployees] = MakeEmployee();
                numEmployees++;
            }

            if (numEmployees == 10) 
            {
                Console.WriteLine("Thanks, we're done! We can't hire more than 10 employees.");
            }

            if (numEmployees > 0)
            {
                Console.WriteLine("\nHere is the information you entered: ");
                Console.WriteLine(Employee.ColumnHeadings());
                for (int i = 0; i < numEmployees; i++)
                {
                    Employee employee = employees[i];
                    Console.WriteLine(employee.ToString());
                }
            }

            Console.WriteLine("\nThanks! Press any key to exit.");
            Console.ReadKey();
        }

        public static Employee MakeEmployee()
        {
            string name, occupation;
            int age = 0;
            int salary = 0;

            Console.WriteLine("\nPlease enter an employee's information.");

            // Get the person's name
            Console.Write("\tName: ");
            name = Console.ReadLine();

            // Get the person's age
            Console.Write("\tAge: ");
            while (age == 0) {
                try {
                    age = Int32.Parse(Console.ReadLine());
                } catch (Exception e) {
                    Console.Write("\tPlease enter an integer: ");
                }
            }

            // Get the employee's occupation
            Console.Write("\tOccupation: ");
            occupation = Console.ReadLine();

            // Get the employee's salary
            Console.Write("\tSalary: ");
            while (salary == 0) {
                try {
                    salary = Int32.Parse(Console.ReadLine());
                } catch (Exception e) {
                    Console.Write("\tPlease enter an integer without commas: ");
                }
            }

            return new Employee(name, age, occupation, salary);
        }
    }
}
