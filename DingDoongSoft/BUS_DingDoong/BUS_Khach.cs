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
    public class BUS_Khach
    {
        DAL_Khach dalKhach = new DAL_Khach();

        public DataTable getKhach()
        {
            return dalKhach.getKhach();
        }

        public DataTable getKhachMail()
        {
            return dalKhach.getKhachMail();
        }

        //Ham Send Mail
        public bool SendMail(string email, MailMessage msg)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);

                NetworkCredential cred = new NetworkCredential("duongdtbps11905@fpt.edu.vn", "Baoduong666@@@@");

                msg.From = new MailAddress("duongdtbps11905@fpt.edu.vn");
                msg.To.Add(email);
                msg.Subject = "CHƯƠNG TRÌNH KHUYẾN MÃI - TRI ÂN KHÁCH HÀNG";
                msg.Body = "aaa";
                client.EnableSsl = true;
                client.Send(msg);

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
          
            
            

        }

        public bool insertKhach(DTO_Khach khach)
        {
            return dalKhach.insertKhach(khach);
        }

        public DTO_Khach curKhach(string SDT_KH)
        {
            DTO_Khach khach = (from DataRow dr in dalKhach.getKhach().Rows
                               where string.Compare(dr[0].ToString(), SDT_KH, true) == 0
                               select new DTO_Khach
                               {
                                   SDT = dr[0].ToString(),
                                   TenKH = dr[1].ToString(),
                                   Email = dr[2].ToString(),
                                   GioiTinh = string.Compare(dr[3].ToString(), "Nam", true) == 0 ? 1 : 0,
                                   NgaySinh = (DateTime)dr[4]
                               }).FirstOrDefault();
            return khach;
        }

        public bool UpdateKhach(DTO_Khach khach)
        {
            return dalKhach.UpdateKhach(khach);
        }
        public DataTable SearchKhach(string sdt)
        {
            return dalKhach.SearchKhach(sdt);
        }
    }
}
