﻿using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Linq.Extras.Tests.XEnumerableTests
{
    public class ElementAtOrDefaultTests
    {
        [Fact]
        public void ElementAtOrDefault_Throws_If_Argument_Is_Null()
        {
            var source = Enumerable.Empty<int>();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            TestHelper.AssertThrowsWhenArgumentNull(() => source.ElementAtOrDefault(0, 42));
        }

        [Fact]
        public void ElementAtOrDefault_Throws_If_Index_Is_Negative()
        {
            var source = XEnumerable.Empty<int>().ForbidEnumeration();
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => source.ElementAtOrDefault(-1, 42));
            ex.ParamName.Should().Be("index");
        }

        [Fact]
        public void ElementAtOrDefault_Returns_Specified_Default_Value_If_Sequence_Is_Empty()
        {
            var source = XEnumerable.Empty<int>().ForbidMultipleEnumeration();
            source.ElementAtOrDefault(0, 42).Should().Be(42);
        }

        [Fact]
        public void ElementAtOrDefault_Returns_Specified_Default_Value_If_Index_Is_Out_Of_Range()
        {
            var source = new[] { 1, 2, 3 }.ForbidMultipleEnumeration();
            source.ElementAtOrDefault(5, 42).Should().Be(42);
        }

        [Fact]
        public void ElementAtOrDefault_Returns_Element_At_Specified_Position_If_It_Exists()
        {
            var source = new[] { 1, 2, 3 }.ForbidMultipleEnumeration();
            source.ElementAtOrDefault(0, 42).Should().Be(1);
        }

    }
}
