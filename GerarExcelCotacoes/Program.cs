using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using GerarExcelCotacoes.Excel;
using GerarExcelCotacoes.Data;

namespace GerarExcelCotacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando configurações...");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            DateTime dataHoraExtracao = DateTime.Now;
            var excelConfigurations = new ExcelConfigurations();
            new ConfigureFromConfigurationOptions<ExcelConfigurations>(
                configuration.GetSection("ExcelConfigurations"))
                    .Configure(excelConfigurations);

            Console.WriteLine("Gerando o arquivo .xlsx (Excel) com as cotações...");

            string arquivoXlsx = ArquivoExcelCotacoes.GerarArquivo(
                excelConfigurations, dataHoraExtracao,
                CotacoesRepository.GetAll());
            Console.WriteLine($"O arquivo {arquivoXlsx} foi gerado com sucesso!");
        }
    }
}