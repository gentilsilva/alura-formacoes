
partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);
            // var linha = leitor.ReadLine();                   Lê a linha ^^

            // var texto = leitor.ReadToEnd();                  Lê até o final do arquivo ^^

            // var numero = leitor.Read();                      Lê o primeiro byte

            while (!leitor.EndOfStream)                         // Lê o todo o arquivo, mas não faz a leitura de uma só vez. Diferente do ReadToEnd()
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }
        Console.ReadLine();
    }
}