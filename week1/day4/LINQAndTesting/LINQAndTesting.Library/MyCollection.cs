using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAndTesting.Library
{
    /// <summary>
    /// a list with some extra helper methods
    /// </summary>
    /// inheritance or composition
    public class MyCollection : MyGenericCollection<string>
    {
        //private readonly List<string> _list = new List<string>(); became redundant
        public int Length { get { return _list.Count; } }

        public override void Add(string item)
        {
            _list.Add(item);
        }

        public string Get(int index)
        {
            return _list[index];
        }

        public string Longest()
        {
            int longestLength = -1;
            string longest = null;
            foreach (string item in _list)
            {
                if (item != null && item.Length > longestLength)
                {
                    longestLength = item.Length;
                    longest = item;
                }
            }
            return longest;
        }
        public double AverageLength()
        {
            return _list.Average(x => x.Length);
        }
        public IEnumerable<int> Lengths()
        {
            return _list.Select(x => x.Length);
        }
        public int NumberOfAs()
        {
            return _list.Count(x => (x!= null && x.Length > 0 && x[0] == 'a'));
        }
        private static bool ContainsVowel(string s)
        {
            return s.Any(x => "AEIOUaeiou".Contains(x));
        }
        public int NumberWithVowels()
        {
            return _list.Count(ContainsVowel);
        }
        public string FirstAlphabetical()
        {
            IEnumerable<string> sorted = _list.OrderBy(x => x);
            var first = sorted.First();
            return first;
        }
    }
}
