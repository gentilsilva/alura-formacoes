package br.com.alura.screenmatch.desafio;

import java.util.Collections;
import java.util.Scanner;

public class PrincipalDesafio {

    public static void main(String[] args) {

        Scanner leia = new Scanner(System.in);
        int opcao;
        String descricao;
        double valorCompra;
        boolean valida;


        System.out.print("Informe o limite do cartão: ");
        CartaoCredito cartaoCredito = new CartaoCredito(Double.parseDouble(leia.nextLine()));


        do {

            System.out.print("Digite 1 para acrescentar outra conta ou 0 para encerrar: ");
            opcao = Integer.parseInt(leia.nextLine());

            if (opcao == 0) break;

            System.out.print("Informe a descrição da compra: ");
            descricao = leia.nextLine();
            System.out.print("Informe o valor da compra: ");
            valorCompra = Double.parseDouble(leia.nextLine());

            Compra compra = new Compra(descricao, valorCompra);

            valida = cartaoCredito.lancaCompra(compra);

        } while (valida);

        Collections.sort(cartaoCredito.getCompras());
        System.out.println("Compras realizadas: ");
        for (Compra compra: cartaoCredito.getCompras()) {
            System.out.println(compra.getDescricao() + " - " + compra.getValor());
        }

        System.out.println("-----------------------");
        System.out.println("Saldo cartão: " + cartaoCredito.getSaldo());

    }

}
