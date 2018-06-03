using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_EnMetodosHttp.Models
{
    public class ColorsActionsLogic
    {
        public async Task<Color> GetColorById(int id)
        {
            Color color;
            using (ColorsDbContext db = new ColorsDbContext())
            {
                color = await db.Colors.FindAsync(id);
            }

            return color;
        }

        public async Task<Color> PostColor(Color color)
        {
            using (ColorsDbContext db = new ColorsDbContext())
            {
                db.Colors.Add(color);
                await db.SaveChangesAsync();
            }

            return color;
        }

        public async Task UpdateColor(Color color)
        {
            using (ColorsDbContext db = new ColorsDbContext())
            {
                db.Entry(color).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Color> DeleteColor(int id)
        {
            Color color;
            using (ColorsDbContext db = new ColorsDbContext())
            {
                color = await db.Colors.FindAsync(id);
                if (color == null)
                {
                    throw new Exception();
                }

                db.Colors.Remove(color);
                await db.SaveChangesAsync();
            }

            return color;
        }

        public async Task<bool> ColorExists(int id)
        {
            int idColor;

            idColor = await Task.Run<int>(() =>
            {
                int idC;
                using (ColorsDbContext db = new ColorsDbContext())
                {
                    idC = db.Colors.Count(e => e.Id == id);
                }
                return idC;
            });

            return idColor > 0;
        }
    }
}