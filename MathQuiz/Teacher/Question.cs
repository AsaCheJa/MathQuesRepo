using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher
{
	public class MathQues : IComparable<MathQues>
	{
		public int LeftOp { get; set; }
		public int RightOp { get; set; }
		public int Answer { get; set; }
		public string MathOp { get; set; }

		public MathQues(int leftOp, string mathOp, int rightOp, int answer)
		{
			LeftOp = leftOp;
			RightOp = rightOp;
			Answer = answer;
			MathOp = mathOp;
		}

		public override string ToString()
		{
			return Answer + "(" + LeftOp + MathOp + RightOp + ")";
		}

		public string questionToSend()
		{
			return LeftOp + " " + MathOp + " " + RightOp + " = " + Answer;
		}

		public int CompareTo(MathQues otherQues)
		{
			int result = 0;
			if (Answer < otherQues.Answer)
			{
				result = -1;
			}
			else if (Answer > otherQues.Answer)
			{
				result = 1;
			}
			return result;
		}
	}
}




		

		
  
