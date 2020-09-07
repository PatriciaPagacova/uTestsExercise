using Application;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    class EmailSenderTests
    {
        [TestCase(EmailTypes.Warning)]
        [TestCase(EmailTypes.Thanks)]
        [TestCase(EmailTypes.Error)]
        public void Test_SendEmail_CallsEmailContentCreatorWithRightEmailType(EmailTypes emailTypes)
        {
            // given
            Mock<IEmailContentCreator> emailContentCreatorMock = new Mock<IEmailContentCreator>();
            Mock<IEmailSendingService> emailSendingServiceMock = new Mock<IEmailSendingService>();
            var emailSender = new EmailSender(emailContentCreatorMock.Object, emailSendingServiceMock.Object);
            ITranslator translator = Mock.Of<ITranslator>();

            // when
            emailSender.SendEmail(emailTypes, translator);

            // then
            emailContentCreatorMock.Verify(_ => _.GetEmailContent(It.Is<EmailTypes>(x => x == emailTypes)));
        }

        [Test]
        public void Test_SendEmail_CallsTranslatorWithContentCreatorOutput()
        {
            // given
            string emailContent = "anyEmailContent";
            Mock<IEmailContentCreator> emailContentCreatorMock = new Mock<IEmailContentCreator>();
            Mock<IEmailSendingService> emailSendingServiceMock = new Mock<IEmailSendingService>();
            var emailSender = new EmailSender(emailContentCreatorMock.Object, emailSendingServiceMock.Object);
            ITranslator translator = Mock.Of<ITranslator>();
            emailContentCreatorMock.Setup(_ => _.GetEmailContent(It.IsAny<EmailTypes>())).Returns(emailContent);

            // when
            emailSender.SendEmail(EmailTypes.Error, translator);
            
            // then
            Mock.Get(translator).Verify(_ => _.Translate(It.Is<string>(x => x == emailContent)));
        }

        [Test]
        public void Test_SendEmail_CallsEmailSendingServiceWithTranslatorOutput()
        {
            // given
            string translatedContent = "anyTranslatedContent";
            Mock<IEmailContentCreator> emailContentCreatorMock = new Mock<IEmailContentCreator>();
            Mock<IEmailSendingService> emailSendingServiceMock = new Mock<IEmailSendingService>();
            var emailSender = new EmailSender(emailContentCreatorMock.Object, emailSendingServiceMock.Object);
            ITranslator translator = Mock.Of<ITranslator>();
            Mock.Get(translator).Setup(_ => _.Translate(It.IsAny<string>())).Returns(translatedContent);

            // when
            emailSender.SendEmail(EmailTypes.Error, translator);

            // then
            emailSendingServiceMock.Verify(_=>_.Send(It.Is<string>(x => x == translatedContent)));
        }

        [Test]
        public void Test_SendEmail_ReturnBoolBasedOnEmailSendingServiceOutput([Values(true, false)] bool outputOfEmailSendingServiceSend)
        {
            // given
            Mock<IEmailSendingService> emailSendingServiceMock = new Mock<IEmailSendingService>();
            var emailSender = new EmailSender(Mock.Of<IEmailContentCreator>(), emailSendingServiceMock.Object);
            ITranslator translator = Mock.Of<ITranslator>();
            emailSendingServiceMock.Setup(_ => _.Send(It.IsAny<string>())).Returns(outputOfEmailSendingServiceSend);

            // when
            bool result = emailSender.SendEmail(EmailTypes.Error, translator);

            // then
            Assert.AreEqual(outputOfEmailSendingServiceSend, result);
        }

        [Test]
        public void Test_SendEmail_RaiseEventOnlyIfEmailWasSentSuccessfully([Values(true, false)] bool wasEmailSentSuccessfully)
        {
            // given
            bool wasEventCalled = false;
            Mock<IEmailSendingService> emailSendingServiceMock = new Mock<IEmailSendingService>();
            var emailSender = new EmailSender(Mock.Of<IEmailContentCreator>(), emailSendingServiceMock.Object);
            emailSender.EmailSent += (sender, e) => wasEventCalled = true;
            emailSendingServiceMock.Setup(_ => _.Send(It.IsAny<string>())).Returns(wasEmailSentSuccessfully);

            // when
            emailSender.SendEmail(EmailTypes.Error, Mock.Of<ITranslator>());

            // then
            Assert.AreEqual(wasEmailSentSuccessfully, wasEventCalled);
        }

    }
}
