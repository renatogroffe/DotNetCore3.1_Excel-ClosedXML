using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using GerarExcelCotacoes.Models;

namespace GerarExcelCotacoes.Excel
{
    public static class ArquivoExcelCotacoes
    {
        public static string GerarArquivo(
            ExcelConfigurations configurations,
            DateTime dataHoraExtracao,
            List<Cotacao> cotacoes)
        {
            string caminhoArqCotacoes =
                configurations.DiretorioGeracaoArqCotacoes +
                $"Cotacoes {DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}.xlsx";
            File.Copy(configurations.TemplateArqCotacoes, caminhoArqCotacoes);

            using (var workbook = new XLWorkbook(caminhoArqCotacoes))
            {
                var worksheet = workbook.Worksheets.Worksheet("Valores");

                for (int i = 0; i < cotacoes.Count; i++)
                {
                    var cotacao = cotacoes[i];
                    worksheet.Cell("A" + (4 + i)).Value =
                        cotacao.NomeMoeda;
                    worksheet.Cell("B" + (4 + i)).Value =
                        cotacao.ValorReais;
                }
                worksheet.Cell("B9").Value = dataHoraExtracao;

                workbook.Save();
            }

            return caminhoArqCotacoes;
        }
    }
}