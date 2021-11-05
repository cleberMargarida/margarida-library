using NUnit.Framework;
using FluentAssertions;
using Margarida.Util.Linq;
using Margarida.Util.Convert;
using Margarida.Util.String;

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
            public CopiedStructLvl2 Lvl2 { get; set; }

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
                Integer = 1, Phrase = "phrase...", 
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
                Integer = "NotInteger", Phrase = "phrase...",
                Lvl2 = new { Integer = "NotInteger", Phrase = "phrase...2" }
            };

            var copied = source.Copy<SomeStruct>();

            copied.Should()
                .BeEquivalentTo(source, options => options
                    .Excluding(a => a.Integer)
                    .Excluding(a => a.Lvl2.Integer));

            copied.Integer.Should().Be(0);
            copied.Lvl2.Integer.Should().Be(0);
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
            copied.Lvl2.Integer.Should().Be(0);
        }

        [Test]
        public void TestUnescapString()
        {
            const string source = "123\\t\\b\\\t\\\"";
            const string expected = "123\t\b\t\"";

            source.Unescape().Should().Be(expected);
        }
    }
}