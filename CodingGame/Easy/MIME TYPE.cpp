#include <iostream>
#include <string>
#include <map>

using namespace std;

string toupper(string str)
{
	for (auto & c : str) c = toupper(c);
	return str;
}

int main()
{
	int N, Q;
	cin >> N >> Q; cin.ignore();

	map<string, string> mime;
	for (int i = 0; i < N; i++)
	{
		string key, value;
		cin >> key >> value; cin.ignore();
		mime[toupper(key)] = value;
	}

	string str;
	while (getline(cin, str))
	{
		int pos = str.find_last_of(".");
		str = (pos == -1) ? "" : toupper(str.substr(pos + 1));
		cout << (mime.count(str) ? mime[str] : "UNKNOWN") << endl;
	}
}