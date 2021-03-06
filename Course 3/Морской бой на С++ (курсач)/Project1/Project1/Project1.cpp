#include <iostream>
#include <iomanip>
#include <string>
#include <conio.h>
#include <windows.h>
#include <time.h>
using namespace std;
const int n = 10;
int map1[n][n] = { 0 };
int map2[n][n] = { 0 };
int smoke_p[n][n] = { 0 };
int si = 1;
int cor[20] = { 0 };

void menu1(), v_rand_rast(), game(), menu2(), show_map(int map[n][n]), v_sam_rast();

void menu1_1(int iItem) { //главное меню (вид)
	int i;
	system("mode con cols=45 lines=24");
	system("cls");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	for (i = 0; i<7; i++)
		cout << endl;
	cout << " +-----------------------------------------+" << endl;
	cout << " |                                         |" << endl;
	cout << " |               Морской бой               |" << endl;
	cout << " |                                         |" << endl;
	cout << " +-----------------------------------------+" << endl;
	if (iItem == 1) {
		cout << " |               ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Начать игру";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "               |" << endl;
	}
	else
		cout << " |               Начать игру               |" << endl;
	cout << " |                                         |" << endl;
	if (iItem == 2) {
		cout << " |                  ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Выход";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "                  |" << endl;
	}
	else
		cout << " |                  Выход                  |" << endl;
	cout << " +-----------------------------------------+" << endl;
}

//---------------------------------------------------------------------------

void menu2_2(int iItem1) { //меню выбора расстановки(вид)
	int i;
	system("mode con cols=45 lines=24");
	system("cls");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	for (i = 0; i<7; i++)
		cout << endl;
	cout << " +-----------------------------------------+" << endl;
	cout << " |                                         |" << endl;
	cout << " |           Расстановка кораблей          |" << endl;
	cout << " |                                         |" << endl;
	cout << " +-----------------------------------------+" << endl;
	if (iItem1 == 1) {
		cout << " |              ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Самостоятельно";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "             |" << endl;
	}
	else
		cout << " |              Самостоятельно             |" << endl;
	cout << " |                                         |" << endl;
	if (iItem1 == 2) {
		cout << " |                 ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Случайно";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "                |" << endl;
	}
	else
		cout << " |                 Случайно                |" << endl;
	cout << " |                                         |" << endl;
	if (iItem1 == 3) {
		cout << " |                  ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Назад";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "                  |" << endl;
	}
	else
		cout << " |                  Назад                  |" << endl;
	cout << " +-----------------------------------------+" << endl;
}

//---------------------------------------------------------------------------

void menu3_3(int iItem2) { //меню выбора cлучайной расстановки (вид)
	system("mode con cols=45 lines=15");
	system("cls");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	show_map(map1);
	cout << endl;
	cout << "Сменить расстановку кораблей?" << endl;
	if (iItem2 == 1) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Да";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "       ";
	}
	else
		cout << "Да       ";
	if (iItem2 == 2) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Нет";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		cout << "       ";
	}
	else
		cout << "Нет       ";
	if (iItem2 == 3) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "Назад" << endl;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	}
	else
		cout << "Назад" << endl;
}
//---------------------------------------------------------------------------

void menu3() { //меню выбора cлучайной расстановки
	int iItem2 = 1;
	int nLast2 = 3;
	system("mode con cols=45 lines=24");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	menu3_3(iItem2);
	while (TRUE) {
		if (GetAsyncKeyState(VK_LEFT)) {
			keybd_event(VK_LEFT, 0, KEYEVENTF_KEYUP, 0);
			if (0 < iItem2 - 1)
				iItem2 = iItem2 - 1;
			else
				iItem2 = nLast2;
			menu3_3(iItem2);
		}
		if (GetAsyncKeyState(VK_RIGHT)) {
			keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
			if (iItem2 < nLast2)
				iItem2 = iItem2 + 1;
			else
				iItem2 = 1;
			menu3_3(iItem2);
		}
		if (GetAsyncKeyState(VK_RETURN)) {
			keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
			menu3_3(iItem2);
			switch (iItem2) {
			case 1: v_rand_rast(); break;
			case 2: game(); break;
			case 3: menu2();
			}
		}
	}
}

