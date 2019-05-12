using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{

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

            //Obtengo una lista de todas aquellas letras que serían válidas para el inicio de word, empezando por las mas cortas para evaluar todas las opciones
            foreach (string itemCodificado in codificationOrdenada)
            {
                if (word.StartsWith(itemCodificado))
                {
                    resultado = Decode(itemCodificado).ToString();
                                                                                                                                                
                    string wordReducida = word.Substring(itemCodificado.Length);//le quito a la cadena el caracter decodificado
                    if(wordReducida.Length == 0)//nada más a decodificar, devuelvo mi resultado como una lista de un solo item
                    {
                        resultadoLista.Add(resultado);
                        return resultadoLista;
                    }
                    //Agrego a mi listado de resultados los resultados de codificar el resto de la cadena
                    foreach (string resultadoPosible in DecodeWord(wordReducida))
                    {
                        resultadoLista.Add(resultado + resultadoPosible); //Agrego el caracter a la posible solucion
                    }                    
                }
            }
            return resultadoLista;
        }

        public List<string> DecodeWordDictionary(string sentence, Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> diccionarioOrdenado = dictionary.OrderBy(x => x.Value.Length).ToDictionary(v => v.Key, v => v.Value);

            string resultado = "";
            List<string> resultadoLista = new List<string>();
          
            //Obtengo una lista de todas aquellas palabras del diccionario que serían válidas para el inicio de sentence, empezando por las mas cortas para evaluar todas las opciones
            foreach (KeyValuePair<string, string> itemDiccionario in diccionarioOrdenado)
            {
                if (sentence.StartsWith(itemDiccionario.Value))
                {
                    resultado = itemDiccionario.Key;

                    string wordReducida = sentence.Substring(itemDiccionario.Value.Length);//le quito a la cadena el caracter decodificado
                    if (wordReducida.Length == 0)//nada más a decodificar, devuelvo mi resultado como una lista de un solo item
                    {
                        resultadoLista.Add(resultado);
                        return resultadoLista;
                    }
                    //Agrego a mi listado de resultados los resultados de codificar el resto de la cadena
                    foreach (string resultadoPosible in DecodeWordDictionary(wordReducida, dictionary))
                    {
                        resultadoLista.Add(resultado + " " + resultadoPosible); //Agrego el caracter a la posible solucion
                    }
                }
            }
            return resultadoLista;
        }
      
        public string Encode(char letter)
        {
            int index = original.IndexOf(letter);
            return codification[index];
        }

        public string EncodeWord(string word)
        {
            string result = "";
            List<char> listChar = word.ToUpper().ToList();
            foreach (char caracter in listChar)
            {
                string caracterEncoded = Encode(caracter);
                result += caracterEncoded;
            }
            return result;
        }
    }
}
