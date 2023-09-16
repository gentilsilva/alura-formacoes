using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
#nullable disable
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-X") {Saldo = 100, Titular = new Cliente{Cpf = "11111", Nome = "Gentil"}},
            new ContaCorrente(95, "951258-X") {Saldo = 200, Titular = new Cliente{Cpf = "22222", Nome = "Isabella"}},
            new ContaCorrente(95, "987321-W") {Saldo = 60, Titular = new Cliente{Cpf = "33333", Nome = "Fernanda"}}
        };

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("=== 1 - Cadastrar Conta     ===");
                    Console.WriteLine("=== 2 - Lista Contas        ===");
                    Console.WriteLine("=== 3 - Remover Conta       ===");
                    Console.WriteLine("=== 4 - Ordenar Contas      ===");
                    Console.WriteLine("=== 5 - Pesquisar Conta     ===");
                    Console.WriteLine("=== 6 - Sair do Sistema     ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);
                    }
                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverConta();
                            break;
                        case '4':
                            OrdenarConta();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opção não implementada.");
                            break;

                    }
                }
            }
            catch (ByteBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}"); ;
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    CADASTRO DE CONTA    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta  ===");

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"O número da conta [NOVA]: {conta.Conta}");

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe o nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe a profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);

            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    LISTAR CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                //Console.WriteLine("===   Dados da Conta   ===");
                //Console.WriteLine("Número da conta: " + item.Conta);
                //Console.WriteLine("Saldo da Conta: " + item.Saldo);
                //Console.WriteLine("Titular da conta: " + item.Titular.Nome);
                //Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine(item.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.ReadKey();
            }
        }

        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      REMOVER CONTA      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Informe o número da Conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;

            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }

        private void OrdenarConta()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada ...");
            Console.ReadKey();
        }

        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      PESQUISAR CONTA      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar (1) NUMERO DA CONTA - (2) CPF TITULAR - (3) NÚMERO DA AGÊNCIA: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Informe o número da Conta: ");
                    string _numeroConta = Console.ReadLine();
                    ContaCorrente consultaConta = ConsultarPorNumeroConta(_numeroConta);
                    Console.WriteLine(consultaConta.ToString());
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Write("Informe o CPF do Titular: ");
                    string _cpf = Console.ReadLine();
                    ContaCorrente consultaCpf = ConsultarPorCpfTitular(_cpf);
                    Console.WriteLine(consultaCpf.ToString());
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Write("Informe o número da agência: ");
                    int _numeroAgencia = int.Parse(Console.ReadLine());
                    var consultaNumeroAgencia = ConsultarPorNumeroAgencia(_numeroAgencia);
                    ExibirListaDeContas(consultaNumeroAgencia);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção não implmenentada.");
                    break;
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }

        private void ExibirListaDeContas(List<ContaCorrente> consultaNumeroAgencia)
        {
            if (consultaNumeroAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou valores ...");
            }
            else
            {
                foreach (var item in consultaNumeroAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> ConsultarPorNumeroAgencia(int numeroAgencia)
        {
            var consulta = (                                    // É possível fazer pesquisas que se assemelham a query SQL utilizando Linq
                from conta in _listaDeContas
                where conta.Numero_agencia == numeroAgencia
                select conta).ToList();
            return consulta;
        }

        private ContaCorrente ConsultarPorCpfTitular(string cpf)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}
            //return conta;
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        private ContaCorrente ConsultarPorNumeroConta(string numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}
            //return conta;
            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();      // Método Where extende da classe Linq(Language Integrated Query) -> permite consultas em diferentes fontes de dados
        }
    }
}
