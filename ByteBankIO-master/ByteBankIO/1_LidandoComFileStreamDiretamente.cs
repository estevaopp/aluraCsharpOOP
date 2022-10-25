using ByteBankIO;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        string enderecoDoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contas.txt";

        using (FileStream fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            int numeroDeBytesLidos = -1;
            byte[] buffer = new byte[1024]; //1KB


            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length);
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }
            Array.Clear(buffer);
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        UTF8Encoding utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);

        /*
        foreach (var meuBuffer in buffer)
        {
            Console.Write(meuBuffer);
            Console.Write(" ");
        }
        */
    }
}