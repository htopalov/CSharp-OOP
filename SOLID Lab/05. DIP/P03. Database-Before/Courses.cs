using P03._Database_Before;
using System.Collections.Generic;

namespace P03._Database
{
    public class Courses
    {
        private IData courseDatabase;
        public Courses(IData courseData)
        {
            courseDatabase = courseData;
        }
        public void PrintAll()
        {
            var courses = courseDatabase.CourseNames();
            System.Console.WriteLine(string.Join(", ",courses));

            //print courses
        }

        public void PrintIds()
        {
            var courseIds = courseDatabase.CourseIds();
            System.Console.WriteLine(string.Join(", ",courseIds));
            //print course ids
        }

        public void PrintById(int id)
        {
           var course = courseDatabase.GetCourseById(id);
            System.Console.WriteLine(course);
            // print course
        }
    }
}
