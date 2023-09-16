using csharp_exception.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_exception.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }

        public static float TaxaDeOperacao { get; set; }

        public static float TaxaOperacao { get; private set; }

        private int numeroAgencia;
        public int NumeroAgencia
        {
            get { return numeroAgencia; }
            private set
            {
                if (value > 0)
                {
                    numeroAgencia = value;
                }
            }
        }


        public string Conta { get; set; }

        private double saldo = 100;

        public Cliente? Titular { get; set; }

        public void Depositar(double valor)
        {
            saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                return true;
            }
            else
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para operação desejada.");
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo < valor)
            {
                return false;
            }
            else
            {
                Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
        }

        public void SetSaldo(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            else
            {
                saldo = valor;
            }
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public ContaCorrente(int numeroAgencia, string numeroConta)
        {
            NumeroAgencia = numeroAgencia;
            Conta = numeroConta;
            if (numeroAgencia <= 0) throw new ArgumentException("Número de agência não pode ser menor ou igual a zero!", nameof(numeroAgencia));     // nameof -> passa o nome da variável como string para exibir.
            /*
            try
            {
                TaxaDeOperacao = 10 / TotalDeContasCriadas;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero.");
            }
            */
            TotalDeContasCriadas++;
        }


    }
}
