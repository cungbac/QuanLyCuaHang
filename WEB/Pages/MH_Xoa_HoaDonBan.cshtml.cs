using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Xoa_HoaDonBan : PageModel
    {
        private IXuLyHoaDonBan _xuLyHoaDonBan = new XuLyHoaDonBan();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public HoaDonBanHang hoaDonBan;
        public string message;
        public int maHoaDon;
        public bool kiemTraMaHang;
        public int soLuongTonKhoHienTai;
        public int soLuongTonKhoMoi;

        public void OnGet()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonBan = _xuLyHoaDonBan.DocThongTinHoaDon(maHoaDon);
            }
            catch
            {
                message = "Hoá đơn không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonBan = _xuLyHoaDonBan.DocThongTinHoaDon(maHoaDon);

                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(hoaDonBan.MaHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai + hoaDonBan.SoLuong;

                _xuLyMatHang.CapNhatTonKho(hoaDonBan.MaHang, soLuongTonKhoMoi);
                _xuLyHoaDonBan.XoaHoaDonBan(maHoaDon);

                message = "Successful";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

