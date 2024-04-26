using System;
using Entities;

namespace Repo
{
    public class LuuTruLoaiHang : ILuuTruLoaiHang
    {
        public string GetFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).FullName;

            string dataFolder = "Repo/Data";
            string fileName = "loaihang.txt";

            string filePath = Path.Combine(projectDirectory, dataFolder, fileName);

            return filePath;
        }

        public List<LoaiHang> DocDanhSachLoaiHang()
        {
            string filePath = GetFilePath();

            List<LoaiHang> dsLoaiHang = new List<LoaiHang>();
            StreamReader reader = new StreamReader(filePath);

            int n;
            string s = reader.ReadLine();
            n = int.Parse(s);
            for (int i = 0; i < n; i++)
            {
                s = reader.ReadLine();
                string[] m = s.Split(",");
                dsLoaiHang.Add(new LoaiHang(m));
            }
            reader.Close();

            return dsLoaiHang;
        }
        public void LuuDanhSachLoaiHang(List<LoaiHang> dsLoaiHang)
        {
            string filePath = GetFilePath();
            StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine(dsLoaiHang.Count());
            foreach (var loaiHang in dsLoaiHang)
            {
                writer.WriteLine($"" +
                    $"{loaiHang.MaLoaiHang}," +
                    $"{loaiHang.TenLoaiHang}"
                );
            }
            writer.Close();
        }
        public void ThemLoaiHang(LoaiHang loaiHang)
        {
            List<LoaiHang> dsLoaiHang = DocDanhSachLoaiHang();
            dsLoaiHang.Add(loaiHang);
            LuuDanhSachLoaiHang(dsLoaiHang);
        }
        public void XoaLoaiHang(LoaiHang loaiHang)
        {
            List<LoaiHang> dsLoaiHang = DocDanhSachLoaiHang();
            dsLoaiHang.Remove(loaiHang);
            LuuDanhSachLoaiHang(dsLoaiHang);
        }
    }
}

