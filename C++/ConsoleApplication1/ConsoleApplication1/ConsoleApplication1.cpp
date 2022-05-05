// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

class Car 
{
public:
    int n;
    Car(int _n): n(_n){}
    void Draw() {
        cout << n << " : () == ()" << endl;
    }
};

class CarList {
public:
    Car* carList[100];
    int i;
    CarList() {
        i = 0;
    }
    void push(Car* car) {
        carList[i++] = car;
    }

    void Draw() {
        for (int j = 0; j < i; j++) {
            carList[j]->Draw();
            delete carList[j];
        }
        
    }
};

int main()
{
    CarList* carList = new CarList();

    for (int i = 0; i < 3; i++) {
        carList->push(new Car(i));
    }
    carList->Draw();
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
