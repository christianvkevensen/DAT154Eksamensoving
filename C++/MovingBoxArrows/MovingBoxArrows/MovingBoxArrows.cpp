// MovingBoxArrows.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "MovingBoxArrows.h"
#include <string>
#include <random>

class Car {
public:
    int x;
    int y;

    Car(int _x,int  _y) : x(_x), y(_y) {};

    ~Car(){}

    void Draw(HDC hdc) {
        Rectangle(hdc, x, y, x + 15, y + 15);
    }

    void MoveN() {
        y -= 10;
    }
    void MoveS() {
        y += 10;
    }
    void MoveW() {
        x -= 10;
    }
    void MoveE() {
        x += 10;
    }
};
class Fuel {
public: 
    int x, y;
    Fuel(int _x, int _y) : x(_x), y(_y) {};

    void Draw(HDC hdc) {
        Rectangle(hdc, x, y, x + 10, y + 10);
    }
    ~Fuel(){}
};

void MoveN(Car* car) {
    car->MoveN();
}
void MoveS(Car* car) {
    car->MoveS();
}
void MoveW(Car* car) {
    car->MoveW();
}
void MoveE(Car* car) {
    car->MoveE();
}

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
Car* car; 
Fuel* fuel;
typedef void (*FP) (Car* car);
FP funcPointer = 0;
int points = 0;


// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_MOVINGBOXARROWS, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MOVINGBOXARROWS));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_MOVINGBOXARROWS));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_MOVINGBOXARROWS);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    PAINTSTRUCT ps;
    HDC hdc = BeginPaint(hWnd, &ps);
    RECT screen;
    GetClientRect(hWnd, &screen);
    switch (message)
    {
    case WM_CREATE: {
       
        car = new Car(0, 100);

        fuel = new Fuel(rand() % screen.right, rand() & screen.bottom);
        SetTimer(hWnd, 0, 50, 0);
        funcPointer = MoveE;
        break;
    }
    case WM_TIMER: {
        switch (wParam) {
        case 0:
        {
            funcPointer(car);
            if ((car->x - fuel->x <= 10 && fuel->x - car->x <= 10) && (car->y - fuel->y <= 10 && fuel->y - car->y <= 10)) {
                points++;                
                delete fuel;
                fuel = new Fuel(rand() % screen.right, rand() & screen.bottom);
            }
            InvalidateRect(hWnd, 0, true);
            break;
        }
        }
    case WM_KEYDOWN:
    {
        switch (wParam)
        {
        case VK_LEFT:
        {
            funcPointer = MoveW;
            break;

        }
        case VK_RIGHT:
        {
            funcPointer = MoveE;
            break;

        }case VK_UP:
        {
            funcPointer = MoveN;
            break;

        }case VK_DOWN:
        {
            funcPointer = MoveS;
            break;
        }

        }
    }
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        // Parse the menu selections:
        switch (wmId)
        {
        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
    }
    break;
    case WM_PAINT:
    {
        car->Draw(hdc);
        fuel->Draw(hdc);
    
        TCHAR text[256];
        swprintf_s(text, 256, L"points: %d", points);
        TextOut(hdc,10,10, text, wcslen(text));
        // TODO: Add any drawing code that uses hdc here...
        EndPaint(hWnd, &ps);
    }
    break;
    case WM_DESTROY:
        KillTimer(hWnd, 0);
        delete car;
        delete fuel;
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
        return 0;
    }
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
