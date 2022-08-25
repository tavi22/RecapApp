using Microsoft.EntityFrameworkCore;
using RecapV4.Models.Data;
using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(RecapContext context) : base(context) { }

        public async Task<SessionToken> GetByJti(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
