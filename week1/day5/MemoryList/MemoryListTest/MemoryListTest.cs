using System;
using System.Collections.Generic;
using Xunit;
using MemoryList.Library;
namespace MemoryListTest
{
    public class MemoryListTest
    {
        /// <summary>
        /// Tests to ensure AddToList Adds items to both the list and the history
        /// </summary>
        /// <param name="input">array of strings to add to list</param>
        /// <param name="query">string to search history for</param>
        /// <param name="expected">boolean that should be returned by IsInHistory</param>
        [Theory]
        [InlineData (new string[] {"aba"}, "aba", true)]//tests Add To History
        [InlineData (new string[] { "aba", "acc", "bb3dc" }, "aba", true)]//Tests Add to History
        [InlineData (new string[] { "aba" }, "abb", false)]//Test for items not in history
        [InlineData (new string[] {""}, "", true)]// Tests with empty string
        [InlineData (new string[] { null, null }, "abc", false)]//tests with null string
        public void AddAddsToBoth(string[] input, string query, bool expected)
        {
            // instantiate and populate list
            var sut = new MemoryListClass();
            foreach (var item in input)
                sut.AddToList(item);
            //check if 'query' is in history 
            bool actual = sut.IsInHistory(query);
            //check method return against expected result
            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// Test to make sure history retains values removed from list
        /// </summary>
        /// <param name="input">array of strings to add to list</param>
        /// <param name="removed">array of strings to remove from list</param>
        /// <param name="query">string to search history for</param>
        /// <param name="expected">expected boolean return from method IsInHistory</param>
        [Theory]
        [InlineData(new string[] {"aaa", "bbb", "ccc" }, new string[] { "aaa","bbb"}, "bbb", true)]
        [InlineData(new string[] {"aaa", "bbb", "ccc" }, new string[] { "aaa","bbb"}, "ddd", false)]
        [InlineData(new string[] { "aaa", "", "ccc" }, new string[] { "aaa"  }, "", true)]
        [InlineData(new string[] { "aaa", null, "ccc" }, new string[] { "aaa", null }, null, true)]
        public void RetainsHistory(string[] input, string[] removed, string query, bool expected)
        {
            //instantiate and populate list, then remove several items
            var sut = new MemoryListClass();
            foreach (var item in input)
                sut.AddToList(item);
            foreach (var item in removed)
                sut.Remove(item);
            //check if query is in history
            bool actual = sut.IsInHistory(query);
            //check value returned by IsInHistory against expected value
            Assert.Equal(expected, actual);           
        }
    }
}
