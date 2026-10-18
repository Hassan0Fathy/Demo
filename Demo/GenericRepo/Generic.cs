using Demo.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Demo.GenericRepo
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public Generic(AppDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var search = await _dbset.FindAsync(id);
            return search;
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
