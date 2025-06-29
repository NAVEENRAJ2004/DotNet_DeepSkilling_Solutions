using CustomerCommLib;

using Moq;
using NUnit.Framework;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_CallsSendMail_ReturnsTrue()
        {
            _mockMailSender.Setup(ms => ms.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var result = _customerComm.SendMailToCustomer();

            Assert.That(result, Is.True);
            _mockMailSender.Verify(ms => ms.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
