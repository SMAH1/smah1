using System;
using Xunit;

namespace TestSMAH1.Core
{
    public class WildcardTest
    {
        [Fact]
        public void Setup()
        {
            Assert.True(SMAH1.Wildcard.Compare("ABC", "ABC"));
        }

        [Theory]
        [InlineData("ran.jpg", "*.jpg")]
        [InlineData("", "*")]
        [InlineData(" ", "?")]
        [InlineData("a", "*")]
        [InlineData("ab", "*")]
        [InlineData("a", "?")]
        [InlineData("abc", "*?")]
        [InlineData("a", "*?")]
        [InlineData("abc", "?*")]
        [InlineData("a", "?*")]
        [InlineData("abc", "*abc")]
        [InlineData("abc", "*abc*")]
        [InlineData("abc", "*a*b*c*")]
        [InlineData("aXXXbc", "*a*bc*")]
        [InlineData("a?bc", @"a\?bc")]
        [InlineData("a?bcd", @"a\?bc*")]
        [InlineData("a?bcd", @"a\?bc?")]
        [InlineData("a*bc", @"a\*bc")]
        [InlineData("a*bcd", @"a\*bc*")]
        [InlineData("a*bcd", @"a\*bc?")]
        public void BulkTestResultTrue(string input, string pattern)
        {
            Assert.True(SMAH1.Wildcard.Compare(input, pattern));
        }

        [Theory]
        [InlineData("", "*a")]
        [InlineData("", "a*")]
        [InlineData("", "?")]
        [InlineData("a", "*b*")]
        [InlineData("ab", "b*a")]
        [InlineData("a", "??")]
        [InlineData("", "*?")]
        [InlineData("a", "??*")]
        [InlineData("abX", "*abc")]
        [InlineData("Xbc", "*abc*")]
        [InlineData("ac", "*a*bc*")]
        [InlineData("a*bc", @"*a\?bc*")]
        [InlineData("adbc", @"*a\?bc*")]
        [InlineData("a?bc", @"*a\*bc*")]
        [InlineData("adbc", @"*a\*bc*")]
        public void BulkTestResultFalse(string input, string pattern)
        {
            Assert.False(SMAH1.Wildcard.Compare(input, pattern));
        }
    }
}
