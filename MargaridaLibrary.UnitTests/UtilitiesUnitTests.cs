using System.Collections.Generic;
using FluentAssertions;
using Margarida.Util.Expressions;
using Margarida.Util.Convert;
using Margarida.Util.String;
using Margarida.Util.Type;
using Margarida.Util.Json;
using Margarida.Util.Number;
using NUnit.Framework;
using System;
using Margarida.Util.Bool;
using System.Linq;
using Margarida.Util.Enum;
using System.Linq.Expressions;

namespace Margarida.UnitTests
{
    [TestFixture]
    public class UtilitiesUnitTests
    {
        #region Internal Classes
        public enum SomeEnum
        {
            [Util.Attributes.Description("value 1")]
            val1 = 1, 
            
            val2 = 2
        }

        public struct SomeStruct
        {
            public struct CopiedStructLvl2
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
        public void TestHasValue_complexListWithValue()
        {
            var complexListWithValue = new[] { SomeStruct.Gen(), SomeStruct.Gen() };
            Assert.IsTrue(complexListWithValue.HasValue(), "Assert of complex list with values has failed.");
        }

        [Test]
        public void TestHasValue_complexListWithoutValue()
        {
            List<SomeStruct> complexListWithoutValue = new();
            Assert.IsFalse(complexListWithoutValue.HasValue(), "Assert of complex list without values has failed.");
        }

        [Test]
        public void TestHasValue_complexListNull()
        {
            List<SomeStruct>? complexListNull = null;
            Assert.IsFalse(complexListNull.HasValue(), "Assert of complex list null has failed.");
        }

        [Test]
        public void TestHasValue_complexWithValue()
        {
            var complexWithValue = SomeStruct.Gen();
            Assert.IsTrue(complexWithValue.HasValue(), "Assert of complex object with values has failed.");
        }

        [Test]
        public void TestHasValue_complexWithValueAndAttNule()
        {
            var complexWithValueAndAttNule = SomeStruct.Gen().Inner(x => x.Lvl2 = null);
            Assert.IsTrue(complexWithValueAndAttNule.HasValue(), "Assert of complex object with values and atributte null has failed.");
        }

        [Test]
        public void TestHasValue_stringWithValue()
        {
            string stringWithValue = "abc";
            Assert.IsTrue(stringWithValue.HasValue(), "Assert of string with values has failed.");
        }

        [Test]
        public void TestHasValue_stringWithoutValue()
        {
            string stringWithoutValue = "";
            Assert.IsFalse(stringWithoutValue.HasValue(), "Assert of string empty has failed.");
        }

        [Test]
        public void TestHasValue_intWithValue()
        {
            int intWithValue = 1;
            Assert.IsTrue(intWithValue.HasValue(), "Assert of int with values has failed.");
        }

        [Test]
        public void TestHasValue_intWithoutValue()
        {
            int intWithoutValue = 0;
            Assert.IsFalse(intWithoutValue.HasValue(), "Assert of int without values has failed.");
        }

        [Test]
        public void TestHasValue_longWithValue()
        {
            long longWithValue = 1;
            Assert.IsTrue(longWithValue.HasValue(), "Assert of long with values has failed.");
        }

        [Test]
        public void TestHasValue_longWithoutValue()
        {
            long longWithoutValue = 0;
            Assert.IsFalse(longWithoutValue.HasValue(), "Assert of long without values has failed.");
        }

        [Test]
        public void TestRandomNumber()
        {
            NumberExt.RandomNumber().Should().BePositive();
            NumberExt.RandomNumber().Should().BeGreaterThanOrEqualTo(0);
        }

        [Test]
        public void TestSetDateTimeFrom_yyyymmddWithSlash()
        {
            DateTime dateTime = new DateTime(), expect = new DateTime(2021, 01, 01);
            string dtString = "2021/01/01", format = "yyyy/mm/dd";

            dateTime.SetDateTimeFrom(dtString)
                .Should().Be(expect);

            dateTime.SetDateTimeFrom(dtString, format)
                .Should().Be(expect);
        }

        [Test]
        public void TestSetDateTimeFrom_yyyymmddWithHyphen()
        {
            DateTime dateTime = new DateTime(), expect = new DateTime(2021, 01, 01);
            string dtString = "2021-01-01", format = "yyyy-mm-dd";

            dateTime.SetDateTimeFrom(dtString)
                .Should().Be(expect);

            dateTime.SetDateTimeFrom(dtString, format)
                .Should().Be(expect);
        }

        [Test]
        public void TestValidatorJson()
        {
            var jsonInvalid = 
            @"{
                id : 1,
                x
            }";

            jsonInvalid.IsValid().Should().BeFalse();

            var jsonValid =
            @"{
                id : 1,
            }";

            jsonValid.IsValid().Should().BeFalse();
        }
    }
}