using NUnit.Framework;
using WeatherStackLibrary.Model;
using WeatherStackLibrary.Process;
using System.Collections.Generic;

namespace SimpleUnitTest
{
    public class PositiveOutcomeTest
    {
        private IWeatherModel data;
        [SetUp]
        public void Setup()
        {
            data = new WeatherModel();
            data.Wind_Speed = "16";
            data.UV_Index = "4";
            data.Weather_Descriptions = new List<string>(){ "sunny"};
        }

        [Test]
        public void CanGoOut()
        {
            //arrange

            //act
            IResponse goOUT = new CanGoOutside();
            string actual = goOUT.Respond(data);
            string expected = "Yes, It is not raining.";

            //assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CanWearSunscreen()
        {
            //act
            IResponse goOUT = new CanWearSunscreen();
            string actual = goOUT.Respond(data);
            string expected = "Yes, you should wear sunscreen.";

            //assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void CanFlyKite()
        {
            //act
            IResponse goOUT = new CanFlyKite();
            string actual = goOUT.Respond(data);
            string expected = "Yes, It is perfect weather condition to fly kite.";

            //assert
            Assert.AreEqual(actual, expected);
        }



    }
}