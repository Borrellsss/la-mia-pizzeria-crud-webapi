using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repositories
{
    public class DbCategoryRepository : IDbCategoryRepository
    {
        private PizzeriaDbContext db;
        public DbCategoryRepository(PizzeriaDbContext _db)
        {
            db = _db;
        }
        public List<Category> GetAll(bool pizzas)
        {
            if (pizzas)
            {
                return db.Categories.Include("Pizzas").ToList();
            }

            return db.Categories.ToList();
        }
    }
}