﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_DingDoong;


namespace DAL_DingDoong
{
    public class DAL_Ban:Dbconnect
    {
        public DataTable DanhSachBan()
        {
            
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_DanhSachBan";
                cm.Connection = _conn;
                DataTable dtBan = new DataTable();
                dtBan.Load(cm.ExecuteReader());
                return dtBan;
            }
            finally
            {

                _conn.Close();
            }
        }

        public bool UpdateTrangThaiBan(int IdBan,int TrangThai)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_updateBan";
                cm.Parameters.AddWithValue("IdBan", IdBan);
                cm.Parameters.AddWithValue("TrangThai", TrangThai);
                if (cm.ExecuteNonQuery() > 0)
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

        public DataTable rptHoaDon(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "getHDinfo";
                cm.Parameters.AddWithValue("MaHD", MaHD);
                cm.Connection = _conn;
                DataTable dtHD = new DataTable();
                dtHD.Load(cm.ExecuteReader());
                return dtHD;
            }
            finally
            {

                _conn.Close();
            }
        }

        public DataTable rptHoaDonChitiet(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetListTD";
                cm.Parameters.AddWithValue("MaHD", MaHD);
                cm.Connection = _conn;
                DataTable dtHDCT = new DataTable();
                dtHDCT.Load(cm.ExecuteReader());
                return dtHDCT;
            }
            finally
            {

                _conn.Close();
            }
        }



        public bool ThemHoaDonTam(DTO_HoaDon hd)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_insertHDTemp";
                cm.Parameters.AddWithValue("MaHD", hd.MaHD);
                cm.Parameters.AddWithValue("IdBan", hd.IdBan);
                cm.Parameters.AddWithValue("TrangThai", hd.TrangThai);
                DateTime date = DateTime.Now;
                cm.Parameters.AddWithValue("NgayBatDau", date);
                if (cm.ExecuteNonQuery() > 0)
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

        public bool ThemHoaDonFinal(DTO_HoaDon hd)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_ThemHD";
                cm.Parameters.AddWithValue("MaHD", hd.MaHD);
                cm.Parameters.AddWithValue("MaNV", hd.MaNV);
                cm.Parameters.AddWithValue("sdtkh", hd.SDT_KH);
                        
                cm.Parameters.AddWithValue("IdBan",hd.IdBan);

                cm.Parameters.AddWithValue("KhuyenMai", hd.KhuyenMai);
                
                if (cm.ExecuteNonQuery() > 0)
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

        public bool ThemHoaDonFinalNoneKH(DTO_HoaDon hd)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Sp_ThemHD";
                cm.Parameters.AddWithValue("MaHD", hd.MaHD);
                cm.Parameters.AddWithValue("MaNV", hd.MaNV);
                cm.Parameters.AddWithValue("sdtkh", DBNull.Value);

                cm.Parameters.AddWithValue("IdBan", hd.IdBan);

                cm.Parameters.AddWithValue("KhuyenMai", hd.KhuyenMai);

                if (cm.ExecuteNonQuery() > 0)
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

        public bool ThemCTHDFinal(DTO_CTHD cthd)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_insertCTHD";
                cm.Parameters.AddWithValue("MaHD", cthd.MaHD);
                cm.Parameters.AddWithValue("MaTD", cthd.MaTD);
                cm.Parameters.AddWithValue("SoLuong", cthd.SoLuong);
                cm.Parameters.AddWithValue("MoTa", cthd.GhiChu);


                if (cm.ExecuteNonQuery() > 0)
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

        public bool ThemChiTietHoaDonTam(DTO_CTHD cthd)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_themCTHDTam";
                cm.Parameters.AddWithValue("MaHD", cthd.MaHD);
                cm.Parameters.AddWithValue("MaTD", cthd.MaTD);
                cm.Parameters.AddWithValue("SoLuong", cthd.SoLuong);
                cm.Parameters.AddWithValue("MoTa", cthd.GhiChu);
                
               
                if (cm.ExecuteNonQuery() > 0)
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

        public DataTable HoaDonTam(int idBan)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "sp_laydanhsachHDtam";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("IdBan", idBan);
                cm.Connection = _conn;
                DataTable dtHD = new DataTable();
                dtHD.Load(cm.ExecuteReader());
                return dtHD;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable DanhSachHDCTTam(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "sp_layDanhSachHDCTtam";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("MaHD", MaHD);
                cm.Connection = _conn;
                DataTable dtHD = new DataTable();
                dtHD.Load(cm.ExecuteReader());
                return dtHD;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable LayHDCTFinal(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "sp_laydanhsachHDCTFinal";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("MaHD", MaHD);
                cm.Connection = _conn;
                DataTable dtHD = new DataTable();
                dtHD.Load(cm.ExecuteReader());
                return dtHD;
            }
            finally
            {
                _conn.Close();
            }
        }

        public float TongTienHDTam(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = _conn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_TongtienHDTamKM";
                cm.Parameters.AddWithValue("MaHD", MaHD);

                return (cm.ExecuteScalar() is null ? 0 : float.Parse(cm.ExecuteScalar().ToString()));

            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool UpdateKMtoHD(string MaHD, float ChietKhau)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_themKMvaoHD";
                cmd.Parameters.AddWithValue("MaHd", MaHD);
                cmd.Parameters.AddWithValue("ChietKhau", ChietKhau);


                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateKHtoHD(string MaHD, string SDTKH)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_updateKHtoHDtam";
                cmd.Parameters.AddWithValue("MaHd", MaHD);
                cmd.Parameters.AddWithValue("SDT_KH", SDTKH);


                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool ClearTemp(string MaHD)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "clearTemp";
                cmd.Parameters.AddWithValue("MaHD", MaHD);
             


                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }


    }
}
