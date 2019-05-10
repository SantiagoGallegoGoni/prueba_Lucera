using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{

    //TODO: Abstraer los metodos que serian equivalentes en todas las clases de este tipo
    public class MorseCodeHelper : CodeInterface
    {
        private Dictionary<char, string> morseCodification = new Dictionary<char, string>();
        private readonly List<char> origin;
        private readonly List<string> codification;

        /// <summary>
        /// Inicializa la codificación
        /// </summary>
        public MorseCodeHelper()
        {
            origin = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }.ToList();
            codification = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." }.ToList();
        }

        /// <summary>
        /// Decodifica una cadena codificada solo si tiene coincidencia exacta con un caracter
        /// </summary>
        /// <param name="word">cadena codificada</param>
        /// <returns></returns>
        public char Decode(string word)
        {
            try
            {
                int index = codification.IndexOf(word);
                return origin[index];
            }
            catch
            {
                return char.MinValue;
            }
        }

        /// <summary>
        /// Decodifica una cadena codificada
        /// </summary>
        /// <param name="word">cadena codificada</param>
        /// <returns></returns>
        public string DecodeWord(string word)
        {
            return codification.Find(x => x == word);
        }

        /// <summary>
        /// Codifica un caracter
        /// </summary>
        /// <param name="letter">caracter a codificar</param>
        /// <returns></returns>
        public string Encode(char letter)
        {
            int index = origin.IndexOf(letter);
            return codification[index];
        }

        /// <summary>
        /// Codifica una palabra
        /// </summary>
        /// <param name="word">palabra a codificar</param>
        /// <returns></returns>
        public string EncodeWord(string word)
        {
            string result = "";
            List<char> listChar = word.ToList();
            foreach (char caracter in listChar)
            {
                string caracterEncoded = Encode(caracter);
                result += caracterEncoded;
            }
            return result;
        }
    }
}
