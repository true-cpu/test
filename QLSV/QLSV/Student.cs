using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class Student
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public double Diem { get; set; }

        public Student(string maSV, string hoTen, string lop, double diem)
        {
            MaSV = maSV;
            HoTen = hoTen;
            Lop = lop;
            Diem = diem;
        }

    }
}
