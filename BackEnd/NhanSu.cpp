#include "pch.h"
#include "NhanSu.h"
#include <iostream>
using namespace std;

//Định nghĩa phương thức nhập
void NhanSu::Nhap()
{
	cout << "\nNhap ma so nhan su: ";
	cin >> MaSo;

	cin.ignore();
	cout << "Nhap ho ten: ";
	getline(cin, hoTen);

	cout << "Nhap nam sinh: ";
	getline(cin, namSinh);

	cout << "Nhap gioi tinh (0: Nam; 1: Nu): ";
	cin >> gioiTinh;

	cin.ignore();
	cout << "Nhap chuc danh: ";
	getline(cin, chucDanh);

	cout << "Nhap chuc vu: ";
	getline(cin, chucVu);

	cout << "Nhap luong: ";
	cin >> luong;

	cin.ignore();
	cout << "Nhap don vi: ";
	cin >> donVi;

	cout << "Nhap muc do hoan thanh nhiem vu trong nam (don vi theo %): ";
	cin >> mucDoHoanThanhNhiemVuTrongNam;
}
//Định nghĩa phương thức xuất
void NhanSu::Xuat()
{
	cout << "\nMa so nhan su: " << MaSo;
	cout << "\nHo va ten: " << hoTen;
	cout << "\nNam sinh: " << namSinh;
	cout << "\nGioi tinh: " << gioiTinh;
	cout << "\nChuc danh: " << chucDanh;
	cout << "\nChuc vu: " << chucVu;
	cout << "\nLuong: " << luong;
	cout << "\nDon vi: " << donVi;
	cout << "\nMuc do hoan thanh nhiem vu trong nam: " << mucDoHoanThanhNhiemVuTrongNam << "%";
	cout << "\nDanh gia: " << DanhGia;
}
//Định nghĩa các phương thức điểu chỉnh dữ liệu 
void NhanSu::setMaSo(string x)
{
	MaSo = x;
}
void NhanSu::setHoTen(string x)
{
	hoTen = x;
}
void NhanSu::setNamSinh(string x)
{
	namSinh = x;
}
void NhanSu::setGioiTinh(string x)
{
	gioiTinh = x;
}
void NhanSu::setChucDanh(string x)
{
	chucDanh = x;
}
void NhanSu::setChucVu(string x)
{
	chucVu = x;
}
void NhanSu::setLuong(long long x)
{
	luong = x;
}
void NhanSu::setDonVi(string x)
{
	donVi = x;
}
void NhanSu::setMucDoHoanThanhNhiemVuTrongNam(double x)
{
	mucDoHoanThanhNhiemVuTrongNam = x;
}
void NhanSu::setDanhGia(string x)
{
	DanhGia = x;
}
//Định nghĩa các phương thức truy cập giá trị trong các thuộc tính
string NhanSu::getMaSo()
{
	return MaSo;
}
string NhanSu::getHoTen()
{
	return hoTen;
}
string NhanSu::getNamSinh()
{
	return namSinh;
}
string NhanSu::getGioiTinh()
{
	return gioiTinh;
}
string NhanSu::getChucDanh()
{
	return chucDanh;
}
string NhanSu::getChucVu()
{
	return chucVu;
}
long long NhanSu::getLuong()
{
	return luong;
}
string NhanSu::getDonVi()
{
	return donVi;
}
double NhanSu::getMucDoHoanThanhNhiemVuTrongNam()
{
	return mucDoHoanThanhNhiemVuTrongNam;
}
string NhanSu::getDanhGia()
{
	return DanhGia;
}
//Định nghĩa toán tử gán cho lớp đối tượng nhân sự.
NhanSu& NhanSu::operator=(const NhanSu& x)
{
	MaSo = x.MaSo;
	hoTen = x.hoTen;
	namSinh = x.namSinh;
	gioiTinh = x.gioiTinh;
	chucDanh = x.chucDanh;
	chucVu = x.chucVu;
	luong = x.luong;
	donVi = x.donVi;
	mucDoHoanThanhNhiemVuTrongNam = x.mucDoHoanThanhNhiemVuTrongNam;
	DanhGia = x.DanhGia;
	return *this;
}