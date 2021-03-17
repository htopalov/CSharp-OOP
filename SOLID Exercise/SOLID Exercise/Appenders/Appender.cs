using SOLID_Exercise.Enums;
using SOLID_Exercise.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= this.ReportLevel;
        }
    }
}
