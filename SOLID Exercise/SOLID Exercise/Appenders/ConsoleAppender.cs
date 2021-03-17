using SOLID_Exercise.Enums;
using SOLID_Exercise.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!this.CanAppend(reportLevel))
            {
                return;
            }
            string content = string.Format(this.layout.Template, date, reportLevel, message);
            Console.WriteLine(content);
        }
    }
}
