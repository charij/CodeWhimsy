#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	int lightX, lightY, initialTX, initialTY;
	cin >> lightX >> lightY >> initialTX >> initialTY; cin.ignore();

	// game loop
	while (1)
	{
		int remainingTurns;
		cin >> remainingTurns; cin.ignore();

		string direction = "";

		int dy = initialTY - lightY;
		int dx = initialTX - lightX;

		if (0 < dy) {
			direction = "N";
			initialTY -= 1;
		}
		else
			if (0 > dy) {
				direction = "S";
				initialTY += 1;
			}

		if (0 < dx) {
			direction += "W";
			initialTX -= 1;
		}
		else
			if (0 > dx) {
				direction += "E";
				initialTX += 1;
			}

		cout << direction << endl;
	}
}