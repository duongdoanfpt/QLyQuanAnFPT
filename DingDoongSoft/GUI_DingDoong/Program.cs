using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_DingDoong
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
            //Application.Run(new FormLogin());
<<<<<<< HEAD
            Application.Run(new FormNhanVien());
=======
            Application.Run(new FormKhachHang());
>>>>>>> 872699f7ef0ffd326197f09a48f702f80df403fa
        }
    }
}
