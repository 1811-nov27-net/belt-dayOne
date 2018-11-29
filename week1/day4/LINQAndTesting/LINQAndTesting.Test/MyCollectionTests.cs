using LINQAndTesting.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace LINQAndTesting.Test
{
    //one test class per real class
    public class MyCollectionTests
    {
        //each test should test one thing
        [Fact]//attribute
        public void EmptyCollectionHasZeroLength()
        {
            //arrange
            var sut = new MyCollection();//sut = Subject Under Testing
            //act
            var result = sut.Length;
            //assert
            Assert.Equal(0, result); //Assert has a lot of static methods
        }
        [Theory]//fact is for test that take no arguments
        [InlineData (new string[]{"a","ab"}, "ab")]
        [InlineData (new string[]{"ab","a"}, "ab")]
        [InlineData (new string[]{"a"}, "a")]
        [InlineData (new string[]{"ab","b2"}, "ab")]
        [InlineData (new string[]{}, null)]
        [InlineData (new string[]{"ab", null, "a"}, "ab")]
        [InlineData (new string[] {""}, "")]
        public void LongestShouldReturnLongest(string[] items, string expected)
        {
            var coll = new MyCollection();
            foreach (var item in items)
                coll.Add(item);

            var actual = coll.Longest();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestIsEmpty()
        {
            var coll = new MyCollection();

            var actual = coll.IsEmpty();

            Assert.True(actual);
        }

    }
}
