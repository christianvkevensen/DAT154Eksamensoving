// PolyMorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
using namespace std;

class Drink {
public:
    virtual bool MayDrive() = 0;    
};

class Juice : public Drink {
public:
    virtual bool MayDrive() {
        return true;
    }
};

class Beer : public Drink {
public:
    virtual bool MayDrive() {
        return false;
    }
};
Drink* ReadDrink() {
    char x;
    cout << "J = Juice, B=Beer, Q = Quit: ";
    cin >> x;
    switch (x)
    {
    case 'J':
        return new Juice;
    case 'B':
        return new Beer;
    default:
        return 0;
    }
};

void PolyMorphic() {
    Drink* tab[100];

    int i = 0;
    while (tab[i++] = ReadDrink());

    cout << "Total drinks: " << (i-1) << endl;

    string MayDrive = "yes";
    for (int j = 0; j < i; j++) {
        if (tab[j]->MayDrive()) {
            MayDrive = "Never";
            break;
        }
    }
    cout << "you may drive: " << MayDrive;

    for (int j = 0; j < i; j++) {
        delete tab[j];
    }
};

int main()
{
    PolyMorphic();
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
