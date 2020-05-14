using System.Collections.Generic;
using GerarExcelCotacoes.Models;

namespace GerarExcelCotacoes.Data
{
    public static class CotacoesRepository
    {
        public static List<Cotacao> GetAll()
        {
            var dados = new List<Cotacao>();

            dados.Add(new Cotacao()
            {
                Codigo = "USD",
                NomeMoeda = "Dolar Norte-Americano",
                ValorReais = 5.901
            });

            dados.Add(new Cotacao()
            {
                Codigo = "EUR",
                NomeMoeda = "Euro",
                ValorReais = 6.371
            });

            dados.Add(new Cotacao()
            {
                Codigo = "LIB",
                NomeMoeda = "Libra Esterlina",
                ValorReais = 7.204
            });

            dados.Add(new Cotacao()
            {
                Codigo = "PES",
                NomeMoeda = "Peso Argentino",
                ValorReais = 0.087
            });

            return dados;
        }
    }
}