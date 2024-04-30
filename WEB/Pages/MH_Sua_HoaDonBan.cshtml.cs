using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace WEB.Pages
{
    public class MH_Sua_HoaDonBan : PageModel
    {
        private IXuLyHoaDonBan _xuLyHoaDonBan = new XuLyHoaDonBan();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();

        public List<string> dsTenLoaiHang;
        public HoaDonBanHang hoaDonBan;
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
        public double giaBan { get; set; }

        public void OnGet()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonBan = _xuLyHoaDonBan.DocThongTinHoaDon(maHoaDon);
                if (hoaDonBan == null)
                {
                    message = "Hoá đơn bán hàng không tồn tại!";
                }
            }
            catch
            {
                message = "Hoá đơn bán hàng không tồn tại!";
            }
        }
        public void OnPost()
        {
            try
            {
                maHoaDon = int.Parse(Request.Query["mahoadon"]);
                hoaDonBan = _xuLyHoaDonBan.DocThongTinHoaDon(maHoaDon);

                tenHang = _xuLyMatHang.DocTenMatHang(maHang);
                ngayTao = hoaDonBan.NgayTao;
                ngayCapNhat = DateTime.Now.ToString("yyyy-MM-dd");

                soLuongTonKhoHienTai = _xuLyMatHang.DocSoLuongTonKho(maHang);
                soLuongTonKhoMoi = soLuongTonKhoHienTai + hoaDonBan.SoLuong - soLuong;

                kiemTraMaHang = _xuLyMatHang.KiemTraMaHang(maHang);

                if (kiemTraMaHang)
                {
                    if (soLuongTonKhoMoi > 0)
                    {
                        var hoaDonMoi = new HoaDonBanHang(ngayTao, ngayCapNhat, maHang, tenHang, soLuong, giaBan);
                        hoaDonMoi.MaHoaDon = maHoaDon;
                        _xuLyHoaDonBan.SuaHoaDonBan(hoaDonMoi);
                        _xuLyMatHang.CapNhatTonKho(maHang, soLuongTonKhoMoi);

                        message = "Successful";
                    }
                    else
                    {
                        message = "Số lượng bán lớn hơn số lượng tồn kho!";
                    }
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

