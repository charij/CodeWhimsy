#include <iostream>
#include <string>
#include <algorithm>
#include <sstream>
#include <locale>

using namespace std;

class CommaRadixPoint : public numpunct<char> { protected: char do_decimal_point() const { return ','; } };

void stod(string &s, double &f)
{
	stringstream ss(s);
	ss.imbue(locale(locale(), new CommaRadixPoint));
	ss >> f;
}

int main()
{
	int N;
	double lonA, latA, lonB, latB, minD = 999999;
	string index, name, address, phone, lon, lat, minName;

	cin.imbue(locale(locale(), new CommaRadixPoint));
	cin >> lonA >> latA >> N; cin.ignore();

	for (int i = 0; i < N; i++)
	{
		getline(cin, index, ';');
		getline(cin, name, ';');
		getline(cin, address, ';');
		getline(cin, phone, ';');
		getline(cin, lon, ';');
		getline(cin, lat);

		stod(lon, lonB);
		stod(lat, latB);

		double x = (lonA - lonB) * cos((latA + latB) / 2),
			y = latA - latB,
			newD = sqrt(pow(x, 2) + pow(y, 2)) * 6371;

		if (minD >= newD)
		{
			minD = newD;
			minName = name;
		}
	}
	cout << minName << endl;
}