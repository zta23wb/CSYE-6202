using EcoSystemLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Tests
{
    [TestFixture]
    public class WhenUsingEcoSystem
    {
        [Test]
        public void SearchEnterprisedByGivenID_NOTValidID_ShouldReturnNull()
        {
            //arrange
            EnterpriseDirectory eD = new EnterpriseDirectory();
            Enterprise enterprise = eD.AddEnterprise();
            enterprise.EnterpriseID = 1;
            Enterprise expected = null;
            //act
            var actual = eD.SearchEnterprise(0);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void SearchEnterprisedByGivenID_ValidID_ShouldReturnEnterprise()
        {
            //arrange
            EnterpriseDirectory eD = new EnterpriseDirectory();
            Enterprise enterprise = eD.AddEnterprise();
            enterprise.EnterpriseID = 1;
            Enterprise expected = enterprise;
            //act
            var actual = eD.SearchEnterprise(1);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void IUserfNameIsUnique_UniqueName_ShouldReturnTrue()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.Username = "One";
            string name = "two";
            bool expected = true; 
            //act
            var actual = ud.IfUsernameIsUnique(name);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void IUserfNameIsUnique_NotUniqueName_ShouldReturnFalse()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.Username = "One";
            string name = "One";
            bool expected = false;
            //act
            var actual = ud.IfUsernameIsUnique(name);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void AuthenticaUser_ValidInfo_ShouldReturnUseAccount()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.Username = "1";
            ua.Password = "-1";
            UserAccount expected = ua;
            //act
            var actual = ud.AuthenticateUser(ua.Username, ua.Password);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void AuthenticaUser_NotValidInfo_ShouldReturnNull()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.Username = "1";
            ua.Password = "-1";
            UserAccount expected = null;
            //act
            var actual = ud.AuthenticateUser("22", "33");
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void SearchUserByGivenID_ValidInformation_ShouldReturnUserAccount()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.UserAccountID = 1;
            UserAccount expected = ua;
            //act
            var actual = ud.SearchUser(ua.UserAccountID);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void SearchUserByGivenID_ValidInformation_ShouldReturnUserNull()
        {
            //arrange
            UserAccountDirectory ud = new UserAccountDirectory();
            UserAccount ua = ud.AddUserAccount();
            ua.UserAccountID = 1;
            UserAccount expected = null;
            //act
            var actual = ud.SearchUser(0);
            //assert
            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void SearchAppointmentByGivenID_ValidInformation_ShouldReturnAppointment()
        {
            AppointmentQueue aq = new AppointmentQueue();
            Appointment a = aq.AddAppointment();
            a.AppointmentID = 1;
            var expected = a;

            var actual = aq.SearchAppointment(expected.AppointmentID);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SearchAppointmentByGivenID_NotVaIidInformation_ShouldReturnNull()
        {
            AppointmentQueue aq = new AppointmentQueue();
            Appointment a = aq.AddAppointment();
            a.AppointmentID = 1;
            Appointment expected = null;

            var actual = aq.SearchAppointment(2);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
