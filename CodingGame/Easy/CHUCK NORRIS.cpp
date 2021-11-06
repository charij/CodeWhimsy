#include <iostream>
#include <string>
#include <map>

using namespace std;

map<string, string> code
{
	{ "00", "0" },
	{ "11", "0" },
	{ "1" , "0 0" },
	{ "0" , "00 0" },
	{ "01", " 0 0" },
	{ "10", " 00 0" },
};

int main()
{
	string msg, prev;
	getline(cin, msg);

	for (char c : msg)
		for (char m = 0x40; m > 0; m /= 2)
		{
			string next = (c & m) ? "1" : "0";
			cout << code[prev + next];
			prev = next;
		}
}