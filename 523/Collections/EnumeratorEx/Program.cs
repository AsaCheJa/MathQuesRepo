/*
    ----------------------------------------------------------------------------------
    Collections in C# --- (6) Enumerator --- also includes "Enum"
    ----------------------------------------------------------------------------------
    JUST AS AN ASIDE ... re: the term "Enum" and "Enumeration"

    NOTE #1: 
            C# .NET refers to "Enum" (or Enumeration) as a constant set of values.
            For example: 
            enum Colours {Red, Orange, Yellow, Green, Blue, Indigo, Violet};

            These values are not strings, but named constants which in themselves represent numeric values
            Red holds 0, Orange holds 1, Yellow holds 2 etc.
            An enumeration may be useful for programmers when working with a simple set of data (e.g. days,  months or categories).

            IMPORTANT: An Enumeration is NOT THE SAME as an Enumerator!

    NOTE #2:    
            C# .Net uses the term "Enumerating", which refers to iterating or looping through all values 
            in a C# Collection using an Enumerator.

            Enumerators are specialist objects which provide the means to move through a Collection of objects 
            one at a time (the same kind of thing is sometimes called a ‘cursor’ --- especially in database traversals)

            Typically, C# implements the IEnumerable and IEnumerator interfaces to support the use of a loop 
            like foreach to iterate through a collection.
            
            Don't get that term "iterate" confused with an iterator. 
            Both the Enumerator and the iterator allow you to "iterate". 
            Enumerating and iterating are basically the same process, but are implemented differently. 
            Enumerating means you've implemented the IEnumerator interface. 
            Iterating means you've created the iterator construct in your class (demonstrated below), 
            and you are calling foreach on your class, at which time the compiler automatically creates 
            the enumerator functionality for you.
    


    IEnumerator interface (Microsoft documentation)
    https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netcore-3.1

    Properties: 
    Current (Gets the element in the collection at the current position of the enumerator)

    Methods:
    MoveNext()	--- this method advances the enumerator to the next element of the collection.

    Reset()     --- this method sets the enumerator to its initial position, which is before the first element in the collection.


    IEnumerable interface (Microsoft documentation)
    https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=netcore-3.1

    Methods:
    METHODS
    GetEnumerator()	--- this method returns an enumerator that iterates through a collection.

    From documentation:
    It is a best practice to implement IEnumerable and IEnumerator on your collection classes 
    to enable the foreach syntax, however implementing IEnumerable is not required. 

    If your collection does not implement IEnumerable, you must still follow the iterator pattern 
    to support this syntax by providing a GetEnumerator() method that returns an interface, class or struct. 
    When developing with C# you must provide a class that contains a Current property, 
    and MoveNext() and Reset() methods as described by IEnumerator, but the class does not have to implement IEnumerator.

    Source code is error-free and was tested in MS Visual Studio 2022 (Community Edition) as at 20th April 2022
    Hans Telford

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorEx
{
    class Project
    {
        // declared enumeration example
        enum Colours { Red, Orange, Yellow, Green, Blue, Indigo, Violet };

        static void Main(string[] args)
        {
            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*****    Enumeration (Enum) Example    *****");
            Console.WriteLine("********************************************");

            // 1. Enumeration example
            // declare favColour and assign to Green
            Colours favColour = Colours.Green;
            // display variable value (will be Green)
            Console.WriteLine(favColour);
            // use ToString() (will be Green)
            Console.WriteLine(favColour.ToString());
            // display value from original enumeration Colours (will be Green)
            Console.WriteLine(Colours.Green);
            // display as typecast from integer to Colours enumeration (will be Green)
            Console.WriteLine((Colours)3);
            // display as typecast from Colours variable to integer (will be 3)
            Console.WriteLine((int)favColour);

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("********     Enumerator Example     ********");
            Console.WriteLine("********************************************");
            Console.WriteLine();

            // 2. Enumerator (enumerating through a collection) example
            //    using IEnumerator and IEnumerable
            // create EmployeeList (basically a Collection of Employee objects within a class)
            Employees EmployeeList = new Employees();
            // create 2 employee objects from the Employee class
            Employee e1 = new Employee(1, "Joe Black", 1250.75);
            Employee e2 = new Employee(2, "Jesse White", 1275.85);
            // add 2 employee objects to EmployeeList
            EmployeeList.AddEmployee(e1);
            EmployeeList.AddEmployee(e2);

            // display EmployeeList objects using a foreach loop
            // NOTE: The IEnumerator and IEnumerable interfaces are not explicitly called
            //       Instead, the foreach loop uses an implicit Enumerator
            Console.WriteLine("Enumerating EmployeeList using foreach loop (IEnumerator is implicit)");
            // loop through the list using an implicit Enumerator object
            foreach (Employee employee in EmployeeList)
            {
                Console.WriteLine(employee.ToString());
            }

            // display EmployeeList objects using an IEnumerator objects and the MoveNext() method
            // NOTE: Reset() resets the position of the IEnumerator object to -1 (before index 0)
            Console.WriteLine();
            Console.WriteLine("\nEnumerating EmployeeList using explicit IEnumerator object");
            IEnumerator EmployeeEnumerator = EmployeeList.GetEnumerator();
            // Reset() moves the Enumerator object to position -1 (ahead of the first element in the list)
            // This must be done as the previous foreach loop has moved the implicit Enumerator to the end of the list
            EmployeeEnumerator.Reset();
            // loop through the list using an explicit Enumerator object
            while (EmployeeEnumerator.MoveNext())
            {
                Console.WriteLine((Employee)EmployeeEnumerator.Current);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
        /****************************************************************************************/
        /************************         Employee class         ********************************/
        /****************************************************************************************/
        public class Employee
        {
            private int id;
            private string name;
            private double salary;

            // data properties
            public int Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }

            // constructor method
            public Employee(int id, string name, double salary)
            {
                this.Id = id;
                this.Name = name;
                this.Salary = salary;
            }

            // override ToString() method - customised to display values for an Employee instance
            public override string ToString()
            {
                return "Id: #" + this.Id.ToString() + "\nName: " + Name + "\nSalary: $" + Salary.ToString() + " p/f";
            }
        }

        /****************************************************************************************/
        /************************         Employees class        ********************************/
        /****************************************************************************************/
        public class Employees : IEnumerable, IEnumerator
        {
            // ArrayList of employee objects
            // ArrayList EmployeeList = new ArrayList();
            // List of employee objects
            List<Employee> EmployeeList = new List<Employee>();

            // tracks the current element position in EmployeeList
            private int Position = -1;

            // AddEmployee() method --- this adds a new Employee object to the EmployeeList
            public void AddEmployee(Employee newEmployee)
            {
                EmployeeList.Add(newEmployee);
            }

            // Needed since implementing IEnumerable interface
            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }

            // Needed since implementing IEnumerator interface
            public bool MoveNext()
            {
                if (Position < EmployeeList.Count - 1)
                {
                    ++Position;
                    return true;
                }
                return false;
            }

            // Needed since implementing IEnumerator interface
            public void Reset()
            {
                Position = -1;
            }

            // Needed since implementing IEnumerator interface
            // return current Employee object in the EmployeeList collection (as per the element in the Position index)
            // NOTE: This is a property used in the IEnumerator interface
            public object Current
            {
                get
                {
                    try
                    {
                        return EmployeeList[Position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                    
                }
            }
        }
    }
}


/*
    OUTPUT:

    Green
    Green
    Green
    Green
    3

    Enumerating EmployeeList using foreach loop (IEnumerator is implicit)
    Id: #1
    Name: Joe Black
    Salary: $1250.75 p/f
    Id: #2
    Name: Jesse White
    Salary: $1275.85 p/f


    Enumerating EmployeeList using explicit IEnumerator object
    Id: #1
    Name: Joe Black
    Salary: $1250.75 p/f
    Id: #2
    Name: Jesse White
    Salary: $1275.85 p/f
*/
