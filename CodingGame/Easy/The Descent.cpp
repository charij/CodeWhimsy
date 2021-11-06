#include <iostream>
#include <algorithm>

using namespace std;

int main() {
	while (1) {
		int heights[8];
		for (int i = 0; i < 8; i++) cin >> heights[i];

		cout << distance(begin(heights), max_element(begin(heights), end(heights))) << endl;
	}
}