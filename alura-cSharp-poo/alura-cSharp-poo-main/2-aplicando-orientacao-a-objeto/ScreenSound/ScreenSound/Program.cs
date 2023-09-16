Episodio episodioUm = new(1, "Técnicas de facilitação", 45);
episodioUm.AdicionarConvidado("Maria");
episodioUm.AdicionarConvidado("Marcelo");

Episodio episodioDois = new(2, "Técnicas de aprendizado", 67);
episodioDois.AdicionarConvidado("Fernando");
episodioDois.AdicionarConvidado("Marcos");
episodioDois.AdicionarConvidado("Flavia");

Podcast podcast = new("Podcast especial", "Daniel");
podcast.AdicionarEpisodio(episodioUm);
podcast.AdicionarEpisodio(episodioDois);
podcast.ExibirDetalhes();