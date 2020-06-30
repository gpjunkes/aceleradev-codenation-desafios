using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> resultado = new List<int>();

            int valorAnt = 0;
            int valorAtual = 1;
            int valorSomado = valorAtual + valorAnt;

            resultado.Add(valorAnt);

            while (valorSomado <= 350)
            {
                resultado.Add(valorSomado);

                valorSomado = valorAtual + valorAnt;
                valorAnt = valorAtual;
                valorAtual = valorSomado;

            }

            return resultado;
        }

        public bool IsFibonacci(int numberToTest)
        {
            return Fibonacci().Contains(numberToTest);
        }
    }
}
