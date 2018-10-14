using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instructer
{
    public class Instructor
    {
        // IncludeTitle is a boolean, it should only be possible to set it in the constructor, and
        // it should only be possible to read it inside the class.
        readonly bool IncludeTitle;

        // HasPhd is a boolean, it should be possible to read it in the class, and possible to write
        // to it in the class or outside of the class.
        public bool HasPhd { private get; set; }

        // Name is a string. It should be possible to read it and write to it both inside of the class
        // and outside of it. If the code sets it, for example myInstructor.Name = "mike newsound", it 
        // should save the value in upper case using the ToUpper() method, "MIKE NEWSOUND". When the code
        // reads it, it should give the name preceeded by a title if IncludeTitle is true. The title should
        // be "DR." if HasPhd is true, "PROF." if HasPhd is false.
        private String name;
        public String Name
        {
            get
            {
                if (HasPhd)
                    return "DR. " + name;
                else
                    return "PROF " + name;
            }
            set
            {
                name = value.ToUpper();
            }
        }

        // This is a List<string> that should be accessible for both reading and writing in the class, and
        // not accessible at all outside of the class.
        private List<string> _courses = new List<string>();

        // This is a string. It should be possible to read it both inside the class and outside of it, and
        // it should be impossible to write to it both inside the class and outside it. The value it returns
        // should be all of the strings in _courses separated by commas.
        public string Courses
        {
            get { return string.Join(",", _courses); }
        }

        // This is an int, it should be possible to read it and write to it inside of the class, it should be
        // completely inaccessible outside of the class.
        private int CommitteeMemberships;

        // This is a bool. It should be possible to read it in the class but not possible to set it in the class,
        // and it should be impossible to read it or write to it outside of the class. The value it returns
        // should be true if the sum of the number of courses being taught (the Count of _courses) and the number
        // of committee memberships is 4 or more, false otherwise.
        private bool FullTime
        {
            get
            {
                if (_courses.Count >= 4)
                    return true;
                else
                    return false;
            }
        }

        // Base Salary is an int. It should be possible to read it only inside of the class and it should only
        // be possible to set it in the constructor.
        readonly int BaseSalary;

        // Salary is an int. It should be possible to read it both inside and outside of the class, and impossible
        // to set it both inside and outside of the class. The value it returns shouild be BaseSalary, plus 1000 
        // if HasPhd is true.
        public int Salary
        {
            get
            {
                if (HasPhd)
                    return BaseSalary + 1000;
                else
                    return BaseSalary;
            }
        }

        // You will not need to modify this method
        public bool AddWorkUnit(String descr)
        {
            if (descr == "committee")
                CommitteeMemberships++;
            else
            {
                if (_courses.Count == 4)
                    return false;
                _courses.Add(descr);
            }
            return true;
        }

        // You will not need to modify the constructor
        public Instructor(string name, bool hasPhd, int baseSalary, bool includeTitle)
        {
            Name = name;
            HasPhd = hasPhd;
            BaseSalary = baseSalary;
            IncludeTitle = includeTitle;
        }

        // This method is just to test that you did everything correctly. Uncomment the code to see if you get
        // a compile error where indicated.
        public void Reset()
        {
            // This line should fail:
            //IncludeTitle = false;

            // This line should succeed:
            HasPhd = false;

            // This line should succeed:
            Name = "John Doe";

            // This line should succeed:
            _courses = new List<string>();

            // This line should fail:
            //Courses = ""; 

            // This line should succeed:
            CommitteeMemberships = 0;

            // This line should fail:
            //FullTime = false;

            // This line should fail:
            //BaseSalary = 0;

            // This line should fail:
            //Salary = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Instructor instructor = new Instructor("U. T. Mellings", true, 3000, true);
            instructor.AddWorkUnit("MCO 364");
            instructor.AddWorkUnit("committee");

            // This line should fail:
            //instructor.IncludeTitle = false;

            // This line should fail:
            //Console.WriteLine($"Include Title: {instructor.IncludeTitle}");

            // This line should succeed:
            instructor.HasPhd = false;

            // This line should fail:
            //Console.WriteLine($"Has Phd: {instructor.HasPhd}");

            // This line should succeed:
            instructor.Name = "T. Z. Burtonlive";

            // This line should succeed:
            Console.WriteLine($"Name: {instructor.Name}");

            // This line should fail:
            //instructor._courses = new List<string>();

            // This line should fail:
            //Console.WriteLine($"Courses: {String.Join(", ", instructor._courses)}");

            // This line should fail:
            //instructor.Courses = "MCO 264, MCO 152";

            // This line should succeed:
            Console.WriteLine($"Courses: {instructor.Courses}");

            // This line should fail:
            //instructor.CommitteeMemberships = 1;

            // This line should fail:
            //Console.WriteLine($"Committee Memberships: {instructor.CommitteeMemberships}");

            // This line should fail:
            //instructor.FullTime = true;

            // This line should fail:
            //Console.WriteLine($"Full Time: {String.Join(", ", instructor.FullTime)}");

            // This line should fail:
            //instructor.BaseSalary = 4500;

            // This line should fail:
            //Console.WriteLine($"Base Salary: {String.Join(", ", instructor.BaseSalary)}");

            // This line should fail:
            //instructor.Salary = 4500;

            // This line should succeed:
            Console.WriteLine($"Salary: {String.Join(", ", instructor.Salary)}");
            Console.ReadKey();
        }
    }
}