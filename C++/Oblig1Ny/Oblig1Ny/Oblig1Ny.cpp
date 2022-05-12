// Oblig1Ny.cpp : Defines the entry point for the application.
//
#include "framework.h"
#include "Oblig1NY.h"
#include "d2d1.h"
#include <vector>

using namespace std;
class Car {
public:
	int posX;
	int posY;
	Car(int _posX, int _posY) {
		this->posX = _posX;
		this->posY = _posY;

	}

	void draw(HDC hdc) {
		HBRUSH carBrush = CreateSolidBrush(RGB(255, 0, 0));
		HGDIOBJ hOrg = SelectObject(hdc, carBrush);
		Rectangle(hdc, posX, posY, posX + 10, posY + 10);
	}

};

class CarList {
public:
	vector<Car*> carlist;

	void AddCar(int x, int y) {
		carlist.push_back(new Car(x, y));
	}

	void Draw(HDC hdc) {
		for (vector<Car*>::iterator it = carlist.begin(); it != carlist.end(); ++it) {
			(*it)->draw(hdc);
		}
	}

	void Clear() {
		carlist.clear();
	}

	void MoveE(int counter, int line, int dx, int r_screen) {
		for (vector<Car*>::iterator it = carlist.begin(); it != carlist.end(); ++it) {
			if ((*it)->posX > r_screen) {
				//carlist.erase(it);
				//delete* it;
			}
		}
		int xprev = -1321;
		for (vector<Car*>::iterator it = carlist.begin(); it != carlist.end(); ++it) {
			if (xprev == -1321) {
				if ((*it)->posX > line) {
					(*it)->posX += dx;
					xprev = (*it)->posX;
				}
				else if ((counter == 0 || counter == 1) && ((*it)->posX > line - 5 && (*it)->posX < line + 5)) {
					xprev = (*it)->posX;
				}
				else {
					(*it)->posX += dx;
					xprev = (*it)->posX;
				}

			}
			else if (xprev - dx < ((*it)->posX + dx)) {
				xprev = (*it)->posX;
			}
			else if ((counter == 0 || counter == 1) && ((*it)->posX > line - 5 && (*it)->posX < line + 5)) {
				xprev = (*it)->posX;
			}
			else {
				(*it)->posX += dx;
				xprev = (*it)->posX;
			}
		}

	}
	void MoveN(int counter, int line, int dy, int b_screen) {
		for (vector<Car*>::iterator it = carlist.begin(); it != carlist.end(); ++it) {
			if ((*it)->posY > b_screen) {
				
				//carlist.erase(carlist.begin());
				//delete* it;
			}
		}
		int yprev = -100;
		for (vector<Car*>::iterator it = carlist.begin(); it != carlist.end(); ++it) {
			if (yprev == -100) {
				if ((*it)->posY > line) {
					(*it)->posY += dy;
					yprev = (*it)->posY;
				}
				else if ((counter == 2 || counter == 3) && ((*it)->posY > line - 5 && (*it)->posY < line + 5)) {
					yprev = (*it)->posY;
				}
				else {
					(*it)->posY += dy;
					yprev = (*it)->posY;
				}

			}
			else if (yprev - dy < ((*it)->posY + dy)) {
				yprev = (*it)->posY;
			}
			else if ((counter == 2 || counter == 3) && ((*it)->posY > line - 5 && (*it)->posY < line + 5)) {
				yprev = (*it)->posY;
			}
			else {
				(*it)->posY += dy;
				yprev = (*it)->posY;
			}
		}

	}

};



