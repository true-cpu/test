using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class StudentManager
    {
        private List<Student> danhSach = new List<Student>();

        public List<Student> LayDanhSach() => danhSach;

        public void Them(Student sv)
        {
            danhSach.Add(sv);
        }

        public void Xoa(string maSV)
        {
            var sv = danhSach.FirstOrDefault(s => s.MaSV == maSV);
            if (sv != null)
                danhSach.Remove(sv);
        }

        public void Sua(Student svMoi)
        {
            var sv = danhSach.FirstOrDefault(s => s.MaSV == svMoi.MaSV);
            if (sv != null)
            {
                sv.HoTen = svMoi.HoTen;
                sv.Lop = svMoi.Lop;
                sv.Diem = svMoi.Diem;
            }
        }

        public List<Student> TimKiem(string keyword)
        {
            return danhSach
                .Where(s => s.HoTen.ToLower().Contains(keyword.ToLower()) || s.MaSV.Contains(keyword))
                .ToList();
        }
    }
}
