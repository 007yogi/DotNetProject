using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectoin.SimpleDependency
{
    public class School
    {
        public void SchoolName()
        {
            Console.WriteLine("Delhi Public School");
        }
    }
    public class Student
    {
        private School school;
        public Student()
        {
            school = new School();
        }
        public void StudentName()
        {
            Console.WriteLine("Student name is: Yogesh Kumar");
            school.SchoolName();
        }
    }
}
