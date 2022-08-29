using RecapV4.Models.Data;

namespace RecapV4.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RecapContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        private IAddressRepository _address;

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

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public IAddressRepository Address
        {
            get
            {
                if (_address == null) _address = new AddressRepository(_context);
                return _address;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
