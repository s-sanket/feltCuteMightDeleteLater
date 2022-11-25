
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

internal class Program
{

    private static void Main(string[] args)
    {

        List<Employee> employeeList = new List<Employee>();

        employeeList.Add(new Employee() { Id = 101, Name = "Raju", Salary = 5000, Experience = 5 });
        employeeList.Add(new Employee() { Id = 102, Name = "Shyam", Salary = 4000, Experience = 4 });
        employeeList.Add(new Employee() { Id = 103, Name = "Babu", Salary = 6000, Experience = 6 });
        employeeList.Add(new Employee() { Id = 104, Name = "Kabira", Salary = 3000, Experience = 7 });


        IsPromotable checkForPromotion = new IsPromotable(Promote);
        IsPromotable checkForPromotion2 = new IsPromotable(PromoteRaju);


        Console.WriteLine("---- First Department -----");
        Employee.PromoteEmployee(employeeList, checkForPromotion);


        Console.WriteLine("---- Second Department -----");
        Employee.PromoteEmployee(employeeList, checkForPromotion2);



    }

    public static bool Promote(Employee employee)
    {
        if (employee.Experience > 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static bool PromoteRaju(Employee employee)
    {
        if (employee.Name == "Raju")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // Delegate definition to check for Promotion criteria for Employee
    public delegate bool IsPromotable(Employee employee);


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }


        public static void PromoteEmployee(List<Employee> employeeList, IsPromotable IsEligibleToPromote)
        {
            foreach (Employee emp in employeeList)
            {
                if (IsEligibleToPromote(emp))
                {
                    Console.WriteLine(emp.Name + " Promoted");
                }
            }
        }

    }

}