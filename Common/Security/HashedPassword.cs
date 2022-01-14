using System;
using System.Security.Cryptography;

namespace Common.Security
{
    public class HashedPassword
    {
        public static string GenerateSaltedHash(int size, string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(size);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return salt + "-" + hashPassword;
        }

        public static bool VerifySaltedPassword(string enteredPassword, string encodedPassword)
        {
            string[] words = encodedPassword.Split('-');
            var saltBytes = Convert.FromBase64String(words[0]);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == words[1];
        }
    }
}
