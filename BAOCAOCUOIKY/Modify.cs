using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAOCAOCUOIKY
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter;//truy xuat du lieu vao bang
        SqlCommand sqlCommand;
        public Modify()
        {
        }
        // truy vấn dữ liệu từ bảng PHIEUNHAP
        public DataTable getAllphieunhap()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM PHIEUNHAP WHERE TrangThai = N'Chờ duyệt'";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        // truy vấn dữ liệu từ bảng PHIEUNHAP lịch sử đã duyệt
        public DataTable getPhieuNhapDaDuyet()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM LICHSU_DUYET";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        // truy vấn dữ liệu từ bảng CTPHIEUNHAP theo MaPN
        public DataTable getAllCTPhieuNhap(string MaPN = null)
        {
            DataTable dataTable = new DataTable();
            string query =
                "SELECT CTPHIEUNHAP.MaSP, SANPHAM.TenSP, CTPHIEUNHAP.SoLuong, CTPHIEUNHAP.DonGiaNhap " +
                "FROM CTPHIEUNHAP " +
                "JOIN SANPHAM ON CTPHIEUNHAP.MaSP = SANPHAM.MaSP " +
                "WHERE CTPHIEUNHAP.MaPN = @MaPN";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@MaPN", MaPN);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                sqlConnection.Close();
            }
            return dataTable;
        }
        // truy vấn dữ liệu từ bảng SANPHAM
        public DataTable getAllSanPham()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM SANPHAM";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // duyệt phiếu nhập của admin
        public bool DuyetPhieu(string maPN)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string query = "UPDATE PHIEUNHAP SET TrangThai = N'Đã duyệt' WHERE MaPN = @MaPN";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);

                int rows = cmd.ExecuteNonQuery();

                return rows > 0; // Trigger tự chạy
            }
        }
        // hủy phiếu nhập của admin
        public bool HuyPhieu(string maPN)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa bảng chi tiết
                    string deleteCT = "DELETE FROM CTPHIEUNHAP WHERE MaPN = @MaPN";
                    SqlCommand cmdCT = new SqlCommand(deleteCT, conn, transaction);
                    cmdCT.Parameters.AddWithValue("@MaPN", maPN);
                    cmdCT.ExecuteNonQuery();

                    // Xóa phiếu nhập
                    string deletePN = "DELETE FROM PHIEUNHAP WHERE MaPN = @MaPN";
                    SqlCommand cmdPN = new SqlCommand(deletePN, conn, transaction);
                    cmdPN.Parameters.AddWithValue("@MaPN", maPN);
                    int row = cmdPN.ExecuteNonQuery();

                    transaction.Commit();
                    return row > 0;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        // tìm kiếm phiếu nhập của admin
        public DataTable TimKiemPhieuNhap(string maPN)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM PHIEUNHAP WHERE MaPN LIKE @MaPN";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPN", "%" + maPN + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            return dataTable;
        }
        // truy vấn dữ liệu từ bảng PHIEUXUAT
        public DataTable getAllphieuxuat()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM PHIEUXUAT";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        // xử lý xuất hàng ( xuất hàng-> cập nhật tồn khi -> lưu vào lịch sử phiếu xuất -> xóa chi tiết phiếu xuất và phiếu xuất )
        public bool TruSoLuongXuat(string maSP, int soLuong)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE SANPHAM 
                                SET SLTon = SLTon - @SL 
                                WHERE MaSP = @MaSP AND SLTon >= @SL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SL", soLuong);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public double GetTongTienXuat(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT SUM(SoLuong * DonGiaXuat) 
                                FROM CTPHIEUXUAT WHERE MaPX = @MaPX";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);
                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToDouble(result);
            }
        }
        public bool ThemLichSuXuat(string maPX, DateTime ngayXuat, double tongTien, string maNV)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO LICHSU_XUATHANG (MaPX, NgayXuat, TongTien, MaNV)
                                VALUES (@MaPX, @NgayXuat, @TongTien, @MaNV)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);
                cmd.Parameters.AddWithValue("@NgayXuat", ngayXuat);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public void XoaCTPX(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"DELETE FROM CTPHIEUXUAT WHERE MaPX = @MaPX";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);
                cmd.ExecuteNonQuery();
            }
        }
        public void XoaPhieuXuatKhiDaXuat(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"DELETE FROM PHIEUXUAT WHERE MaPX = @MaPX";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);
                cmd.ExecuteNonQuery();
            }
        }

        // xử lý thêm phiếu xuất
        public bool CheckMaPhieuDaTonTai(string maPX)
        {
            string query = $"SELECT COUNT(*) FROM PHIEUXUAT WHERE MaPX = '{maPX}'";
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool checkChucVuNhanVien(string maNV)
        {
            string query = $"SELECT COUNT(*) FROM NHANVIEN WHERE MaNV ='{maNV}' AND ChucVu = N'Nhân viên kho'";
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool CheckMaPhieuTonTaiTrongLichSu(string maPX)
        {
            string query = $"SELECT COUNT(*) FROM LICHSU_XUATHANG WHERE MaPX = @maPX";
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maPX", maPX);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public bool CheckMaNhanVienTonTai(string maNV)
        {
            string query = $"SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = '{maNV}' AND TrangThai = N'Đang làm'";
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        public void Command(string query)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public bool XoaPhieuXuat(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa bảng chi tiết PX
                    string deleteCT = "DELETE FROM CTPHIEUXUAT WHERE MaPX = @MaPX";
                    SqlCommand cmdCT = new SqlCommand(deleteCT, conn, transaction);
                    cmdCT.Parameters.AddWithValue("@MaPX", maPX);
                    cmdCT.ExecuteNonQuery();

                    // Xóa phiếu xuất
                    string deletePX = "DELETE FROM PHIEUXUAT WHERE MaPX = @MaPX";
                    SqlCommand cmdPX = new SqlCommand(deletePX, conn, transaction);
                    cmdPX.Parameters.AddWithValue("@MaPX", maPX);
                    int row = cmdPX.ExecuteNonQuery();

                    transaction.Commit();
                    return row > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa phiếu xuất: " + ex.Message);
                    return false;
                }
            }
        }

        // xử lý combobox chọn sản phẩm
        public DataTable GetSanPham(string maSP)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaSP, TenSP, DonViTinh, DonGia, SLTon FROM SANPHAM WHERE MaSP = @MaSP";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDanhSachSanPham()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaSP FROM SANPHAM";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetDanhSachSanPham2()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaSP FROM SANPHAM WHERE TrangThai = N'Đang bán'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // xử lý lưu chi tiết phiếu xuất sang phieu xuat
        public bool InsertCTPhieuXuat(string maPX, string maSP, int soLuong, double donGia)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string query =
                    "INSERT INTO CTPHIEUXUAT (MaPX, MaSP, SoLuong, DonGiaXuat) " +
                    "VALUES (@MaPX, @MaSP, @SoLuong, @DonGia)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPX", maPX);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@DonGia", donGia);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // xử lý xem chi tiết phiếu của 1 phiếu xuất
        public DataTable GetCTPhieuXuat(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT CT.MaSP, SP.TenSP, SP.DonViTinh,
                           CT.SoLuong, CT.DonGiaXuat,
                           (CT.SoLuong * CT.DonGiaXuat) AS ThanhTien
                    FROM CTPHIEUXUAT CT
                    JOIN SANPHAM SP ON CT.MaSP = SP.MaSP
                    WHERE CT.MaPX = @MaPX";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // xử lý delete bên trong phiếu xuất và insert lại khi người dùng sửa 
        public void XoaCTPhieuXuat(string maPX)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM CTPHIEUXUAT WHERE MaPX = @MaPX";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPX", maPX);
                cmd.ExecuteNonQuery();
            }
        }

        // THỐNG KÊ
        public int CountNhanVien()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NHANVIEN WHERE TrangThai = N'Đang làm'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
        public int CountPhieuNhap()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM PHIEUNHAP WHERE TrangThai = N'Chờ duyệt'";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
        public int CountSanPham()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SANPHAM";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
        public DataTable getPhieuCho()
        {
            DataTable dataTable = new DataTable();
            {
                string query = "SELECT MaPN, NgayLap FROM PHIEUNHAP WHERE TrangThai = N'Chờ duyệt' ORDER BY NgayLap DESC ";
                using (SqlConnection sqlConnection = Connection.GetConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                }
                return dataTable;
            }
        }
        public DataTable getCanhCaoTonKho()
        {
            DataTable dataTable = new DataTable();
            {
                string query = "SELECT MaSP, TenSP, SLTon FROM SANPHAM WHERE SLTon <= 5";
                using (SqlConnection sqlConnection = Connection.GetConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                }
                return dataTable;
            }
        }

        // Lịch sử duyệt phiếu nhập
        public DataTable getLichSuPhieuXuat()
        {
            DataTable dataTable = new DataTable();
            {
                string query = "SELECT * FROM LICHSU_XUATHANG ORDER BY NgayXuat DESC";
                using (SqlConnection sqlConnection = Connection.GetConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(query, sqlConnection);
                    dataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                }
                return dataTable;
            }
        }
        public double GetTongTienLichSu()
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(TongTien) FROM LICHSU_XUATHANG";

                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                    return 0;

                return Convert.ToDouble(result);
            }
        }



        // PHẦN BÀI CỦA HIỀN BÉO
        public DataTable getPhieuNhapByStatus(string status)
        {
            string query;
            if (status == "ALL")
                query = "SELECT * FROM PHIEUNHAP";
            else
                query = "SELECT * FROM PHIEUNHAP WHERE TrangThai = @status";

            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();

                SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection);

                if (status != "ALL")
                    da.SelectCommand.Parameters.AddWithValue("@status", status);

                da.Fill(dataTable);
            }

            return dataTable;
        }
        public int countByStatus(string status)
        {
            string query;

            if (status == "ALL")
                query = "SELECT COUNT(*) FROM PHIEUNHAP";
            else
                query = "SELECT COUNT(*) FROM PHIEUNHAP WHERE TrangThai = @status";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (status != "ALL")
                    cmd.Parameters.AddWithValue("@status", status);

                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }

        public bool GuiPhieu(string maPN)
        {
            string query = "UPDATE PHIEUNHAP SET TrangThai = N'Chờ duyệt' WHERE MaPN = @MaPN";

            using (SqlConnection conn = Connection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeletePhieuNhap(string maPN)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Xóa chi tiết phiếu nhập
                    string queryCT = "DELETE FROM CTPHIEUNHAP WHERE MaPN = @MaPN";
                    using (SqlCommand cmd = new SqlCommand(queryCT, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", maPN);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa phiếu nhập
                    string queryPN = "DELETE FROM PHIEUNHAP WHERE MaPN = @MaPN";
                    using (SqlCommand cmd = new SqlCommand(queryPN, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaPN", maPN);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public bool CheckMaPhieuDaTonTai2(string maPN)
        {
            string query = $"SELECT COUNT(*) FROM PHIEUNHAP WHERE MaPN = '{maPN}'";
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
        //chi tiết phiếu nhập
        public DataTable GetCTPN(string maPN)
        {
            string query = @"
                SELECT c.MaSP, s.TenSP, c.SoLuong,
                CASE
                    WHEN p.TrangThai = N'Nháp' THEN s.GiaNhap
                    ELSE c.DonGiaNhap
                END AS DonGiaNhap,
                CASE
                    WHEN p.TrangThai = N'Nháp' THEN (c.SoLuong * s.GiaNhap)
                    ELSE (c.SoLuong * c.DonGiaNhap)
                END AS ThanhTien
                FROM CTPHIEUNHAP c
                JOIN SANPHAM s ON c.MaSP = s.MaSP
                JOIN PHIEUNHAP p ON c.MaPN = p.MaPN
                WHERE c.MaPN = @MaPN";

            using (SqlConnection conn = Connection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public decimal GetTongTien(string maPN)
        {
            string query = @"
                SELECT SUM(c.SoLuong * c.DonGiaNhap)
                FROM CTPHIEUNHAP c
                JOIN SANPHAM s ON c.MaSP = s.MaSP
                WHERE c.MaPN = @MaPN";

            using (SqlConnection conn = Connection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }
        public DataRow GetPhieuNhap(string maPN)
        {
            string query = "SELECT * FROM PHIEUNHAP WHERE MaPN = @MaPN";

            using (SqlConnection conn = Connection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];

                return null;
            }
        }
        public DataTable GetAllProductCodes()
        {
            string query = "SELECT MaSP FROM SANPHAM WHERE TrangThai = N'Đang bán'";
            using (SqlConnection conn = Connection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataRow GetProductInfo(string maSP)
        {
            string query = "SELECT TenSP, DonViTinh FROM SANPHAM WHERE MaSP = @maSP";
            using (SqlConnection conn = Connection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@maSP", maSP);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                return null;
            }
        }
        //Begin: xử lý THêm sản phẩm vòa chi tiết phiếu
        // Thêm chi tiết phiếu nhập (KHÔNG có thành tiền)
        public bool ThemCTPN(string maPN, string maSP, int soLuong, float donGia)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO CTPHIEUNHAP
                               (MaPN, MaSP, SoLuong, DonGiaNhap)
                               VALUES (@MaPN, @MaSP, @SoLuong, @DonGiaNhap)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGiaNhap", donGia);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy đơn giá nhập theo MaSP
        public float LayDonGia(string maSP)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = "SELECT GiaNhap FROM SANPHAM WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                object kq = cmd.ExecuteScalar();
                if (kq != null)
                    return float.Parse(kq.ToString());

                return 0;
            }
        }

        // Load chi tiết: TỰ TÍNH Thành tiền
        public DataTable LoadCTPN(string maPN)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT 
                                    ct.MaSP,
                                    sp.TenSP,
                                    ct.SoLuong,
                                    ct.DonGiaNhap,
                                    (ct.SoLuong * ct.DonGiaNhap) AS ThanhTien
                               FROM CTPHIEUNHAP ct
                               JOIN SANPHAM sp ON ct.MaSP = sp.MaSP
                               WHERE ct.MaPN = @MaPN";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // Tính tổng tiền của phiếu (TỰ TÍNH)
        public decimal TinhTongTien(string maPN)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT SUM(SoLuong * DonGiaNhap) 
                               FROM CTPHIEUNHAP 
                               WHERE MaPN = @MaPN";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);

                object kq = cmd.ExecuteScalar();

                if (kq != DBNull.Value)
                    return Convert.ToDecimal(kq);

                return 0;
            }
        }

        // Kiểm tra sản phẩm đã tồn tại trong phiếu chưa (chống trùng)
        public bool KiemTraSPTrongPhieu(string maPN, string maSP)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT COUNT(*) FROM CTPHIEUNHAP
                               WHERE MaPN = @MaPN AND MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        //end: xử lý Thêm sản phẩm vào chi tiết phiếu

        //begin: Xử lý sự kiện Xóa sản phẩm ở chi tiết phiếu nhập
        public bool XoaCTPN(string maPN, string maSP)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"DELETE FROM CTPHIEUNHAP 
                       WHERE MaPN = @MaPN AND MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //end: xử lý sự kiện Xóa sản phẩm ở chi tiết phiếu nhập

        //begin: Xử lý sự kiện Chỉnh sửa sản phẩm
        public bool CapNhatCTPN(string maPN, string maSP, int soLuong, float donGia)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE CTPHIEUNHAP
                       SET SoLuong = @SoLuong,
                           DonGiaNhap = @DonGia
                       WHERE MaPN = @MaPN AND MaSP = @MaSP";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //end: Xử lý sự kiện chỉnh sửa sản phẩm


        // PHẦN BÀI CỦA CÔNG MINH
        public DataTable getAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string query = "Select * from NHANVIEN WHERE TrangThai = N'Đang làm'";
            using (SqlConnection sqlConnection = Connection.GetConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        public bool CheckExistMaNV(string maNV)
        {
            string query = "SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV.Trim());

                int count = (int)cmd.ExecuteScalar();
                return count > 0;   // true = đã tồn tại
            }
        }


        public bool insertNV(nhanvien nhanVien)
        {
            string query = "INSERT INTO NHANVIEN VALUES (@MaNV, @HoTen, @MatKhau, @ChucVu, @SoDienThoai, @DiaChi, @NgayLam, @TrangThai)";

            using (SqlConnection conn = Connection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.Manv.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nhanVien.Tennv.Trim();
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau.Trim();
                    cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nhanVien.Chucvu.Trim();
                    cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = nhanVien.Sodienthoai.Trim();
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.Diachi.Trim();
                    cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = nhanVien.Ngaylam;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Đang làm";

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        public bool updateNV(nhanvien nhanVien)
        {
            string query = @"UPDATE NHANVIEN 
                             SET HoTen = @HoTen,
                                 SoDienThoai = @SoDienThoai,
                                 MatKhau = @MatKhau,
                                 DiaChi = @DiaChi,
                                 NgayLam = @NgayLam,
                                 ChucVu = @ChucVu
                             WHERE MaNV = @MaNV";

            using (SqlConnection conn = Connection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.Manv.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nhanVien.Tennv.Trim();
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = nhanVien.Matkhau.Trim();
                    cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nhanVien.Chucvu.Trim();
                    cmd.Parameters.Add("@SoDienThoai", SqlDbType.NVarChar).Value = nhanVien.Sodienthoai.Trim();
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.Diachi.Trim();
                    cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = nhanVien.Ngaylam;

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        // Xóa mềm nhân viên bằng cách chuyển đổi trạng thái thành nghỉ việc
        public bool deleteNV(string maNV)
        {
            string query = "UPDATE NHANVIEN SET TrangThai = N'Nghỉ việc' WHERE MaNV = @MaNV";

            using (SqlConnection conn = Connection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = maNV.Trim();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        //Tìm kiếm nhân viên với từ khóa giống Mã, tên, sđt, buộc là trạng thái đang làm
        public DataTable TimkiemNV(string key)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM NHANVIEN 
                            WHERE TrangThai = N'Đang làm'
                            AND (MaNV LIKE @key 
                                OR HoTen LIKE @key 
                                OR SoDienThoai LIKE @key)";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + key.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }


        public DataTable FindProductByID(string maSP)
        {
            SqlConnection conn = Connection.GetConnection();
            string query = "SELECT * FROM SANPHAM WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = maSP;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public bool insert(QuanLySanPham sanPham)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "insert into SANPHAM values (@MaSP, @TenSP,@DonViTinh, @GiaNhap, @DonGia, @SLTon, @HinhAnh, @TrangThai )";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSP", SqlDbType.Char).Value = sanPham.MaSP;
                sqlCommand.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSP;
                sqlCommand.Parameters.Add("@DonViTinh", SqlDbType.NVarChar).Value = sanPham.DonViTinh;
                sqlCommand.Parameters.Add("@GiaNhap", SqlDbType.Float).Value = sanPham.GiaNhap;
                sqlCommand.Parameters.Add("@DonGia", SqlDbType.Float).Value = sanPham.DonGia;
                sqlCommand.Parameters.Add("@SLTon", SqlDbType.Int).Value = sanPham.SLTon;
                sqlCommand.Parameters.Add("@HinhAnh", SqlDbType.Image).Value = sanPham.HinhAnh;
                sqlCommand.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = sanPham.TrangThaisp;

                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        // Sửa sản phẩm 
        public bool update(QuanLySanPham sanPham)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "update SANPHAM set TenSP=@TenSP, DonViTinh= @DonViTinh,GiaNhap= @GiaNhap,DonGia= @DonGia,SLTon= @SLTon,HinhAnh= @HinhAnh, TrangThai=@TrangThai where MaSP= @MaSP";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSP", SqlDbType.Char).Value = sanPham.MaSP;
                sqlCommand.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSP;
                sqlCommand.Parameters.Add("@DonViTinh", SqlDbType.NVarChar).Value = sanPham.DonViTinh;
                sqlCommand.Parameters.Add("@GiaNhap", SqlDbType.Float).Value = sanPham.GiaNhap;
                sqlCommand.Parameters.Add("@DonGia", SqlDbType.Float).Value = sanPham.DonGia;
                sqlCommand.Parameters.Add("@SLTon", SqlDbType.Int).Value = sanPham.SLTon;
                sqlCommand.Parameters.Add("@HinhAnh", SqlDbType.Image).Value = sanPham.HinhAnh;
                sqlCommand.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = sanPham.TrangThaisp;

                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        //Xóa sản phẩm bằng cách sử dụng update để thay đổi trạng thái
        public bool delete(string MaSP)
        {
            SqlConnection sqlConnection = Connection.GetConnection();
            string query = "UPDATE SANPHAM SET TrangThai = N'Ngừng bán' WHERE MaSP = @MaSP";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaSP", SqlDbType.Char).Value = MaSP;

                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        //Tìm kiếm sản phẩm
        public DataTable Timkiem(string key)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM SANPHAM WHERE TrangThai = N'Đang bán' AND (MaSP LIKE @key OR TenSP LIKE @key)";

            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }



        // BACKUPDATABASE
        public bool BackupDatabase(string folderPath)
        {
            try
            {
                using (SqlConnection con = Connection.GetConnection())
                {
                    con.Open();

                    string db = con.Database;
                    string fileName = $"{db}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.bak";
                    string fullPath = System.IO.Path.Combine(folderPath, fileName);

                    string sql =
                        $@"BACKUP DATABASE [{db}]
                        TO DISK = @path
                        WITH FORMAT, MEDIANAME = 'DBBackup',
                        NAME = 'Full Backup {db}'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@path", fullPath);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Backup: " + ex.Message);
                return false;
            }
        }
        // RESTORE
        public bool RestoreDatabase(string backupPath)
        {
            try
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    conn.Open();

                    // Chuyển sang master
                    using (SqlCommand cmd = new SqlCommand("USE master", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Đặt database về SINGLE_USER để tránh lỗi
                    string sqlSingleUser = @"
                ALTER DATABASE Quanlykhohangfinal SET SINGLE_USER WITH ROLLBACK IMMEDIATE
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlSingleUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Lệnh RESTORE
                    string sqlRestore = $@"
                        RESTORE DATABASE Quanlykhohangfinal 
                        FROM DISK = '{backupPath}' 
                        WITH REPLACE
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlRestore, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Đưa về MULTI_USER
                    string sqlMultiUser = @"
                ALTER DATABASE Quanlykhohangfinal SET MULTI_USER
            ";
                    using (SqlCommand cmd = new SqlCommand(sqlMultiUser, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }




    }

}
