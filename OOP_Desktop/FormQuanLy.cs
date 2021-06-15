﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace OOP_Desktop
{
    public partial class FormQuanLy : Form
    {
        public FormQuanLy()
        {
            InitializeComponent();
            formQlySPLoad();
            
        }

        //Khai báo biến--------------------------------------
        #region Khai báo biến
        BookSmart Sach = new BookSmart("Select MaSach as 'Mã sách', Series as 'Series', MaTL as 'Mã thể loại', TenSach as 'Tên sách', SoLuong as 'Số lượng', GiaBan as 'Giá bán' from dbo.SanPham");
        BookSmart KH = new BookSmart("Select MaKH as 'Mã KH', TenKH as 'Tên khách hàng', GioiTinh as 'Giới tính', Phone as 'SĐT', DiaChi as 'Địa chỉ', Email from dbo.KhachHang");
        BookSmart NV = new BookSmart("Select MaNV as 'Mã NV', TenNV as 'Tên nhân viên', TaiKhoan as 'Tài khoản', MatKhau as 'Mật khẩu', Phone as 'SĐT', DiaChi as 'Địa chỉ' from dbo.NhanVien");
        SQL SQLConnector = new SQL(@"Data Source=BI\SQLEXPRESS;Initial Catalog=SQL_EndOfTerm;Integrated Security=True");
        object[] CellPrivous= new object[3];
        #endregion

        //Các hàm chức năng------------------------------------
        #region Hàm chức năng
        //Hàm chuyển đổi màu button
        public void ChangebtnEffect(string btn)
        {
            int[] color1 = new int[] {33,31,45};
            int[] color2 = new int[] { 11,8,20};
            int[] color3 = new int[] { 67, 231, 192 };
            int[] color4 = new int[] { 255,255,255 };
            //Fill background
            btnDashboard.BackColor = Color.FromArgb(11, 8, 20);
            btnQlySach.BackColor = Color.FromArgb(11, 8, 20);
            btnQlyKH.BackColor = Color.FromArgb(11, 8, 20);
            btnQlyNV.BackColor = Color.FromArgb(11, 8, 20);
            btnQlyDoanhThu.BackColor = Color.FromArgb(11, 8, 20);
            btnDangXuat.BackColor = Color.FromArgb(11, 8, 20);
            //Fill text
            btnDashboard.ForeColor = Color.FromArgb(255, 255, 255);
            btnQlySach.ForeColor = Color.FromArgb(255, 255, 255);
            btnQlyKH.ForeColor = Color.FromArgb(255, 255, 255);
            btnQlyNV.ForeColor = Color.FromArgb(255, 255, 255);
            btnQlyDoanhThu.ForeColor = Color.FromArgb(255, 255, 255);
            btnDangXuat.ForeColor = Color.FromArgb(255, 255, 255);
            //Font Style
            btnDashboard.Font = new Font(btnDashboard.Font, FontStyle.Regular);
            btnQlySach.Font = new Font(btnQlySach.Font, FontStyle.Regular);
            btnQlyKH.Font = new Font(btnQlyKH.Font, FontStyle.Regular);
            btnQlyNV.Font = new Font(btnQlyNV.Font, FontStyle.Regular);
            btnQlyDoanhThu.Font = new Font(btnQlyDoanhThu.Font, FontStyle.Regular);
            btnDangXuat.Font = new Font(btnDangXuat.Font, FontStyle.Regular);
            //Unvisible
            pnlDashboard.Visible = false;
            pnlQlyKH.Visible = false;
            pnlQlySach.Visible = false;
            pnlQlyNV.Visible = false;

            switch (btn)
            {
                case "btnDashboard":
                    {
                        btnDashboard.BackColor = Color.FromArgb(33, 31, 45);
                        btnDashboard.ForeColor = Color.FromArgb(67, 231, 192);
                        btnDashboard.Font = new Font(btnDashboard.Font, FontStyle.Bold);
                        pnlDashboard.Visible = true;
                    };
                    break;
                case "btnQlySach":
                    {
                        btnQlySach.BackColor = Color.FromArgb(33, 31, 45);
                        btnQlySach.ForeColor = Color.FromArgb(67, 231, 192);
                        btnQlySach.Font = new Font(btnQlySach.Font, FontStyle.Bold);
                        pnlQlySach.Visible = true;
                    }
                    break;
                case "btnQlyKH":
                    {
                        pnlQlyKH.Visible = true;
                        btnQlyKH.BackColor = Color.FromArgb(33, 31, 45);
                        btnQlyKH.ForeColor = Color.FromArgb(67, 231, 192);
                        btnQlyKH.Font = new Font(btnQlyKH.Font, FontStyle.Bold);
                    }
                    break;
                case "btnQlyNV":
                    {
                        btnQlyNV.BackColor = Color.FromArgb(33, 31, 45);
                        btnQlyNV.ForeColor = Color.FromArgb(67, 231, 192);
                        btnQlyNV.Font = new Font(btnQlyNV.Font, FontStyle.Bold);
                        pnlQlyNV.Visible = true;
                    }
                    break;
                case "btnQlyDoanhThu":
                    {
                        btnQlyDoanhThu.BackColor = Color.FromArgb(33, 31, 45);
                        btnQlyDoanhThu.ForeColor = Color.FromArgb(67, 231, 192);
                        btnQlyDoanhThu.Font = new Font(btnQlyDoanhThu.Font, FontStyle.Bold);
                    }
                    break;
                case "btnDangXuat":
                    {
                        btnDangXuat.BackColor = Color.FromArgb(33, 31, 45);
                        btnDangXuat.ForeColor = Color.FromArgb(67, 231, 192);
                        btnDangXuat.Font = new Font(btnDangXuat.Font, FontStyle.Bold);
                    }
                    break;

            }
        }
        #endregion

        //Các event chức năng của Form-------------------------
        public void formQlySPLoad()
        {
            txtKhachHang.Text = SQLConnector.Count("dbo.KhachHang").ToString();
            txtDoanhThu.Text = "VNĐ";
        }

        //Event khi chuyển giữa các chức năng
        #region Event khi chuyển qua các chức năng
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Fill và định dạng bảng
            ChangebtnEffect("btnDashboard");
            txtKhachHang.Text = SQLConnector.Count("dbo.KhachHang").ToString();
            
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            // Fill và định dạng bảng
            ChangebtnEffect("btnQlySach");
            dataSach.DataSource = SQLConnector.Select(Sach.Query).Tables[0];
        }

        private void btnQlyKH_Click(object sender, EventArgs e)
        {
            // Fill và định dạng bảng
            ChangebtnEffect("btnQlyKH");
            dataKH.DataSource = SQLConnector.Select(KH.Query).Tables[0];
            
        }

        private void btnQlyNV_Click(object sender, EventArgs e)
        {
            ChangebtnEffect("btnQlyNV");
            dataNV.DataSource = SQLConnector.Select(NV.Query).Tables[0];
        }

        private void btnQlyDoanhThu_Click(object sender, EventArgs e)
        {
            ChangebtnEffect("btnQlyDoanhThu");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            ChangebtnEffect("btnDangXuat"); 
        }
        #endregion

        //Tạo số thứ tự tự động cho bảng datagridview
        #region Tạo số thứ tự cho Bảng
        private void dataSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataSach.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataKH.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataNhanVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataNV.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }
        #endregion

        //Event định dạng layout bảng
        #region Event định dạng layout bảng
        private void dataKH_DataSourceChanged(object sender, EventArgs e)
        {
            dataKH.Columns[2].FillWeight = 140;
            dataKH.Columns[3].FillWeight = 70;
            dataKH.Columns[6].FillWeight = 200;
        }
        #endregion


        //Event tìm kiếm
        #region Event tìm kiếm sách
        private void btnTimKiemSach_Click(object sender, EventArgs e)
        {
            if(btnTimKiemSach.Text == "Tìm kiếm")
            {
                btnTimKiemSach.Text = "Hủy";
                dataSach.DataSource = SQLConnector.Select(Sach.SearchQuery(txtTimKiemSach.Text)).Tables[0];
            }
            else
            {
                btnTimKiemSach.Text = "Tìm kiếm";
                txtTimKiemSach.Text = "Tìm kiếm";
                dataSach.DataSource = SQLConnector.Select(Sach.Query).Tables[0];
            }    
        }

        private void txtTimKiemSach_Click(object sender, EventArgs e)
        {
            txtTimKiemSach.Text = "";
        }
        private void txtTimKiemSach_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemSach.Text == "") txtTimKiemSach.Text = "Tìm kiếm";
        }

        #endregion

        #region Event Tìm kiếm Khách hàng
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (btnTimKiemKH.Text == "Tìm kiếm")
            {
                btnTimKiemKH.Text = "Hủy";
                dataKH.DataSource = SQLConnector.Select(KH.SearchQuery(txtTimKiemKH.Text)).Tables[0];
            }
            else
            {
                btnTimKiemKH.Text = "Tìm kiếm";
                txtTimKiemKH.Text = "Tìm kiếm";
                dataKH.DataSource = SQLConnector.Select(KH.Query).Tables[0];
            }
        }

        private void txtTimKiemKH_Click(object sender, EventArgs e)
        {
            txtTimKiemKH.Text = "";
        }

        private void txtTimKiemKH_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemKH.Text == "") txtTimKiemKH.Text = "Tìm kiếm";
        }


        #endregion

        #region Event tìm kiếm nhân viên
        #endregion


        // Event thêm, sửa xóa
        #region Thêm, sửa, xóa Sách
        private void btnXoaSach_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            if (btnSuaSach.Text == "Sửa")
            {
                CellPrivous[0] = dataSach.CurrentCell.Value.ToString();
                CellPrivous[1] = dataSach.CurrentCell.RowIndex;
                CellPrivous[2] = dataSach.CurrentCell.ColumnIndex;
                dataSach.ReadOnly = false;
                dataSach.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                btnSuaSach.Text = "Hủy";
            }
            else
            {
                dataSach.Rows[(int)CellPrivous[1]].Cells[(int)CellPrivous[2]].Value = CellPrivous[0];
                dataSach.ReadOnly = true;
                btnSuaSach.Text = "Sửa";
            }

        }

        private void dataSach_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataSach.ReadOnly = true;
            if (btnSuaSach.Text == "Hủy")
            {
                btnSuaSach.Text = "Sửa";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Bạn có muốn lưu thay đổi", "BookSmart", button);
                if (result == DialogResult.Yes)
                {
                    string query = "UPDATE dbo.SanPham SET ";
                    query += Sach.Field()[(int)CellPrivous[2] - 1] + " = N'" + (string)CellPrivous[0] + "' Where " + Sach.Field()[0] + " = N'" + dataSach.Rows[(int)CellPrivous[2]].Cells[1].Value.ToString() + "'";
                    SQLConnector.ExcuteQuery(query);
                    dataSach.DataSource = SQLConnector.Select(Sach.Query);
                }
                else dataSach.Rows[(int)CellPrivous[1]].Cells[(int)CellPrivous[2]].Value = CellPrivous[0];
            }

        }
        #endregion

        #region Thêm, sửa xóa Khách hàng

        #endregion

        #region Thêm, sửa xóa Nhân Viên

        #endregion





    }
}
