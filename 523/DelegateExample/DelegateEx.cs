/*
    A delegate is a type that represents references to methods with a particular parameter list 
    and return type. 

    When you instantiate a delegate, you can associate its instance with any method 
    with a compatible signature and return type. You can invoke (or call) the method 
    through the delegate instance.

    Refer Link:
    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/

    Delegates have the following properties:

    - Delegates are similar to C++ function pointers, but are type safe.
    - Delegates allow methods to be passed as parameters.
    - Delegates can be used to define callback methods.
    - Delegates can be chained together; for example, multiple methods 
      can be called on a single event.
    - Methods don't need to match the delegate signature exactly.
    - Using a delegate allows the programmer to encapsulate a reference to a method 
      inside a delegate object. The delegate object can then be passed to code 
      that can call the referenced method, without having to know at compile time 
      which method will be invoked.

    An interesting and useful property of a delegate is that it does not know or care 
    about the class of the object that it references. Any object will do; all that matters 
    is that the method's argument types and return type match the delegate's. 
    This makes delegates perfectly suited for "anonymous" invocation.

    A delegate has 3 steps
    - Declaration
    - Instantiation
    - Invocation

    Tested using MS Visual Studio 2022 Community Edition
    Example created by the anonymous invocator - Hans Telford
    20-Apr-2022
*/


using System;
using System.Collections.Generic;

namespace DelegateExample
{
    internal class DelegateEx
    {
        delegate string [] Combine (string [] strArray1, string [] strArray2);
        delegate string[] ArrayOperation(string[] strArray);

        static void Main(string[] args)
        {
            string[] namesArray1 = { "Mark Hamill", "Harrison Ford", "Carrie Fisher", "Alec Guiness", "James Earl Jones", "Phil Brown"};
            string[] namesArray2 = { "Mark Hamill", "Harrison Ford", "Carrie Fisher", "Alec Guiness", "James Earl Jones", "Frank Oz"};
            string[] namesArray3 = { "Mark Hamill", "Harrison Ford", "Carrie Fisher", "James Earl Jones", "Frank Oz", "Billy Dee Williams", "Tim Rose" };

            Combine combine = new Combine (CombineArrays);
            string[] combinedArray = combine(combine(namesArray1, namesArray2), namesArray3);

            // display combinedArray
            Console.WriteLine("Combined Array (unsorted) ...");
            DisplayArray(combinedArray);
            Console.WriteLine("*****************************************");

            ArrayOperation arrayOp = new ArrayOperation(SortArray);
            string[] sortedCombinedArray = arrayOp(combinedArray);

            // display sorted combinedArray
            Console.WriteLine("Combined Array (sorted) ...");
            DisplayArray(sortedCombinedArray);
            Console.WriteLine("*****************************************");

            arrayOp = new ArrayOperation(RemoveDuplicates);
            string[] noDuplicatesSortedCombinedArray = arrayOp (sortedCombinedArray);

            // display sorted combinedArray with no duplicates
            Console.WriteLine("Combined Array (sorted with no duplicates) ...");
            DisplayArray(noDuplicatesSortedCombinedArray);
            Console.WriteLine("*****************************************");

        }

        public static string [] CombineArrays (string [] array1, string [] array2)
        {
            string[] combinedArray;

            if (array1.Length > 0 && array2.Length > 0)
            {
                combinedArray = new string[array1.Length + array2.Length];
                Array.Copy (array1, 0, combinedArray, 0, array1.Length);
                Array.Copy(array2, 0, combinedArray, array1.Length, array2.Length);
            }
            else if (array1.Length > 0)
            {
                combinedArray = new string[array1.Length];
                Array.Copy(array1, 0, combinedArray, 0, array1.Length);
            }
            else if (array2.Length > 0)
            {
                combinedArray = new string[array2.Length];
                Array.Copy(array2, 0, combinedArray, 0, array2.Length);
            }
            else
            {
                combinedArray = new string[1];
                combinedArray[0] = "";
            }
            return combinedArray;
        }

        public static string [] SortArray (string [] array)
        {
            // List of string values from string [] array input
            List<string> strList = new List<string>(array);
            // Alphabetically sort the list
            strList.Sort();
            // Return sorted array
            return strList.ToArray ();
        }

        public static string[] RemoveDuplicates(string[] array)
        {
            List<string> strList = new List<string>(array);
            List<string> strListNoDuplicates = new List<string> ();
            strListNoDuplicates.Add(strList[0]);
            for (int i = 1; i < strList.Count; i++)
            {
                string str = strList[i];
                bool duplicateStatus = false;
                for (int j = 0; j < strListNoDuplicates.Count; j++)
                {
                    if (str.Equals(strListNoDuplicates[j]))
                    {
                        duplicateStatus = true;
                        break;
                    }
                }
                if (!duplicateStatus)
                {
                    strListNoDuplicates.Add(str);
                }
            }
            string[] uniqueStr = strListNoDuplicates.ToArray();

            return uniqueStr;
        }

        public static void DisplayArray (string [] array)
        {
            foreach (string str in array)
            {
                Console.WriteLine (str);
            }
            Console.WriteLine ();
        }
    }
}

/*
Sample output:

Combined Array (unsorted) ...
Mark Hamill
Harrison Ford
Carrie Fisher
Alec Guiness
James Earl Jones
Phil Brown
Mark Hamill
Harrison Ford
Carrie Fisher
Alec Guiness
James Earl Jones
Frank Oz
Mark Hamill
Harrison Ford
Carrie Fisher
James Earl Jones
Frank Oz
Billy Dee Williams
Tim Rose

*****************************************
Combined Array (sorted) ...
Alec Guiness
Alec Guiness
Billy Dee Williams
Carrie Fisher
Carrie Fisher
Carrie Fisher
Frank Oz
Frank Oz
Harrison Ford
Harrison Ford
Harrison Ford
James Earl Jones
James Earl Jones
James Earl Jones
Mark Hamill
Mark Hamill
Mark Hamill
Phil Brown
Tim Rose

*****************************************
Combined Array (sorted with no duplicates) ...
Alec Guiness
Billy Dee Williams
Carrie Fisher
Frank Oz
Harrison Ford
James Earl Jones
Mark Hamill
Phil Brown
Tim Rose

*****************************************
*/
