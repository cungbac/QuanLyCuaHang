using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Sua_MatHang : PageModel
    {
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();

        public List<string> dsTenLoaiHang;
        public MatHang matHang;
        public string message;
        public int maHang;

        [BindProperty]
        public string tenHang { get; set; }

        [BindProperty]
        public string hanDung { get; set; }

        [BindProperty]
        public string congTySanXuat { get; set; }

        [BindProperty]
        public string ngaySanXuat { get; set; }

        [BindProperty]
        public string loaiHang { get; set; }

        [BindProperty]
        public double giaBan { get; set; }

        public void OnGet()
        {
            try
            {
                maHang = int.Parse(Request.Query["mahang"]);
                matHang = _xuLyMatHang.DocThongTinMatHang(maHang);
                dsTenLoaiHang = _xuLyLoaiHang.DocDanhSachTenLoaiHang();
                if (matHang == null)
                {
                    message = "Mặt hàng không tồn tại!";
                }
            }
            catch
            {
                message = "Mặt hàng không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maHang = int.Parse(Request.Query["mahang"]);
                matHang = _xuLyMatHang.DocThongTinMatHang(maHang);
                dsTenLoaiHang = _xuLyLoaiHang.DocDanhSachTenLoaiHang();

                var matHangMoi = new MatHang(tenHang, hanDung, congTySanXuat, ngaySanXuat, loaiHang, giaBan);
                matHangMoi.MaHang = maHang;
                matHangMoi.SoLuongTonKho = matHang.SoLuongTonKho;

                _xuLyMatHang.SuaMatHang(matHangMoi);

                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

