using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        private Random random;
        public RandomList(IEnumerable<string> list)
            :base(list)
        {
            random = new Random();
        }
        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string result = this[index];
            this.RemoveAt(index);
            return result;
        }
    }
}
