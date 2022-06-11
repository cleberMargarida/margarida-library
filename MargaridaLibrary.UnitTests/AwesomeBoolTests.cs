using FluentAssertions;
using Margarida.Util.Bool;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.UnitTests
{
    [TestFixture]
    internal class AwesomeBoolTests
    {

        [Test]
        public void TestBoolExtValueGets()
        {
            var p = true;
            var q = false;
            var r = true;

            ((bool)p.Value()).Should().BeTrue();
            p.Value().Not.Should().BeFalse();
            p.Then(q).Should().BeFalse();
            p.With(!q).HasSameValue.Should().BeTrue();
            (!p).With(q).HasSameValue.Should().BeTrue();
            (!p).With(q).ResultInFalse.Should().BeTrue();
            p.With(!q).ResultInTrue.Should().BeTrue();
            (p).With(q).ResultOfImplication.Should().BeFalse();
            p.With(!q).With(r).ResultInTrue.Should().BeTrue();
            (!p).With(q).With(!r).ResultInFalse.Should().BeTrue();
            (p).With(q).With(!r).ResultOfImplication.Should().BeFalse();
        }

        [Test]
        public void TestWhenTrueWhenNot()
        {
            int i = 0;
            var ret = 1;

            i = ret.When(i == 0);
            i.Should().Be(ret);

            i = 1;
            ret = 0;
            var other = 2;

            i = ret.When(i == 0).WhenNot(other);
            i.Should().NotBe(1);
            i.Should().NotBe(ret);
            i.Should().Be(other);
        }
    }
}
