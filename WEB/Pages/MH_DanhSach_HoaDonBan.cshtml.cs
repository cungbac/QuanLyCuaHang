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
        public string chuoi;

        [BindProperty]
        public string tuKhoa { get; set; }

        public void OnGet()
        {
            dsHoaDonBan = _xuLyHoaDonBan.DocDanhSachHoaDonBan("");
        }
        public void OnPost()
        {
            dsHoaDonBan = _xuLyHoaDonBan.DocDanhSachHoaDonBan(tuKhoa);
        }
    }
}

