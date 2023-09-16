class Episodio
{
    public int Duracao { get; }
    public string Titulo { get; }
    public int Ordem { get; }

    private List<string> convidados = new List<string>();
    public string Resumo => $"{Ordem}. {Titulo} com duração de {Duracao} minutos. - Com os seguintes convidados: {string.Join(", ", convidados)}";    // string.Join concatena os membros de uma lista para imprimir



    public Episodio(int ordem, string titulo, int duracao)
    {
        Ordem = ordem;
        Titulo = titulo;
        Duracao = duracao;
    }

    public void AdicionarConvidado(string nome)
    {
        convidados.Add(nome);
    }

}