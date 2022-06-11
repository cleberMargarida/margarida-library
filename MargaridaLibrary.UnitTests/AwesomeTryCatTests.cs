using Margarida.Util.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Margarida.UnitTests
{
    [TestFixture]
    internal class AwesomeTryCatTests
    {
        [Test]
        public void TestTryCatNone()
        {
            Helper.Ex.Try(DoSomeElse)
                     //.IgnoreFails()
                     //.CatchType<NotImplementedException>(TreatmentEx).On(x => x.Following(x => x.Message != string.Empty))
                     .Catch(Treatment).On(x => x.OfType<NotImplementedException>())
                     //.Attempts(1)
                     //.Finally(() => { })
                     .Fire();
        }

        private void DoSomeElse()
        {
            throw new NotImplementedException();
        }

        public void Treatment()
        {
        }

        public void TreatmentEx(NotImplementedException ex)
        {
        }
    }
}
