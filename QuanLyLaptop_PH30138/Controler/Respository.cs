using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLaptop_PH30138.DomainClass;
using QuanLyLaptop_PH30138.Model.Context;

namespace QuanLyLaptop_PH30138.Controler
{
    internal class Respository
    {
        DBContext _context;
        public Respository()
        {
            _context = new DBContext();
        }
        public List<Hang> GetHangs()
        {
            List<Hang> lstHang = _context.Hangs.ToList();
            return lstHang;
        }
        public List<NoiSanXuat> GetNoiSanXuats()
        {
            List<NoiSanXuat> lstNSX = _context.NoiSanXuats.ToList();
            return lstNSX;
        }
        public List<Laptop> GetLaptops()
        {
            List<Laptop> lstLaptop = _context.Laptops.ToList();
            return lstLaptop;
        }
        public bool AddLaptop(Laptop laptop)
        {
            if (laptop == null)
            {
                return false;
            }
            else
            {
                laptop.GuidId = Guid.NewGuid();
                _context.Add(laptop);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteLaptop(Laptop laptop)
        {
            if (laptop == null)
            {
                return false;
            }
            else
            {
               
                _context.Remove(laptop);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateLaptop(Laptop laptop)
        {
            if (laptop == null)
            {
                return false;
            }
            else
            {
                _context.Update(laptop);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
