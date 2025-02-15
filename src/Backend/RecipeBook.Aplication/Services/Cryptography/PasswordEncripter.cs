using System.Security.Cryptography;
using System.Text;

namespace RecipeBook.Aplication.Services.Cryptography
{
    public class PasswordEncripter
    {
        public string Encrypt(string password)
        {   var salt = "#-12";
            var newPassword = $"{password}{salt}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);
            return StringByteConverter(hashBytes);
        }
        private static string StringByteConverter(byte[] data)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in data)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
