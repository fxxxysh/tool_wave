// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

//#include "stdafx.h"
#include "comlink.h"

using namespace std;

int ttt_add(int x, int y)
{
	return x + y;
}

//// 这是导出变量的一个示例
//DLL_API int nDllDemo = 1;
//DLL_API int nExternCDllDemo = 2;
//
//// 这是导出函数的一个示例。
//DLL_API int fnDllDemo(void)
//{
//	return 42;
//}
//
//DLL_API int fnExternCDllDemo(void)
//{
//	return 142;
//}
//
//char DLL_API fnDefault(char, int, float)
//{
//	return 'a';
//}
//char DLL_API __stdcall fnstdcall(char, int, float)
//{
//	return 'b';
//}
//char DLL_API __cdecl fncdecl(char, int, float)
//{
//	return 'c';
//}
//char DLL_API __fastcall fnfastcall(char, int, float)
//{
//	return 'd';
//}
//
//// 这是已导出类的构造函数。
//// 有关类定义的信息，请参阅 DllDemo.h
//CDllDemo::CDllDemo()
//{
//	return;
//}
