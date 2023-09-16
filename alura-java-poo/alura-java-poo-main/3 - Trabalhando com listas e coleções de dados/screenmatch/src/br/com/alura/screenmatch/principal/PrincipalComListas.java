package br.com.alura.screenmatch.principal;

import br.com.alura.screenmatch.modelos.Filme;
import br.com.alura.screenmatch.modelos.Serie;
import br.com.alura.screenmatch.modelos.Titulo;

import java.util.*;

public class PrincipalComListas {

    public static void main(String[] args) {

        Filme meuFilme = new Filme("O poderoso chefão", 1970);
        meuFilme.avalia(9);
        Filme outroFilme = new Filme("Avatar", 2023);
        outroFilme.avalia(6);
        var filmeTres = new Filme("Dogville", 2003);
        filmeTres.avalia(10);
        Serie lost = new Serie("Lost", 2000);

//        Filme f1 = filmeTres;  // Aqui f1 se referência para o mesmo lugar que filmeTres, e não cria nada novo.
//        f1.setNome("google");
//        System.out.println(filmeTres);

        ArrayList<Titulo> lista = new ArrayList<>();
        lista.add(meuFilme);
        lista.add(outroFilme);
        lista.add(filmeTres);
        lista.add(lost);

        System.out.println("Lista de titulos antes de ordenar:");
        for (Titulo item: lista) {
            System.out.println(item.getNome());
            if (item instanceof Filme filme && filme.getClassificacao() > 2) {
                System.out.println("Classificação: " + filme.getClassificacao());
            }
        }

        List<String> buscaPorArtista = new LinkedList<>();
        buscaPorArtista.add("Adam  Sandler");
        buscaPorArtista.add("Paulo");
        buscaPorArtista.add("Jacqueline");
        System.out.println("Antes da ordenação: " + buscaPorArtista);

        Collections.sort(buscaPorArtista);
        System.out.println("Depois da ordenação: " + buscaPorArtista);

        Collections.sort(lista);
        System.out.println("Lista de titulos depois de ordenar: ");
        System.out.println(lista);

        lista.sort(Comparator.comparing(Titulo::getAnoDeLancamento));
        System.out.println("Ordenando por ano de lançamento: ");
        System.out.println(lista);
    }

}
