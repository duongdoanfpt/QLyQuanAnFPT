using DAL_DingDoong;
using DTO_DingDoong;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
                      Email = dr[1].ToString()


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

    }
}
