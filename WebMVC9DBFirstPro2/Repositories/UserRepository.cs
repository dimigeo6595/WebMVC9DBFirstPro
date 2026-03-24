using System.Linq.Expressions;
using WebMVC9DBFirstPro2.Core;
using WebMVC9DBFirstPro2.Data;
using WebMVC9DBFirstPro2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebMVC9DBFirstPro2.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SchoolMvc9proContext context) : base(context) 
        { 
        }


        public async Task<User?> GetUserByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username || u.Email == username);

        public async Task<PaginatedResult<User>> GetUserByUsernameAsync(int pageNumber, int pageSize, List<Expression<Func<User, bool>>> predicates)
        {
            int totalRecords;
            IQueryable<User> query = _context.Users;

            if (predicates != null && predicates.Count > 0)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }

            }

            totalRecords = await query.CountAsync();
            int skip = (pageNumber - 1) * pageSize;

            var data = await query 
                .OrderBy(u => u.Id)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<User>()
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
