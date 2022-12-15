using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

/// <summary>
/// Employee Information Class
/// </summary>
public class Employee { 

   //Properties of listexample
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Salary { get; set; }
}


public class ListExample
{
    public static void Main()
    {
        try
        {
            // Create employee list
            ListExample sample = new ListExample();
            List<Employee> empList = sample.CreateList();
            Console.WriteLine("The employee list are:\n");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();

            // Edit employee list
            sample.EditEmployee(4, 100, empList);
            Console.WriteLine("After edition employee list is:\n");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();

            // sort the employee list
            sample.SortEmployee(empList);
            Console.WriteLine("Sorted list of employee:\n");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();

            // delete employee list
            sample.DeleteEmployee(2, empList);
            Console.WriteLine("After deletion of employee using id:\n");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();
            sample.DeleteEmployeeByIndex(3, empList);
            Console.WriteLine("Afetr deletion of employee using the index:\n");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();

            //insert employee to list
            sample.InsertEmployee(empList);
            Console.WriteLine("Employee list after insertion");
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Id:{0},name:{1},salary{2}", emp.Id, emp.Name, emp.Salary);
            }
            Console.WriteLine();

            //clear the employee list
            sample.DeleteEmployee(empList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    /// <summary>
    /// Func to create the employee list
    /// </summary>
    /// <returns></returns>
    public List<Employee> CreateList()
    {

        Employee lie1 = new()
        {
            Id = 1,
            Name = "bhavan",
            Salary = 1000
        };
        Employee lie2 = new()
        {
            Id = 2,
            Name = "bhuvan",
            Salary = 2000
        };
        Employee lie3 = new()
        {
            Id = 3,
            Name = "likith",
            Salary = 3000
        };
        Employee lie4 = new()
        {
            Id = 4,
            Name = "suhas",
            Salary = 4000
        };

        List<Employee> empList = new List<Employee>();
        empList.Add(lie1);
        empList.Add(lie2);
        empList.Add(lie3);
        empList.Add(lie4);
        return empList;

        public List<Employee> EditEmployee(int id, double salary, List<Employee> empList)
        {
            Employee emp = empList.Find(x => x.Id == id);
            emp.Salary = salary;
            empList.Remove(emp);
            empList.Add(emp);
            return empList;
        }
        public List<Employee> SortEmployee(List<Employee> empList)
        {
            empList.Sort(CompareSalary);
            return empList;
        }
        public static int CompareSalary(Employee a, Employee b)
        {
            return b.Salary.CompareTo(a.Salary);
        }
        public List<Employee> DeleteEmployee(int id, List<Employee> empList)
        {
            Employee emp = empList.Find(x => x.Id == id);
            empList.Remove(emp);
            return empList;
        }
        public List<Employee> DeleteEmployeeByIndex(int id, List<Employee> empList)
        {
            int emp = empList.FindIndex(x => x.Id == id);
            empList.RemoveAt(emp);
            return empList;
        }
        public List<Employee> InsertEmployee(List<Employee> empList)
        {
            empList.Insert(2, new Employee { Id = 5, Name = "suman", Salary = 5000 });
            return empList;
        }
        public List<Employee> DeleteEmployee(List<Employee> empList)
        {
            return empList.Clear();

        }
    }
}