#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
int counter = 0;
int pw=90;
int pn=90;

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    Prob(HWND, UINT, WPARAM, LPARAM);
void                MakeTrafficLight(HDC hdc, RECT vei1, RECT vei2, bool tr);
CarList* listE = new CarList();
CarList* listN = new CarList();

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
	LoadStringW(hInstance, IDC_OBLIG1NY, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_OBLIG1NY));

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

	return (int)msg.wParam;
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

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_OBLIG1NY));
	wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_OBLIG1NY);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

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

	SetTimer(hWnd, 1, 1000, (TIMERPROC)NULL);
	SetTimer(hWnd, 2, 400, (TIMERPROC)NULL);

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
	RECT vei1, vei2;
	RECT screen;
	GetClientRect(hWnd, &screen);
	HDC hdc = BeginPaint(hWnd, &ps);
	HBRUSH carBrush = CreateSolidBrush(RGB(255, 0, 0));
	HGDIOBJ hOrg = SelectObject(hdc, carBrush);
	vei1 = { 0, screen.bottom / 3, screen.right, screen.bottom / 2 };
	vei2 = { 500, screen.top / 2, 600, screen.bottom };

	switch (message)
	{
	case WM_LBUTTONDOWN:
	{
		DialogBox(hInst, MAKEINTRESOURCE(IDD_DIALOG1), hWnd, Prob);
		//listE->AddCar(0, ((vei1.bottom - vei1.top) / 2) + vei1.top);

		break;
	}
	case WM_RBUTTONDOWN: 
	{
		//listN->AddCar((((vei2.right - vei2.left) / 2) +vei2.left), 0);

		break;
	}
	case WM_KEYDOWN:
	{
		switch (wParam)
		{
		case VK_LEFT:
		{
			pw += 10;
		}
		case VK_RIGHT:
		{
			pw -= 10;
		}case VK_UP:
		{
			pn -= 10;
		}case VK_DOWN:
		{
			pn += 10;
		}
		}
	}
	case WM_TIMER:

		switch (wParam)
		{
		case 1:
			counter = (counter + 1) % 4;
			InvalidateRect(hWnd, 0, true);
			break;

		case 2:
			if ((rand() % 100) >= pw) {
				listE->AddCar(0, ((vei1.bottom - vei1.top) / 2) + vei1.top);
			}
			if (rand() % 100 >= pn) {
				listN->AddCar((((vei2.right - vei2.left) / 2) + vei2.left), 0);
			}

			listE->MoveE(counter, vei2.left, 10, vei1.right);
			listN->MoveN(counter, vei1.top-10, 10, vei2.bottom);
			InvalidateRect(hWnd, 0, true);
			break;
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

		HBRUSH blackBrush = CreateSolidBrush(RGB(0, 0, 0));

		FillRect(hdc, &vei1, blackBrush);
		FillRect(hdc, &vei2, blackBrush);

		hOrg = SelectObject(hdc, carBrush);

		listE->Draw(hdc);
		listN->Draw(hdc);


		DeleteObject(carBrush);
		MakeTrafficLight(hdc, vei1, vei2, true);
		MakeTrafficLight(hdc, vei1, vei2, false);

		// TODO: Add any drawing code that uses hdc here...

		EndPaint(hWnd, &ps);
	}
	break;
	case WM_DESTROY:
		KillTimer(hWnd, 1);
		KillTimer(hWnd, 2);
		listE->Clear();
		listN->Clear();
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
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
INT_PTR CALLBACK Prob(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;


	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			
			pn = GetDlgItemInt(hDlg, IDC_PN, 0, 0);
			pw = GetDlgItemInt(hDlg, IDC_PW, 0, 0);
			if (pw > 100) {
				pw = 100;
			}
			if (pw < 0) {
				pw = 0;
			}
			if (pn > 100) {
				pn = 100;
			}
			if (pn < 0) {
				pn = 0;
			}
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
void MakeTrafficLight(HDC hdc, RECT vei1, RECT vei2, bool tr) {
	RECT window;
	RECT rect;
	HBRUSH blackBrush = CreateSolidBrush(RGB(0, 0, 0));
	HBRUSH grayBrush = CreateSolidBrush(RGB(58, 58, 58));
	HBRUSH redBrush = CreateSolidBrush(RGB(255, 0, 0));
	HBRUSH yellowBrush = CreateSolidBrush(RGB(255, 255, 0));
	HBRUSH greenBrush = CreateSolidBrush(RGB(0, 128, 0));

	int l_counter = counter;

	if (tr) {
		rect.left = vei2.left - (vei2.right * 0.2);
		rect.top = vei1.top - (vei2.bottom * 0.3);
		rect.bottom = vei1.top - 20;
		rect.right = vei2.left - 50;
	}
	else {
		rect.left = vei2.left - (vei2.right * 0.2);
		rect.top = vei1.bottom + 20;
		rect.bottom = vei1.bottom + (vei2.bottom * 0.3);
		rect.right = vei2.left - 50;
		l_counter = (counter + 2) % 4;
	}
	int height = rect.bottom - rect.top;

	HGDIOBJ hOrg;
	FillRect(hdc, &rect, blackBrush);
	switch (l_counter) {
	case 0:
	{
		hOrg = SelectObject(hdc, redBrush);
		Ellipse(hdc, rect.left, rect.top, rect.right, rect.top + (height * 0.33));
		hOrg = SelectObject(hdc, grayBrush);
		Ellipse(hdc, rect.left, rect.top + (height * 0.33), rect.right, rect.top + (height * 0.66));
		Ellipse(hdc, rect.left, rect.top + (height * 0.66), rect.right, rect.bottom);
		break;
	}
	case 1:
	{
		hOrg = SelectObject(hdc, redBrush);
		Ellipse(hdc, rect.left, rect.top, rect.right, rect.top + (height * 0.33));

		hOrg = SelectObject(hdc, yellowBrush);
		Ellipse(hdc, rect.left, rect.top + (height * 0.33), rect.right, rect.top + (height * 0.66));
		hOrg = SelectObject(hdc, grayBrush);
		Ellipse(hdc, rect.left, rect.top + (height * 0.66), rect.right, rect.bottom);
		break;
	}
	case 2:
	{
		hOrg = SelectObject(hdc, grayBrush);
		Ellipse(hdc, rect.left, rect.top, rect.right, rect.top + (height * 0.33));

		Ellipse(hdc, rect.left, rect.top + (height * 0.33), rect.right, rect.top + (height * 0.66));
		hOrg = SelectObject(hdc, greenBrush);
		Ellipse(hdc, rect.left, rect.top + (height * 0.66), rect.right, rect.bottom);
		break;


	}
	case 3:
	{
		hOrg = SelectObject(hdc, yellowBrush);
		Ellipse(hdc, rect.left, rect.top + (height * 0.33), rect.right, rect.top + (height * 0.66));

		hOrg = SelectObject(hdc, grayBrush);
		Ellipse(hdc, rect.left, rect.top, rect.right, rect.top + (height * 0.33));

		Ellipse(hdc, rect.left, rect.top + (height * 0.66), rect.right, rect.bottom);

		break;

	}

	DeleteObject(blackBrush);
	DeleteObject(grayBrush);
	DeleteObject(greenBrush);
	DeleteObject(yellowBrush);
	DeleteObject(redBrush);
	DeleteObject(hOrg);

	}
}