#include "pch.h"
#include "BinarySearchTree.h"
#include <iostream>
using namespace std;

void LNR(TNode* t)
{
	if (t == NULL)
		return;
	LNR(t->pLeft);
	cout << endl;
	t->Data.Xuat();
	cout << endl;
	LNR(t->pRight);
}
//Định nghĩa các hàm phụ trợ cho việc xóa đối tượng theo kiến trúc của cây nhị phân tìm kiếm
void findAndReplace(TNode*& p, TNode*& t)
{
	if (t->pLeft != NULL)
		findAndReplace(p, t->pLeft);
	else
	{
		p->Data = t->Data;
		p = t;
		t = t->pRight;
	}
}
void deleteNodeByID(TNode*& t, NhanSu ns)
{
	if (t != NULL)
	{
		if (t->Data.getMaSo() > ns.getMaSo())
			deleteNodeByID(t->pLeft, ns);
		else if (t->Data.getMaSo() < ns.getMaSo())
			deleteNodeByID(t->pRight, ns);
		else
		{
			TNode* p = t;
			if (t->pLeft == NULL)
				t = t->pRight;
			else
			{
				if (t->pRight == NULL)
					t = t->pLeft;
				else
					findAndReplace(p, t->pRight);
			}
			delete p;
		}
	}
}
//Định nghĩa các hàm phụ trợ cho việc tìm kiếm đối tượng theo kiến trúc của cây nhị phân tìm kiếm
TNode* findID(TNode* t, std::string ns)
{
	if (t != NULL)
	{
		if (t->Data.getMaSo() == ns) return t;
		if (t->Data.getMaSo() > ns)
			return findID(t->pLeft, ns);
		if (t->Data.getMaSo() < ns)
			return findID(t->pRight, ns);
	}
	return NULL;
}
TNode* findName(TNode* t, std::string ns)
{
	if (t == NULL)
		return NULL;
	if (t->Data.getHoTen() == ns)
		return t;
	TNode* tmp;
	if ((tmp = findName(t->pLeft, ns)) != NULL) return tmp;
	if ((tmp = findName(t->pRight, ns)) != NULL) return tmp;
	return NULL;
}
//Định nghĩa hàm phụ trợ cho phương thức phá hủy của lớp đối tượng
void RemoveAll(TNode*& t)
{
	if (t != NULL)
	{
		RemoveAll(t->pLeft);
		RemoveAll(t->pRight);
		delete t;
	}
}

//Định nghĩa phương thức thiết lập
BinarySearchTree::BinarySearchTree()
{
	//Chưa có gốc
	root = NULL;
}
//Định nghĩa phương thức truy cập vào gốc của cây
TNode* BinarySearchTree::getTree()
{
	return root;
}
//Định nghĩa phương thức khởi tạo cây
void BinarySearchTree::init()
{
	//Chưa có gốc
	root = NULL;
}
//Định nghĩa phương thức tạo một node cho cây với đối số là nhân sự
TNode* BinarySearchTree::getNode(NhanSu ns)
{
	//Xin hệ điều hành một vùng nhớ TNode gọi thực hiện phương thức thiết lập với đối số ns
	TNode* p = new TNode(ns);
	if (p == NULL)
		return NULL;
	return p;
}
//Định nghĩa phương thức thêm node vào cây theo nguyên tắc
void BinarySearchTree::insertNode(TNode*& t, NhanSu ns)
{
	if (t != NULL)
	{
		if (t->Data.getMaSo() > ns.getMaSo())
			insertNode(t->pLeft, ns); //Thêm node vào cây con trái
		if (t->Data.getMaSo() < ns.getMaSo())
			insertNode(t->pRight, ns); //Thêm node vào cây con phải 
		return;
	}
	//Đã tìm một vĩ trí thích hợp để thêm nên ta tiến hành tạo một Node ở đó
	t = getNode(ns);
	if (t == NULL)
		return;
}
//Định nghĩa phương thức thêm node vào cây với ít đối số hơn để dễ gọi hàm
void BinarySearchTree::insertNode(NhanSu ns)
{
	insertNode(this->root, ns);
}
//Định nghĩa phương thức nhập cho cây
void BinarySearchTree::Nhap()
{
	char DiemDung;
	do
	{
		NhanSu x;
		cout << "Nhap nhan su: ";
		x.Nhap();
		insertNode(root, x);

		cout << "Nhap 'n' hoac 'N' de dung: ";
		cin >> DiemDung;
	} while (DiemDung != 'n' && DiemDung != 'N');
	analyze(root);
}
//Định nghĩa phương thức sắp xếp cho cây
void BinarySearchTree::getTreeSort() //Cay nhi phan tim kiem la mot kieu du lieu da duoc sap xep san
{

}
//Định nghĩa phương thức tìm kiếm một nhân viên cho cây 
NhanSu BinarySearchTree::findInfo(std::string ns)
{
	//Khai báo các biến cần thiết cho việc tìm kiếm
	NhanSu tmp;
	tmp.setMaSo("");
	TNode* tmpp = new TNode;
	tmpp->Data = tmp;
	TNode* p = NULL;
	//Nếu tìm thấy theo mã số ta trả về
	p = findID(root, ns);
	//Nếu tìm thấy theo tên ta trả về 
	if (p == NULL) p = findName(root, ns);
	//Nếu không tìm thấy theo cả hai cách, ta cho mã số trả về là ""
	if (p == NULL) p = tmpp;
	return p->Data;
}

//Định nghĩa phương thức xóa đối tượng
void BinarySearchTree::deleteNode(NhanSu ns)
{
	//Gọi hàm xóa đã xây dựng sẵn
	deleteNodeByID(root, ns);
}
//Định nghĩa phương thức thêm mới
void BinarySearchTree::updateNode(NhanSu ns)
{
	//Trước khi thêm ta cần xóa trước để tránh bị trùng
	deleteNode(ns);
	//Gọi thực hiện hàm thêm đã xây dựng sẵn
	insertNode(root, ns);
	return;
}
//Định nghĩa phường thức đánh giá
void BinarySearchTree::analyze(TNode* t)
{
	if (t == NULL)
		return;
	double x = t->Data.getMucDoHoanThanhNhiemVuTrongNam();
	//Các mức độ đánh giá
	if (x >= 80)
		t->Data.setDanhGia("HTXSNV");
	if (x >= 65 && x < 80)
		t->Data.setDanhGia("HTTNV");
	if (x >= 50 && x < 65)
		t->Data.setDanhGia("HTNV");
	if (x < 50)
		t->Data.setDanhGia("KHTNV");
	analyze(t->pLeft);//Đánh giá các node trong cây bên trái
	analyze(t->pRight);//Đánh giá các node trong cây con bên phải
}
//Định nghĩa phương thức đánh giá cho tất cả đối tượng trong cây
void BinarySearchTree::analyzeAll()
{
	analyze(this->root);
}
//Định nghĩa phương thức hủy
BinarySearchTree::~BinarySearchTree()
{
	//Gọi thực hiện hàm hủy đã được xây dựng sẵn.
	RemoveAll(root);
}