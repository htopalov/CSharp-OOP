namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Make", "Model");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
        }
        [TestCase(null)]
        [TestCase("")]
        public void CheckIfPropertyMakeAndModelThrowExceptionsNullValue(string value)
        {
            Assert.Throws<ArgumentException>(()=>
            {
                var phone = new Phone(value, "Model");
                var phone2 = new Phone("Make", value);
            });
        }
        [Test]
        public void CheckIfAddContactThrowsExceptionWhenContactExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Ivan", "12345");
                phone.AddContact("Ivan", "12345");
            });
        }
        [Test]
        public void CheckIfAddContactWorksCorrectly()
        {
            phone.AddContact("Todor", "1243");
            Assert.AreEqual(phone.Count, 1);
        }
        [Test]
        public void CheckIfCallMethodThrowsExceptionWhenContactDoesnExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Joro");
            });
        }
        [Test]
        public void CheckIfCallMethodReturnsCorrectly()
        {
            phone.AddContact("Dimo", "12345");
            Assert.AreEqual("Calling Dimo - 12345...", phone.Call("Dimo"));
        }
    }
}