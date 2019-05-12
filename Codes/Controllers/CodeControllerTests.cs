using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prueba_Lucera;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera.Tests
{
    [TestClass()]
    public class CodeControllerTests
    {

        string ruta = "C:\\lucera\\words.txt";
        CodeController controlador = new CodeController();

        [TestMethod()]
        public void InitDictionaryTest()
        {
            
            controlador.CodificationType = "Morse";

            try
            {
                controlador.InitDictionary(ruta);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        [TestMethod()]
        public void DecryptTest()
        {
            string original  = "-.....-.-.---..--.-.-.-.--.....-....--..---.--..-...";
            string esperado = "the country has people";

            InitDictionaryTest();
            controlador.Sentence = original;

            List<string> resultado = controlador.Decrypt();

            Assert.IsTrue(resultado.Contains(esperado));

        }

        [TestMethod()]
        public void DecryptTestLucera()
        {
            string original = "--.--.---.......-.---.-.-.-..-.....--..-....-.-----..-";
            //string esperado = "thecountryhaspeople";

            InitDictionaryTest();
            controlador.Sentence = original;

            List<string> resultado = controlador.Decrypt();

            foreach (string item in resultado)
            {
                Debug.WriteLine(item);
            }

            //Assert.IsTrue(resultado.Contains(esperado));

        }
    }
}