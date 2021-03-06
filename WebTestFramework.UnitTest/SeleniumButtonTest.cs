﻿using System;
using Moq;
using NUnit.Framework;
using Selenium;
using WebTestFramework.Selenium;

namespace WebTestFramework.UnitTest
{
    [TestFixture]
	public class SeleniumButtonTest : SeleniumControlTest
    {
        private IButton _button;

        [SetUp]
        public void Setup()
        {
            _button = Driver.CreateButton(ControlID);
        }

        [Test]
        public void ClickCallsSeleniumClick()
        {
            // Setup
            SeleniumMock.Setup(x => x.Click(ControlLocator));

            // Excercise
            _button.Click();

            // Validate
            SeleniumMock.Verify();
        }

        [Test]
        public void ClickAndWait()
        {
            // Setup
            SeleniumMock.Setup(x => x.Click(ControlLocator));
            SeleniumMock.Setup(x => x.WaitForPageToLoad(It.IsAny<string>()));

            // Exercise
            _button.ClickAndWait();

            // Validate
            SeleniumMock.VerifyAll();
        }
    }

	[TestFixture]
	public class CreateSeleniumButtonTest
	{
		private  Mock<ISelenium> _seleniumMock;
		private  SeleniumDriver _driver;

		[SetUp]
		public void Setup()
		{
			_seleniumMock = new Mock<ISelenium>(MockBehavior.Strict);
			_driver = new SeleniumDriver(_seleniumMock.Object);
		}

		private void AssertLocatorIs(IButton button, string expectedLocator)
		{
			if (expectedLocator == null) throw new ArgumentNullException("expectedLocator");
			string actualLocator = null;
			_seleniumMock
				.Setup(x => x.Click(It.IsAny<string>()))
				.Callback<string>(s => actualLocator = s);
			button.Click();
			Assert.That(actualLocator, Is.Not.Null, "Guard");
			Assert.That(actualLocator, Is.EqualTo(expectedLocator));
		}

		[Test]
		public void CreateFromIDDirect()
		{
			var button = _driver.CreateButton("locator");
			AssertLocatorIs(button, "id=locator");
		}

		[Test]
		public void CreateFromID()
		{
			var button = _driver.CreateButton().FromID("locator");
			AssertLocatorIs(button, "id=locator");
		}

		[Test]
		public void CreateFromName()
		{
			var button = _driver.CreateButton().FromName("locator");
			AssertLocatorIs(button, "name=locator");
		}
	}
}
