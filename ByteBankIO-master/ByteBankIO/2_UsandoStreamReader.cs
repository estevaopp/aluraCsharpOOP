using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamReader()
    {
        string enderecoDoArquivo = "C:\\Users\\estev\\Desktop\\ByteBankIO-master\\ByteBankIO-master\\contas.txt";
        using (FileStream fluxoDeDados = new FileStream(enderecoDoArquivo, FileMode.Open))
        using (StreamReader leitor = new StreamReader(fluxoDeDados))
        {
            //var arquivoCompleto = leitor.ReadToEnd();
            //Console.WriteLine(arquivoCompleto);

            //var linha = leitor.ReadLine();
            //Console.WriteLine(linha);

            //linha = leitor.ReadLine();
            //Console.WriteLine(linha);

            //var umByte = leitor.Read();
            //Console.WriteLine(umByte);

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                ContaCorrente contaCorrente = ConverterStringParaContaCorrente(linha);
                var msg = $"{contaCorrente.Titular.Nome}: numero {contaCorrente.Numero}, agencia {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campos = linha.Split(",");
        int agencia = int.Parse(campos[0]);
        int numero = int.Parse(campos[1]);
        double saldoComoDouble = double.Parse(campos[2].Replace(".", ","));
        string titular = campos[3];

        ContaCorrente resultado = new ContaCorrente(agencia, numero);
        resultado.Depositar(saldoComoDouble);
        resultado.Titular = new Cliente();
        resultado.Titular.Nome = titular;

        return resultado;
    }
}