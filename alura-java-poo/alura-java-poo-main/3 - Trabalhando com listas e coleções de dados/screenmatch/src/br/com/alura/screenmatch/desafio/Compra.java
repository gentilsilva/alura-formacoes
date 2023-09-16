package br.com.alura.screenmatch.desafio;

public class Compra implements Comparable<Compra> {

    private String descricao;
    private double valor;

    public Compra(String descricao, double valor) {
        this.descricao = descricao;
        this.valor = valor;
    }

    public String getDescricao() {
        return descricao;
    }

    public double getValor() {
        return valor;
    }

    @Override
    public String toString() {
        return "Descricao: " + this.getDescricao() + "-" + "Valor: " + this.getValor();
    }

    @Override
    public int compareTo(Compra compra) {
        return Double.valueOf(this.valor).compareTo(Double.valueOf(compra.valor));
    }
}
