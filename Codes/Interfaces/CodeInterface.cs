using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Lucera
{
    interface CodeInterface
    {
        char Decode(string word);
        string Encode(char letter);
        string DecodeWord(string word);
        string EncodeWord(string word);

    }
}
