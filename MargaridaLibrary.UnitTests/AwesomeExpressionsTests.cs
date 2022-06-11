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
        public class Foo
        {
            public int MyProperty { get; set; }

            public void DoSomething()
            {
                MyProperty++;
            }
        }

        public static class Bar
        {
            public static Foo Foo => new Foo();
            public static Foo CreateFooWithProperty1AndSume1(Expression<Func<Foo, int>> expression) => expression.Assign(1).To(Foo).Execute(x => x.DoSomething());
            public static Foo CreateFooWithProperty2(Expression<Func<Foo, int>> expression) => expression.To(Foo).Assign(2);
        }

        [Test]
        public void TestAwesomeExpressionSetValueIn()
        {
            var foo = Bar.CreateFooWithProperty1AndSume1(x => x.MyProperty);
            foo.MyProperty.Should().Be(2);

            foo = Bar.CreateFooWithProperty1AndSume1(x => x.MyProperty);
            foo.MyProperty.Should().Be(1);
        }
    }
}
