using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClientLibrary
{
    public class WebApiColors_Attributes : Interfaces.IWebApiColorsAsync
    {
        private string BaseURI;

        public WebApiColors_Attributes(string baseURI)
        {
            BaseURI = baseURI;
        }

        private void ConfigDefaultRequestHeaderValues(HttpClient ApiClient)
        {
            ApiClient.BaseAddress = new Uri(BaseURI);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Color> DeleteColor(int id)
        {
            Color Color;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.DeleteAsync($"webapi/colors/Eliminar/{id}");
                HttpResponse.EnsureSuccessStatusCode();
            }

            Color = await HttpResponse.Content.ReadAsAsync<Color>();

            return Color;
        }

        public async Task<Color> GetColorById(int id)
        {
            Color Color;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.GetAsync($"webapi/colors/ConsultaPorId/{id}");
                HttpResponse.EnsureSuccessStatusCode();
            }

            Color = await HttpResponse.Content.ReadAsAsync<Color>();

            return Color;
        }

        public async Task<List<Color>> GetColors()
        {
            throw new NotImplementedException();
        }

        public async Task<Uri> InsertColor(Color color)
        {
            Uri UriColor;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.PutAsJsonAsync<Color>("webapi/colors/Guardar",
                    color);
                HttpResponse.EnsureSuccessStatusCode();
            }

            UriColor = HttpResponse.Headers.Location;

            return UriColor;
        }

        public async Task UpdateColor(int id, Color color)
        {
            HttpResponseMessage HttpResponse;

            using (HttpClient ApiClient = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(ApiClient);

                HttpResponse = await ApiClient.PutAsJsonAsync<Color>($"webapi/colors/Actualizar/{id}",
                    color);

                HttpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
