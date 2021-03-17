using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Layout
{
    public class SimpleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
