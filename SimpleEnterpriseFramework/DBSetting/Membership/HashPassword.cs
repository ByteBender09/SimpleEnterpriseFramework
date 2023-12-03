using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnterpriseFramework.DBSetting.Membership.HashPassword
{
    class HashPassword
    {
        // Hàm băm mật khẩu sử dụng SHA-256
        public static string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Băm mật khẩu
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Chọn một số lượng ký tự từ đầu của chuỗi hash
                int desiredLength = 32;
                string truncatedHash = BitConverter.ToString(hashedBytes, 0, desiredLength / 2).Replace("-", "");

                return truncatedHash;
            }
        }


    }
}
