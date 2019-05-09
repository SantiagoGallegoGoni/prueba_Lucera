using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class MainProgram
    {
        static int Main(string[] args)
        {
            if(args == null)
            {
                Console.WriteLine("Debe de proporcionar una codificación, una ruta con el diccionario y una cadena a descifrar");
                return 1; //TODO: mirar codigo error devuelto
            }
            else
            {
                CodeController codeController = new CodeController();
                for (int i = 0; i < args.Length; i++)
                {
                    string argument = args[i];
                    //TODO: Mejorar esto, que lo detecte por parametros rollo -L
                    switch (i)
                    {
                        case 0:
                            codeController.setCodificacion(argument);
                        break;
                        case 1:
                            codeController.setDictionary(argument);
                        break;
                        case 2:
                            codeController.sentence = argument;
                        break;
                        default:
                            //TODO: too many arguments
                        break;
                    }

                }
                return 0;
            }
        }
    }
}
