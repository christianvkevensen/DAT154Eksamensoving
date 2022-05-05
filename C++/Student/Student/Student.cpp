// Student.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
using namespace std;

class Student {
public:
    int studNr;
    string name;

    Student(int studNr, string name) {
        this->studNr = studNr;
        this->name = name;
    }
    static Student* makeStudent() {
        int studNr;
        string name;
        bool ferdig = false;
        cout << "StudName: (q if quit)" << endl;
        cin >> name;
        cout << "StudNr: " << endl;
        cin >> studNr;

        return new Student(studNr, name);
    }
};

int main()
{
    Student* students[10];
  
    for (int i = 0; i < 3; i++) {
        students[i]=(Student::makeStudent());
    }

    for (int i = 0; i < 3; i++) {
        cout << students[i]->name << students[i]->studNr << endl;
    }
    for (int i = 0; i < 3; i++) {
        delete students[i];
    }

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
