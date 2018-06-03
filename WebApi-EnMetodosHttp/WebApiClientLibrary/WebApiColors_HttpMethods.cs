using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClientLibrary
{
    public class WebApiColors_HttpMethods : Interfaces.IWebApiColorsAsync
    {
        private string BaseURI;

        public WebApiColors_HttpMethods(string baseURI)
        {
            BaseURI = baseURI;
        }

        public async Task<Color> DeleteColor(int id)
        {
            Color Color;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.DeleteAsync($"api/Colors/{id}");
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
                HttpResponse = await Client.GetAsync($"api/Colors/{id}");
                HttpResponse.EnsureSuccessStatusCode();
            }

            Color = await HttpResponse.Content.ReadAsAsync<Color>();

            return Color;
        }

        public async Task<List<Color>> GetColors()
        {
            List<Color> Colors;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.GetAsync($"api/Colors");
                HttpResponse.EnsureSuccessStatusCode();
            }

            Colors = await HttpResponse.Content.ReadAsAsync<List<Color>>();

            return Colors;
        }

        public async Task<Uri> InsertColor(Color color)
        {
            Uri UriColor;
            HttpResponseMessage HttpResponse;

            using (HttpClient Client = new HttpClient())
            {
                ConfigDefaultRequestHeaderValues(Client);
                HttpResponse = await Client.PostAsJsonAsync<Color>("api/Colors",
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

                HttpResponse = await ApiClient.PutAsJsonAsync<Color>($"api/Colors/{id}",
                    color);

                HttpResponse.EnsureSuccessStatusCode();
            }
        }

        private void ConfigDefaultRequestHeaderValues(HttpClient ApiClient)
        {
            ApiClient.BaseAddress = new Uri(BaseURI);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
