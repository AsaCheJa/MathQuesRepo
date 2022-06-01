using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesExample
{
    class Friend : IComparable<Friend>
    {
        // private data fields
        private string fName;
		private string lName;
		private DateTime dob;

        // public properties
        public string FName
        {
            get { return fName; }
            set { fName = value; }
        }

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        // constructor
        public Friend(string fName, string lName, DateTime dob)
        {
            FName = fName;
            LName = lName;
            Dob = dob;
        }

        // CompareTo() method implementation from IComparable interface
        // compares date of birth of (this) Dob with that of the otherFriend Dob
        // returns 0 if both dates are chronologically the same
        // returns -1 if the otherFriend has an older date (this object's date of birth is more recent)
        // returns 1 if the otherFriend has a more recent date (this object's date of birth is older)

        public int CompareTo(Friend otherFriendObj)
        {
            DateTime friendDOB = ((Friend)otherFriendObj).dob;

            if (this.dob > friendDOB)
                return 1;
            else if (this.dob < friendDOB)
                return -1;
            else
                return 0;
        }

        // ToString() over-ride method to display all data for the instance
        public override string ToString()
        {
            return fName + "," + lName + "," + dob.ToString();
        }

    }
}
