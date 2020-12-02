using DAL_DingDoong;
using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_DingDoong
{
   public class BUS_NhanVien
    {
        DAL_NhanVien dALNhanVien = new DAL_NhanVien();
        public DataTable getDanhSachNV()
        {
            return dALNhanVien.getDanhSachNV();
        }

        public DTO_NhanVien curNV(string Email)
        {
            DTO_NhanVien NV = new DTO_NhanVien();
            NV = (from DataRow dr in getDanhSachNV().Rows
                  where string.Compare(dr[1].ToString(), Email, true) == 0
                  select new DTO_NhanVien
                  {
                      MaNV = dr[0].ToString(),
                      TenNV = dr[2].ToString(),
                      Email = dr[1].ToString(),
                      DiaChi = dr[3].ToString(),
                      Quyen = string.Compare(dr[4].ToString(), "Nhân viên", true) == 0 ? 1 : 0,
                    


                  }).FirstOrDefault();
            return NV;

        }

        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dALNhanVien.NhanVienDangNhap(nv);
        }

        //HamMaHoa
        public string Encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();

        }

        //Ham Send Mail
        public void SendMail(string email, string matkhau)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

            NetworkCredential cred = new NetworkCredential("bellben7777@gmail.com", "Baoduong666@@@@");
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("bellben7777@gmail.com");
            Msg.To.Add(email);
            Msg.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";
            Msg.Body = "Mật khẩu mới là " + matkhau;
            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(Msg);


        }

        //Tao chuoi Ngau Nhien
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        //Tao so ngau nhien
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        //Doi Mat Khau
        public bool doiMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            return dALNhanVien.DoiMatKhau(email, matKhauCu, matKhauMoi);
        }

        // Quen Mat Khau
        public bool NhanVienQuenMatKhau(string email)
        {
            return dALNhanVien.NhanVienQuenMatKhau(email);
        }

        //Tao Mat Khau Moi
        public bool updateMK(DTO_NhanVien nv)
        {
            return dALNhanVien.TaoMatKhauMoi(nv);
        }

    }
}
