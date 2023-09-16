using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar Música");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Digite a música que deseja avaliar: ");
            string tituloMusica = Console.ReadLine()!;
            if (banda.Musicas.Any(a => a.Nome.Equals(tituloMusica)))
            {
                Musica musica = banda.Musicas.First(a => a.Nome.Equals(tituloMusica));
                Console.Write($"Qual a nota que a música {tituloMusica} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                musica.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a música {tituloMusica}");
                Thread.Sleep(2000);
                Console.Clear(); 
            }
            else
            {
                Console.WriteLine($"\nO albúm {tituloMusica} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}