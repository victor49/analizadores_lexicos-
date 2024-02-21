namespace analizador_lexico
{
    public class SimbolosEspeciales
    {
        public HashSet<string> Palabras { get; }
        public SimbolosEspeciales() 
        {
            Palabras = new HashSet<string>
            {
                "{", "}", "(", ")", "[", "]", ";", ",", ".", ":", "?", "@", "#", "$", "%", "&",
                "!", "|", "^", "_", "-", "=",
            };
        }
        public bool EsSimbolosEspeciales(string palabra)
        {
            return Palabras.Contains(palabra);
        }
    }
}
