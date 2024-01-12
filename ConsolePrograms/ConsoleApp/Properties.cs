using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Properties
    {
        private int _StdId;    // private variables.
        private string _firstName;
        public string _lastName {  get; private set; }      // auto implemented property.

        public int StdId
        {
            set
            {
                if (StdId <= 0)
                {
                    Console.WriteLine("Id can not be zero.");
                }
                else
                {
                    this._StdId = value;
                }
            }
            get
            {
                return this._StdId;
            }
        }

        public string FirstName
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._firstName = value;
                }
                else
                {
                    Console.WriteLine("name can not be empty");
                }
            }
            get
            {
                return this._firstName;
            }
        }

        public Properties(string lname)     // constructor
        {
            this._lastName = lname;
        }
    }
}
