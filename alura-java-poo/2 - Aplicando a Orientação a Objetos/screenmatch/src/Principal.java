import br.com.alura.screenmatch.desafio.modelos.MinhasPreferidas;
import br.com.alura.screenmatch.desafio.modelos.Musica;
import br.com.alura.screenmatch.desafio.modelos.PodCast;

public class Principal {
    public static void main(String[] args) {

        //region Filmes e series
//        Filme meuFilme = new Filme();
//        meuFilme.setNome("O poderoso chefão");
//        meuFilme.setAnoDeLancamento(1970);
//        meuFilme.setDuracaoEmMinutos(180);
//
//        meuFilme.exibeFichaTecnica();
//
//        meuFilme.avaliaFilme(8);
//        meuFilme.avaliaFilme(5);
//        meuFilme.avaliaFilme(10);
//
//        Filme outroFilme = new Filme();
//        outroFilme.setNome("Avatar");
//        outroFilme.setAnoDeLancamento(2023);
//        outroFilme.setDuracaoEmMinutos(200);
//
//
////        System.out.println("Total de avaliações: " + meuFilme.getTotalDeAvaliacoes());
////        System.out.println(meuFilme.pegaMedia());
//
//        Serie lost = new Serie();
//        lost.setNome("Lost");
//        lost.setAnoDeLancamento(2000);
//        lost.exibeFichaTecnica();
//        lost.setTemporadas(10);
//        lost.setEpisodiosPorTemporada(10);
//        lost.setMinutosPorEpisodio(50);
//
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
        //endregion

        //region Description
        Musica minhaMusica = new Musica();
        minhaMusica.setTitulo("Forever");
        minhaMusica.setArtista("Kiss");

        for (int i = 0; i < 100; i++) {
            minhaMusica.reproduz();
        }

        for (int i = 0; i < 50; i++) {
            minhaMusica.curte();
        }

        PodCast meuPodcast = new PodCast();
        meuPodcast.setTitulo("BolhaDev");
        meuPodcast.setApresentador("Marcus Mendes");

        for (int i = 0; i < 5000; i++) {
            meuPodcast.reproduz();
        }

        for (int i = 0; i < 1000; i++) {
            meuPodcast.curte();
        }

        MinhasPreferidas minhasPreferidas = new MinhasPreferidas();
        minhasPreferidas.inclui(minhaMusica);
        minhasPreferidas.inclui(meuPodcast);

        //endregion
    }
}
