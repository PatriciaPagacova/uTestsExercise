using Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    class EmailContentCreatorTests
    {
        [TestCase(EmailTypes.Warning)]
        [TestCase(EmailTypes.Thanks)]
        [TestCase(EmailTypes.Error)]
        public void Test_GetEmailContent_HasExpectedOutput(EmailTypes emailType)
        {
            // given
            var subject = new EmailContentCreator();

            // when
            string testString = subject.GetEmailContent(emailType);

            // then
            Assert.AreEqual($"SUBJECT: {emailType.ToString()} | CONTENT: This is email of type: \"{emailType.ToString()}\".", testString);
        }
    }
}
