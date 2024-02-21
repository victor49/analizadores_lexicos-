using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analizador_lexico
{
    public class Operadores
    {
        public HashSet<string> Palabras { get; }
        public Operadores() 
        {
            Palabras = new HashSet<string>
            {
                "+", "-", "*", "/", "%", "++", "--", "==", "!=", ">", "<", ">=", "<=", "&&", 
                "||", "!", "&", "|", "^", "~", "<<", ">>", "=", "+=", "-=", "*=", "/=", "%=", 
                "&=", "|=", "^=", "<<=", ">>=", "=>", "?", "??", ":", 
            };
        }
        public bool EsOperadores(string palabra)
        {
            return Palabras.Contains(palabra);
        }
    }
}
