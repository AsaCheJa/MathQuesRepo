/*
    ----------------------------------------------------------------------------------
    Collections in C# --- (1) Lists and Linked Lists
    Developed by Hans Telford
    ----------------------------------------------------------------------------------
    Collection data types are basically data structures that are DYNAMIC in nature
    
   ... meaning ...
    
    that during the run-time of a program, they can contain any number of data elements.
    This means that the collection can contain nothing or one or several data elements.

    This is unlike a standard array where you need to declare the size it must be 
    (how many values to go into it) before you do anything with the array.
    
    Collection data elements can consist of value types (e.g. bool, char, int, long, float, double)
    or reference types (e.g. any of the C# classes or user-defined classes).

    The following are examples of C# Collection data types:
    - Lists
    - Linked Lists
    - Hash Tables
    - Dictionaries
    - Stacks
    - Queues

    All of these data types are known as generic data structures. Each have their particular advantages.
    The 'generic' means that they can contain any reference data type - being any of the C# classes.

    The List class for example
    refer MSDN documentation:
    https://msdn.microsoft.com/en-us/library/6sh2ey19(v=vs.110).aspx
    
    shows the List<T> data structure, where <T> indicates the generic data type.

    To declare a List of string values, the <T> is replaced by <string>
    For example:
    List<string> gameGenres = new List<string>();

    Lists are very flexible to work with - one can add, insert and remove elements anywhere in the structure.

    A List is essentially a resizable array.

    List methods include (this listing is not inclusive):
    Add(T)              --- adds an element T at the end of the List
    BinarySearch(T)     --- searches the entire sorted list looking for element T
    Clear()             --- removes all elements from the List
    Contains(T)         --- determines whether element T exists in the List
    Insert(Int32, T)    --- inserts an element T at position Int32
    Remove(T)           --- removes the first occurrence of T
    RemoveAt(Int32)     --- removes the element at position Int32
    Reverse()           --- reverses the order of the elements in the entire List
    Sort()              --- sorts the order of the elements in the entire List using the default comparer
    ToArray()           --- copies the elements in the List to a fixed new array object

    Code examples below show various ways to declare the List<T> object in C#.

    A LinkedList typically consists of a chain (or a series of sequential) nodes.
    Each node contains 3 things:
    - the <T> data consisting of any C# reference type instance
    - the memory address of the previous node
    - the memory address of the next node

    Note: Nodes are not necessarily stored in a contiguous manner like fixed-sized arrays
    As nodes can be removed and added during run-time, memory locations are determined by the operating system.

    Source code is error-free and was tested in MS Visual Studio 2022 (Community Edition) as at 20th April, 2022
    Hans Telford
 
*/

using System;
using System.Collections.Generic;   // need this to use List<T> data structure


namespace List_Example
{
    /********************************************************************************/
    // User-defined Dog class
    // NOTE: This class uses the IComparable interface
    // which means that CompareTo() method is implemented specifically for this class
    // CompareTo() is used to compare the name value of the instance ('this') with the name 
    // of another Dog object
    // e.g. instance name value of "Bruce" compared with "Bruce" for the other Dog name returns 0 (same)
    // e.g. instance name value of "Al" compared with "Bruce" for the other Dog name returns -1 (less)
    // e.g. instance name value of "Bruce" compared with "Al" for the other Dog name returns 1 (greater)
    // This implementation is necessary if desirous of sorting Dog objects using the List Sort() method
    /********************************************************************************/
    public class Dog : IComparable<Dog>
    {
        // private instance data (can only be accessed by public properties in this class)
        private string name;
        private string type;
        private int age;

        // public properties (provide public get() and set() methods for private instance data)
        public string Name
        { 
            get {return name;}
            set {name = value;}
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // constructor method (intialises the private data by using input values)
        public Dog (string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }

        // override method ToString() used to override the Object class ToString() method
        // this is done to provide a customised string output of the class instance variables
        public override string ToString()
        {
            return "Dog object - Name: " + Name + "\tType: " + Type + "\tAge: " + Age;
        }

        // CompareTo() method (implementation of IComparable interface method)
        public int CompareTo (Dog otherDog)
        {
            return this.Name.CompareTo(otherDog.Name);
        }

    } // end Dog class

