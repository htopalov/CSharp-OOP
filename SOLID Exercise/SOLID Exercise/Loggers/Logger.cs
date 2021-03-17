using SOLID_Exercise.Appenders;
using SOLID_Exercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Warning, message);
        }
        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Error, message);
        }

        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Critical, message);
        }


        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Fatal, message);
        }

        private void AppendToAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(date, ReportLevel.Info, message);

            }
        }
    }
}
