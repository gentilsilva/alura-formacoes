import java.util.Scanner;

public class Desafio {
    public static void main(String[] args) {
        Scanner leia = new Scanner(System.in);
        String nome = "Opsum Ipsum";
        String tipoConta = "Corrente";
        double saldoInicial = 2500.00;
        int opcao;

        do {
            System.out.println();
            System.out.println(dadosIniciais(nome, tipoConta, saldoInicial));
            System.out.println();
            do {
                System.out.print("""
                                    Operações
                                    
                                    1 - Consultar Saldo
                                    2 - Depositar Valor
                                    3 - Transferir Valor
                                    4 - Sair
                                    
                                    """);
                System.out.print("Digite a opcao desejada: ");
                opcao = leia.nextInt();
                if(opcao < 1 || opcao > 4) {
                    System.out.println("Opção inválida. Digite uma das opções a seguir.");
                }
            } while (opcao < 1 || opcao > 4);

            if(opcao == 1) {
                System.out.println();
                System.out.println(consultarSaldo(saldoInicial));
                System.out.println();
            } else if(opcao == 2) {
                double deposito;
                System.out.println();
                System.out.print("Informe o valor a ser depositado: ");
                deposito = leia.nextDouble();

                saldoInicial = depositarValor(deposito, saldoInicial);

                System.out.println("Saldo atualizado é: " + saldoInicial);
                System.out.println();
            } else if(opcao == 3) {
                double transferir;
                System.out.print("Digite o valor a ser transferido: ");
                transferir = leia.nextDouble();

                System.out.println();
                if(transferirValor(transferir, saldoInicial) == 0) {
                    System.out.println("Não há saldo suficiente para fazer essa transferência.");
                } else {
                    saldoInicial = transferirValor(transferir, saldoInicial);
                    System.out.println("Novo saldo é: " + saldoInicial);
                }
                System.out.println();
            }

        } while (opcao != 4);



    }

    public static String dadosIniciais(String nome, String tipoConta, double saldoInicial) {
        String mensagem;
        mensagem = String.format("""
                **************************
                Dados iniciais do cliente:

                Nome: %s
                Tipo conta: %s
                Saldo inicial: %.2f
                **************************""", nome, tipoConta, saldoInicial);
        return mensagem;
    }

    public static String consultarSaldo(double saldoInicial) {
        return "O saldo atual e: " + saldoInicial;
    }

    public static double depositarValor(double valor, double saldoInicial) {
        return valor + saldoInicial;
    }

    public static double transferirValor(double valor, double saldoInicial) {
        if(valor > saldoInicial) {
            return 0;
        } else {
            return saldoInicial - valor;
        }
    }
}
