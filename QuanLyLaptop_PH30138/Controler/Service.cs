using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLaptop_PH30138.Controler;
using QuanLyLaptop_PH30138.Model.Context;
using QuanLyLaptop_PH30138.DomainClass;
namespace QuanLyLaptop_PH30138.Controler
{
    internal class Service
    {
        Respository _repos = new Respository();
       
        public List<Hang>  LstHangs()
        {
            var dataHang = _repos.GetHangs();
            return dataHang;
        }
        public List<NoiSanXuat> LstNSX()
        {
            var dataNSX = _repos.GetNoiSanXuats();
            return dataNSX;
        }
        public List<Laptop> LstLaptop()
        {
            var dataLaptop = _repos.GetLaptops();   
            return dataLaptop;  
        }
        public void ThemLaptop(Laptop obj)
        {
            if (_repos.AddLaptop(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void XoaLaptop(Laptop obj)
        {
            if (_repos.DeleteLaptop(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public void SuaLaptop(Laptop obj)
        {
            if (_repos.UpdateLaptop(obj) == true)
            {
                MessageBox.Show("Cập nhập thành công");
            }
            else
            {
                MessageBox.Show("Cập nhập thất bại");
            }
        }
    }
}
