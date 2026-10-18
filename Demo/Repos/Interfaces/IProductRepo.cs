using Demo.GenericRepo;
using Demo.Models;

namespace Demo.Repos.Interfaces
{
    public interface IProductRepo : IGeneric<Product>
    {
        Task<ICollection<Product>> GetByFilter(int? categoryId, int? pageNumber, int? pageSize, int? Price);
        Task<Product> GetSecondMostPriceByCategoryId(int categoryId);
        Task<Product> SearchByName(string name);
    }
}
