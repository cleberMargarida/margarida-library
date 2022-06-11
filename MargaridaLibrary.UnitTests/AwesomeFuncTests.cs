using FluentAssertions;
using Margarida.Util.Bool;
using Margarida.Util.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.UnitTests
{
    [TestFixture]
    internal class AwesomeFuncTests
    {

        [Test]
        public void TestAwesomeFuncWithOnly()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1);
            str.Should().Be("1");
        }

        [Test]
        public void TestAwesomeFuncWithWhereConditionIsFail()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1).When(x => x == 0);
            str.Should().Be(null);
        }

        [Test]
        public void TestAwesomeFuncWithWhereConditionIsCorrect()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1).When(x => x == 1);
            str.Should().Be("1");
        }

        [Test]
        public void TestAwesomeFuncWithMultipleParam()
        {
            Func<int, int, int, int, string> sumToString = (i, j, k, l) => (i + j + k).ToString();
            string str = sumToString.With(0, 1, 2, 3).When((x, y, z, w) => x == 0);
            str.Should().Be("3");
        }

        [Test]
        public void TestAwesomeFuncWithMultipleWhen()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1).When(x => x == 1).When(x => x != 0);
            str.Should().Be("1");
        }

        [Test]
        public void TestAwesomeFuncWithMultipleWhenFirstPassSecondFail()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1).When(x => x == 1).When(x => x != 1);
            str.Should().BeNull();
        }

        [Test]
        public void TestAwesomeFuncWithMultipleWhenBothFail()
        {
            Func<int, string> IntIntoString = i => i.ToString();
            string str = IntIntoString.With(1).When(x => x == 0).When(x => x != 1);
            str.Should().BeNull();
        }
    }
}
