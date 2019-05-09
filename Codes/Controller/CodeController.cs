using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class CodeController
    {
        private CodeInterface codification;

        public string sentence { get; internal set; }

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

        internal void setDictionary(string argument)
        {
            throw new NotImplementedException();
        }
    }
}
