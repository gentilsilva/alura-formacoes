using OpenAI_API;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        try
        {
            var client = new OpenAIAPI("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");
            var chat = client.Chat.CreateConversation();

            chat.AppendSystemMessage($"Resuma a banda {banda} em 1 parágrafo. Adote um estilo informal.");

            string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = resposta;
        }
        catch (Exception e)
        {
            Console.WriteLine("Não foi possível recuperar o resumo. Plano vencido.");
            banda.Resumo = "Não foi possível recuperar o resumo. Plano vencido.";
        }
        
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}