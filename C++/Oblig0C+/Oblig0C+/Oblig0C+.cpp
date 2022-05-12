// Oblig0C+.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "calculator.h"
#include <vector>
#include <algorithm>
using namespace std;


int Myfunction(const char* p) {
    int i = 0;
    for (; *p; p++) {
        i++;
    }

    return i;
}

int main()
{
    char buffer[25];
    vector<string> words;
    vector<string> ::iterator ptr;
    string q;
    
    while (words.size() < 5) {
        cout << "Enter a char: ";
        cin >> q;
        words.push_back(q);
    }
    sort(words.begin(), words.end());
    int x = 10;
    pluss(x);

    cout << Myfunction(buffer) << "\n" << endl;
    cout << x << "\n" << endl;
    for (ptr = words.begin(); ptr < words.end(); ptr++) {
        cout << *ptr << endl;
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
