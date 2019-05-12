using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    /// <summary>
    /// Clase controladora para cualquier tipo de código. Se llamará a su helper con sus metodos especificos según se asigne el tipo
    /// de codificación
    /// </summary>
    class CodeController
    {
        #region variables privadas
        private ICodeHelperInterface codification;
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private string sentence;
        private string codificationType;
        #endregion

        #region geters y seters 
        public string Sentence { get => sentence; set => sentence = value; }
        protected Dictionary<string, string> Dictionary { get => dictionary; set => dictionary = value; }
        /// <summary>
        /// Indica el tipo de codificacion
        /// </summary>
        public string CodificationType
        {
            get => codificationType;
            set {
                codificationType = value;
                switch (codificationType)
                {
                    case "Morse":
                        codification = new MorseCodeHelper();
                        break;
                    default:
                        //TODO: Devolver codificacion no conocida
                        break;
                }
            }
        }

        #endregion

        #region métodos públicos

        /// <summary>
        /// Constructor
        /// </summary>
        public CodeController()
        {
            this.codification = null;
            this.dictionary = null;
            this.sentence = null;
        }

        /// <summary>
        /// Crea el diccionario con las palabras más comunes
        /// </summary>
        /// <param name="input">Un string con las palabras separadas por salto de linea</param>
        public void InitDictionary(string input) //TODO: Hacer que el separador se pase y sea dinámico
        {
            List<string> inputSeparated = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string word in inputSeparated)
            {
                dictionary.Add(input, codification.EncodeWord(word));
            }
        }

        /// <summary>
        /// ecnripta una cadena
        /// </summary>
        /// <returns>cadena encriptada</returns>
        public string Encrypt()
        {
            return codification.EncodeWord(sentence);
        }

        /// <summary>
        /// Desencripta la cadena y devuelve un listado con las posibilidades
        /// </summary>
        /// <returns></returns>
        public List<string> Decrypt()
        {
            if (codification == null)
            {
                throw new NullReferenceException("Debe de asignar una codificación");
            }
            else if (sentence == null)
            {
                throw new NullReferenceException("Debe de asignar una frase a decodificar");
            }
            else
            {
                List<string> result = new List<string>();
                if (dictionary != null) //con diccionario
                {
                    //result = codification.DecodeWordDictionary(sentence, dictionary);
                }
                else //sin diccionario
                {
                    //result = codification.DecodeWord(sentence);
                }

                return result;
            }
        }

        #endregion
    }
}
