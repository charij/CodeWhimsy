#include <iostream>
#include <string>

using namespace std;

int index(char c) { return isalpha(c) ? toupper(c) - 'A' : 26; }

int main()
{
	int L, H;
	string T, row;

	cin >> L >> H; cin.ignore();
	getline(cin, T);

	while (getline(cin, row))
	{
		for (char c : T)
			cout << row.substr(index(c) * L, L);
		cout << endl;
	}
}