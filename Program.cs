using analizador_lexico;
using System.Text.RegularExpressions;

namespace AnalizadorLexico
{
    class Program
    {
        static void Main(string[] args)
        {
            string codigoFuentePath = "codigo_fuente.txt";
            
            string codigoFuente = File.ReadAllText(codigoFuentePath);

            PalabrasReservadas palabrasReservadas = new PalabrasReservadas();
            Operadores operadores = new Operadores();
            SimbolosEspeciales simbolosEspeciales = new SimbolosEspeciales();

            List<Token> tokens = AnalizadorLexico(codigoFuente, palabrasReservadas, operadores, simbolosEspeciales);
            
            Console.WriteLine("Tokens encontrados:");
            foreach (var token in tokens)
            {
                Console.WriteLine($"{token.Tipo}: {token.Valor}");
            }
        }

        public class Token
        {
            public string Tipo { get; set; }
            public string Valor { get; set; }
        }

        static List<Token> AnalizadorLexico(string codigoFuente, PalabrasReservadas palabrasReservadas , Operadores operadores, SimbolosEspeciales simbolosEspeciales)
        {
            List<Token> tokens = new List<Token>();
            
            string[] palabras = Regex.Split(codigoFuente, @"(?<=[^\s.;])[\s.;]+(?=[^\s.;])|//.*");
            foreach (string palabra in palabras)

            {
                Token token = new Token();
                token.Valor = palabra;

                long number1 = 0;
                bool canConvert = long.TryParse(palabra, out number1);
                
                if (palabrasReservadas.EsPalabraReservada(palabra))
                {
                    token.Tipo = "Palabra Reservada";
                }
                else if (operadores.EsOperadores(palabra))
                {
                    token.Tipo = "Operador";
                }
                else if (simbolosEspeciales.EsSimbolosEspeciales(palabra))
                {
                    token.Tipo = "Simbolos Especiales";
                }
                else if(canConvert == true)
                {
                    token.Tipo = "Constantes numericas";
                }
                else if (EsConstanteCaracter(palabra))
                {

                    token.Tipo = "Constantes de cadena";                        
                }
                else if (EsConstanteCadena(palabra))
                {
                    token.Tipo = "Constante de cadena";                
                }
                else
                {
                    token.Tipo = "Identificador";
                }

                tokens.Add(token);
            }
            static bool EsConstanteCaracter(string palabra)
            {                
                return palabra is char;
            }

            static bool EsConstanteCadena(object palabra)
            {
                if (palabra is string)
                {
                    string strVariable = (string)palabra;
                    return Regex.IsMatch(strVariable, "^\".*\"$");
                }
                return false;
            }
            return tokens;
        }
    }
}
