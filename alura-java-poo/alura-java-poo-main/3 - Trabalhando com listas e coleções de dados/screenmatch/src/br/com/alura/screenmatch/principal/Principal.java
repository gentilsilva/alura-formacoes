package br.com.alura.screenmatch.principal;

import br.com.alura.screenmatch.modelos.*;

import java.util.ArrayList;

public class Principal {
    public static void main(String[] args) {

        //region Filmes e series

        Filme meuFilme = new Filme("O poderoso chefão", 1970);
        meuFilme.setDuracaoEmMinutos(180);

        meuFilme.exibeFichaTecnica();

        meuFilme.avalia(8);
        meuFilme.avalia(5);
        meuFilme.avalia(10);

        Filme outroFilme = new Filme("Avatar", 2023);
        outroFilme.setDuracaoEmMinutos(200);


//        System.out.println("Total de avaliações: " + meuFilme.getTotalDeAvaliacoes());
//        System.out.println(meuFilme.pegaMedia());

        Serie lost = new Serie("Lost", 2000);
        lost.exibeFichaTecnica();
        lost.setTemporadas(10);
        lost.setEpisodiosPorTemporada(10);
        lost.setMinutosPorEpisodio(50);

//        System.out.println("Duração para maratonar lost: " + lost.getDuracaoEmMinutos());
//
//        CalculadoraDeTempo calculadoraDeTempo = new CalculadoraDeTempo();
//        calculadoraDeTempo.inclui(meuFilme);
//        calculadoraDeTempo.inclui(outroFilme);
//        calculadoraDeTempo.inclui(lost);
//        System.out.println(calculadoraDeTempo.getTempoTotal());
//
//        FiltroRecomendacao filtro = new FiltroRecomendacao();
//        filtro.filtra(meuFilme);
//
//        Episodio episodio = new Episodio();
//        episodio.setNumero(1);
//        episodio.setSerie(lost);
//        episodio.setTotalVisualizacoes(300);
//
//        filtro.filtra(episodio);

        var filmeTres = new Filme("Dogville", 2003);
        filmeTres.setDuracaoEmMinutos(200);
        filmeTres.avalia(10);

        ArrayList<Filme> listaDeFilmes = new ArrayList<>();
        listaDeFilmes.add(meuFilme);
        listaDeFilmes.add(outroFilme);
        listaDeFilmes.add(filmeTres);
        System.out.println("Tamanho da lista: " + listaDeFilmes.size());
        System.out.println("Primeiro filme: " + listaDeFilmes.stream().findFirst().get().getNome());
        System.out.println(listaDeFilmes);

        //endregion
    }
}
