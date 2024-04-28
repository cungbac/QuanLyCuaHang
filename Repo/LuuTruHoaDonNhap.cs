using System;
using Entities;

namespace Repo
{
    public class LuuTruHoaDonNhap : ILuuTruHoaDonNhap
    {
        public string GetFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;

            string dataFolder = "Repo/Data";
            string fileName = "hoadonnhaphang.txt";

            string filePath = Path.Combine(projectDirectory, dataFolder, fileName);

            return filePath;
        }

        public List<HoaDonNhapHang> DocDanhSachHoaDonNhap()
        {
            string filePath = GetFilePath();

            List<HoaDonNhapHang> dsHoaDonNhap = new List<HoaDonNhapHang>();
            StreamReader reader = new StreamReader(filePath);

            int n;
            string s = reader.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                dsHoaDonNhap.Add(new HoaDonNhapHang(s));
            }
            reader.Close();

            return dsHoaDonNhap;
        }
        public void LuuDanhSachHoaDonNhap(List<HoaDonNhapHang> dsHoaDonNhap)
        {
            string filePath = GetFilePath();
            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine(dsHoaDonNhap.Count());
            foreach (var hoaDonNhap in dsHoaDonNhap)
            {
                writer.WriteLine($"" +
                    $"{hoaDonNhap.MaHoaDon}," +
                    $"{hoaDonNhap.NgayTao}," +
                    $"{hoaDonNhap.NgayCapNhat}," +
                    $"{hoaDonNhap.MaHang}," +
                    $"{hoaDonNhap.TenHang}," +
                    $"{hoaDonNhap.SoLuong}," +
                    $"{hoaDonNhap.GiaNhap}," +
                    $"{hoaDonNhap.ThanhTien}"
                );
            }
            writer.Close();
        }
        public void ThemHoaDonNhap(HoaDonNhapHang hoaDonNhap)
        {
            List<HoaDonNhapHang> dsHoaDonNhap = DocDanhSachHoaDonNhap();
            dsHoaDonNhap.Add(hoaDonNhap);
            LuuDanhSachHoaDonNhap(dsHoaDonNhap);
        }
        public void XoaHoaDonNhap(HoaDonNhapHang hoaDonNhap)
        {
            List<HoaDonNhapHang> dsHoaDonNhap = DocDanhSachHoaDonNhap();
            dsHoaDonNhap.Remove(hoaDonNhap);
            LuuDanhSachHoaDonNhap(dsHoaDonNhap);
        }
        public void SuaHoaDonNhap(HoaDonNhapHang maHoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDonNhap();
            for (int i = 0; i < dsHoaDon.Count(); i++)
            {
                if (dsHoaDon[i].MaHoaDon == maHoaDon.MaHoaDon)
                {
                    dsHoaDon[i] = maHoaDon;
                }
            }
            LuuDanhSachHoaDonNhap(dsHoaDon);
        }
        public HoaDonNhapHang? DocThongTinHoaDon(int maHoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDonNhap();
            foreach (var hoaDon in dsHoaDon)
            {
                if (hoaDon.MaHoaDon == maHoaDon)
                {
                    return hoaDon;
                }
            }
            return null;
        }
    }
}

