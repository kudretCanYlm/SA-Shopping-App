using SA.Domain.Base;
using SA.Domain.Domains.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SA.Domain.Domains.Auth
{
    //will add logs for per IP
    public class LoginEntity : BaseEntity
    {
        public LoginEntity() : base()
        {

        }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public Guid UserId { get; set; }
        public RoleEnum Role { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Username;
            yield return Password;
        }

        public void ToHashPassword()
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(this.Password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                this.Password = builder.ToString();
            }
        }
        public static string ToHashPassword(string value)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
