using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Color> DeleteColor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Color> GetColorById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Color>> GetColors()
        {
            throw new NotImplementedException();
        }

        public async Task<Uri> InsertColor(Color color)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateColor(int id, Color color)
        {
            throw new NotImplementedException();
        }
    }
}
