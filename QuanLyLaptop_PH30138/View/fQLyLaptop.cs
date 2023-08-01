using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLaptop_PH30138.Controler;
using QuanLyLaptop_PH30138.DomainClass;

namespace QuanLyLaptop_PH30138.View
{
   
    public partial class fQLyLaptop : Form
    {
        Service _sev = new Service();
        public fQLyLaptop()
        {
            InitializeComponent();
            cmbHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNSX.DropDownStyle = ComboBoxStyle.DropDownList;
            DataCmb();
            dtgQlyLapTop.CellClick += dtgQlyLapTop_CellContentClick;
            LoadGid();
        }
        public void DataCmb()
        {
            var lstHang = _sev.LstHangs().ToList();
            cmbHang.DataSource = lstHang;
            cmbHang.DisplayMember = "tenHang";
            var lstNSX = _sev.LstNSX().ToList();
            cmbNSX.DataSource = lstNSX;
            cmbNSX.DisplayMember = "tenNSX";
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtMaLaptop.Text)||
                string.IsNullOrEmpty(txtTenLaptop.Text)||
                string.IsNullOrEmpty(txtGiaNiemYet.Text)||
                string.IsNullOrEmpty(txtChietKhau.Text))
            {
                return false;
            }         
            return true;
        }
        public void LoadGid()
        {
            
            int stt = 1;
            dtgQlyLapTop.ColumnCount = 8;
            dtgQlyLapTop.Columns[0].Name = "STT";
            dtgQlyLapTop.Columns[1].Name = "Mã Laptop";
            dtgQlyLapTop.Columns[2].Name = "Tên Laptop";
            dtgQlyLapTop.Columns[3].Name = "Hãng";
            dtgQlyLapTop.Columns[4].Name = "Nơi sản xuất";
            dtgQlyLapTop.Columns[5].Name = "Giá niêm yết";
            dtgQlyLapTop.Columns[6].Name = "Chiết khấu";
            dtgQlyLapTop.Columns[7].Name = "Giá thực";

            dtgQlyLapTop.Rows.Clear();
            
            foreach (var item in _sev.LstLaptop())
            {
                 var giaThuc = item.GiaNiemYet - (item.GiaNiemYet * (Convert.ToDouble(item.ChietKhau) / 100));
                dtgQlyLapTop.Rows.Add(stt++, item.MaLaptop, item.TenLaptop, item.Hang, item.NoiSanXuat, item.GiaNiemYet, item.ChietKhau, giaThuc);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (CheckInput() == true )
            {
                Laptop lap = new Laptop();
                lap.MaLaptop = txtMaLaptop.Text;
                var listMaSV = _sev.LstLaptop().ToList();
                foreach (var item in listMaSV)
                {
                    if (txtMaLaptop.Text == item.MaLaptop)
                    {
                        MessageBox.Show("Mã laptop đã tồn tại!");
                        return;
                    }
                }
                lap.TenLaptop = txtTenLaptop.Text;
                Hang itemHang = cmbHang.SelectedItem as Hang;
                lap.Hang = itemHang.TenHang.ToString();
                NoiSanXuat itemNSX = cmbNSX.SelectedItem as NoiSanXuat;
                lap.NoiSanXuat = itemNSX.TenNsx.ToString();
                lap.GiaNiemYet = Convert.ToDouble(txtGiaNiemYet.Text);
                lap.ChietKhau = Convert.ToInt32(txtChietKhau.Text);
                _sev.ThemLaptop(lap);
                LoadGid();
               
            }
            else
            {
                MessageBox.Show("Không được bỏ trống các trường!"); 
            }
            
        }
        private string _idwhenclick;
        private void dtgQlyLapTop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _idwhenclick = dtgQlyLapTop.CurrentRow.Cells[1].Value.ToString();
            txtMaLaptop.Text = dtgQlyLapTop.CurrentRow.Cells[1].Value.ToString();
            txtTenLaptop.Text = dtgQlyLapTop.CurrentRow.Cells[2].Value.ToString();
            cmbHang.Text = dtgQlyLapTop.CurrentRow.Cells[3].Value.ToString();
            cmbNSX.Text = dtgQlyLapTop.CurrentRow.Cells[4].Value.ToString();
            txtGiaNiemYet.Text = dtgQlyLapTop.CurrentRow.Cells[5].Value.ToString();
            txtChietKhau.Text = dtgQlyLapTop.CurrentRow.Cells[5].Value.ToString();

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            var obj = _sev.LstLaptop().FirstOrDefault(l => l.MaLaptop == _idwhenclick);
            _sev.XoaLaptop(obj);
            LoadGid();
        }
        private void Clear()
        {
            txtMaLaptop.Text = "";
            txtTenLaptop.Text = "";
            txtGiaNiemYet.Text = "";
            txtChietKhau.Text = "";
        }
        private void btnF5_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (CheckInput() == true)
            {
                var lap = _sev.LstLaptop().FirstOrDefault(lp => lp.MaLaptop == txtMaLaptop.Text);
                if (txtMaLaptop.Text != dtgQlyLapTop.CurrentRow.Cells[1].Value.ToString())
                {
                    var listMaSV = _sev.LstLaptop().ToList();
                    foreach (var item in listMaSV)
                    {
                        if (txtMaLaptop.Text == item.MaLaptop)
                        {
                            MessageBox.Show("Mã laptop đã tồn tại!");
                            return;
                        }
                    }
                }
                lap.MaLaptop = txtMaLaptop.Text;
                lap.TenLaptop = txtTenLaptop.Text;
                Hang itemHang = cmbHang.SelectedItem as Hang;
                lap.Hang = itemHang.TenHang.ToString();
                NoiSanXuat itemNSX = cmbNSX.SelectedItem as NoiSanXuat;
                lap.NoiSanXuat = itemNSX.TenNsx.ToString();
                lap.GiaNiemYet = Convert.ToDouble(txtGiaNiemYet.Text);
                lap.ChietKhau = Convert.ToInt32(txtChietKhau.Text);
                _sev.SuaLaptop(lap);
                LoadGid();              
            }
            else
            {
                MessageBox.Show("Không được bỏ trống các trường!");
            }
        }

        private void txtGiaNiemYet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void txtChietKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }
    }
}
