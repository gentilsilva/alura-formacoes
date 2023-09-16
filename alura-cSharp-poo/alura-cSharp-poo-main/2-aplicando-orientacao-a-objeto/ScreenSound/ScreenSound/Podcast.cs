class Podcast
{
    public string Host { get; }
    public string Nome { get; }

    private List<Episodio> episodios = new List<Episodio>();

    public int totalEpisodios => episodios.Count;

    public Podcast(string host,  string nome)
    {
        Host = host;
        Nome = nome;
    }

    public void AdicionarEpisodio(Episodio episodio)
    {
        episodios.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast {Nome} apresentado por {Host}.\n");
        foreach (Episodio episodio in episodios.OrderBy(e => e.Ordem))
        {
            Console.WriteLine(episodio.Resumo);
        }
        Console.WriteLine($"\nEste podcast possui {totalEpisodios} episódios");
    }

}