//---------------------------------------------------------------------------

void menu2() { //меню выбора расстановки
	int iItem1 = 1;
	int nLast1 = 3;
	system("mode con cols=45 lines=24");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	menu2_2(iItem1);
	while (TRUE) {
		if (GetAsyncKeyState(VK_UP)) {
			keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, 0);
			if (0 < iItem1 - 1)
				iItem1 = iItem1 - 1;
			else
				iItem1 = nLast1;
			menu2_2(iItem1);
		}
		if (GetAsyncKeyState(VK_DOWN)) {
			keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
			if (iItem1 < nLast1)
				iItem1 = iItem1 + 1;
			else
				iItem1 = 1;
			menu2_2(iItem1);
		}
		if (GetAsyncKeyState(VK_RETURN)) {
			keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
			menu2_2(iItem1);
			switch (iItem1) {
			case 1: v_sam_rast(); break;
			case 2: v_rand_rast(); break;
			case 3: menu1();
			}
		}
	}
}

//---------------------------------------------------------------------------

void menu1() { //главное меню
	int iItem = 1;
	int nLast = 2;
	system("mode con cols=45 lines=24");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	menu1_1(iItem);
	while (TRUE) {
		if (GetAsyncKeyState(VK_UP)) {
			keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, 0);
			if (0 < iItem - 1)
				iItem = iItem - 1;
			else
				iItem = nLast;
			menu1_1(iItem);
		}
		if (GetAsyncKeyState(VK_DOWN)) {
			keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
			if (iItem < nLast)
				iItem = iItem + 1;
			else
				iItem = 1;
			menu1_1(iItem);
		}
		if (GetAsyncKeyState(VK_RETURN)) {
			keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
			menu1_1(iItem);
			switch (iItem) {
			case 1: menu2(); break;
			case 2: exit(0);
			}
		}
	}
}

//---------------------------------------------------------------------------

