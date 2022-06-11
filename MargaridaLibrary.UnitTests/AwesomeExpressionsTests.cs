using FluentAssertions;
using Margarida.Util.Linq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace Margarida.UnitTests
{
    [TestFixture]
    internal class AwesomeExpressionsTests
    {
        public record Foo(int MyProperty = 0);
        public static class Bar
        {
            public static Foo Foo => new Foo();
            public static Foo CreateFooWithProperty1(Expression<Func<Foo, int>> expression) => expression.Assign(1).To(Foo);
            public static Foo CreateFooWithProperty2(Expression<Func<Foo, int>> expression) => expression.To(Foo).Assign(2);
        }

        [Test]
        public void TestAwesomeExpressionSetValueIn()
        {
            var foo = Bar.CreateFooWithProperty1(x => x.MyProperty);
            foo.MyProperty.Should().Be(1);

            foo = Bar.CreateFooWithProperty1(x => x.MyProperty);
            foo.MyProperty.Should().Be(1);
        }
    }
}
