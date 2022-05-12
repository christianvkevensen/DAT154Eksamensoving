// Abstract.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;
extern void GetCars();

class Vehicle {
public:
    int _wheels;
    string _modell;

    ~Vehicle() {}

    virtual void GetWheels() = 0;
};

class Car : public Vehicle {
public:
    Vehicle::Vehicle;
    void GetWheels() {
        _wheels = 4;
    }
};

class Bike : public Vehicle {
public:
    void GetWheels() {
        _wheels = 2;
    }
};

void GetCars() {
    Vehicle* vehicles[10];

    string modell;
    char type = 0;
    int i = 0;
    while (type != 'q') {
        cout << "Car type?" << endl;
        cin >> type;
        cout << "Car Modell?" << endl;
        cin >> modell;
        switch (type)
        {
        case 'b':
        {
            Bike* bike = new Bike();
            bike->_modell = modell;
            bike->GetWheels();
            vehicles[i] = bike;
            i++;
            break;
        }
        case 'c':
        {
            Car* car = new Car();
            car->_modell = modell;
            car->GetWheels();
            vehicles[i] = car;
            i++;
            break;
        }
        case'q':
        {
            break;
        }
        }
    }
    for (int k = 0; k < i; k++) {
        cout << vehicles[k]->_modell << " " << vehicles[k]->_wheels;
    }

    for (int j = 0; j < i; j++) {
        delete vehicles[j];
    }
}

int main()
{
    GetCars();
    char liste[] = "swaggyti";
    char* peker = liste;
    
    cout << peker[3] << endl;
    
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
