using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationAndAsync
{
    public class Person
    {
        public int id { get; set; }
        public Name name { get; set; }
        public List<string> nicknames { get; set; } = new List<string>();
        public Address address { get; set; }
        public int age { get; set; }
    }
}
