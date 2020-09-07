using System;
using Application;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class EnToSkTranslatorTests
    {
        [TestCase("Error", "Chyba")]
        [TestCase("SUBJECT: Warning | CONTENT: This is email of type: \"Warning\".", "SUBJECT: Varovanie | CONTENT: Toto je email typu: \"Varovanie\".")]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Uz prelozeny text", "Uz prelozeny text")]
        [TestCase("123", "123")]
        [TestCase("Dľžne a mäkčene", "Dľžne a mäkčene")]
        [TestCase("!@#-+*/", "!@#-+*/")]
        public void Test_Translate_HasExpectedOutput(string input, string espectedOutput)
        {
            // given
            var skTranslator = new EnToSkTranslator();

            // when
            string testString = skTranslator.Translate(input);

            // then
            Assert.AreEqual(espectedOutput, testString);
        }
    }
}
