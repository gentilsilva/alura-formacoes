using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numeroDeBytesLidos = -1;
            var buffer = new byte[1024];

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length);             // public override int Read(byte[] array, int offset, int count);
                // Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            fluxoDoArquivo.Close();
            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = Encoding.UTF8;

        var texto = utf8.GetString(buffer, 0, bytesLidos);                             // public virtual string GetString(byte[] bytes, int index, int count)
        Console.Write(texto);

        //foreach ( var meuByte in buffer )
        //{
        //    Console.Write(meuByte);
        //    Console.Write(" ");
        //}
    }
}