using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class BaseCodeController
    {
        protected CodeInterface codification;
        protected Dictionary<string,string> dictionary = new Dictionary<string, string>();

        public string sentence { get; internal set; }

        public BaseCodeController()
        {
            this.codification = null;
            this.dictionary = null;
            this.sentence = null;
        }

        /// <summary>
        /// Indica el tipo de codificacion
        /// </summary>
        /// <param name="code">Values: Morse</param>
        public void setCodificacion(string code)
        {
            switch (code)
            {
                case "Morse":
                    codification = new MorseCodeHelper();
                    break;
                default:
                    //TODO: Valor por defecto
                    break;
            }
        }

        /// <summary>
        /// Crea el diccionario con las palabras más comunes
        /// </summary>
        /// <param name="input">Un string con las palabras separadas por salto de linea</param>
        public void setDictionary(string input) //TODO: Hacer que el separador se pase y sea dinámico
        {
            List<string> inputSeparated = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string word in inputSeparated)
            {
                codification.EncodeWord(word);
            }
        }

    }
}
