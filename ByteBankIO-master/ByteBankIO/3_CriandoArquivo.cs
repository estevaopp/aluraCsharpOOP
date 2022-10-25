using ByteBankIO;
using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contasExportadas.csv";

        using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            string contaComoString = "123,13231,976.53,Adalberto Luiz";

            var encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(contaComoString);

            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }
    static void CriarArquivoComWriter()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contasExportadas.csv";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
        {
            string contaComoString = "876,124576,91176.53,Julio Romeu";

            escritor.Write(contaComoString);
        }
    }

    static void TestaEscrita()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\teste.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush();
                Console.WriteLine($"Linha {i} foi escrita no arquivo, Tecle enter ...");
                Console.ReadLine();
            }
        }
    }

    static void EscritaBinaria()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contaCorrente.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new BinaryWriter(fluxoDeArquivo))
        {
            escritor.Write(456);//agencia
            escritor.Write(546544);//numero
            escritor.Write(4000.50);//saldo
            escritor.Write("Gustavo Braga");//nome
        }
    }

    static void LeituraBinaria()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contaCorrente.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Open))
        using (var leitor = new BinaryReader(fluxoDeArquivo))
        {
            var agencia = leitor.ReadInt32();
            var numero = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{titular}: {agencia}/{numero}/{saldo}");
        }
    }

    static void UsarStreamEntrada()
    {
        string caminhoNovoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\entradaConsole.txt";

        using (var fluxoDeArquivo = Console.OpenStandardInput())
        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var buffer = new byte[1024];

            var bytesLidos = 0;


            while (bytesLidos != 2)
            {
                bytesLidos = fluxoDeArquivo.Read(buffer, 0, buffer.Length);
                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();

                Console.WriteLine($"Byte lidos na console: {bytesLidos}");
            }
        }
    }
}