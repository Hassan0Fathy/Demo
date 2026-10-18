using Demo.GenericRepo;
using Demo.Models;
using Demo.Repos.Interfaces;

namespace Demo.UnitOfWork
{
    public interface IUOW
    {
        IProductRepo Product { get; }
        IUserRepo User { get; }
        IGeneric<Category> Category { get; }
        IGeneric<Order> Order { get; }
        IGeneric<OrderItem> OrderItem { get; }
        Task Save();
    }
}
