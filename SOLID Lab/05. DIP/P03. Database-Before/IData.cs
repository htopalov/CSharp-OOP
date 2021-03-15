using System;
using System.Collections.Generic;
using System.Text;

namespace P03._Database_Before
{
    public interface IData
    {
        public IEnumerable<int> CourseIds();
        public IEnumerable<string> CourseNames();
        public string GetCourseById(int id);
    }
}
