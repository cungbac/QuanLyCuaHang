using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Sua_HoaDonNhap : PageModel
    {
        private IXuLyHoaDonNhap _xuLyHoaDonNhap = new XuLyHoaDonNhap();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public List<string> dsTenLoaiHang;
        public HoaDonNhapHang hoaDonNhap;
        public int maHoaDon;
        public string tenHang;
        public bool kiemTraMaHang;
        public int soLuongTonKhoHienTai;
        public int soLuongTonKhoMoi;

        public string message;

        [BindProperty]
        public string ngayTao { get; set; }

        [BindProperty]
        public string ngayCapNhat { get; set; }

        [BindProperty]
        public int maHang { get; set; }

        [BindProperty]
        public int soLuong { get; set; }

        [BindProperty]
        public double giaNhap { get; set; }

        public void OnGet()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonNhap = _xuLyHoaDonNhap.DocThongTinHoaDon(maHoaDon);
                if (hoaDonNhap == null)
                {
                    message = "Hoá đơn nhập hàng không tồn tại!";
                }
            }
            catch
            {
                message = "Hoá đơn nhập hàng không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonNhap = _xuLyHoaDonNhap.DocThongTinHoaDon(maHoaDon);

                tenHang = _xuLyMatHang.DocTenMatHang(maHang);
                ngayTao = hoaDonNhap.NgayTao;
                ngayCapNhat = DateTime.Now.ToString("yyyy-MM-dd");

                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(maHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai - hoaDonNhap.SoLuong + soLuong;

                kiemTraMaHang = _xuLyMatHang.KiemTraMaHang(maHang);

                if (kiemTraMaHang)
                {
                    var hoaDonMoi = new HoaDonNhapHang(ngayTao, ngayCapNhat, maHang, tenHang, soLuong, giaNhap);
                    hoaDonMoi.MaHoaDon = maHoaDon;
                    _xuLyHoaDonNhap.SuaHoaDonNhap(hoaDonMoi);
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

