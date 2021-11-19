using NUnit.Framework;
using FluentAssertions;
using Margarida.Util.Linq;
using Margarida.Util.Convert;
using Margarida.Util.String;
using System.Collections.Generic;
using Margarida.Util.Type;
using Margarida.Util.Json;
using Margarida.Util.Decimal;

namespace Margarida.UnitTests
{
    [TestFixture]
    public class UtilitiesUnitTests
    {
        #region Internal Classes
        internal struct SomeStruct
        {
            internal struct CopiedStructLvl2
            {
                public string Phrase { get; set; }
                public int Integer { get; set; }
            }

            public int Integer { get; set; }
            public string Phrase { get; set; }
            public CopiedStructLvl2? Lvl2 { get; set; }

            public static SomeStruct Gen()
            {
                return new SomeStruct
                {
                    Integer = 1,
                    Phrase = "phrase...",
                    Lvl2 = new CopiedStructLvl2
                    {
                        Integer = 2,
                        Phrase = "phrase...2"
                    }
                };
            }

        }
        #endregion

        [Test]
        public void TestCorrectStringToInt()
        {
            const string source = "123";
            const int expected = 123;

            source.ToInt().Should().Be(expected);
        }

        [Test]
        public void TestNotCorrectStringToInt()
        {
            const string source = "@#$";
            const int expected = 0;

            source.ToInt().Should().Be(expected);
        }

        [Test]
        public void TestCloneSucessfully()
        {
            var source = SomeStruct.Gen();
            var copied = source.Clone();

            copied.Should().BeEquivalentTo(source);
        }

        [Test]
        public void TestCopySucessfully()
        {
            var source = new
            {
                Integer = 1,
                Phrase = "phrase...",
                Lvl2 = new { Integer = 2, Phrase = "phrase...2" }
            };

            var copied = source.Copy<SomeStruct>();

            copied.Should().BeEquivalentTo(source);
        }

        [Test]
        public void TestCopyMembersWithDiffTypes()
        {
            var source = new
            {
                Integer = "NotInteger",
                Phrase = "phrase...",
                Lvl2 = new { Integer = "NotInteger", Phrase = "phrase...2" }
            };

            var copied = source.Copy<SomeStruct>();

            copied.Should()
                .BeEquivalentTo(source, options => options
                    .Excluding(a => a.Integer)
                    .Excluding(a => a.Lvl2.Integer));

            copied.Integer.Should().Be(0);
            copied.Lvl2.GetValueOrDefault().Integer.Should().Be(0);
        }

        [Test]
        public void TestCopyMembersWithNull()
        {
            var source = new
            {
                Integer = "null",
                Lvl2 = new { Integer = "null", Phrase = "null" }
            };

            var copied = source.Copy<SomeStruct>();

            copied.Should()
                .BeEquivalentTo(source, options => options
                    .Excluding(a => a.Integer)
                    .Excluding(a => a.Lvl2.Integer));

            copied.Integer.Should().Be(0);
            copied.Lvl2.GetValueOrDefault().Integer.Should().Be(0);
        }

        [Test]
        public void TestUnescapString()
        {
            const string source = "123\\t\\b\\\t\\\"";
            const string expected = "123\t\b\t\"";

            source.Unescape().Should().Be(expected);
        }

        [Test]
        public void TestMethodHasValue()
        {
            var complexListWithValue = new[] { SomeStruct.Gen(), SomeStruct.Gen() };
            List<SomeStruct> complexListWithoutValue = new();
            List<SomeStruct>? complexListNull = null;
            var complexWithValue = SomeStruct.Gen();
            var complexWithValueAndAttNule = SomeStruct.Gen().Inner(x => x.Lvl2 = null);
            string stringWithValue = "abc";
            string stringWithoutValue = "";
            int intWithValue = 1;
            int intWithoutValue = 0;
            long longWithValue = 1;
            long longWithoutValue = 0;

            Assert.IsTrue(complexListWithValue.HasValue(), "Assert of complex list with values has failed.");
            Assert.IsTrue(complexWithValue.HasValue(), "Assert of complex object with values has failed.");
            Assert.IsTrue(complexWithValueAndAttNule.HasValue(), "Assert of complex object with values and atributte null has failed.");
            Assert.IsTrue(stringWithValue.HasValue(), "Assert of string with values has failed.");
            Assert.IsTrue(intWithValue.HasValue(), "Assert of int with values has failed.");
            Assert.IsTrue(longWithValue.HasValue(), "Assert of long with values has failed.");
            Assert.IsFalse(complexListNull.HasValue(), "Assert of complex list null has failed.");
            Assert.IsFalse(complexListWithoutValue.HasValue(), "Assert of complex list without values has failed.");
            Assert.IsFalse(stringWithoutValue.HasValue(), "Assert of string empty has failed.");
            Assert.IsFalse(intWithoutValue.HasValue(), "Assert of int without values has failed.");
            Assert.IsFalse(longWithoutValue.HasValue(), "Assert of long without values has failed.");
        }

        [Test]
        public void TestRandomNumber()
        {
            NumberExt.RandomNumber.Should().BePositive();
            NumberExt.RandomNumber.Should().BeGreaterThanOrEqualTo(0);
        }
    }
}
