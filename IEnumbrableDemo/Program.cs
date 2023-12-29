using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumbrableDemo
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Standard { get; set; }
    }

    public class School : IEnumerable
    {
        List<Student> students = new List<Student>();
        public void Add1(Student s)
        {
            students.Add(s);
        }

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            /*List<Student> students = new List<Student>()
            {
                new Student(){Id = 1, Name = "Rock", Standard = 10 },
                new Student(){Id = 2, Name = "Tony", Standard = 20 },
                new Student(){Id = 3, Name = "Peter", Standard = 30 },
            };*/

            Student std1 = new Student();
            std1.Id = 1;
            std1.Name = "Bill";
            std1.Standard = 12;

            Student std2 = new Student();
            std2.Id = 2;
            std2.Name = "Smith";
            std2.Standard = 20;

            //List<Student> students = new List<Student>();
            School school = new School();

            school.Add1(std1);
            school.Add1(std2);

            foreach (Student item in school)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Standard);
            }
            Console.ReadLine();
        }
    }

    

    
}
