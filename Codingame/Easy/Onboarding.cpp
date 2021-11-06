#include <iostream>

using namespace std;

int main() {
	while (1) {
		string  e1, e2;
		int     d1, d2;
		cin >> e1 >> d1 >> e2 >> d2;
		cout << (d1 < d2 ? e1 : e2) << endl;
	}
}