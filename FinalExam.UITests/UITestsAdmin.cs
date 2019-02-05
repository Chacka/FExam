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
        public void HotelAddTest()
        {
            LoginAsAdmin().
                GoToHotelsPage();
                    
        }
    }
}

/*
private HotelsPage AddHotel(out string name)
{
    return Go.To<HotelsPage>().
       Add.ClickAndGo().
           HotelName.SetRandom(out name).
           HotelDescription.SetRandom(out string description).
           Location.Set("London").
           HotelType.Set("Motel").
           HotelStars.Set("3").
           IsFeatured.Set("Yes").
           From.Set(DateTime.Now).
           To.Set(DateTime.Now + TimeSpan.FromDays(3)).
           Submit();
}
*/
