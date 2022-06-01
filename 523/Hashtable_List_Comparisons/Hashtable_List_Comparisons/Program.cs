/*****************************************************************/
/*
    This program reads in an external csv file consisting of the
    periodic table of elements (118 elements in total)
    The elements are listed in atomic number order

    Two (2) data structures are used to store the element values
    These are a List<Element> and a Hashtable
    The List stores instances of the Element class
    The Hashtable also stores instances of the Element class
    AND a string (element name) as the indexed value

    The Element class contains
    int - atomic number
    string - element name
    string - element symbol

    The program prompts the user to enter the name of an element to search
    The program then runs a search through the List and then through the Hashtable
    Each search is being timed (in tick values) and compared.

    Run the program several times and it will consistently show
    that the search via the Hashtable is always the faster than
    the search via the pre-sorted List<Element> 
    using a standard Binary search method
    (usually)

*/
/*****************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable_List_Comparisons
{
    // Element class with CompareTo() implementation from IComparable interface
    public class Element : IComparable<Element>
    {
        // private data
        private int atomicNumber;
        private string elementName;
        private string elementSymbol;

        // public properties
        public int AtomicNumber
        {
            get { return atomicNumber; }
            set { atomicNumber = value; }
        }

        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }

        public string ElementSymbol
        {
            get { return elementSymbol; }
            set { elementSymbol = value; }
        }

        // constructor method
        public Element (int atomicNumber, string elementName, string elementSymbol)
        {
            AtomicNumber = atomicNumber;
            ElementName = elementName;
            ElementSymbol = elementSymbol;
        }

        // CompareTo() method
        public int CompareTo (Element otherElement)
        {
            return ElementName.CompareTo(otherElement.ElementName);
        }

        // Overriden ToString() method
        public override string ToString()
        {
            return "[" + AtomicNumber.ToString() + "] " + ElementName + " (" + ElementSymbol + ")";
        }


    }
    class Program
    {
        // Main() method - entry point to program
        static void Main(string[] args)
        {
            // display header
            Console.WriteLine("**************************************************");
            Console.WriteLine("***   Hashtable and List Search Example  ***");
            Console.WriteLine("**************************************************");

            // List of elements
            List<Element> periodicTable_List = new List<Element>();
            // Hashtable of elements
            Hashtable periodicTable_Hashtable = new Hashtable();
            
            // line to read in from external file
            string line;
            // delimiters
            string[] delimiters = { "," };

            // read external file
            // read the list of elements from external csv file
            try
            {
                // set up FileStream object
                // this is used to open and read the external file
                // each line is read in (line by line)
                // e.g. 1,H,Hydrogen
                FileStream fs = new FileStream("elements.csv", FileMode.Open, FileAccess.Read);

                // use a StreamReader object to read the file contents line by line
                using (var streamReader = new StreamReader(fs, Encoding.UTF8))
                {
                    // loop while the streamReader is getting content and stop when it gets nothing
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // each string line is split using the comma delimiter
                        string[] splitStr = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        // element's atomic number
                        int atomicNumber = Int32.Parse(splitStr[0]);
                        // element symbol
                        string elementSymbol = splitStr[1];
                        // element name
                        string elementName = splitStr[2];
                        // create Element instance
                        Element element = new Element(atomicNumber, elementName, elementSymbol);
                        // add element to List
                        periodicTable_List.Add(element);
                        // add element to Hashtable
                        // note: string elementName is being set up as the indexed value
                        // even though the elementName is still a part of the element data
                        periodicTable_Hashtable.Add(elementName, element);
                    }
                }

                // at this point, we have 118 elements stored in both data structures
                

            }
            // Do this in case there is no external file or the external file is corrupted
            catch (Exception e)
            {
                Console.WriteLine("FILE I/O ERROR: " + e.ToString());
            }

            if (periodicTable_List.Count > 0 && periodicTable_Hashtable.Count > 0)
            {
                // sort the unsorted List
                periodicTable_List.Sort();

                // display List
                foreach(Element e in periodicTable_List)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("********************************");
                // display Hashtable
                foreach (DictionaryEntry de in periodicTable_Hashtable)
                {
                    if (de.Key.ToString().Length <= 9)
                    {
                        Console.WriteLine("Key: {0} \t\tValue: {1} \tHashcode: {2}", de.Key, de.Value, de.GetHashCode());
                    }
                    else
                    {
                        Console.WriteLine("Key: {0} \tValue: {1} \tHashcode: {2}", de.Key, de.Value, de.GetHashCode());
                    }
                    
                }
                Console.WriteLine("********************************");

                Stopwatch stopwatch;
                // Get element name to search
                Console.Write("Enter element name to search ==> ");
                string elementToSearch = Console.ReadLine();

                // search the List using Binary search method
                // and record elapsed time in ticks
                // NOTE: C#: A single tick represents one hundred nanoseconds or one ten-millionth of a second. 
                // There are 10,000 ticks in a millisecond, or 10 million ticks in a second.
                long nbrTicks = 0;
                stopwatch = Stopwatch.StartNew();
                int positionFound = BinarySearch(periodicTable_List, elementToSearch);
                stopwatch.Stop();
                nbrTicks = stopwatch.ElapsedTicks;

                if (positionFound >= 0)
                {
                    // found
                    Console.WriteLine(periodicTable_List[positionFound].ToString() + " <-- FOUND");
                }
                else
                {
                    // not found
                    Console.WriteLine(elementToSearch + " was NOT FOUND");
                }
                
                Console.WriteLine("Time taken (ticks) for binary search on sorted list: " + nbrTicks);

                // search the Hashtable and record elapsed time in ticks
                stopwatch = Stopwatch.StartNew();
                bool foundElementStatus = periodicTable_Hashtable.ContainsKey(elementToSearch);
                stopwatch.Stop();
                nbrTicks = stopwatch.ElapsedTicks;

                if (foundElementStatus)
                {
                    // found
                    Console.WriteLine(periodicTable_Hashtable[elementToSearch] + " <-- FOUND");
                }
                else
                {
                    // not found
                    Console.WriteLine(elementToSearch + " was NOT FOUND");
                }
                
                Console.WriteLine("Time taken (ticks) for Hashtable search: " + nbrTicks);

            }
            else
            {
                Console.WriteLine("ERROR: One of the data structures has no data!");
            }


            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        // Binary Search of List<Element>
        static int BinarySearch(List<Element> elementList, string elementToSearch)
        {
            bool foundStatus = false;
            int first = 0;
            int last = elementList.Count - 1;
            int mid;

            int posFound = -1;

            // loop while foundStatus is false AND first is less than or equal to last
            while (!foundStatus && first <= last)
            {
                // get mid index value
                mid = (first + last) / 2;

                // check if value to search is less than the value positioned in the middle of the sorted list
                // if it is, then change the last position to that of the middle less 1
                // this way, last becomes the last value in the sorted upper half of the list
                if (elementToSearch.CompareTo(elementList[mid].ElementName) < 0)
                {
                    last = mid - 1;
                }
                // check if value to search is greater than the value positioned in the middle of the sorted list
                // if it is, then change the first position to that of the middle plus 1
                // this way, first becomes the first value in the sorted lower half of the list
                else if (elementToSearch.CompareTo(elementList[mid].ElementName) > 0)
                {
                    first = mid + 1;
                }
                // otherwise, the value has been found
                else
                {
                    foundStatus = true;
                    posFound = mid;
                }
            }
            return posFound;
        }
    }
}
