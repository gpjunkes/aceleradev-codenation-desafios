using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private const int KEYCRIPT = 3;

        public string Crypt(string message)
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

                novaLetra = (char)novoAsc;
                textoEncriptado += novaLetra;
            }

            return textoEncriptado;
        }

        public string Decrypt(string cryptedMessage)
        {
            if (cryptedMessage == null) throw new ArgumentNullException();

            string textoDescript = string.Empty;
            char novaLetra;
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

        private bool IsAscEspaco(int codigoAsc)
        {
            return codigoAsc == 32;
        }
        private bool IsAscNumerico(int codigoAsc)
        {
            return (codigoAsc > 47 && codigoAsc < 58);
        }
        private bool IsAscLetraValida(int codigoAsc)
        {
            return (codigoAsc > 96 && codigoAsc < 123);
        }
    }
}
