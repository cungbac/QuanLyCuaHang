using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Xoa_HoaDonNhap : PageModel
    {
        private IXuLyHoaDonNhap _xuLyHoaDonNhap = new XuLyHoaDonNhap();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public HoaDonNhapHang hoaDonNhap;
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
                hoaDonNhap = _xuLyHoaDonNhap.DocThongTinHoaDon(maHoaDon);
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
                hoaDonNhap = _xuLyHoaDonNhap.DocThongTinHoaDon(maHoaDon);

                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(hoaDonNhap.MaHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai - hoaDonNhap.SoLuong;

                if (soLuongTonKhoMoi > 0)
                {
                    _xuLyMatHang.CapNhatTonKho(hoaDonNhap.MaHang, soLuongTonKhoMoi);
                    _xuLyHoaDonNhap.XoaHoaDonNhap(maHoaDon);

                    message = "Successful";
                }
                else
                {
                    message = "Số lượng tồn kho nhỏ hơn số lượng hoá đơn nhập!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

