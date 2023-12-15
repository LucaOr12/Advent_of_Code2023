#include <iostream>
#include <cstring>
#include <fstream>
#include <cstdlib>
#include <algorithm>
using namespace std;

int main()
{
    string inputText;
    ifstream input("input1.txt");
    int combinedDigit = 0;

    if (!input.is_open())
    {
        cerr << "error" << endl;
        return 1;
    }
    while (getline(input, inputText))
    {
        size_t firstDigitPos = inputText.find_first_of("0123456789");
        size_t lastDigitPos = inputText.find_last_of("0123456789");

        if (firstDigitPos != string::npos && lastDigitPos != string::npos)
        {
            int firstDigit = inputText[firstDigitPos] - '0';
            int lastDigit = inputText[lastDigitPos] - '0';
            int currentCombinedDigit = firstDigit * 10 + lastDigit;

            combinedDigit += currentCombinedDigit;
        }
    }
    input.close();

    cout << "the combined digits are: " << combinedDigit << endl;
    return 0;
}