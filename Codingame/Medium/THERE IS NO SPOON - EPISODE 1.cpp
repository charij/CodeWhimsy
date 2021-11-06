#include <iostream>
#include <string>
#include <vector>

using namespace std;

int width, height;
vector<string> grid;

string findNode(int x, int y, int dx, int dy)
{
	x += dx;
	y += dy;

	if (x >= width || y >= height)
		return "-1 -1";

	if (grid[y][x] != '0')
		return findNode(x, y, dx, dy);

	return to_string(x) + " " + to_string(y);
}

int main()
{
	cin >> width >> height; cin.ignore();

	grid.resize(height);

	for (auto &row : grid)
		getline(cin, row);

	for (int x = 0; x < width; x++)
		for (int y = 0; y < height; y++)
			if (grid[y][x] == '0')
				cout << to_string(x) << " "
				<< to_string(y) << " "
				<< findNode(x, y, 1, 0) << " "
				<< findNode(x, y, 0, 1) << endl;
}