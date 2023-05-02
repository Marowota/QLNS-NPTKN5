// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include "NhanSu.h"
#include "BinarySearchTree.h"
#include <msclr\marshal_cppstd.h>
#using <mscorlib.dll>

using namespace System;

////to tell the compiler and linker to export function and variable dll
//#ifdef BACKENDLIBRARY_EXPORTS
////for this DLL
//#define BACKENDLIBRARY_API __declspec(dllexport)
//#else
////for the CLI
//#define BACKENDLIBRARY_API __declspec(dllimport)
//#endif
//
//extern "C"
//{

//Tao mot vo boc de boc class C++ thanh C#
//Duoc de trong namespace nham phan biet khi include vao C#
	namespace BackEnd
	{
		public ref class NhanSuWrapper
		{
		private:
			NhanSu* ns;
		public:
			NhanSuWrapper()
			{
				ns = new NhanSu;
			}
			NhanSuWrapper(NhanSu other)
			{
				ns = new NhanSu;
				*ns = other;
			}
			NhanSuWrapper(NhanSuWrapper^ other)
			{
				ns = new NhanSu;
				*ns = *other->ns;
			}
			NhanSu* getNS()
			{
				return ns;
			}
			void setNS(NhanSu other)
			{
				*ns = other;
			}
			property String^ MaSo
			{
				String^ get()
				{
					return gcnew String(ns->getMaSo().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setMaSo(context.marshal_as<std::string>(value));
				}
			}
			property String^ hoTen
			{
				String^ get()
				{
					return gcnew String(ns->getHoTen().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setHoTen(context.marshal_as < std::string>(value));
				}
			}
			property String^ namSinh
			{
				String^ get()
				{
					return gcnew String(ns->getNamSinh().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setNamSinh(context.marshal_as < std::string>(value));
				}
			}
			property String^ gioiTinh
			{
				String^ get()
				{
					return gcnew String(ns->getGioiTinh().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setGioiTinh(context.marshal_as < std::string>(value));
				}
			}
			property String^ chucDanh
			{
				String^ get()
				{
					return gcnew String(ns->getChucDanh().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setChucDanh(context.marshal_as < std::string>(value));
				}
			}
			property String^ chucVu
			{
				String^ get()
				{
					return gcnew String(ns->getChucVu().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setChucVu(context.marshal_as < std::string>(value));
				}
			}
			property long long luong
			{
				long long get()
				{
					return ns->getLuong();
				}
				void set(long long value)
				{
					ns->setLuong(value);
				}
			}
			property String^ donVi
			{
				String^ get()
				{
					return gcnew String(ns->getDonVi().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setDonVi(context.marshal_as < std::string>(value));
				}
			}
			property double mucDoHoanThanh
			{
				double get()
				{
					return ns->getMucDoHoanThanhNhiemVuTrongNam();
				}
				void set(double value)
				{
					ns->setMucDoHoanThanhNhiemVuTrongNam(value);
				}
			}
			property String^ danhGia
			{
				String^ get()
				{
					return gcnew String(ns->getDanhGia().c_str());
				}
				void set(String^ value)
				{
					msclr::interop::marshal_context context;
					ns->setDanhGia(context.marshal_as < std::string>(value));
				}
			}
		};

		public ref class BinarySearchTreeWrapper
		{
		private:
			BinarySearchTree* bt;
			//Su dung mang de chuyen thong tin in sang C#
			void printLNR(TNode* T, array<NhanSuWrapper^>^ nsa, int& i)
			{
				if (T == NULL) return;
				printLNR(T->pLeft, nsa, i);
				nsa[i] = gcnew NhanSuWrapper(T->Data);
				i++;
				printLNR(T->pRight, nsa, i);
			}
		public:

			BinarySearchTreeWrapper()
			{
				bt = new BinarySearchTree();
			}
			void insertNode(NhanSuWrapper^ ns)
			{
				bt->insertNode(*ns->getNS());
			}
			NhanSuWrapper^ findInfo(String^ s)
			{
				NhanSuWrapper^ tmp = gcnew NhanSuWrapper();
				msclr::interop::marshal_context context;
				tmp->setNS(bt->findInfo(context.marshal_as<std::string>(s)));
				return tmp;
			}
			void deleteNode(NhanSuWrapper^ ns)
			{
				bt->deleteNode(*ns->getNS());
			}
			void updateNode(NhanSuWrapper^ ns)
			{
				bt->updateNode(*ns->getNS());
			}
			void analyze()
			{
				bt->analyzeAll();
			}
			int printLNR(array<NhanSuWrapper^>^ nsa)
			{
				int tmp = 0;
				printLNR(bt->getTree(), nsa, tmp);
				return tmp;
			}
		};
	}
//}