    /********************************************************************************/
    // List Examples set up in Main() method
    /********************************************************************************/
    class ListEx
    {
        static void Main(string[] args)
        {
            /********************************************************************************/
            // List of string elements
            /********************************************************************************/
            // 1. Declare data variables needed for this program
            //    Instantiate a List object called gameGenres that contains string values
            List<string> gameGenres = new List<string>();

            //  2. Get string values for the gameGenres List object
            //     In this case, we are only adding data into each of the three data structures

            // Add string elements to gameGenres List
            gameGenres.Add("Action");
            gameGenres.Add("Puzzle");
            gameGenres.Add("Arcade");
            gameGenres.Add("Role-Playing Game or RPG");
            gameGenres.Add("First-Person Shooter or FPS");     

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******          List Example        *******");
            Console.WriteLine("********************************************");

            // 3. Output the List of strings
            Console.WriteLine("The initialised list of game genres ...");
            DisplayGenericList(gameGenres);

            // demonstrate Remove() and RemoveAt() methods
            // remove the string value of "Arcade"
            gameGenres.Remove("Arcade");
            // remove the string value at position (index 0 --- the start)
            gameGenres.RemoveAt(0);
            Console.WriteLine("The list after using Remove('Arcade') and then RemoveAt(0) ...");
            DisplayGenericList(gameGenres);

            // demonstrate Sort() method
            // alphabetically sorts the list of strings
            gameGenres.Sort();
            Console.WriteLine("The list after sorting ...");
            DisplayGenericList(gameGenres);

            // demonstrate Reverse() method
            // reverse alphabetic sort
            gameGenres.Reverse();
            Console.WriteLine("The reversed list ...");
            DisplayGenericList(gameGenres);

            // display list of strings with a method that uses an iterator
            Console.WriteLine("********************************************");
            Console.WriteLine("Game genre string list display using iterator ...");
            DisplayGenericListUsingIterator(gameGenres);
            Console.WriteLine("********************************************");

            /********************************************************************************/
            // List of DateTime elements
            /********************************************************************************/
            List<DateTime> timeList = new List<DateTime>();
            // arguments are: year, month, day, hour, minute, second
            timeList.Add(new DateTime(2015, 2, 1, 7, 0, 0));
            timeList.Add(DateTime.Now);
            timeList.Add(new DateTime(2000, 1, 1, 12, 0, 0));
            // sort the timeList in chronological order
            timeList.Sort();
            // display the timeList elements
            Console.WriteLine("Time list after sorting ...");
            DisplayGenericList(timeList);
            Console.WriteLine("********************************************");
            Console.WriteLine("Time list using iterator ...");
            DisplayGenericListUsingIterator(timeList);
            Console.WriteLine("********************************************");

            /********************************************************************************/
            // List of Dog elements
            /********************************************************************************/

            List<Dog> doggies = new List<Dog>();
            // Add 3 Dog objects to the doggies list
            doggies.Add(new Dog("Lucy", "Jack Russell", 3));
            doggies.Add(new Dog("Bruce", "Chihuahua", 5));
            doggies.Add(new Dog("Ralph", "Labrador", 2));
            // Display
            Console.WriteLine("List of Dog objects (unsorted doggies) ...");
            DisplayGenericList(doggies);
            Console.WriteLine("********************************************");
            // sort the dog objects by name (refer: CompareTo() from IComparable)
            doggies.Sort();
            Console.WriteLine("List of Dog objects (sorted doggies) ...");
            DisplayGenericListUsingIterator(doggies);
            Console.WriteLine("********************************************");

            /********************************************************************************/
            // LinkedList of numeric elements (integers)
            // NOTE: A Linked List is a doubly linked list in that each element
            // contains the memory location of the next element --- AND ---
            // the memory location of the previous element
            // so each node element can point to its next and previous node element counterpart
            // MSDN documentation: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
            /********************************************************************************/

            LinkedList<int> myLinkedList = new LinkedList<int>();
            // Add 4 integers to the linked list in various orders
            myLinkedList.AddFirst(5);
            myLinkedList.AddLast(2);
            myLinkedList.AddFirst(3);
            myLinkedList.AddLast(12);
            // display using an Enumerator and a while loop
            LinkedList<int>.Enumerator en = myLinkedList.GetEnumerator();
            while (en.MoveNext())
            {
                Console.Write("Node value: {0}", en.Current);
                if (en.Current == 3)
                {
                    Console.Write(" <-- First node");
                }
                else if (en.Current == 12)
                {
                    Console.Write(" <-- Last node");
                }
                Console.Write("\n");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        /********************************************************************************/
        // Method: void DisplayGenericList<T> ()
        // Inputs: List<T> genericList --- any List object containing elements of any C# reference type
        // Notes:  Generic method that is able to display many types of list objects
        //         more flexible than using a specific data type for the input list object
        /********************************************************************************/
        static void DisplayGenericList<T> (List<T> genericList)
        {
            Console.WriteLine();
            int i = 1;
            foreach (T genericItem in genericList)
            // alternative: foreach (var genericItem in genericList)
            {
                Console.WriteLine(i + ". " + genericItem.ToString());
                i++;
            }
            Console.WriteLine();
        }

        /********************************************************************************/
        // Method:  void DisplayGenericListUsingIterator<T> ()
        // Inputs:  List<T> genericList --- any List object containing elements of any C# reference type
        // Notes:   Generic method that is able to display many types of list objects using an iterator
        //          An iterator is similar to a database cursor in that it provides
        //          access to data elements in a Collection
        //          C# iterators can be implemented as a method, operator or get accessor
        //
        // An iterator is represented by the IEnumerator interface and is implemented 
        // by the compiler with the following methods:
        // MoveNext():  A method that advances to the next element of the collection 
        //              and indicates the end of that collection
        // Current:     A property that fetches the value of the element currently being pointed to
        // Dispose():   Cleans up the iteration
        //
        // GetEnumerator() is the default iterator method of the IEnumerable interface
        // The method is invoked on execution on execution of the loop, which uses the returned
        // enumerator to iterate through the Collection to return values
        /********************************************************************************/
        static void DisplayGenericListUsingIterator<T> (List<T> genericList)
        {
            IEnumerator<T> iterator = genericList.GetEnumerator();
            Console.WriteLine();
            int i = 1;
            while (iterator.MoveNext())
            {
                Console.WriteLine(i + ". " + iterator.Current.ToString());
                i++;
                
            }
            Console.WriteLine();
        }

    }
}


/*
    OUTPUT:

        ********************************************
        *******          List Example        *******
        ********************************************
        The initialised list of game genres ...

        1. Action
        2. Puzzle
        3. Arcade
        4. Role-Playing Game or RPG
        5. First-Person Shooter or FPS

        The list after using Remove('Arcade') and then RemoveAt(0) ...

        1. Puzzle
        2. Role-Playing Game or RPG
        3. First-Person Shooter or FPS

        The list after sorting ...

        1. First-Person Shooter or FPS
        2. Puzzle
        3. Role-Playing Game or RPG

        The reversed list ...

        1. Role-Playing Game or RPG
        2. Puzzle
        3. First-Person Shooter or FPS

        ********************************************
        Game genre string list display using iterator ...

        1. Role-Playing Game or RPG
        2. Puzzle
        3. First-Person Shooter or FPS

        ********************************************
        Time list after sorting ...

        1. 1/01/2000 12:00:00 PM
        2. 1/02/2015 7:00:00 AM
        3. 26/08/2020 11:02:19 AM

        ********************************************
        Time list using iterator ...

        1. 1/01/2000 12:00:00 PM
        2. 1/02/2015 7:00:00 AM
        3. 26/08/2020 11:02:19 AM

        ********************************************
        List of Dog objects (unsorted doggies) ...

        1. Dog object - Name: Lucy      Type: Jack Russell      Age: 3
        2. Dog object - Name: Bruce     Type: Chihuahua Age: 5
        3. Dog object - Name: Ralph     Type: Labrador  Age: 2

        ********************************************
        List of Dog objects (sorted doggies) ...

        1. Dog object - Name: Bruce     Type: Chihuahua Age: 5
        2. Dog object - Name: Lucy      Type: Jack Russell      Age: 3
        3. Dog object - Name: Ralph     Type: Labrador  Age: 2

        ********************************************
        Node value: 3 <-- First node
        Node value: 5
        Node value: 2
        Node value: 12 <-- Last node
        Press any key to continue . . .
*/
