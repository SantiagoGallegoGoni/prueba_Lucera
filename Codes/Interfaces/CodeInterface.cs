using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    /// <summary>
    /// Interfaz que todo helper de cualquier codificación debe de cumplir
    /// </summary>
    interface ICodeHelperInterface
    {
        /// <summary>
        /// Decodifica una cadena codificada solo si tiene coincidencia exacta con un caracter
        /// </summary>
        /// <param name="word">cadena codificada</param>
        /// <returns></returns>
        char Decode(string word);

        /// <summary>
        /// Codifica un caracter
        /// </summary>
        /// <param name="letter">caracter a codificar</param>
        /// <returns></returns>
        string Encode(char letter);

        /// <summary>
        /// Decodifica una cadena codificada
        /// </summary>
        /// <param name="word">cadena codificada</param>
        /// <returns></returns>
        List<string> DecodeWord(string word);

        /// <summary>
        /// Codifica una palabra
        /// </summary>
        /// <param name="word">palabra a codificar</param>
        /// <returns></returns>
        string EncodeWord(string word);

        /// <summary>
        /// Decodifica una cadena codificada con el uso de un diccionario
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        List<char> DecodeWordDictionary(string sentence, Dictionary<string, string> dictionary);
    }
}
