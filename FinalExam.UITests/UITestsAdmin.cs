using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UITests
{
    public class UITestsAdmin : TestFixture
    {
        [Test]
        public void VerifyLogin()
        {
            LoginAsAdmin().
                userNameText.Text.Should().Equals("Super Admin");
        }

        [Test]
        public void TableTest()
        {
            LoginAsAdmin().
                GoToHotelsPage().
                    HotelsTable.Rows.Count().Should().Equals(12);
        }
    }
}
