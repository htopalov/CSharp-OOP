using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public class LogFile : ILogFile
    {
        private const string Path = "../../../log.txt";
        public int Size => File.ReadAllText(Path)
                               .Where(c => char.IsLetter(c))
                               .Sum(x => x);

        public void Write(string content)
        {
            File.AppendAllText(Path, content);
        }
    }
}
