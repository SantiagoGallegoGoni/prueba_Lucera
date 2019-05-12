using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    class MainProgram
    {
        static string codificationType = null;
        static string dictionary = null;
        static string sentence = null;

        static int Main(string[] args)
        {
            if(args == null)
            {
                ErrorParametros();
                return 1;
            }
            else
            {
                if (args.Length == 1)
                {
                    if (args[0].Equals("-h"))
                    {
                        MostrarAyuda();
                    }
                    else
                    {
                        ErrorParametros();
                    }
                    return 0;
                }
                else if (args.Length == 4 || args.Length == 6)
                {
                    SetArgumentos(args);
                    if (ArgumentosOK())
                    {
                        try
                        {
                            MostrarResultados();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return 3;
                        }
                    }

                    return 0;
                }
                else //demasiados o pocos argumentos
                {
                    ErrorParametros();
                    return 2;
                }

            }
        }

        /// <summary>
        /// Muestra los resultados de la decodificación
        /// </summary>
        private static void MostrarResultados()
        {
            CodeController codeController = new CodeController
            {
                CodificationType = codificationType,
                Sentence = sentence
            };
            if (dictionary != null)
                codeController.InitDictionary(dictionary);

            List<string> resultados = codeController.Decrypt();

            Console.WriteLine("Se han encontrado " + resultados.Count + " resultados:");

            foreach (string resultado in resultados)
            {
                Console.WriteLine(resultado);
            }
        }

        /// <summary>
        /// Comprueba que todos los argumentos son correctos
        /// </summary>
        /// <returns></returns>
        private static bool ArgumentosOK()
        {
            if (codificationType != null || sentence != null)
            {
                if (sentence.Length > 10 && dictionary == null)
                {
                    Console.WriteLine("Si no incluye diccionario, el tamaño máximo de cadena es 10");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Setea los argumentos pasados por linea de comandos
        /// </summary>
        /// <param name="args"></param>
        private static void SetArgumentos(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string argument = args[i];
                switch (argument)
                {
                    case "-c":
                        codificationType = args[i + 1];
                        break;
                    case "-d":
                        dictionary = args[i + 1];
                        break;
                    case "-s":
                        sentence = args[i + 1];
                        break;
                }

            }
        }

        /// <summary>
        /// Muestra el mensaje de error de parametros
        /// </summary>
        private static void ErrorParametros()
        {
            Console.WriteLine("Número de parámetros incorrectos o comando no reconocido: Debe de proporcionar una codificación, una ruta con el diccionario y una cadena a descifrar. Escriba -h para ayuda");
        }

        /// <summary>
        /// Muestra mensaje de ayuda
        /// </summary>
        private static void MostrarAyuda()
        {
            Console.WriteLine("Decodifica una frase mediante un diccionario dado en la codificación especificada");
            Console.WriteLine("");
            Console.WriteLine("\"Prueba Lucera.exe\" [-c[codificacion]] [-d[ruta fichero diccionario]] [-s[frase a decodificar]]");
            Console.WriteLine("");
            Console.WriteLine("Ejemplo: \"Prueba Lucera.exe\" -c Morse -d C:\\Lucera\\words.txt -s --.--.---.......-.---.-.-.-..-.....--..-....-.-----..-");
        }
    }
}
