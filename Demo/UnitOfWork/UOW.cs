using Demo.AppContext;
using Demo.GenericRepo;
using Demo.Models;
using Demo.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.UnitOfWork
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _context;
        public UOW(AppDbContext context, IUserRepo user, IGeneric<Category> category, IGeneric<Order> order ,IGeneric<OrderItem> orderitem , IProductRepo product)
        {
            _context = context;
            User = user;
            Category = category;
            Product = product;
            Order = order;
            OrderItem = orderitem;
        }

        public IUserRepo User { get; }
        public IProductRepo Product { get; }

        public IGeneric<Category> Category { get; }
        public IGeneric<Order> Order { get; }
        public IGeneric<OrderItem> OrderItem { get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
