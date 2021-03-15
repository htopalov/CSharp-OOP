using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03._Database_Before
{
    public class MemoryCourseData : IData
    {
        private List<Course> courses;
        public MemoryCourseData()
        {
            courses = new List<Course>()
            {
                new Course(){Name = "Course_1", Id = 1 },
                new Course(){Name = "Course_2", Id = 2 },
                new Course(){Name = "Course_3", Id = 3 },
                new Course(){Name = "Course_4", Id = 4 },
                new Course(){Name = "Course_5", Id = 5 }
            };
        }
        public IEnumerable<int> CourseIds()
        {
            return courses.Select(x => x.Id);
        }

        public IEnumerable<string> CourseNames()
        {
            return courses.Select(x => x.Name);
        }

        public string GetCourseById(int id)
        {
            return courses.FirstOrDefault(x => x.Id == id).Name;
        }
    }
}
