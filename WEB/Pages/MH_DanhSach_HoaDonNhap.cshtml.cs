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
        public string chuoi;

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsHoaDonNhap = _xuLyHoaDonNhap.DocDanhSachHoaDonNhap("");
        }
        public void OnPost()
        {
            dsHoaDonNhap = _xuLyHoaDonNhap.DocDanhSachHoaDonNhap(tuKhoa);
        }
    }
}

