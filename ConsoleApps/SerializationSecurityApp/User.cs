using System;
using System.Security.Cryptography;
using System.Text;

namespace SerializationSercurityApp
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string GenerateHash()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(ToString()));
                return Convert.ToBase64String(bytes);
            }
        }

        public void EncryptData()
        {
            Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        }
    }
}