void sam_rast(int map[n][n], int ss, int ns) { //самостоятельная расстановка
	int x, y, d = 0, cs = 0, tx, ty, c=0;
	string v1, v2, v3;
	bool sp;
	while (cs < ns) {
		system("cls");
		show_map(map);
		cout << "-----------------------------------------------------" << endl;
		cout << "Размещение корабля с " << ss << " палубами: " << c << " из " << ns << endl;
		cout << "-----------------------------------------------------" << endl;
		cout << "Введите координаты откуда должен распологаться корабль: " << endl;
		cout << "Координата Х (A, B, C, D, E, F, G, H, I, J)" << endl;
		cin >> v1;
		if (v1 == "A" || v1 == "a")
			x = 0;
		else if (v1 == "B" || v1 == "b")
			x = 1;
		else if (v1 == "C" || v1 == "c")
			x = 2;
		else if (v1 == "D" || v1 == "d")
			x = 3;
		else if (v1 == "E" || v1 == "e")
			x = 4;
		else if (v1 == "F" || v1 == "f")
			x = 5;
		else if (v1 == "G" || v1 == "g")
			x = 6;
		else if (v1 == "H" || v1 == "h")
			x = 7;
		else if (v1 == "I" || v1 == "i")
			x = 8;
		else if (v1 == "J" || v1 == "j")
			x = 9;
		else if (v1 == "Nazad" || v1 == "nazad")
			menu2();
		else {
			cout << "Неверно введена координата Х, попробуйте снова" << endl;
			Sleep(1000);
			continue;
		}
		cout << "Координата Y (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)" << endl;
		cin >> v2;
		if (v2 == "0")
			y = 0;
		else if (v2 == "1")
			y = 1;
		else if (v2 == "2")
			y = 2;
		else if (v2 == "3")
			y = 3;
		else if (v2 == "4")
			y = 4;
		else if (v2 == "5")
			y = 5;
		else if (v2 == "6")
			y = 6;
		else if (v2 == "7")
			y = 7;
		else if (v2 == "8")
			y = 8;
		else if (v2 == "9")
			y = 9;
		else {
			cout << "Неверно введена координата Y, попробуйте снова" << endl;
			Sleep(1000);
			continue;
		}
		if (ss > 1) {
			cout << "Введите в каком направлении должен располагаться корабль:" << endl;
			cout << "(Vlevo, Vpravo, Vverh, Vniz)" << endl;
			cin >> v3;
			if (v3 == "Vpravo" || v3 == "vpravo")
				d = 0;
			else if (v3 == "Vniz" || v3 == "vniz")
				d = 1;
			else if (v3 == "Vlevo" || v3 == "vlevo")
				d = 2;
			else if (v3 == "Vverh" || v3 == "vverh")
				d = 3;
			else {
				cout << "Неверно введено направление, попробуйте снова" << endl;
				Sleep(1000);
				continue;
			}
		}
		tx = x;
		ty = y;
		sp = 1;
		for (int i = 0; i < ss; i++) {
			if (x<0 || y<0 || x >= n || y >= n) {
				sp = 0;
				cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
				Sleep(2000);
				break;
			}
			if (ss == 1 && x == 0 && y == 9) {
				if (map[x][y] >= 1 || map[x + 1][y] >= 1 || map[x + 1][y - 1] >= 1 || map[x][y - 1] >= 1) {
					sp = 0;
					cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
					Sleep(2000);
					break;
				}
			}
			else if (ss == 1 && y == 9) {
				if (map[x][y] >= 1 || map[x][y - 1] >= 1 || map[x + 1][y] >= 1 || 
					map[x + 1][y - 1] >= 1 || map[x - 1][y] >= 1 || map[x - 1][y - 1] >= 1) {
					sp = 0;
					cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
					Sleep(2000);
					break;
				}
			}
			if (ss == 1 && x == 0 && y == 0) {
				if (map[x][y] >= 1 || map[x + 1][y] >= 1 || map[x + 1][y + 1] >= 1 || map[x][y + 1] >= 1) {
					sp = 0;
					cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
					Sleep(2000);
					break;
				}
			}
			else if (ss == 1 && y == 0) {
				if (map[x][y] >= 1 || map[x][y + 1] >= 1 || map[x + 1][y] >= 1 ||
					map[x + 1][y + 1] >= 1 || map[x - 1][y] >= 1 || map[x - 1][y + 1] >= 1) {
					sp = 0;
					cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
					Sleep(2000);
					break;
				}
			}
			else if (map[x][y] >= 1 || map[x][y + 1] >= 1 || map[x][y - 1] >= 1 ||
				map[x + 1][y] >= 1 || map[x + 1][y + 1] >= 1 || map[x + 1][y - 1] >= 1 ||
				map[x - 1][y] >= 1 || map[x - 1][y + 1] >= 1 || map[x - 1][y - 1] >= 1) {
				sp = 0;
				cout << "Корабль не может быть так расположен, попробуйте снова" << endl;
				Sleep(2000);
				break;
			}
			switch (d) {
			case 0: x++; break;
			case 1: y++; break;
			case 2: x--; break;
			case 3: y--; break;
			}
		}
		if (sp == 1) {
			x = tx;
			y = ty;
			for (int i = 0; i < ss; i++) {
				map[x][y] = si;
				switch (d) {
				case 0: x++; break;
				case 1: y++; break;
				case 2: x--; break;
				case 3: y--; break;
				}
			}
			cor[si] = ss;
			si++;
			cs++;
			c++;
		}
	}
}

//---------------------------------------------------------------------------

