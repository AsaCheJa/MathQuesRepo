using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSortTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathQues q1 = new MathQues(3, "+", 4, 7);
            //Console.WriteLine(q1.questionToSend());
            //Console.WriteLine(q1.ToString());

            MathQues q2 = new MathQues(6, "-", 2, 4);
            MathQues q3 = new MathQues(15, "/", 3, 5);
            MathQues q4 = new MathQues(3, "*", 4, 12);

            // List of MathQues instances
            List<MathQues> mathQuesList = new List<MathQues>();
            mathQuesList.Add(q1);
            mathQuesList.Add(q2);
            mathQuesList.Add(q3);
            mathQuesList.Add(q4);

            //mathQuesList.Sort();
            mathQuesList = SelectionSort(mathQuesList);
            Console.WriteLine();
            Console.WriteLine("Sorted List ...");
            DisplayList(mathQuesList);
            


        }

        public static void DisplayList(List<MathQues> mList)
        {
            foreach(MathQues m in mList)
            {
                Console.WriteLine(m.questionToSend());
            }
            
        }

        public static List<MathQues> SelectionSort(List<MathQues> mList)
        {
            // create array 
            MathQues[] mArray = mList.ToArray<MathQues>();
            // selection sort (ascending order)
            for (int i = 0; i < mArray.Length - 1; i++)
            {
                for (int j = i + 1; j < mArray.Length; j++)
                {
                    if (mArray[j].Answer > mArray[i].Answer)
                    {
                        // swap value
                        MathQues temp = mArray[j];
                        mArray[j] = mArray[i]; // reassign
                        mArray[i] = temp;
                    }
                }
            }

            // now we have a sorted array
            // return List version of the sorted array
            return new List<MathQues>(mArray);
        }
    }
}
