using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class MorseCodeHelper : CodeInterface
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
        /// Decodifica una cadena codificada
        /// </summary>
        /// <param name="word">cadena codificada</param>
        /// <returns></returns>
        public string Decode(string word)
        {
            return codification.Find(x => x == word);
        }

        /// <summary>
        /// Codifica una caracter
        /// </summary>
        /// <param name="letter">caracter a codificar</param>
        /// <returns></returns>
        public char Encode(char letter)
        {
            return origin.Find(x => x == letter);
        }
    }
}
