using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_DanhSach_HoaDonBan : PageModel
    {
        private IXuLyHoaDonBan _xuLyHoaDonBan = new XuLyHoaDonBan();
        public List<HoaDonBanHang> dsHoaDonBan;
        public int totalItems { get; set; }

        [BindProperty]
        public string timKiemTheo { get; set; }

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsHoaDonBan = _xuLyHoaDonBan.DocDanhSachHoaDonBan(timKiemTheo = "tenhang", tuKhoa = "");
            totalItems = dsHoaDonBan.Count();
        }
        public void OnPost()
        {
            dsHoaDonBan = _xuLyHoaDonBan.DocDanhSachHoaDonBan(timKiemTheo, tuKhoa);
            totalItems = dsHoaDonBan.Count();
        }
    }
}

