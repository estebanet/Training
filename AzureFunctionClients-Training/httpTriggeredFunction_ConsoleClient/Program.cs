using httpTriggeredFunction_ConsoleClient.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace httpTriggeredFunction_ConsoleClient
{
    class Response
    {
        public string Message { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando consumo de Http Triggered Azure Function");
            Task<HttpResponseMessage> Response =
                TriggeredAzureFunction();
            string ResultText;

            if (Response.Result != null)
            {
                Response.Wait();
                var Result = Response.Result.Content.ReadAsAsync(typeof(string));
                Result.Wait();
                ResultText = Result.Result.ToString();
            }
            else
            {
                ResultText = "No disponible";
            }

            Console.WriteLine("Finalizando consumo de Http Triggered Azure Function");
            Console.WriteLine($"Resultado: {ResultText}");
            Console.Read();
        }

        static async Task<HttpResponseMessage> TriggeredAzureFunction()
        {
            HttpResponseMessage Response;

            try
            {
                using (HttpClient httpTriggeredFnClient = new HttpClient())
                {
                    httpTriggeredFnClient.BaseAddress = new Uri($"{AppConfig.BaseAddress}/");
                    httpTriggeredFnClient.DefaultRequestHeaders.Accept.Clear();
                    httpTriggeredFnClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpRequestMessage rm = new HttpRequestMessage();

                    Response = await
                        httpTriggeredFnClient.PostAsJsonAsync($"{AppConfig.RequestURI}?code={AppConfig.ClientTestKey}",
                        new
                        {
                            Nombre = "Croacia",
                            Id = 8,
                            Campeonatos = 0,
                            Apodo = "Los amigos de Luca"
                        });
                    //httpTriggeredFnClient
                    //    .GetAsync($"api/HttpTriggerCSharp1?code=YeHliYJaFGAVz2eaZaZLmAU6zZtCUz/klZEvmFPq3jxrl9wqxev1Lw==&nombre={name}");

                    Response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido una excepción durante el consumo de la Azure Function{Environment.NewLine}" +
                    $"Error: {ex.Message}");
                Response = null;
            }

            return Response;
        }
    }
}
