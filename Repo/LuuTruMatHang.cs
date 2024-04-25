using System;
using Entities;

namespace Repo
{
	public class LuuTruMatHang : ILuuTruMatHang
	{
        public string GetFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;

            string dataFolder = "Repo/Data";
            string fileName = "mathang.txt";

            string filePath = Path.Combine(projectDirectory, dataFolder, fileName);

            return filePath;
        }

        public List<MatHang> DocDanhSachMatHang()
		{
            string filePath = GetFilePath();

            List<MatHang> dsMatHang = new List<MatHang>();
            StreamReader reader = new StreamReader(filePath);

            int n;
            string s = reader.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                dsMatHang.Add(new MatHang(s));
            }
            reader.Close();

            return dsMatHang;
		}
        public void LuuDanhSachMatHang(List<MatHang> dsMatHang)
        {
            string filePath = GetFilePath();
            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine(dsMatHang.Count());
            foreach (var matHang in dsMatHang)
            {
                writer.WriteLine($"" +
                    $"{matHang.MaHang}," +
                    $"{matHang.TenHang}," +
                    $"{matHang.HanDung}," +
                    $"{matHang.CongTySanXuat}," +
                    $"{matHang.NgaySanXuat}," +
                    $"{matHang.LoaiHang}," +
                    $"{matHang.GiaBan}," +
                    $"{matHang.SoLuongTonKho}"
                );
            }
            writer.Close();
        }
        public void ThemMatHang(MatHang matHang)
        {
            List<MatHang> dsMatHang = DocDanhSachMatHang();
            dsMatHang.Add(matHang);
            LuuDanhSachMatHang(dsMatHang);
        }
        public void XoaMatHang(MatHang matHang)
        {
            List<MatHang> dsMatHang = DocDanhSachMatHang();
            dsMatHang.Remove(matHang);
            LuuDanhSachMatHang(dsMatHang);
        }
    }
}

