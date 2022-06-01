/*
    ----------------------------------------------------------------------------------
    Collections in C# --- (2) Stacks and Queues
    Developed by Hans Telford

    NOTE: This also contains a simple LINQ query example
    ----------------------------------------------------------------------------------
    A Stack<T> class is a dynamic data structure that uses a FILO (First-In Last-Out) method of data
    input and retrieval.
    Think of a stack of cleaned dishes --- the first dish that is washed is placed at the bottom of the pile
    The last dish that is stacked at the top and will be the first to be used.

    Methods:
    - Push()    puts new data on the top of the stack
    - Pop()     removes data from the top of the stack
    - Peek()    gets a copy of the data from the top of the stack

    MSDN Documentaton:
    https://msdn.microsoft.com/en-us/library/system.collections.stack(v=vs.110).aspx

    ******************************************************************************************************
    A Queue<T> class is a similar data structure that uses a FIFO (First-In First-Out) method of data
    input of retrievel.
    Think of a queue of people at a ticket office --- first in to get the ticket and the first to get out.

    Methods:
    - Enqueue() puts new data at the end of the queue
    - Dequeue() removes data from the beginning of the queue
    - Peek()    gets a copy of the data from the beginning of the queue

    MSDN Documentation:
    https://msdn.microsoft.com/en-us/library/system.collections.queue(v=vs.110).aspx

    ******************************************************************************************************
    Stack - 
    Pros:
    1. Helps manage the data in particular way (LIFO) if speed is needed to access elements
       Can only access the last element added (reverse order of entry)
    2. Not easily corrupted (can't insert data in the middle)
    2. When function is called the local variables are stored in stack and destroyed once returned. 
       Stack is used when variable is not used outside the function.
       So, it gives control over how memory is allocated and deallocated
    3. Stack frees you from the burden of remembering to cleanup (read delete) the object
    4. Not easily corrupted (No one can easily inset data in middle)

    Cons:
    1. Stack memory is limited
    2. Creating too many objects on the stack will increase the chances of stack overflow
    3. Random access not possible (one-way access only - the last element added, then the one before that etc)

    ******************************************************************************************************
    
    Queue - 
    Pros:
    1. Helps manage the data in particular way (FIFO) if speed is needed to access elements
       Can only access the first element added (in order of entry)
    2. Not easily corrupted (can't insert data in middle)

    Cons:
    1. Random access not possible (one-way access only - the first element added, then the next etc)
    ******************************************************************************************************
    
    Source code is error-free and was tested in MS Visual Studio 2022 as at 20th April, 2022
    Hans Telford


*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    /********************************************************************************/
    // Stack and Queue examples set up in Main() method
    /********************************************************************************/
    class Stack_and_Queue_Example
    {
        static void Main(string[] args)
        {
            // 1. Declare data variables needed for this program
            // myList is a simple List data structure containing integers only
            // Lists allow you to add and remove data at any point of the List
            List<int> myList = new List<int>();
            // myStack is a simple Stack data structure containing integers only
            // Stacks allow you to add and remove data to only the top of the Stack 
            // Last-in First-out (LIFO data structure)
            Stack<int> myStack = new Stack<int>();
            // myQueue is a simple Queue data structure containing integers only
            // Queues allow you to add data to the end of the Queue and to remove data from the beginning
            // of the Queue 
            // First-in First out (FIFO data structure)
            Queue<int> myQueue = new Queue<int>();

            //  2. Add numeric data into each of the three data structures
            //     using a for loop that loops 10 times
            //     add the integer values of 1 to 10 into each object - myList, myStack, myQueue
            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i);
                myStack.Push(i);
                myQueue.Enqueue(i);
            }

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******    Stack and Queue Example   *******");
            Console.WriteLine("********************************************");

            // display each collection (calling separate methods for each specific structure)
            DisplayList(myList);
            DisplayStack (myStack);
            DisplayQueue (myQueue);
            Console.WriteLine();

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******         LINQ Example         *******");
            Console.WriteLine("********************************************");

            /********************************************************************************/
            // LINQ Query example
            // Language-Integrated Query (LINQ) is a useful way to apply a SQL-string-like query against 
            // a strongly-typed data structure (e.g. List)
            // Refer MSDN Documentation: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
            // This example uses 3 parts:
            // i. Data source --- use myList as the data source for this example
            // ii. Query creation
            // iii. Query execution
            // this example is looking for even numbers (evenly divided by 2 without a remainder value)
            // numQuery is an IEnumerable<int>
            /********************************************************************************/
            // The LINQ query returns a dataset of integers that are evenly divisable by 2
            var numQuery = myList.Where (num => num % 2 == 0).OrderBy(n => n);
            Console.WriteLine("Numbers in myList that are divisible by 2 ... ");
            foreach (int num in numQuery)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine();

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******      Palindrome Example      *******");
            Console.WriteLine("********************************************");

            // Palindrome test using Stack and Queue
            // A palindrome is a word which can be the same when spelt backwards
            // e.g. "Mum" is the same spelt backwards
            string strToTest = "";
            // prompt to enter a string for the palindrome test
            Console.Write("Enter string to test for palindrome --> ");
            // get the string input
            strToTest = Console.ReadLine().ToLower();
            Console.WriteLine("");
            // test the string and display the result
            Console.Write(strToTest + " is ");

            if (IsPalindrome(strToTest))
            {
                Console.Write(" a palindrome");
            }
            else
            {
                Console.Write(" not a palindrome");
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        /********************************************************************************/
        // Method: void DisplayList ()
        // Inputs: List<int> intList --- List of integer values
        // Notes:  Displays the full list of integers using a foreach loop
        /********************************************************************************/
        static void DisplayList (List<int> intList)
        {
            Console.WriteLine("List display ...");
            foreach (int intItem in intList)
            {
                Console.Write(intItem + ", ");
            }
            Console.WriteLine("");
        }

        /********************************************************************************/
        // Method: void DisplayStack ()
        // Inputs: Stack<int> intStack --- Stack of integer values
        // Notes:  Displays the full list of integers using a while loop
        //         As Pop() is called, the method returns the integer value of the element
        //         as it is removed
        /********************************************************************************/
        static void DisplayStack (Stack<int> intStack)
        {
            Console.WriteLine("Stack display when using Pop() ...");
            while (intStack.Count > 0)
            {
                Console.Write(intStack.Pop() + ", ");
            }
            Console.WriteLine("");
        }

        /********************************************************************************/
        // Method: void DisplayQueue ()
        // Inputs: Queue<int> intQueue --- Queue of integer values
        // Notes:  Displays the full list of integers using a while loop
        //         As Dequeue() is called, the method returns the integer value of the element
        //         as it is removed
        /********************************************************************************/
        static void DisplayQueue (Queue<int> intQueue)
        {
            Console.WriteLine("Queue display when using Dequeue() ...");
            while (intQueue.Count > 0)
            {
                Console.Write(intQueue.Dequeue() + ", ");
            }
            Console.WriteLine("");
        }

        /********************************************************************************/
        // Method: void IsPalindrome ()
        // Inputs: string strToTest --- string value for the test
        // Output: boolean (true if the string is a palindrome and false if it isn't)
        // Notes:  Uses both the Stack and Queue structures (incorporating character data types)
        //         input string is broken down into its character values and each is placed
        //         into the Stack (using Push() method) and Queue (using Enqueue() method)
        //         The while loop then removes each character from the Stack (using the Pop() method)
        //         and the Queue (using the Dequeue() method)
        //         If the string is a palindrome, then each character removed in turn should be the same
        //         for both the Stack and Queue.
        /********************************************************************************/
        // check whether a word or phrase is a palindrome
        // can be spelt the same way either forward or in reverse
        static bool IsPalindrome (string strToTest)
        {
            Stack<char> charStack = new Stack<char>();
            Queue<char> charQueue = new Queue<char>();
            bool palindromeStatus = true;

            // add characters to charStack and charQueue
            for (int i = 0; i < strToTest.Length; i++)
            {
                charStack.Push(strToTest[i]);
                charQueue.Enqueue(strToTest[i]);
            }

            // loop while the stack is not empty
            while (charStack.Count > 0)
            {
                // get character from stack (FILO --- last character added is on top)
                char stackChar = charStack.Pop();
                // get character from queue (FIFO --- first character added is on top)
                char queueChar = charQueue.Dequeue();
                // compare the two characters
                // if they are the same for each loop, then the string is a palindrome
                // if any of the characters are not the same, then the string is NOT a palindrome
                if (stackChar != queueChar)
                {
                    palindromeStatus = false;
                    break;
                }
            }

            return palindromeStatus;
        }
    }
}

/*
    OUTPUT:
    ********************************************
    *******    Stack and Queue Example   *******
    ********************************************
    List display ...
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
    Stack display when using Pop() ...
    10, 9, 8, 7, 6, 5, 4, 3, 2, 1,
    Queue display when using Dequeue() ...
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,

    ********************************************
    *******         LINQ Example         *******
    ********************************************
    Numbers in myList that are divisible by 2 ...
    2, 4, 6, 8, 10,
    ********************************************
    *******      Palindrome Example      *******
    ********************************************
    Enter string to test for palindrome --> glenelg

    glenelg is  a palindrome
    Press any key to continue . . .

*/
