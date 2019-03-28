using SMAH1.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace TestSMAH1.Core
{
    public class EnumInfoBaseTest
    {
        public enum TestEnum
        {
            [Description("1")]
            First,

            [Descriptions("2", "two")]
            Second,

            Third,

            [Descriptions("4")]
            Fourth
        }

        [Flags]
        public enum TestFlagEnum
        {
            [Description("1")]
            First = 1,

            [Descriptions("2", "two")]
            Second = 2,

            Third = 4,

            [Descriptions("4")]
            Fourth = 8
        }

        [Fact]
        public void TestCountDescription()
        {
            var count = SMAH1.EnumInfoBase<TestEnum>.CountDescription;
            Assert.True(count == 2);
        }

        [Fact]
        public void TestGetFields()
        {
            var res = SMAH1.EnumInfoBase<TestEnum>.GetFields();

            List<TestEnum> shouldList = new List<TestEnum>();
            shouldList.Add(TestEnum.First);
            shouldList.Add(TestEnum.Third);
            shouldList.Add(TestEnum.Fourth);
            shouldList.Add(TestEnum.Second);

            Assert.True(res.Count == shouldList.Count);
            Assert.True(shouldList.All(shouldItem => res.Any(item => item == shouldItem)));
        }

        [Theory]
        [InlineData(0, "1", "2", "Third", "4")]
        [InlineData(1, "Third", "1", "4", "two")]
        [InlineData(2, "Third", "1", "4", "two")]
        [InlineData(3, "Third", "1", "4", "two")]
        public void TestGetFieldsDescription(int index, params string[] shouldList)
        {
            var res = SMAH1.EnumInfoBase<TestEnum>.GetFieldsDescription(index);

            Assert.True(res.Count == shouldList.Length);
            Assert.True(shouldList.All(shouldItem => res.Any(item => item == shouldItem)));
        }

        [Theory]
        [InlineData(TestEnum.First, 0, "1")]
        [InlineData(TestEnum.First, 1, "1")]
        [InlineData(TestEnum.First, 2, "1")]
        [InlineData(TestEnum.First, 3, "1")]
        [InlineData(TestEnum.Second, 0, "2")]
        [InlineData(TestEnum.Second, 1, "two")]
        [InlineData(TestEnum.Second, 2, "two")]
        [InlineData(TestEnum.Second, 3, "two")]
        [InlineData(TestEnum.Third, 0, "Third")]
        [InlineData(TestEnum.Third, 1, "Third")]
        [InlineData(TestEnum.Third, 2, "Third")]
        [InlineData(TestEnum.Third, 3, "Third")]
        [InlineData(TestEnum.Fourth, 0, "4")]
        [InlineData(TestEnum.Fourth, 1, "4")]
        [InlineData(TestEnum.Fourth, 2, "4")]
        [InlineData(TestEnum.Fourth, 3, "4")]
        public void TestGetFieldDescription(TestEnum e, int index, string item)
        {
            var res = SMAH1.EnumInfoBase<TestEnum>.GetFieldDescription(e, index);

            Assert.True(res == item);
        }

        [Theory]
        [InlineData(TestEnum.First, 0, "1")]
        [InlineData(TestEnum.First, 1, "1")]
        [InlineData(TestEnum.First, 2, "1")]
        [InlineData(TestEnum.First, 3, "1")]
        [InlineData(TestEnum.Second, 0, "2")]
        [InlineData(TestEnum.Second, 1, "two")]
        [InlineData(TestEnum.Second, 2, "two")]
        [InlineData(TestEnum.Second, 3, "two")]
        [InlineData(TestEnum.Third, 0, "Third")]
        [InlineData(TestEnum.Third, 1, "Third")]
        [InlineData(TestEnum.Third, 2, "Third")]
        [InlineData(TestEnum.Third, 3, "Third")]
        [InlineData(TestEnum.Fourth, 0, "4")]
        [InlineData(TestEnum.Fourth, 1, "4")]
        [InlineData(TestEnum.Fourth, 2, "4")]
        [InlineData(TestEnum.Fourth, 3, "4")]
        public void TestGetFieldDescriptionsNoneFlag(TestEnum e, int index, params string[] shouldList)
        {
            var res = SMAH1.EnumInfoBase<TestEnum>.GetFieldDescriptions(e, index);

            Assert.True(res.Count == shouldList.Length);
            Assert.True(shouldList.All(shouldItem => res.Any(item => item == shouldItem)));
        }

        [Theory]
        [InlineData(TestFlagEnum.First, 0, "1")]
        [InlineData(TestFlagEnum.First, 1, "1")]
        [InlineData(TestFlagEnum.First, 2, "1")]
        [InlineData(TestFlagEnum.First, 3, "1")]
        [InlineData(TestFlagEnum.Second, 0, "2")]
        [InlineData(TestFlagEnum.Second, 1, "two")]
        [InlineData(TestFlagEnum.Second, 2, "two")]
        [InlineData(TestFlagEnum.Second, 3, "two")]
        [InlineData(TestFlagEnum.Third, 0, "Third")]
        [InlineData(TestFlagEnum.Third, 1, "Third")]
        [InlineData(TestFlagEnum.Third, 2, "Third")]
        [InlineData(TestFlagEnum.Third, 3, "Third")]
        [InlineData(TestFlagEnum.Fourth, 0, "4")]
        [InlineData(TestFlagEnum.Fourth, 1, "4")]
        [InlineData(TestFlagEnum.Fourth, 2, "4")]
        [InlineData(TestFlagEnum.Fourth, 3, "4")]
        [InlineData(TestFlagEnum.Fourth | TestFlagEnum.First, 0, "1", "4")]
        [InlineData(TestFlagEnum.Third | TestFlagEnum.First | TestFlagEnum.Second, 1, "1", "two", "Third")]
        [InlineData(TestFlagEnum.Fourth | TestFlagEnum.Second, 5, "4", "two")]
        public void TestGetFieldDescriptionsIsFlag(TestFlagEnum e, int index, params string[] shouldList)
        {
            var res = SMAH1.EnumInfoBase<TestFlagEnum>.GetFieldDescriptions(e, index);

            Assert.True(res.Count == shouldList.Length);
            Assert.True(shouldList.All(shouldItem => res.Any(item => item == shouldItem)));
        }
    }
}
