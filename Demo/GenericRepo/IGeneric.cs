namespace Demo.GenericRepo
{
    public interface IGeneric<T> where T :class
    {
        Task<T> GetById(int id);
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<ICollection<T>> GetAllAsync();
    }
}
