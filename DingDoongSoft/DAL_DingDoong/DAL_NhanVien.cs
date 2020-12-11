using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_DingDoong;

namespace DAL_DingDoong
{
    public class DAL_NhanVien:Dbconnect
    {
        public DataTable getDanhSachNV() //GET ALL NHANVIEN
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_DanhSachNV";
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cm.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Show All danh sách nhân viên
        public DataTable DanhSachNhanVienAll()
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_DanhSachAllNV";
                DataTable dtNhanVienALL = new DataTable();
                dtNhanVienALL.Load(cm.ExecuteReader());
                return dtNhanVienALL;
            }
            finally
            {
                _conn.Close();
            }
        }

        // DANGNHAP
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DangNhap";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matKhau", nv.MatKhau);

                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Doi Mat Khau
        public bool DoiMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DoiMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@opwd", matKhauCu);
                cmd.Parameters.AddWithValue("@npwd", matKhauMoi);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }

            finally
            {
                _conn.Close();
            }
            return false;
        }

        // DoiMK tu mail
        public bool TaoMatKhauMoi(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_TaoMatKhauMoi";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matkhau", nv.MatKhau);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Phan Quen Mat Khau
        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);

                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Insert NhanVien
        public bool insertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertNhanVien";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("tennv", nv.TenNV);
                cmd.Parameters.AddWithValue("diachi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaitro", nv.Quyen);
                cmd.Parameters.AddWithValue("NgayVaoLam", nv.NgayVL);
                cmd.Parameters.AddWithValue("TinhTrang", nv.TrangThai);
                cmd.Parameters.AddWithValue("Hinh", nv.Hinh);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //GET Hình NV
        public byte[] GetHinhNV(string manv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_gethinhNV";
                cmd.Parameters.AddWithValue("manv", manv);

                var hinh = (byte[])cmd.ExecuteScalar();
                return hinh;

            }

            catch
            {
                return null;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Xoa nhan vien
        public bool XoaNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_DeleteNhanVien";
                cmd.Parameters.AddWithValue("email", email);


                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }

            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Cap nhat nhan vien
        public bool CapNhatNhanVien(string MaNV, DTO_NhanVien td)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_UpdateNhanVien";
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("email", td.Email);
                cmd.Parameters.AddWithValue("tenNv", td.TenNV);
                cmd.Parameters.AddWithValue("diaChi", td.DiaChi);
                cmd.Parameters.AddWithValue("vaiTro", td.Quyen);
                cmd.Parameters.AddWithValue("tinhTrang", td.TrangThai);
                cmd.Parameters.AddWithValue("NgayVaoLam", td.NgayVL);
                cmd.Parameters.AddWithValue("Hinh", td.Hinh);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Cap nhat tinh trang nhân viên
        public bool CapNhatTinhTrang(string MaNV)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_UpdateNV_Enable";
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Tim kiem nhan vien
        public DataTable SearchNhanVien(string tenNhanVien)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_SearchNhanVien";
                cm.Connection = _conn;
                cm.Parameters.AddWithValue("tenNv", tenNhanVien);
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cm.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                _conn.Close();
            }
        }



    }
}
