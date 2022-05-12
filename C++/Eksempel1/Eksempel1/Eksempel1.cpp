// Eksempel1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include<vector>
using namespace std;

class Vehicle {
public:
    int wheels;
    string model;
    int year;

    Vehicle(int _wheels, string _model, int _year) {
        wheels = _wheels;
        model = _model;
        year = _year;
    };
};

class Car : public Vehicle {
    using Vehicle::Vehicle;
};
class MotorBike : public Vehicle {
    using Vehicle::Vehicle;
};

class VehicleList {
public:
    vector<Vehicle*> vehicles;
    vector<Vehicle*> ::iterator itr;

    void Draw() {
        for (itr = vehicles.begin(); itr != vehicles.end(); itr++) {
            cout << "BMW: " + (*itr)->model << (*itr)->wheels << " " << (*itr)->year <<endl;
        }
    }
    void AddCar(Vehicle* v) {
        vehicles.push_back(v);
    }
    void Clear() {
        vehicles.clear();
    }
};

int main()
{
    VehicleList* vehicleList = new VehicleList();
    Car car1 = Car(4, "BMW", 1998);
    Car car2= Car(4, "BMW", 1998);
    Car car3= Car(4, "BMW", 1998);
    Car car4= Car(4, "BMW", 1998);
    MotorBike bike = MotorBike(2, "Merc", 2003);
    vehicleList->AddCar(&car1);
    vehicleList->AddCar(&car2);
    vehicleList->AddCar(&car3);
    vehicleList->AddCar(&car4);
    vehicleList->AddCar(&bike);
    vehicleList->Draw();
    vehicleList->Clear();
    //cout << "Model: " + car->model + ", wheels: " << car->wheels << ", year: " << car->year << endl;

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
