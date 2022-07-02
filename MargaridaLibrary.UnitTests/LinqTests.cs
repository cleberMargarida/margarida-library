using FluentAssertions;
using Margarida.Util.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Margarida.UnitTests
{
    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void TestMost()
        {
            List<int> list = new List<int> { 1, 3, 2, 4, 0, -1 };
            int top;
            top = list.Most((x,y) => x < y); // Compares any item an sequence and return the smallest
            top.Should().Be(-1);
            top = list.Most((x, y) => x > y);// Compares any item an sequence and return the biggest
            top.Should().Be(4);
        }
    }
}
