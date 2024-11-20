using System;
using Lab2_Pt2.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2_Pt2.Tests.model
{
    [TestClass]
    public class PublisherTests
    {
        [TestMethod]
        public void PublisherBuilder_WithValidName_CreatesPublisher()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            Assert.AreEqual("Test Publisher", publisher.Name);
        }

        [TestMethod]
        public void PublisherBuilder_WithInvalidName_ThrowsException()
        {
            var builder = new Publisher.Builder();
            Assert.ThrowsException<ValidationNotBlankException>(() => builder.WithName(""));
        }

        [TestMethod]
        public void PublisherBuilder_WithNullName_ThrowsException()
        {
            var builder = new Publisher.Builder();
            Assert.ThrowsException<NullReferenceException>(() => builder.WithName(null));
        }

        [TestMethod]
        public void Publisher_ToString_ReturnsExpectedFormat()
        {
            var publisher = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var result = publisher.ToString();

            Assert.AreEqual("[Type: Publisher, Name: Test Publisher", result);
        }

        [TestMethod]
        public void Publisher_Equals_WithSameName_ReturnsTrue()
        {
            var publisher1 = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var publisher2 = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            Assert.IsTrue(publisher1.Equals(publisher2));
        }

        [TestMethod]
        public void Publisher_Equals_WithDifferentNames_ReturnsFalse()
        {
            var publisher1 = new Publisher.Builder()
                .WithName("Publisher One")
                .Build();

            var publisher2 = new Publisher.Builder()
                .WithName("Publisher Two")
                .Build();

            Assert.IsFalse(publisher1.Equals(publisher2));
        }

        [TestMethod]
        public void Publisher_GetHashCode_WithSameName_ReturnsSameHash()
        {
            var publisher1 = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            var publisher2 = new Publisher.Builder()
                .WithName("Test Publisher")
                .Build();

            Assert.AreEqual(publisher1.GetHashCode(), publisher2.GetHashCode());
        }

        [TestMethod]
        public void Publisher_GetHashCode_WithDifferentNames_ReturnsDifferentHashes()
        {
            var publisher1 = new Publisher.Builder()
                .WithName("Publisher One")
                .Build();

            var publisher2 = new Publisher.Builder()
                .WithName("Publisher Two")
                .Build();

            Assert.AreNotEqual(publisher1.GetHashCode(), publisher2.GetHashCode());
        }
    }
}