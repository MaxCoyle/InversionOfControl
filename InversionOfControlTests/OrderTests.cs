using InversionOfControlDemo;
using NUnit.Framework;

namespace InversionOfControlTests
{
    [TestFixture]
    public class SaverTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        // ReSharper disable once InconsistentNaming
        private OrderService CreateSUT(IOrderSaver orderSaver)
        {
            return new OrderService(orderSaver);
        }

        [TestCase("The Last Jedi - Star Wars #8", "201701-UK", 1)]
        [TestCase("Peaky Blinders #4", "201702-UK", 2)]
        public void TestSaveToDatabaseSuccess(string description, string referenceNumber, int quantity)
        {
            var orderDatabase = new OrderDatabase();
            var sut = CreateSUT(orderDatabase);
            var response = sut.AcceptOrder(new Order(description, referenceNumber, quantity));
            Assert.IsTrue(response);
        }

        [Test]
        public void TestSaveToDatabaseFailure()
        {
            var orderDatabase = new OrderDatabase();
            var sut = CreateSUT(orderDatabase);
            var response = sut.AcceptOrder(null);
            Assert.IsFalse(response);
        }

        [TestCase("The Shape of Water", "201703-UK", 3)]
        [TestCase("Persepolis Rising - The expanse #7", "201704-UK", 4)]
        public void TestSaveToXmlSuccess(string description, string referenceNumber, int quantity)
        {
            var xmlOrderSaver = new XmlOrderSaver();
            var sut = CreateSUT(xmlOrderSaver);
            var response = sut.AcceptOrder(new Order(description, referenceNumber, quantity));
            Assert.IsTrue(response);
        }

        [Test]
        public void TestSaveToXmlFailure()
        {
            var xmlOrderSaver = new XmlOrderSaver();
            var sut = CreateSUT(xmlOrderSaver);
            var response = sut.AcceptOrder(null);
            Assert.IsFalse(response);
        }
    }
}
