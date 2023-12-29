using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    /*public class Program
    {
        static void Main(string[] args)
        {
            *//*Teacher t1 = new Teacher();
            t1.Name();*//*

            Console.WriteLine("Enter your object type");
            string type = Console.ReadLine();

            ISchool schoolData = FactoryCls.GetTeacherOrStudentData(type);
            Console.WriteLine(schoolData.Name());

            Console.ReadKey();
        }
    }*/

    // factory class
    class FactoryCls
    {
        public static ISchool GetTeacherOrStudentData(string typeOfObj)
        {
            ISchool obj = null;
            if (typeOfObj.ToLower() == "teacher")
            {
                obj = new Teacher();
            }
            else
            {
                obj = new Student();
            }
            return obj;
        }
    }


    interface ISchool
    {
        string Name();
        string Age();
    }

    class Teacher : ISchool
    {
        public string Name()
        {
            return "Teacher Name";
        }
        public string Age()
        {
            return "35";
        }
        public string Home()
        {
            return "Teacher home";
        }
    }

    class Student : ISchool
    {
        public string Name()
        {
            return "Student Name";
        }
        public string Age()
        {
            return "15";
        }
    }
}
