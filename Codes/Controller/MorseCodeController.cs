using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class MorseCodeController : BaseCodeController
    {

        /// <summary>
        /// Desencripta la cadena y devuelve un listado con las posibilidades
        /// </summary>
        /// <returns></returns>
        public List<string> decrypt()
        {
            if(codification == null)
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

                codification.DecodeWord(sentence);


                return result;
            }
        }
    }
}
