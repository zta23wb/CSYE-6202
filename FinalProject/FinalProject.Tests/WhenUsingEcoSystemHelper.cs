using EcoSystemClassLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Tests
{
    [TestFixture]
    public class WhenUsingEcoSystemHelper
    {
        [Test]
        public void IsThreeFieldsIsFilled_AllBlank_ShouldPass()
        {
            //arrange
            string a = string.Empty;
            string b = string.Empty;
            string c = string.Empty;
            bool expected = false;
            //act
            var actual = EcoSystemHelper.IsThreeFieldsFilled(a, b, c);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void IfInputIsLegitBirthDate_CorrectDate_ShouldPass()
        {
            
            string birthDate = "1/1/1993";
            bool expected = true;
            var actual = EcoSystemHelper.IfInputIsLegitBirthDate(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IfInputIsLegitBirthDate_WrongDate_ShouldNotPass()
        {

            string birthDate = "1993/1993/1993";
            bool expected = false;
            var actual = EcoSystemHelper.IfInputIsLegitBirthDate(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void IfInputIsLegitBirthDate_FutureDate_ShouldNotPass()
        {

            string birthDate = "1/1/2017";
            bool expected = false;
            var actual = EcoSystemHelper.IfInputIsLegitBirthDate(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateAge_PastDate_ShouldPass()
        {

            string birthDateString = "1/1/1993";
            DateTime birthDate = DateTime.Parse(birthDateString);
            int expected = 22;
            var actual = EcoSystemHelper.CalculateAge(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateAge_CurrentDate_ShouldPass()
        {

            //string birthDateString = "1/1/1993";
            DateTime birthDate = DateTime.Now;
            int expected = 0;
            var actual = EcoSystemHelper.CalculateAge(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateAge_FutureDate_ShouldNotPass()
        {

            string birthDateString = "1/1/2017";
            DateTime birthDate = DateTime.Parse(birthDateString);
            int expected = -2;
            var actual = EcoSystemHelper.CalculateAge(birthDate);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
