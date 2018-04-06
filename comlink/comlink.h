#pragma once

#define DLL_EXPORTS

#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif

__declspec(dllexport) int ttt_add(int x, int y);


//class DLL_API CDllDemo {
//public:
//	CDllDemo(void);
//	// TODO:  在此添加您的方法。
//};
//
//extern DLL_API int nDllDemo;
//extern "C" extern DLL_API int nExternCDllDemo;
//
//DLL_API int fnDllDemo(void);
//extern "C" DLL_API int fnExternCDllDemo(void);
//
//char DLL_API fnDefault(char, int, float);
//char DLL_API __stdcall fnstdcall(char, int, float);
//char DLL_API __cdecl fncdecl(char, int, float);
//char DLL_API __fastcall fnfastcall(char, int, float);