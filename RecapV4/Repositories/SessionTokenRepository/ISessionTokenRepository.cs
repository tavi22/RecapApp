using RecapV4.Models.Entities;

namespace RecapV4.Repositories
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJti(string jti);
    }
}
