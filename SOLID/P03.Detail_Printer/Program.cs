using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>() { "document 1", "decument 2", "document 3" };
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee("Pesho");
            Manager manager = new Manager("Petur", documents);

            employees.Add(employee);
            employees.Add(manager);

            DetailsPrinter printer = new DetailsPrinter(employees);

            printer.PrintDetails();
        }
    }
}
