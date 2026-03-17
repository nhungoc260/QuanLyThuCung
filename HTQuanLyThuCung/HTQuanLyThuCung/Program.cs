using HTQuanLyThuCung;
using HTQuanLyThuCung.Helpers;
using QuanLyThuCung;
using System;
using System.Windows.Forms;

namespace HTQuanLyThuCung
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmKhachHang khachHangForm = new frmKhachHang();
            FontHelper.SetUnicodeFont(khachHangForm);
            Application.Run(khachHangForm);

            
          
        }
    }
}