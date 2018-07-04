using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplicationTest;
using NUnit.Framework;
using NUnit.Engine.Extensibility;
using TechTalk.SpecRun.Framework;

namespace UnitTestProject
{
    public class TestProject
    {

        [TestCase]
        public void ProgrammerTest()
        {
            var address = new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243");
            var person = new Person("Jane", "Smith", address);
            var biz = new Business("Alliance Reservations Network", address);

            Assert.IsNullOrEmpty(person.Id);
            person.Save();
            Assert.IsNotNullOrEmpty(person.Id);

            Assert.IsNullOrEmpty(biz.Id);
            biz.Save();
            Assert.IsNotNullOrEmpty(biz.Id);

            Person savedPerson = Person.Find(person.Id);
            Assert.IsNotNull(savedPerson);

            Assert.IsNotNull(savedPerson);
            Assert.AreSame(person.Address, address);
            Assert.AreEqual(savedPerson.Address, address);
            Assert.AreEqual(person.Id, savedPerson.Id);
            Assert.AreEqual(person.FirstName, savedPerson.FirstName);
            Assert.AreEqual(person.LastName, savedPerson.LastName);
            Assert.AreEqual(person, savedPerson);
            Assert.AreNotSame(person, savedPerson);
            Assert.AreNotSame(person.Address, savedPerson.Address);

            Business savedBusiness = Business.Find(biz.Id);
            Assert.IsNotNull(savedBusiness);
            Assert.AreSame(biz.Address, address);
            Assert.AreEqual(savedBusiness.Address, address);
            Assert.AreEqual(biz.Id, savedBusiness.Id);
            Assert.AreEqual(biz.Name, savedBusiness.Name);
            Assert.AreEqual(biz, savedBusiness);
            Assert.AreNotSame(biz, savedBusiness);
            Assert.AreNotSame(biz.Address, savedBusiness.Address);


            var dictionary = new Dictionary<object, object> { [address] = address, [person] = person, [biz] = biz };
            Assert.IsTrue(dictionary.ContainsKey(new Address("5455 Apache Trail", "Queen Creek", "AZ", "85243")));
            Assert.IsTrue(dictionary.ContainsKey(new Person("Jane", "Smith", address)));
            Assert.IsTrue(dictionary.ContainsKey(new Business("Alliance Reservations Network", address)));
            Assert.IsFalse(dictionary.ContainsKey(new Address("54553 Apache Trail", "Queen Creek", "AZ", "85243")));
            Assert.IsFalse(dictionary.ContainsKey(new Person("Jim", "Smith", address)));
            Assert.IsFalse(dictionary.ContainsKey(new Business("Alliance Reservation Networks", address)));

            var deletedPersonId = person.Id;
            person.Delete();
            //Assert.IsNullOrEmpty(person.Id);
            //Assert.IsNull(Person.Find(deletedPersonId));

            var deletedBizId = biz.Id;
            biz.Delete();
            Assert.IsNullOrEmpty(biz.Id);
            Assert.IsNull(Person.Find(deletedBizId));

        }
    }
}