void rand_rast(int map[n][n], int ss, int ns) { //случайная расстановка
	int x, y, d = 0, cs = 0, tx, ty;
	bool sp;
	while (cs < ns) {
		x = rand() % n;
		y = rand() % n;
		d = rand() % 4;
		tx = x;
		ty = y;
		sp = 1;
		for (int i = 0; i < ss; i++) {
			if (x<0 || y<0 || x >= n || y >= n) {
				sp = 0;
				break;
			}
			if (map[x][y] >= 1 || map[x][y + 1] >= 1 || map[x][y - 1] >= 1 ||
				map[x + 1][y] >= 1 || map[x + 1][y + 1] >= 1 || map[x + 1][y - 1] >= 1 ||
				map[x - 1][y] >= 1 || map[x - 1][y + 1] >= 1 || map[x - 1][y - 1] >= 1) {
				sp = 0;
				break;
			}
			switch (d) {
			case 0: x++; break;
			case 1: y++; break;
			case 2: x--; break;
			case 3: y--; break;
			}
		}
		if (sp == 1) {
			x = tx;
			y = ty;
			for (int i = 0; i < ss; i++) {
				map[x][y] = si;
				switch (d) {
				case 0: x++; break;
				case 1: y++; break;
				case 2: x--; break;
				case 3: y--; break;
				}
			}
			cor[si] = ss;
			si++;
			cs++;
		}
	}
}

//---------------------------------------------------------------------------

void show_map(int map[n][n]) { //вывод поля игрока при расстановке
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
	for (int i = 0; i < n; i++) {
		switch (i) {
		case 0: cout << setw(3) << "A"; break;
		case 1: cout << setw(2) << "B"; break;
		case 2: cout << setw(2) << "C"; break;
		case 3: cout << setw(2) << "D"; break;
		case 4: cout << setw(2) << "E"; break;
		case 5: cout << setw(2) << "F"; break;
		case 6: cout << setw(2) << "G"; break;
		case 7: cout << setw(2) << "H"; break;
		case 8: cout << setw(2) << "I"; break;
		case 9: cout << setw(2) << "J"; break;
		}
	}
	cout << endl;
	for (int i = 0; i < n; i++) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << i;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		for (int j = 0; j < n; j++) {
			if (map[j][i] == 0) {
				cout << setw(2) << '-';
			}
			else {
				cout << setw(2) << "1";
			}
		}
		cout << endl;
	}
}

//---------------------------------------------------------------------------

void show_smoke(int map1[n][n], int map2[n][n], int smoke_p[n][n]) { //вывод полей
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
	for (int i = 0; i < 2; i++) {
		for (int i = 0; i < n; i++) {
			switch (i) {
			case 0: cout << setw(3) << "A"; break;
			case 1: cout << setw(2) << "B"; break;
			case 2: cout << setw(2) << "C"; break;
			case 3: cout << setw(2) << "D"; break;
			case 4: cout << setw(2) << "E"; break;
			case 5: cout << setw(2) << "F"; break;
			case 6: cout << setw(2) << "G"; break;
			case 7: cout << setw(2) << "H"; break;
			case 8: cout << setw(2) << "I"; break;
			case 9: cout << setw(2) << "J"; break;
			}
		}
		if (i==1)
			cout << "";
		else
			cout << "           ";
	}
	cout << endl;
	for (int i = 0; i < n; i++) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << i;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		for (int j = 0; j < n; j++) {
			if (map1[j][i] == 0) {
				cout << setw(2) << '-';
			}
			else if (map1[j][i] == -1) {
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
				cout << setw(2) << "X";
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
			}
			else if (map1[j][i] == -2) {
				cout << setw(2) << "o";
			}
			else {
				cout << setw(2) << "1";
			}
		}
		cout << "           ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << i;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		for (int j = 0; j < n; j++) {
			if (smoke_p[j][i] == 1) {
				if (map2[j][i] == -2) {
					cout << setw(2) << 'o';
				}
				else if (map2[j][i] == -1) {
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
					cout << setw(2) << "X";
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
				}
				else {
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
					cout << setw(2) << "X";
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
				}
			}
			else
				cout << setw(2) << '-';
		}
		cout << endl;
	}
	cout << "          Вы                           " << "Противник" << endl;
}

