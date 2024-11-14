// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Linq;
class Program{
static void Main(string[] args)
    {
        // Caminho do diretório onde estão os arquivos .yml
        // /home/mac/docker-project/AtualizacaoDocker/UpdateYml
        string directoryPath = @"/home/mac/docker-project/"; // Alterar para o caminho correto
        // Verificar se o diretório existe
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Diretório não encontrado.");
            return;
        }
        // Buscar todos os arquivos .yml no diretório e subdiretórios
        string[] files = Directory.GetFiles(directoryPath, "*.yml", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            Console.WriteLine($"Processando arquivo: {file}");
            // Ler todas as linhas do arquivo
            string[] lines = File.ReadAllLines(file);
            // Remover a linha que contém 'version: "3"'
            var updatedLines = lines.Where(line => !line.Contains("version: '3'")).ToArray();
            // Verificar se houve modificação
            if (updatedLines.Length != lines.Length)
            {
                // Sobrescrever o arquivo com as linhas atualizadas
                File.WriteAllLines(file, updatedLines);
                Console.WriteLine($"Linha removida do arquivo: {file}");
            }
        }
        Console.WriteLine("Processamento concluído.");
    }

}
