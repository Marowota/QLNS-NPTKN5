#pragma once

#include <string>

//Khai báo lớp đối tượng nhân sự với các phương thức và thuộc tính theo đề.
class NhanSu
{
private:
	std::string MaSo;
	std::string hoTen;
	std::string namSinh;
	std::string gioiTinh;
	std::string chucDanh;
	std::string chucVu;
	long long luong;
	std::string donVi;
	double mucDoHoanThanhNhiemVuTrongNam;
	std::string DanhGia;
public:
	//Khai báo phương thức nhập xuất
	void Nhap();
	void Xuat();

	//Khai báo nhóm phương thức điều chỉnh dữ liệu
	void setMaSo(std::string);
	void setHoTen(std::string);
	void setNamSinh(std::string);
	void setGioiTinh(std::string);
	void setChucDanh(std::string);
	void setChucVu(std::string);
	void setLuong(long long);
	void setDonVi(std::string);
	void setMucDoHoanThanhNhiemVuTrongNam(double);
	void setDanhGia(std::string);
	//Khai báo nhóm phương thức truy cập giá trị trong các thuộc tính 
	std::string getMaSo();
	std::string getHoTen();
	std::string getNamSinh();
	std::string getGioiTinh();
	std::string getChucDanh();
	std::string getChucVu();
	long long getLuong();
	std::string getDonVi();
	double getMucDoHoanThanhNhiemVuTrongNam();
	std::string getDanhGia();
	//Khai báo toán tử gán
	NhanSu& operator=(const NhanSu&);
};
