#pragma once

#include "NhanSu.h"
#include "TNode.h"

//Khai báo một số các hàm giúp đỡ cho các phương thức của đối tượng
void LNR(TNode* t);
void findAndReplace(TNode*&, TNode*&);
void deleteNodeByID(TNode*&, NhanSu ns);
TNode* findName(TNode*, std::string ns);
TNode* findID(TNode*, std::string ns);
void RemoveAll(TNode*&);

//Khai báo lớp đối tượng cây nhị phân
class BinarySearchTree
{
private:
	TNode* root;
public:
	BinarySearchTree();
	TNode* getTree();
	void init();
	TNode* getNode(NhanSu ns);
	void insertNode(NhanSu ns);
	void insertNode(TNode*&, NhanSu ns);
	void Nhap();
	void getTreeSort();
	NhanSu findInfo(std::string ns);

	void deleteNode(NhanSu ns);

	void updateNode(NhanSu ns);
	void analyze(TNode*);
	void analyzeAll();
	~BinarySearchTree();
};

