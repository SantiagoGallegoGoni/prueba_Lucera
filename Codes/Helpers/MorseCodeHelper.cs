using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{

    //TODO: Abstraer los metodos que serian equivalentes en todas las clases de este tipo
    public class MorseCodeHelper : ICodeHelperInterface
    {
        private readonly List<char> original;
        private readonly List<string> codification;
        private readonly List<string> codificationOrdenada;

        /// <summary>
        /// Inicializa la codificación
        /// </summary>
        public MorseCodeHelper()
        {
            original = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }.ToList();
            codification = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." }.ToList();
            codificationOrdenada = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." }.OrderBy(x => x.Length).ToList();
        }

        
        public char Decode(string word) 
        {
            try
            {
                int index = codification.IndexOf(word);
                return original[index];
            }
            catch
            {
                return char.MinValue;
            }
        }

     
        public List<string> DecodeWord(string word)
        {
            string resultado = "";
            List<string> resultadoLista = new List<string>();

            //Obtengo una lista de todas aquellas letras que serían válidas para el inicio de word, empezando por las mas cortas
            int i = 0;
            foreach (string itemCodificado in codificationOrdenada)
            {
                if (word.StartsWith(itemCodificado))
                {
                    char caracterDecodificado = Decode(itemCodificado);
                    resultado = caracterDecodificado.ToString();
                                                                                                                                                
                    string wordReducida = word.Substring(itemCodificado.Length);//le quito a la cadena el caracter decodificado
                    if(wordReducida.Length == 0)//terminé
                    {
                        resultadoLista.Add(resultado);
                        return resultadoLista;
                    }
                    //Concateno la siguiente codificación encontrada
                    foreach (string resultadoVariacion in DecodeWord(wordReducida))
                    {
                        resultadoLista.Add(resultado+resultadoVariacion); //Agrego el caracter a la posible solucion
                    }
                    
                }
                i++;
            }
            return resultadoLista;
        }

        public List<char> DecodeWordDictionary(string sentence, Dictionary<string, string> dictionary)
        {
            List<char> resultado = new List<char>();

            //Obtengo una lista de palabras en el diccionario que serían válidas para el inicio de sentence


            return resultado;
        }

       
        public string Encode(char letter)
        {
            int index = original.IndexOf(letter);
            return codification[index];
        }

        
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
