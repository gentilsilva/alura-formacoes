package br.com.alura.screenmatch.desafio.modelos;

public class MinhasPreferidas {

    public void inclui(Audio audio) {
        if (audio.getClassificacao() >= 8) {
            System.out.println(audio.getTitulo() + " é preferido por todos!.");
        } else {
            System.out.println(audio.getTitulo() + " também é um dos que todo mundo está curtindo.");
        }
    }

}
