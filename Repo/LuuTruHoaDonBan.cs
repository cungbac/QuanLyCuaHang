using System;
using Entities;

namespace Repo
{
    public class LuuTruHoaDonBan : ILuuTruHoaDonBan
    {
        public string GetFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;

            string dataFolder = "Repo/Data";
            string fileName = "hoadonbanhang.txt";

            string filePath = Path.Combine(projectDirectory, dataFolder, fileName);

            return filePath;
        }
        public List<HoaDonBanHang> DocDanhSachHoaDonBan()
        {
            string filePath = GetFilePath();

            List<HoaDonBanHang> dsHoaDonBan = new List<HoaDonBanHang>();
            StreamReader reader = new StreamReader(filePath);

            int n;
            string s = reader.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                dsHoaDonBan.Add(new HoaDonBanHang(s));
            }
            reader.Close();

            return dsHoaDonBan;
        }
        public void LuuDanhSachHoaDonBan(List<HoaDonBanHang> dsHoaDonBan)
        {
            string filePath = GetFilePath();
            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine(dsHoaDonBan.Count());
            foreach (var hoaDonBan in dsHoaDonBan)
            {
                writer.WriteLine($"" +
                    $"{hoaDonBan.MaHoaDon}," +
                    $"{hoaDonBan.NgayTao}," +
                    $"{hoaDonBan.NgayCapNhat}," +
                    $"{hoaDonBan.MaHang}," +
                    $"{hoaDonBan.TenHang}," +
                    $"{hoaDonBan.SoLuong}," +
                    $"{hoaDonBan.GiaBan}," +
                    $"{hoaDonBan.ThanhTien}"
                );
            }
            writer.Close();
        }
        public void ThemHoaDonBan(HoaDonBanHang hoaDonBan)
        {
            List<HoaDonBanHang> dsHoaDonBan = DocDanhSachHoaDonBan();
            dsHoaDonBan.Add(hoaDonBan);
            LuuDanhSachHoaDonBan(dsHoaDonBan);
        }
        public void XoaHoaDonBan(int maHoaDon)
        {
            List<HoaDonBanHang> dsHoaDonBan = DocDanhSachHoaDonBan();
            List<HoaDonBanHang> dsHoaDonMoi = new List<HoaDonBanHang>();

            foreach (var hoaDon in dsHoaDonBan)
            {
                if (hoaDon.MaHoaDon != maHoaDon)
                {
                    dsHoaDonMoi.Add(hoaDon);
                }
            }
            LuuDanhSachHoaDonBan(dsHoaDonMoi);
        }
        public void SuaHoaDonBan(HoaDonBanHang hoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDonBan();
            for (int i = 0; i < dsHoaDon.Count(); i++)
            {
                if (dsHoaDon[i].MaHoaDon == hoaDon.MaHoaDon)
                {
                    dsHoaDon[i] = hoaDon;
                }
            }
            LuuDanhSachHoaDonBan(dsHoaDon);
        }
        public HoaDonBanHang? DocThongTinHoaDon(int maHoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDonBan();
            foreach (var hoaDon in dsHoaDon)
            {
                if (hoaDon.MaHoaDon == maHoaDon)
                {
                    return hoaDon;
                }
            }
            return null;
        }
        public bool KiemTraMaHoaDon(int maHoaDon)
        {
            var dsHoaDon = DocDanhSachHoaDonBan();
            foreach (var hoaDon in dsHoaDon)
            {
                if (hoaDon.MaHoaDon == maHoaDon)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

