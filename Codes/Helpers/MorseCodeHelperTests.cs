using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prueba_Lucera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera.Tests
{
    [TestClass()]
    public class MorseCodeHelperTests
    {
        [TestMethod()]
        public void DecodeTest()
        {
            string original = "..-.";
            char esperado = 'F';

            var morse = new MorseCodeHelper();

            char resultado = morse.Decode(original);
            Assert.AreEqual(esperado, resultado);

            original = "-";
            esperado = 'T';

            resultado = morse.Decode(original);
            Assert.AreEqual(esperado, resultado);

            original = "-.";
            esperado = 'T';

            resultado = morse.Decode(original);
            Assert.AreNotEqual(esperado, resultado);
        }

        [TestMethod()]
        public void EncodeTest()
        {
            char original = 'F';
            string esperado = "..-.";

            var morse = new MorseCodeHelper();

            string resultado = morse.Encode(original);
            Assert.AreEqual(esperado, resultado);

            original = 'T';
            esperado = "-";

            resultado = morse.Encode(original);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void EncodeWordTest()
        {
            string original = "HOLAMUNDO";
            string esperado = "....---.-...---..--.-..---";

            var morse = new MorseCodeHelper();

            string resultado = morse.EncodeWord(original);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void EncodeWordTest2()
        {
            string original = "HOLA";
            string esperado = "....---.-...-";

            var morse = new MorseCodeHelper();

            string resultado = morse.EncodeWord(original);
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        public void DecodeWordTest()
        {
            string original = "-.-";
            List<string> esperado = new List<string>();
            esperado.Add("TET");
            esperado.Add("TA");
            esperado.Add("NT");
            esperado.Add("K");

            var morse = new MorseCodeHelper();

            List<string> resultado = morse.DecodeWord(original);

            Assert.IsTrue(resultado.Contains("TET"));
            Assert.IsTrue(resultado.Contains("TA"));
            Assert.IsTrue(resultado.Contains("NT"));
            Assert.IsTrue(resultado.Contains("K"));
            Assert.AreEqual(resultado.Count, 4);

        }

        [TestMethod()]
        public void DecodeWordTest2()
        {
            string original = "....---.-...-";
            string esperado = "HOLA";

            var morse = new MorseCodeHelper();

            List<string> resultado = morse.DecodeWord(original);

            Assert.IsTrue(resultado.Contains(esperado));

            original = "....--.-..";
            esperado = "SANTI";

            resultado = morse.DecodeWord(original);

            Assert.IsTrue(resultado.Contains(esperado));

        }
    }
}