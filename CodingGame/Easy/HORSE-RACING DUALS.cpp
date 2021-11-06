#include <iostream>
#include <algorithm>

using namespace std;

int readInt() { int i; cin >> i; return i; }

int main()
{
	int N = readInt(), P[N];

	generate(P, P + N, readInt);
	sort(P, P + N);

	int diff = P[1] - P[0];
	for (int i = 2; i < N; i++)
		diff = min(diff, P[i] - P[i - 1]);

	cout << diff << endl;
}