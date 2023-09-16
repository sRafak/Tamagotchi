using RestSharp;
using System.Text.Json;
using Tamagoichi_Desafio.Model;

namespace Tamagoichi_Desafio.Service
{
    public static class PokemonService
    {
        public static Pokemon BuscaCaracteristica(string especie)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.ToLower()}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            return JsonSerializer.Deserialize<Pokemon>(response.Content);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    Console.WriteLine(response.Content);
            //}
            //else
            //{
            //    Console.WriteLine(response.ErrorMessage);
            //}
            //Console.ReadKey();
        }
    }
}
