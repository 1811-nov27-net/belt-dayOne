﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LINQAndTesting.Library
{
    public static class StaticStuff
    {
        public static bool Compare<T1, T2>(T1 first, T2 second)
        {
            return first.Equals(second);
        }

        public static void Example()
        {
            Compare(1, "5");
        }
    }
}
