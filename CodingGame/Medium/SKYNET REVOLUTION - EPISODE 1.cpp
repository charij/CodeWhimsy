#include <iostream>

using namespace std;

int main()
{
	int N, L, G, Na, Nt;                    // N = Node Count; L = Link Count; G = Gateway Count;
	cin >> N >> L >> G; cin.ignore();       // Read in count values

	int links[N][N] = { 0 };                  // Build a table of size N by N full of 0s
	for (int N1, N2, i = 0; i < L; i++) {   // For each active link:
		cin >> N1 >> N2; cin.ignore();      // - Read in two nodes that link
		links[N1][N2] = links[N2][N1] = 1;  // - Add to table as a 1 (in both possible positions)
	}
	for (int Gi, i = 0; i < G; i++) {       // For each gateway Node:
		cin >> Gi; cin.ignore();            // - Read in one gateway node
		links[Gi][Gi] = -1;                 // - Add to table as a -1 (overwrite [x][x] as we only care where the agent moves)
	}
	while (cin >> Na)                       // When agent's position has changed, get updated position
	{
		for (int i = 0; i < N; i++)         // Scan though all nodes
			if (links[Na][i] > 0) {         // - If active link between agents node and this one then:            
				Nt = i;                     // -- Set as possible solution
				if (links[i][i] < 0)        // -- If node is also the gateway then:
					break;                  // --- End the scan
			}
		links[Na][Nt] = links[Nt][Na] = 0;  // Clear solution from the link table (in both possible positions)
		cout << Na << " " << Nt << endl;    // Submit solution
	}
}