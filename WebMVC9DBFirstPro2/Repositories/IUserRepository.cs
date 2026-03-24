using System.Linq.Expressions;
using WebMVC9DBFirstPro2.Core;
using WebMVC9DBFirstPro2.Models;

namespace WebMVC9DBFirstPro2.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);

        Task<PaginatedResult<User>> GetUserByUsernameAsync(int pageNumber, int pageSize, 
            List<Expression<Func<User, bool>>> predicates);

    }
}
