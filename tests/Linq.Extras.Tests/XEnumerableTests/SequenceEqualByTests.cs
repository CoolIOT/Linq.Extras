﻿using FluentAssertions;
using Xunit;

namespace Linq.Extras.Tests.XEnumerableTests
{
    public class SequenceEqualByTests
    {
        [Fact]
        public void SequenceEqualBy_Throws_If_Argument_Is_Null()
        {
            var source = XEnumerable.Empty<string>().ForbidEnumeration();
            var other = XEnumerable.Empty<string>().ForbidEnumeration();
            TestHelper.AssertThrowsWhenArgumentNull(
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                () => source.SequenceEqualBy(other, s => s.Length, null));
        }

        [Fact]
        public void SequenceEqualBy_Returns_True_If_Both_Sequences_Are_Empty()
        {
            var source = XEnumerable.Empty<string>().ForbidMultipleEnumeration();
            var other = XEnumerable.Empty<string>().ForbidMultipleEnumeration();
            source.SequenceEqualBy(other, s => s.Length).Should().BeTrue();
        }

        [Fact]
        public void SequenceEqualBy_Returns_False_If_Sequences_Have_Different_Lengths()
        {
            var source = new[] { "hello", "world" }.ForbidMultipleEnumeration();
            var other = new[]{ "world" }.ForbidMultipleEnumeration();
            source.SequenceEqualBy(other, s => s.Length).Should().BeFalse();
        }

        [Fact]
        public void SequenceEqualBy_Returns_True_If_Sequences_Have_Same_Lengths_And_Same_Keys()
        {
            var source = new[] { "hello", "!" }.ForbidMultipleEnumeration();
            var other = new[] { "world", "!" }.ForbidMultipleEnumeration();
            source.SequenceEqualBy(other, s => s.Length).Should().BeTrue();
        }
    }
}
