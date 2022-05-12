// ØvingC++.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string> 
#include "test.h"

using namespace std;


class Car {
public:
	int number;
	string color;

	Car(int _number, string _color) {
		this->number = _number;
		this->color = _color;
	}
	void Show() {
		cout << "\n" << this->color;
	}
	
};


int main()
{
	//int x;
	int y = 5;

	void* p = &y;
	//cin >> x;
	//cin >> y;
	//cout << pluss(x, y);

	string farge = "bajs";
	farge.pop_back();
	cout << farge;

	Car* car1 = new Car(1, "red");
	Car* car2 = new Car(3, "blue");

	Car car3 = Car(1, "green");


	car1->Show();
	car2->Show();
	car3.Show();

	cout << *(int*) p;

	delete car1;
	delete car2;
	
}



// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
