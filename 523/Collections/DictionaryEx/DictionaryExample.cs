/*
    ----------------------------------------------------------------------------------
    Collections in C# --- (4) Dictionary
    Developed by Hans Telford
    ----------------------------------------------------------------------------------
    A Dictionary is a dynamic data structure which represents a collection of key/value pairs 
    that are organized based on the hash code of the key. They are very good for storing unsorted data.

    The Dictionary data structure is similar to the Hashtable and also uses key/value pairs, however it is a 
    generic data type; whereas the hashtable is not. 
    This means the Dictionary provides type safety because you can't insert any random object into it 
    and you don't have to cast values that are taken out.

    Because dictionaries are unordered, they are generally not ideal for lists of values like 
    strings and numbers --- although this example uses this.

    The key is likened to a unique identifier - a primary key in a data base table
    Database developers use primary keys to uniquely identify each row in the table - much like using
    Drivers License numbers, Tax file numbers, Bank account numbers, Passport numbers etc.

    MSDN documentation source:
    https://msdn.microsoft.com/en-us/library/xfhwa508(v=vs.110).aspx

    Dictionary<K, T> bank account example:
    row can be made an object ... K can be integer and T can be the data)
    K - account number (int, string)
    T - BankAccount object (class contains name, address, contact, balance, interest)

    This example includes an example of using File IO to read an external plaintext file (.csv format)
    which consists of a list of 118 elements (with atomic number, element name and element symbol)
    This external file (named "elements.csv" needs to be in the same directory as the executable)

    Each element has a unique atomic number (e.g. Oxygen's atomic number is 8 and no other
    element has this atomic number). For this reason, the key will be the element's atomic number

    Source code is error-free and was tested in MS Visual Studio 2022 (Community Edition) as at 20th April, 2022
    Hans Telford

*/

