package br.com.alura.screenmatch.desafio.modelos;

public class Audio {

    private String titulo;
    private int duracaoEmSegundos;
    private int anoDeLancamento;
    private int totalReproducoes;
    private int totalCurtidas;
    private int classificacao;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public int getDuracaoEmSegundos() {
        return duracaoEmSegundos;
    }

    public void setDuracaoEmSegundos(int duracaoEmSegundos) {
        this.duracaoEmSegundos = duracaoEmSegundos;
    }

    public int getAnoDeLancamento() {
        return anoDeLancamento;
    }

    public void setAnoDeLancamento(int anoDeLancamento) {
        this.anoDeLancamento = anoDeLancamento;
    }

    public int getTotalReproducoes() {
        return totalReproducoes;
    }

    public int getTotalCurtidas() {
        return totalCurtidas;
    }

    public int getClassificacao() {
        return classificacao;
    }

    public void exibeFichaAudio() {
        System.out.printf("""
                Nome audio: 
                Duração em minutos: 
                Ano de lançamento: 
                """, titulo, duracaoEmSegundos, anoDeLancamento);
    }

    public void reproduz() {
        this.totalReproducoes++;
    }

    public void curte() {
        this.totalCurtidas++;
    }
}
