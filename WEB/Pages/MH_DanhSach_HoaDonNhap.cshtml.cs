using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_HoaDonNhap : PageModel
    {
        private IXuLyHoaDonNhap _xuLyHoaDonNhap = new XuLyHoaDonNhap();
        public List<HoaDonNhapHang> dsHoaDonNhap;
        public int totalItems { get; set; }

        [BindProperty]
        public string timKiemTheo { get; set; }

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsHoaDonNhap = _xuLyHoaDonNhap.DocDanhSachHoaDonNhap(timKiemTheo = "tenhang", tuKhoa = "");
            totalItems = dsHoaDonNhap.Count();
        }
        public void OnPost()
        {
            dsHoaDonNhap = _xuLyHoaDonNhap.DocDanhSachHoaDonNhap(timKiemTheo, tuKhoa);
            totalItems = dsHoaDonNhap.Count();
        }
    }
}

