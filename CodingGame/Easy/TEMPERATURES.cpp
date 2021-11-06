#include <iostream>

using namespace std;

int main()
{
	int count, newTemp, lowTemp = ((unsigned int)~0 >> 1);
	cin >> count; cin.ignore();

	if (count == 0) lowTemp = 0;

	while (count-- && cin >> newTemp)
		if (abs(newTemp) < abs(lowTemp) || abs(newTemp) == -lowTemp)
			lowTemp = newTemp;

	cout << lowTemp << endl;
}