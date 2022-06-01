using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Teacher;
using System.IO;
using System.Collections.Generic;

namespace TeacherUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private List<MathQues> mathList;
        [TestMethod]
        public bool bubbleTest()
        {
            
            List<MathQues> mathlist = new List<MathQues>();
            mathList.Add(new MathQues(4,"+",3, 7));
            mathList.Add(new MathQues(6, "-", 1, 5));
            mathList.Add(new MathQues(3, "*", 3, 9));
            mathList.Add(new MathQues(4, "/", 2, 8));

            MathQues[] mathQuesArray = mathList.ToArray();
            for (int i = 0; i < mathQuesArray.Length; i++)
            {
                for (int j = 0; j < mathQuesArray.Length - 1; j++)
                {

                    if (mathQuesArray[i].Answer < mathQuesArray[j].Answer)
                    {
                        MathQues temp = mathQuesArray[i];
                        mathQuesArray[i] = mathQuesArray[j];
                        mathQuesArray[j] = temp;
                        // swapCounter++;
                    }

                } // end inner for loop
            } // end outer for loop
            
            //reassign mathList
            mathList = new List<MathQues>(mathQuesArray);
            return true;
        }   



        public void TestMethod1()
        {
           
            bool actualResult = true;
            bool expectedResult = true;
            Assert.AreEqual(actualResult, expectedResult);

        }
    }
}
