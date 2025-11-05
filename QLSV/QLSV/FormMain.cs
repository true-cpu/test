using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class FormMain : Form
    {
        StudentManager manager = new StudentManager();

        public FormMain()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        private void HienThiDanhSach()
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = manager.LayDanhSach();
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearInput()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtLop.Clear();
            txtDiem.Clear();
            txtTimKiem.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtLop.Text) ||
                string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtDiem.Text, out double diem))
            {
                MessageBox.Show("Điểm phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sv = new Student(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), txtLop.Text.Trim(), diem);
            manager.Them(sv);
            HienThiDanhSach();
            ClearInput();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Nhập Mã SV cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtDiem.Text, out double diem))
            {
                MessageBox.Show("Điểm phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sv = new Student(txtMaSV.Text.Trim(), txtHoTen.Text.Trim(), txtLop.Text.Trim(), diem);
            manager.Sua(sv);
            HienThiDanhSach();
            ClearInput();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Nhập Mã SV cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ms = txtMaSV.Text.Trim();
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên mã '{ms}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                manager.Xoa(ms);
                HienThiDanhSach();
                ClearInput();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var keyword = txtTimKiem.Text.Trim();
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = manager.TimKiem(keyword);
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSinhVien.Rows.Count)
            {
                var row = dgvSinhVien.Rows[e.RowIndex];
                // Assuming DataGridView columns are in order: MaSV, HoTen, Lop, Diem
                txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? row.Cells[0].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? row.Cells[1].Value?.ToString();
                txtLop.Text = row.Cells["Lop"].Value?.ToString() ?? row.Cells[2].Value?.ToString();
                txtDiem.Text = row.Cells["Diem"].Value?.ToString() ?? row.Cells[3].Value?.ToString();
            }
        }
    }
}