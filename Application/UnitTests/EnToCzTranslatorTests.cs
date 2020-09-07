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
    class EnToCzTranslatorTests
    {
        [TestCase("Warning", "Varovani")]
        [TestCase("Thanks", "Podekovani")]
        [TestCase("Error", "Chyba")]
        [TestCase("SUBJECT: Warning | CONTENT: This is email of type: \"Warning\".", "SUBJECT: Varovani | CONTENT: Tohle je email typu: \"Varovani\".")]
        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase("Uz prelozeny text", "Uz prelozeny text")]
        [TestCase("123", "123")]
        [TestCase("Dľžne a mäkčene", "Dľžne a mäkčene")]
        [TestCase("!@#-+*/", "!@#-+*/")]
        public void Test_Translate_HasExpectedOutput(string input, string espectedOutput)
        {
            // given
            var czTranslator = new EnToCzTranslator();

            // when
            string testString = czTranslator.Translate(input);

            // then
            Assert.AreEqual(espectedOutput, testString);
        }
    }
}
