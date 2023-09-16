package br.com.alura.screenmatch.desafio;

import java.util.ArrayList;
import java.util.List;

public class CartaoCredito {

    private double limite;
    private double saldo;
    private List<Compra> compras = new ArrayList<>();

    public CartaoCredito(double limite) {
        this.limite = limite;
        this.saldo = limite;
    }

    public double getLimite() {
        return limite;
    }

    public double getSaldo() {
        return saldo;
    }

    public boolean lancaCompra(Compra compra) {
        if (this.saldo > compra.getValor()) {
            this.saldo -= compra.getValor();
            compras.add(compra);
            return true;
        }
        return false;
    }

    public List<Compra> getCompras() {
        return compras;
    }
}
