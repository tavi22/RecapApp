using Microsoft.AspNetCore.Authentication.JwtBearer;
using RecapV4.Repositories;
using System.IdentityModel.Tokens.Jwt;

namespace RecapV4.Helpers
{
    public class SessionTokenValidator
    {
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<IRepositoryWrapper>();

            if (context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {
                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                var tokenInDb = await repository.SessionToken.GetByJti(jti);

                if (tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }

                context.Fail("");
            }
        }
    }
}
