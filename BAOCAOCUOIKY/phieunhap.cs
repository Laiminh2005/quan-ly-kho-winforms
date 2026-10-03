using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAOCAOCUOIKY
{
    internal class phieunhap
    {
        private string _mapn;
        private string _manv;
        private DateTime _ngaynhap;
        private string _trangthai;

        public phieunhap()
        {
        }

        public phieunhap(string mapn, string manv, DateTime ngaynhap, string trangthai)
        {
            _mapn = mapn;
            _manv = manv;
            _ngaynhap = ngaynhap;
            _trangthai = trangthai;
        }

        public string Mapn { get => _mapn; set => _mapn = value; }
        public string Manv { get => _manv; set => _manv = value; }
        public DateTime Ngaynhap { get => _ngaynhap; set => _ngaynhap = value; }
        public string Trangthai { get => _trangthai; set => _trangthai = value; }
    }
    internal class Ctphieunhap
    {
        //private string _mact;
        private string _mapn;
        private string _masp;
        private int _soluong;
        private float _dongianhap;

        public Ctphieunhap()
        {
        }

        public Ctphieunhap( string mapn, string masp, int soluong, float dongianhap)
        {
            //_mact = mact;
            _mapn = mapn;
            _masp = masp;
            _soluong = soluong;
            _dongianhap = dongianhap;
        }

        //public string Mact { get => _mact; set => _mact = value; }
        public string Mapn { get => _mapn; set => _mapn = value; }
        public string Masp { get => _masp; set => _masp = value; }
        public int Soluong { get => _soluong; set => _soluong = value; }
        public float Dongianhap { get => _dongianhap; set => _dongianhap = value; }
    }
    
    internal class phieuxuat
    {
        private string _mapx;
        private DateTime _ngaylap;
        private string _manv;
        private float _tongtien;

        public phieuxuat()
        {
        }

        public phieuxuat(string mapx, DateTime ngaylap, string manv, float tongtien)
        {
            _mapx = mapx;
            _ngaylap = ngaylap;
            _manv = manv;
            _tongtien = tongtien;
        }

        public string Mapx { get => _mapx; set => _mapx = value; }
        public DateTime Ngaylap { get => _ngaylap; set => _ngaylap = value; }
        public string Manv { get => _manv; set => _manv = value; }
        public float Tongtien { get => _tongtien; set => _tongtien = value; }
    }
    internal class ctphieuxuat
    {
        private string _mapx;
        private string _masp;
        private int _soluong;
        private float _thanhtien;

        public ctphieuxuat()
        {
        }

        public ctphieuxuat(string mapx, string masp, int soluong, float thanhtien)
        {
            _mapx = mapx;
            _masp = masp;
            _soluong = soluong;
            _thanhtien = thanhtien;
        }

        public string Mapx { get => _mapx; set => _mapx = value; }
        public string Masp { get => _masp; set => _masp = value; }
        public int Soluong { get => _soluong; set => _soluong = value; }
        public float Thanhtien { get => _thanhtien; set => _thanhtien = value; }
    }
    internal class lichsuduyet
    {
        private string _mals;// sau cập nhật lại database thì xóa
        private string _mapn;
        private string _manv;
        private DateTime _ngayduyet;
        private string _trangthai;

        public lichsuduyet()
        {
        }

        public lichsuduyet(string mals, string mapn, string manv, DateTime ngayduyet, string trangthai)
        {
            _mals = mals;
            _mapn = mapn;
            _manv = manv;
            _ngayduyet = ngayduyet;
            _trangthai = trangthai;
        }

        public string Mals { get => _mals; set => _mals = value; }
        public string Mapn { get => _mapn; set => _mapn = value; }
        public string Manv { get => _manv; set => _manv = value; }
        public DateTime Ngayduyet { get => _ngayduyet; set => _ngayduyet = value; }
        public string Trangthai { get => _trangthai; set => _trangthai = value; }
    }
    internal class nhanvien
    {
        private string _manv;
        private string _tennv;
        private string _matkhau;
        private string _chucvu;
        private string _sodienthoai;
        private string _diachi;
        private DateTime _ngaylam;
        private string _trangthai;

        public nhanvien()
        {
        }

        public nhanvien(string manv, string tennv, string matkhau, string chucvu, string sodienthoai, string diachi, DateTime ngaylam, string trangthai)
        {
            _manv = manv;
            _tennv = tennv;
            _matkhau = matkhau;
            _chucvu = chucvu;
            _sodienthoai = sodienthoai;
            _diachi = diachi;
            _ngaylam = ngaylam;
            _trangthai = trangthai;
        }

        public string Manv { get => _manv; set => _manv = value; }
        public string Tennv { get => _tennv; set => _tennv = value; }
        public string Matkhau { get => _matkhau; set => _matkhau = value; }
        public string Chucvu { get => _chucvu; set => _chucvu = value; }
        public string Sodienthoai { get => _sodienthoai; set => _sodienthoai = value; }
        public string Diachi { get => _diachi; set => _diachi = value; }
        public DateTime Ngaylam { get => _ngaylam; set => _ngaylam = value; }
        public string Trangthai { get => _trangthai; set => _trangthai = value; }
    }
    class QuanLySanPham
    {
        private string _MaSP;
        private string _TenSP;
        private string _DonViTinh;
        private float _GiaNhap;
        private float _DonGia;
        private int _SLTon;
        private byte[] _HinhAnh;
        private string TrangThai;

        public QuanLySanPham(string maSP, string tenSP, string donViTinh, float giaNhap, float donGia, int sLTon, byte[] hinhAnh, string trangThai)
        {
            _MaSP = maSP;
            _TenSP = tenSP;
            _DonViTinh = donViTinh;
            _GiaNhap = giaNhap;
            _DonGia = donGia;
            _SLTon = sLTon;
            _HinhAnh = hinhAnh;
            TrangThai = trangThai;
        }

        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }
        public float GiaNhap { get => _GiaNhap; set => _GiaNhap = value; }
        public float DonGia { get => _DonGia; set => _DonGia = value; }
        public int SLTon { get => _SLTon; set => _SLTon = value; }
        public byte[] HinhAnh { get => _HinhAnh; set => _HinhAnh = value; }
        public string TrangThaisp { get => TrangThai; set => TrangThai = value; }
    }
}