//---------------------------------------------------------------------------

void v_rand_rast() { //процесс случайной расстановки
	srand(time(0));
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			map1[i][j] = 0;
			map2[i][j] = 0;
			smoke_p[i][j] = 0;
		}
	}
	system("cls");
	rand_rast(map1, 4, 1);
	rand_rast(map1, 3, 2);
	rand_rast(map1, 2, 3);
	rand_rast(map1, 1, 4);
	rand_rast(map2, 4, 1);
	rand_rast(map2, 3, 2);
	rand_rast(map2, 2, 3);
	rand_rast(map2, 1, 4);
	menu3();
}

//---------------------------------------------------------------------------

void v_sam_rast() { //процесс самостоятельной расстановки
		system("mode con cols=57 lines=20");
		HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
		srand(time(0));
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				map1[i][j] = 0;
				map2[i][j] = 0;
				smoke_p[i][j] = 0;
			}
		}
		system("cls");
		for (int i = 0; i < 8; i++)
			cout << endl;
		cout << "       ";
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		system("pause");
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
		system("mode con cols=57 lines=25");
		system("cls");
		sam_rast(map1, 4, 1);
		sam_rast(map1, 3, 2);
		sam_rast(map1, 2, 3);
		sam_rast(map1, 1, 4);
		rand_rast(map2, 4, 1);
		rand_rast(map2, 3, 2);
		rand_rast(map2, 2, 3);
		rand_rast(map2, 1, 4);
		Sleep(2000);
		game();
}

//---------------------------------------------------------------------------

void gg_game(int g_g) { //определение победителя
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	system("mode con cols=45 lines=24");
	system("cls");
	for (int i = 0; i<10; i++)
		cout << endl;
	if (g_g == 0) {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "                Вы проиграли" << endl;;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	}
	else {
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
		cout << "                Вы победили" << endl;;
		SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	}
	Sleep(2000);
	menu1();
}

//---------------------------------------------------------------------------

