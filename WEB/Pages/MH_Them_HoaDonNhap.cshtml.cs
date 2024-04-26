using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Them_HoaDonNhap : PageModel
    {
        private IXuLyHoaDonNhap _xuLyHoaDonNhap = new XuLyHoaDonNhap();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public List<MatHang> dsMatHang;
        public string message;
        public string tenHang;
        public bool kiemTraMaHang;
        public int soLuongTonKhoHienTai;
        public int soLuongTonKhoMoi;

        [BindProperty]
        public string ngayTao { get; set; }

        [BindProperty]
        public int maHang { get; set; }

        [BindProperty]
        public int soLuong { get; set; }

        [BindProperty]
        public double giaNhap { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            try
            {
                tenHang = _xuLyMatHang.DocTenMatHang(maHang);
                ngayTao = DateTime.Now.ToString("yyyy-MM-dd");
                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(maHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai + soLuong;

                kiemTraMaHang = _xuLyMatHang.KiemTraMaHang(maHang);

                if (kiemTraMaHang)
                {
                    var hoaDonNhap = new HoaDonNhapHang(ngayTao, maHang, tenHang, soLuong, giaNhap);
                    _xuLyHoaDonNhap.ThemHoaDonNhap(hoaDonNhap);
                    _xuLyMatHang.CapNhatTonKho(maHang, soLuongTonKhoMoi);
                    message = "Successful";
                }
                else
                {
                    message = "Mã hàng không tồn tại!";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

