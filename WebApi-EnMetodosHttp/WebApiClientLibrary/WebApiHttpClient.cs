using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClientLibrary
{
    public class WebApiHttpClient
    {
        private Interfaces.IWebApiColorsAsync WebApiColors;

        public WebApiHttpClient(string baseURI, 
            Enums.tipo_enrutamiento tipo_Enrutamiento)
        {
            switch (tipo_Enrutamiento)
            {
                case Enums.tipo_enrutamiento.METODOS_HTTP:
                    WebApiColors = new WebApiColors_HttpMethods(baseURI);
                    break;
                case Enums.tipo_enrutamiento.NOMBRES_ACCIONES:
                    WebApiColors = new WebApiColors_ActionNames(baseURI);
                    break;
                case Enums.tipo_enrutamiento.ATRIBUTO:
                    WebApiColors = new WebApiColors_Attributes(baseURI);
                    break;
            }
        }

        public async Task<List<Color>> GetColors()
        {
            List<Color> Colors;
            Colors = await WebApiColors.GetColors();

            return Colors;
        }

        public async Task<Color> GetColorById(int id)
        {
            Color Color;
            Color = await WebApiColors.GetColorById(id);

            return Color;
        }

        public async Task UpdateColor(int id, Color color)
        {
            await WebApiColors.UpdateColor(id, color);
        }

        public async Task<Uri> InsertColor(Color color)
        {
            Uri Uri;
            Uri = await WebApiColors.InsertColor(color);

            return Uri;
        }

        public async Task<Color> DeleteColor(int id)
        {
            Color Color;
            Color = await WebApiColors.DeleteColor(id);

            return Color;
        }
    }
}