using System;
using System.Collections.Generic;   // needed for the Dictionary<TKey, TValue> class
using System.IO;                    // used for File I/O
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEx
{
    /********************************************************************************/
    // Dictonary example set up in Main() method
    /********************************************************************************/
    class DictionaryExample
    {
        static void Main(string[] args)
        {
            // 1. Declare data variables needed for this program
            string line = "";
            string[] delimiters = { "," };
            Dictionary<int, string> elements = new Dictionary<int, string>();
            int atomicNbr = 0;

            // display header
            Console.WriteLine("********************************************");
            Console.WriteLine("*******       Dictionary Example     *******");
            Console.WriteLine("********************************************");

            // 2. Get/Set input for the data we need
            // 3. Process the data in some meaningful way
            // read the list of elements from external csv file
            try
            {
                // set up FileStream object
                // this is used to open and read the external file
                // each line is read in (line by line) --- each line contains atomic number, element name and
                // element symbol
                // the string line is then split into 3 components
                // atomic number is made the index --- a unique identifier for the entire data set
                // (rather like drivers licence number, tax file number, bank account number etc)
                // this equates to the  <int> part of the Dictionary object
                // The element name and symbol makes up the <string> part
                FileStream fs = new FileStream("elements.csv", FileMode.Open, FileAccess.Read);

                // use a StreamReader object to read the file contents line by line
                using (var streamReader = new StreamReader(fs, Encoding.UTF8))
                {
                    // loop while the streamReader is getting content and stop when it gets nothing
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // each string line is split using the comma delimiter
                        string [] splitStr = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        // assemble the element details (for the value part of the Dictionary element)
                        string elementDetails = splitStr[2] + " (" + splitStr[1] + ")";
                        // add the dictionary element (Key, Value)
                        // Key is the atomic number and Value is the Element name and symbol in parenthesis)
                        elements.Add(Int32.Parse(splitStr[0]), elementDetails);
                    }
                }

                // at this point, we have 118 elements stored in the dictionary object "elements"
                // the key (integer) represents the atomic number (e.g. 8)
                // the value (string) represents the element name and element symbol (e.g. Oxygen (O))
                   
            }
            // Do this in case there is no external file or the external file is corrupted
            catch (Exception e)
            {
                Console.WriteLine("FILE I/O ERROR: " + e.ToString());
            }

            // 4. Output what we want to see
            // the test
            if (elements.Count > 0)
            {
                // display elements count and ask user for atomic number (key) to search for
                try
                {
                    Console.WriteLine("There are " + elements.Count + " elements listed ... ");
                    
                    foreach (KeyValuePair<int, string> elementDetails in elements)
                    {
                        Console.WriteLine(elementDetails);
                    }

                    Console.WriteLine("********************************************");
                    Console.Write("Enter the atomic number for the element you wish to search for: ");
                    atomicNbr = Int32.Parse(Console.ReadLine());

                    // search for atomic number
                    // NOTE: This is a lot simpler than doing a for loop (like for Lists or Arrays)
                    if (elements.ContainsKey(atomicNbr))
                    {
                        Console.WriteLine("Element for atomic number #" + atomicNbr + " is: " + 
                                                       elements[atomicNbr].ToString());
                    }
                    else
                    {
                        // otherwise, display an error message
                        Console.WriteLine("ERROR: " + atomicNbr + " is not listed.");
                    }

                // deal with any potential problem with user entry of an integer
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: Could not convert to integer: " + e.ToString());
                }
                

            // deal with any potential problem of a number that doesn't exist in the dictionary
            }
            else
            {
                Console.WriteLine("Sorry, there are no elements listed in the dictionary");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

/*
    OUTPUT:

    ********************************************
    *******       Dictionary Example     *******
    ********************************************
    There are 118 elements listed ...
    [1, Hydrogen (H)]
    [2, Helium (He)]
    [3, Lithium (Li)]
    [4, Beryllium (Be)]
    [5, Boron (B)]
    [6, Carbon (C)]
    [7, Nitrogen (N)]
    [8, Oxygen (O)]
    [9, Fluorine (F)]
    [10, Neon (Ne)]
    [11, Sodium (Na)]
    [12, Magnesium (Mg)]
    [13, Aluminum (Al)]
    [14, Silicon (Si)]
    [15, Phosphorus (P)]
    [16, Sulfur (S)]
    [17, Chlorine (Cl)]
    [18, Argon (Ar)]
    [19, Potassium (K)]
    [20, Calcium (Ca)]
    [21, Scandium (Sc)]
    [22, Titanium (Ti)]
    [23, Vanadium (V)]
    [24, Chromium (Cr)]
    [25, Manganese (Mn)]
    [26, Iron (Fe)]
    [27, Cobalt (Co)]
    [28, Nickel (Ni)]
    [29, Copper (Cu)]
    [30, Zinc (Zn)]
    [31, Gallium (Ga)]
    [32, Germanium (Ge)]
    [33, Arsenic (As)]
    [34, Selenium (Se)]
    [35, Bromine (Br)]
    [36, Krypton (Kr)]
    [37, Rubidium (Rb)]
    [38, Strontium (Sr)]
    [39, Yttrium (Y)]
    [40, Zirconium (Zr)]
    [41, Niobium (Nb)]
    [42, Molybdenum (Mo)]
    [43, Technetium (Tc)]
    [44, Ruthenium (Ru)]
    [45, Rhodium (Rh)]
    [46, Palladium (Pd)]
    [47, Silver (Ag)]
    [48, Cadmium (Cd)]
    [49, Indium (In)]
    [50, Tin (Sn)]
    [51, Antimony (Sb)]
    [52, Tellurium (Te)]
    [53, Iodine (I)]
    [54, Xenon (Xe)]
    [55, Cesium (Cs)]
    [56, Barium (Ba)]
    [57, Lanthanum (La)]
    [58, Cerium (Ce)]
    [59, Praseodymium (Pr)]
    [60, Neodymium (Nd)]
    [61, Promethium (Pm)]
    [62, Samarium (Sm)]
    [63, Europium (Eu)]
    [64, Gadolinium (Gd)]
    [65, Terbium (Tb)]
    [66, Dysprosium (Dy)]
    [67, Holmium (Ho)]
    [68, Erbium (Er)]
    [69, Thulium (Tm)]
    [70, Ytterbium (Yb)]
    [71, Lutetium (Lu)]
    [72, Hafnium (Hf)]
    [73, Tantalum (Ta)]
    [74, Tungsten (W)]
    [75, Rhenium (Re)]
    [76, Osmium (Os)]
    [77, Iridium (Ir)]
    [78, Platinum (Pt)]
    [79, Gold (Au)]
    [80, Mercury (Hg)]
    [81, Thallium (Tl)]
    [82, Lead (Pb)]
    [83, Bismuth (Bi)]
    [84, Polonium (Po)]
    [85, Astatine (At)]
    [86, Radon (Rn)]
    [87, Francium (Fr)]
    [88, Radium (Ra)]
    [89, Actinium (Ac)]
    [90, Thorium (Th)]
    [91, Protactinium (Pa)]
    [92, Uranium (U)]
    [93, Neptunium (Np)]
    [94, Plutonium (Pu)]
    [95, Americium (Am)]
    [96, Curium (Cm)]
    [97, Berkelium (Bk)]
    [98, Californium (Cf)]
    [99, Einsteinium (Es)]
    [100, Fermium (Fm)]
    [101, Mendelevium (Md)]
    [102, Nobelium (No)]
    [103, Lawrencium (Lr)]
    [104, Rutherfordium (Rf)]
    [105, Dubnium (Db)]
    [106, Seaborgium (Sg)]
    [107, Bohrium (Bh)]
    [108, Hassium (Hs)]
    [109, Meitnerium (Mt)]
    [110, Darmstadtium (Ds)]
    [111, Roentgenium (Rg)]
    [112, Copernicium (Cn)]
    [113, Nihonium (Nh)]
    [114, Flerovium (Fl)]
    [115, Moscovium (Mc)]
    [116, Livermorium (Lv)]
    [117, Tennessine (Ts)]
    [118, Oganesson (Og)]
    ********************************************
    Enter the atomic number for the element you wish to search for: 8
    Element for atomic number #8 is: Oxygen (O)
    Press any key to continue . . .
*/
