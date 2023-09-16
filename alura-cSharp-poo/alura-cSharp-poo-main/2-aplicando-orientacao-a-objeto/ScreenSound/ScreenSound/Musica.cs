class Musica
{
    public string? Nome { get; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";   // Na maioria dos casos, em operações somente de leitura é feito por lambda (Funções anônimas)
    private Genero Genero { get; set; }

    // Essa é uma outra alternativa, mas pouco utilizada no caso de só termos a leitura (get)
    //{ 
    //    get
    //    {
    //        return $"A música {Nome} pertence à banda {Artista}";
    //    } 
    //}

    public Musica(Banda artista, string? nome)
    {
        Artista = artista;
        Nome = nome;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao} segundos");
        if (Disponivel)
        {
            Console.WriteLine("Disponivel no plano");
        }
        else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

}

