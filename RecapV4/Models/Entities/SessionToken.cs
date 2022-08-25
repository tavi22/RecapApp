using System.ComponentModel.DataAnnotations;

namespace RecapV4.Models.Entities
{
    public class SessionToken
    {
        public SessionToken() { }

        public SessionToken(string jti, int userId, DateTime expirationDate)
        {
            Jti = jti;
            ExpirationDate = expirationDate;
            UserId = userId;
        }

        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
