using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IAddable, IRemovable, IUsed
    {
        private List<string> list;

        public MyList()
        {
            list = new List<string>();
        }
        public int Used { get { return list.Count; } }

        public int Add(string input)
        {
            list.Insert(0, input);
            return 0;
        }

        public string Remove()
        {
            string firstItem = list[0];
            list.RemoveAt(0);
            return firstItem;
        }
    }
}
