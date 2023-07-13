using System.Text;

namespace LMSSystemAPI.Helpers
{
    public class MD5
    {
        public static string HashPasswordMD5(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {             
                byte[] hashBytes = md5.ComputeHash(inputBytes);             
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static bool VerifyPasswordMD5(string password, string hashedPassword)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                // So sánh mật khẩu đã hash trong cơ sở dữ liệu với mật khẩu đã nhập
                return sb.ToString() == hashedPassword;
            }
        }
    }
}
