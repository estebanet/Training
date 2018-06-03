using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClientLibrary.Interfaces
{
    public interface IWebApiColorsAsync
    {
        Task<List<Color>> GetColors();

        Task<Color> GetColorById(int id);

        Task UpdateColor(int id, Color color);

        Task<Uri> InsertColor(Color color);

        Task<Color> DeleteColor(int id);
    }
}
