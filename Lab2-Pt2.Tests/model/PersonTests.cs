using System;
using Lab2_Pt2.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests.model
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void PersonBuilder_WithValidData_CreatesPerson()
        {
            var person = new Person.Builder()
                .WithName("Test Name")
                .WithAge(30)
                .Build();

            Assert.AreEqual("Test Name", person.Name);
            Assert.AreEqual(30, person.Age);
        }

        [TestMethod]
        public void PersonBuilder_WithInvalidName_ThrowsValidationException()
        {
            var builder = new Person.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithName(""));
        }

        [TestMethod]
        public void PersonBuilder_WithInvalidAge_ThrowsValidationException()
        {
            var builder = new Person.Builder();
            Assert.ThrowsException<ValidationNotCourseInException<int>>(() => builder.WithAge(-1));
        }

        [TestMethod]
        public void PersonBuilder_WithZeroAge_ThrowsValidationException()
        {
            var builder = new Person.Builder();
            Assert.ThrowsException<ValidationNotCourseInException<int>>(() => builder.WithAge(-1));
        }

        [TestMethod]
        public void PersonBuilder_CopyConstructor_CreatesCopy()
        {
            var originalPerson = new Person.Builder()
                .WithName("Test Name")
                .WithAge(30)
                .Build();

            var copiedBuilder = new Person.Builder()
                .WithName(originalPerson.Name)
                .WithAge(originalPerson.Age);
            var copiedPerson = copiedBuilder.Build();

            Assert.AreEqual(originalPerson.Name, copiedPerson.Name);
            Assert.AreEqual(originalPerson.Age, copiedPerson.Age);
        }

        [TestMethod]
        public void Person_ToString_ReturnsExpectedFormat()
        {
            var person = new Person.Builder()
                .WithName("Test Name")
                .WithAge(30)
                .Build();

            var expected = "[Type: Person, Name: Test Name, Age: 30]";
            var result = person.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}