using SOLID_Exercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
