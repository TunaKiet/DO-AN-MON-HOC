using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offical_winform_quanlybaidang
{
    public class DsTaiKhoan
    {
        private static DsTaiKhoan instance;
        public static DsTaiKhoan Instance 
        {
            get
            {
                if (instance == null)
                    instance = new DsTaiKhoan();
                return instance;
            }
                set => instance = value; 
        }
        List<TaiKhoan> listTaiKhoan;

        public List<TaiKhoan> ListTaiKhoan 
        {
            get => listTaiKhoan; 
            set => listTaiKhoan = value; 
        }
        

        DsTaiKhoan()
        {
            listTaiKhoan = new List<TaiKhoan>();
            listTaiKhoan.Add(new TaiKhoan("Khoa", "123"));
            listTaiKhoan.Add(new TaiKhoan("Kiet", "123"));
            listTaiKhoan.Add(new TaiKhoan("Duc", "123"));
            listTaiKhoan.Add(new TaiKhoan("Huy", "123"));
        }
    }
}