void game() { //игра
	int x1, y1, x2, y2, gg, d=0, prov1=0, prov2 = 0, kp=10;
	string v1, v2, v3;
	system("mode con cols=53 lines=24");
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
	for (int i = 0; i < 10; i++)
		cout << endl;
	cout << "      ";
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
	system("pause");
	SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
	while (true) {
		prov1 = 0;
		for (int i = 0; i < n; i++) {
			for (int j = 0; j < n; j++) {
				if (map2[i][j] == -1)
					prov1++;
			}
		}
		if (prov1 == 20) {
			gg = 1;
			gg_game(gg);
		}
		system("cls");
		show_smoke(map1, map2, smoke_p);
		cout << "-----------------------------------------------------" << endl;
		cout << "Вам осталось потопить " << kp << " кораблей противника" << endl;
		cout << "-----------------------------------------------------" << endl;
		cout << "Введите координаты выстрела: " << endl;
		cout << "Координата Х (A, B, C, D, E, F, G, H, I, J)" << endl;
		cin >> v1;
		if (v1 == "A" || v1 == "a")
			x1 = 0;
		else if (v1 == "B" || v1 == "b")
			x1 = 1;
		else if (v1 == "C" || v1 == "c")
			x1 = 2;
		else if (v1 == "D" || v1 == "d")
			x1 = 3;
		else if (v1 == "E" || v1 == "e")
			x1 = 4;
		else if (v1 == "F" || v1 == "f")
			x1 = 5;
		else if (v1 == "G" || v1 == "g")
			x1 = 6;
		else if (v1 == "H" || v1 == "h")
			x1 = 7;
		else if (v1 == "I" || v1 == "i")
			x1 = 8;
		else if (v1 == "J" || v1 == "j")
			x1 = 9;
		else if (v1 == "Stop" || v1 == "stop"){
			gg = 0;
			gg_game(gg);
		}
		else {
			cout << "Неверно введена координата Х, попробуйте снова" << endl;
			Sleep(1000);
			continue;
		}
		cout << "Координата Y (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)" << endl;
		cin >> v2;
		if (v2 == "0")
			y1 = 0;
		else if (v2 == "1")
			y1 = 1;
		else if (v2 == "2")
			y1 = 2;
		else if (v2 == "3")
			y1 = 3;
		else if (v2 == "4")
			y1 = 4;
		else if (v2 == "5")
			y1 = 5;
		else if (v2 == "6")
			y1 = 6;
		else if (v2 == "7")
			y1 = 7;
		else if (v2 == "8")
			y1 = 8;
		else if (v2 == "9")
			y1 = 9;
		else if (v2 == "Stop" || v2 == "stop") {
			gg = 0;
			gg_game(gg);
		}
		else {
			cout << "Неверно введена координата Y, попробуйте снова" << endl;
			Sleep(1000);
			continue;
		}
		if (map2[x1][y1] >= 1) {
			cor[map2[x1][y1]]--;
			if (cor[map2[x1][y1]] <= 0) {
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
				cout << "Убит" << endl;
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
				map2[x1][y1] = -1;
				smoke_p[x1][y1] = 1;
				Sleep(2000);
				kp--;
				continue;
			}
			else {
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
				cout << "Ранен" << endl;
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
				map2[x1][y1] = -1;
				smoke_p[x1][y1] = 1;
				Sleep(2000);
				continue;
			}
		}
		else {
			SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
			cout << "Мимо" << endl;
			SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
			smoke_p[x1][y1] = 1;
			map2[x1][y1] = -2;
			Sleep(2000);
		}
		while (true) {
			prov2 = 0;
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					if (map1[i][j] == -1)
						prov2++;
				}
			}
			if (prov2 == 20) {
				gg = 0;
				gg_game(gg);
			}
			x2 = rand() % 9;
			y2 = rand() % 9;
			if (map1[x2][y2] == -1 || map1[x2][y2] == -2)
				continue;
			system("cls");
			show_smoke(map1, map2, smoke_p);
			cout << "-----------------------------------------------------" << endl;
			cout << "Ход противника: " << endl;
			if (x2 == 0)
				v3 = "A";
			else if (x2 == 1)
				v3 = "B";
			else if (x2 == 2)
				v3 = "C";
			else if (x2 == 3)
				v3 = "D";
			else if (x2 == 4)
				v3 = "E";
			else if (x2 == 5)
				v3 = "F";
			else if (x2 == 6)
				v3 = "G";
			else if (x2 == 7)
				v3 = "H";
			else if (x2 == 8)
				v3 = "I";
			else if (x2 == 9)
				v3 = "J";
			if (map1[x2][y2] >= 1) {
				cor[map1[x2][y2]]--;
				if (cor[map1[x2][y2]] <= 0) {
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
					cout << "Ваш корабль убит" << endl;
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
					Sleep(2000);
					map1[x2][y2] = -1;
					continue;
				}
				else {
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
					cout << "Ваш корабль ранен по координатам [" << v3 << "][" << y2 << "]" << endl;
					SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
					Sleep(2000);
					map1[x2][y2] = -1;
					continue;
				}
			}
			else {
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 4));
				cout << "Противник промазал по координатам [" << v3 << "][" << y2 << "]" << endl;
				SetConsoleTextAttribute(hConsole, (WORD)((15 << 4) | 9));
				Sleep(2000);
				map1[x2][y2] = -2;
				break;
			}
		}
	}
}

//---------------------------------------------------------------------------

int main() {
	system("mode con cols=45 lines=24");
	setlocale(LC_ALL, "rus");
	menu1();
	return 0;
}