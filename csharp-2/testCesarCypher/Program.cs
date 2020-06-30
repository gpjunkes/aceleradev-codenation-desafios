using System;

namespace testCesarCypher
{
    class Program
    {
        private const int KEYCRIPT = 3;
        public static void Main(string[] args)
        {
            //var textoParaEncriptar = "Teste texto encript 1234 LALA";
            //string textoEncript = Crypt(textoParaEncriptar);
            //Console.WriteLine($"Encript: {textoParaEncriptar}");
            //Console.WriteLine($"Descript: {textoEncript}");
            //Console.WriteLine("-------------------");

            //var textoParaDesencriptar = "a whvwh whawr hqfulsw 1234 ODOD";
            //string textoDesencript = Decrypt(textoParaDesencriptar);
            //Console.WriteLine($"Encript: {textoParaDesencriptar}");
            //Console.WriteLine($"Descript: {textoDesencript}");


            //var textoParaDesencriptar = "a whvwh whawr hqfulsw 1234 ODOD";
            string textoDesencript = Decrypt(null);

        }

        private static bool IsAscEspaco(int codigoAsc)
        {
            return codigoAsc == 32;
        }
        private static bool IsAscNumerico(int codigoAsc)
        {
            return (codigoAsc > 47 && codigoAsc < 58);
        }
        private static bool IsAscLetraValida(int codigoAsc)
        {
            return (codigoAsc > 96 && codigoAsc < 123);
        }

        public static string Crypt(string message)
        {
            if (message == string.Empty) return string.Empty;
            if (message == null) throw new ArgumentNullException();

            message = message.ToLower();

            string textoEncriptado = string.Empty;
            char novaLetra;

            for (int i = 0; i < message.Length; i++)
            {
                var letra = message.Substring(i, 1);
                var codAsc = Convert.ToInt32(Convert.ToChar(letra));

                if (IsAscEspaco(codAsc) || IsAscNumerico(codAsc))
                {
                    textoEncriptado += letra;
                    continue;
                }
                
                if (!IsAscLetraValida(codAsc)) throw new ArgumentOutOfRangeException();

                var novoAsc = codAsc + KEYCRIPT;
                if (novoAsc > 122) novoAsc -= 26;

                novaLetra = (char) novoAsc;
                textoEncriptado += novaLetra;
            }

            return textoEncriptado;
        }
        public static string Decrypt(string cryptedMessage)
        {
            string textoDescript = string.Empty;
            char novaLetra;

            if (cryptedMessage == null) throw new ArgumentNullException();

            cryptedMessage = cryptedMessage.ToLower();
            for (int i = 0; i < cryptedMessage.Length; i++)
            {
                var letra = cryptedMessage.Substring(i, 1);
                var codAsc = Convert.ToInt32(Convert.ToChar(letra));

                if (IsAscEspaco(codAsc) || IsAscNumerico(codAsc))
                {
                    textoDescript += letra;
                    continue;
                }

                if (!IsAscLetraValida(codAsc)) throw new ArgumentOutOfRangeException();

                var novoAsc = codAsc - KEYCRIPT;
                if (novoAsc < 97) novoAsc += 26;

                novaLetra = (char)novoAsc;
                textoDescript += novaLetra;
            }
            
            return textoDescript;
        }
    }
}
