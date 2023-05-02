#pragma once

#include "NhanSu.h"

class TNode
{
public:
	NhanSu Data;
	TNode* pLeft;
	TNode* pRight;
	int ID;
	TNode() {};
	TNode(NhanSu x)
	{
		static int genID = 1;
		this->Data = x;
		this->pLeft = NULL;
		this->pRight = NULL;
		this->ID = genID++;
	}
	//~TNode()
	//{
	//	delete pLeft;
	//	delete pRight;
	//}
};
