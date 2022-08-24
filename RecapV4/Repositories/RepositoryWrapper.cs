using RecapV4.Models.Data;
using RecapV4.Repositories;

namespace RecapV4.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RecapContext _context;
        private IUserRepository _user;

        public RepositoryWrapper(RecapContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
