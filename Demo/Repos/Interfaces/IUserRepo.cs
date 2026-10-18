using Demo.GenericRepo;
using Demo.Models;

namespace Demo.Repos.Interfaces
{
    public interface IUserRepo :IGeneric<User>
    {
        Task<User> GetByEmail(string email);
    }
}
