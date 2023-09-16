class Album
{
    private List<Musica> musicas = new List<Musica>();

    public string? Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);             // Método de somar da classe de lista, permite somar a quantidade de valores de determinado atributo
    public Album(string? nome)
    {
        Nome = nome;
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        musicas.ForEach(musica => { Console.WriteLine($"Música: {musica.Nome}."); });
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal} segundos disponíveis.");
    }
}