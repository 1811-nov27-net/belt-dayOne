using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTesting.Library
{
    public static class MyCollectionExtensions
    {
        public static bool IsEmpty(this MyCollection coll)
        {
            return coll.Length == 0;
        }
    }
}
