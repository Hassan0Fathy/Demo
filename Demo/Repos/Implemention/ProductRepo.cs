using Demo.AppContext;
using Demo.GenericRepo;
using Demo.Models;
using Demo.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repos.Implemention
{
    public class ProductRepo : Generic<Product>, IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<ICollection<Product>> GetByFilter(int? categoryId, int? pageNumber, int? pageSize, int? Price)
        {
            var query =  _context.Products.AsQueryable();
            if(categoryId!= null)
            {
                query = query.Where(a => a.CategoryId == categoryId);
            }
            if(pageNumber!= null && pageSize != null)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            if(Price != null)
            {
                query = query.OrderByDescending(a => a.Price >= Price);
            }
            return await query.ToListAsync();
        }

        public async Task<Product> GetSecondMostPriceByCategoryId(int categoryId)
        {
            var search = await _context.Products.Where(a => a.CategoryId == categoryId).OrderByDescending(a => a.Price).Skip(1).Take(1).FirstOrDefaultAsync();
            return  search;
        }

        public async Task<Product> SearchByName(string name)
        {
            var search = await _context.Products.Where(s => s.ProductName == name).FirstOrDefaultAsync();
            return search;
        }
    }
}
