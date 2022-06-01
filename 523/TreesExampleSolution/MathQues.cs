using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    class MathQues : IComparable<MathQues>
    {
        // private data fields for a single math question
        // 2 + 3 = 5
        // leftOperand is 2
        // rightOperand is 3
        // mathOp is +
        // answer is 5
        private int leftOperand;
        private int rightOperand;
        private string mathOp;
        private int answer;
		

        // public properties (provide public get() and set() methods for private instance data)
        // TO DO
        public int LeftOperand { get; set; }
        public int RightOperand { get; set; }
        public string MathOp { get; set; }
        public int Answer { get; set; }





        // constructor method
        public MathQues(int leftOperand, int rightOperand, string mathOperator, int answer)
        {
            // TO DO
			LeftOperand = leftOperand;
            RightOperand = rightOperand;
            MathOp = mathOperator;
            Answer = answer;	
        }

        // CompareTo() method implementation from IComparable interface
        // compares answer of (this) object with that of the input otherMathObj answer
        // returns 0 if both answers are the same
        // returns -1 if the 'this' object is numerically less than the otherMathObj answer
        // returns 1 if the 'this' object is numerically greater than the otherMathObj answer
        public int CompareTo(MathQues otherMathQues)
        {
            // TO DO
            int result = 0;
            if (Answer < otherMathQues.Answer)
            {
                result = -1;
            }
            else if (Answer > otherMathQues.Answer)
            {
                result = 1;
            }
            return result;
        }

        // ToString() over-ride method to display all data for the instance
		// Format example 24(3 * 8)
        public override string ToString()
        {
            // TO DO
            return Answer + "(" + LeftOperand + " " + MathOp + " " + RightOperand + ")";
        }

    }
}
