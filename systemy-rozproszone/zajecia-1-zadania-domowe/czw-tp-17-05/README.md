Kontynuujemy implementowanie namiastki systemu zarz�dzania serwerami. 

W ramach zadania domowego zajmiemy si� tworzeniem osobnego serwera zajmuj�cego si� pomiarem czasu komunikacji.

Nale�y zaimplementowa� trzy klasy: 

**Client**, uruchamiany na maszynie u�ytkownika (np. administratora systemu). W tej klasie b�dziemy wy�wietla� u�ytkownikowi wszystkie pomiary.

**MeasurementServer**, reprezentuj�cy dzia�aj�cy w ustalonym miejscu punkt docelowy. W tej klasie b�dziemy wykonywa� pomiary.

**SupervisedServer**, reprezentuj�cy dzia�aj�cy w sieci serwer aplikacji. W tej klasie b�dziemy wykonywa� operacje.

**SupervisedServer** powinien oferowa� 3 operacje:

 - `int getLoad()` - zwracaj�cy dowoln� sta�� liczb� z zakresu 0-100
 - `int moveFile(String fromLocation, String toLocation)` - przesuni�cie pliku w obr�bie serwera (tzn. usun�� plik `fromLocation` ze stanu i doda� plik `toLocation` o takich samych uprawnieniach do stanu). 
 Je�li plik o zadanej nazwie nie istnieje, nale�y zwr�ci� 1, je�li plik docelowy ju� istnieje i zosta�by nadpisany nale�y zwr�ci� 2, je�li operacja si� uda nale�y zwr�ci� 0.
 - `int setPermissions(String fileName, int permissions)` - zmiana uprawnie� dla zadanego pliku. 
 Je�li plik o zadanej nazwie nie istnieje nale�y zwr�ci� 1, w przeciwnym razie wykona� operacj� i zwr�ci� 0
 
w stanie serwera **SupervisedServer** nale�y przechowa� *zahardkodowane* dane (nie pobiera� ich z dysku ani znik�d indziej) - obci��enie serwera (int load) 
i obs�ugiwane pliki (pary nazwa-uprawnienia, np. w postaci obiekt�w albo mapy nazwa -> uprawnienia). W stanie powinno by� przynajmniej 15 plik�w.

uprawnienia mog� by� podane w dowolnej formie, tzn. nie musi by� to format u�ywany przez systemy POSIXowe, mo�na u�y� po prostu liczb 1, 2, 3 itd.

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje wykonanie i argumenty.

**MeasurementServer** powinien oferowa� dwie operacje:

 - `double measureSyncMove(List<String> froms, List<String> tos)`, kt�ra synchronicznie wywo�uje `moveFile` dla ka�dej pary (from, to), a na koniec zwraca czas wykonania wszystkich operacji.
 Je�li rozmiar froms i tos jest r�ny, wynikiem powinno by� `NaN` (Not a Number), tak samo je�li dla kt�rej� z operacji serwer zwr�ci b��d (brak pliku o zadanej nazwie)
 - `double measureAsyncMove(List<String> from, List<String> to,)` - to samo tylko �e `moveFile` ma by� wywo�ywany asynchronicznie. Pomiar mo�e by� trudny w przypadku Apache XMLRPC 1.2b, gdzie nie 
 jest dost�pny TimingOutCallback (oczekiwanie na odpowied�) - w przypadku tej wersji biblioteki mo�na ewentualnie przy oczekiwaniu na wynik u�y� funkcji `sleep` w p�tli z kr�tkim interwa�em czasowym (~10ms)

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje wykonanie i argumenty. 
 
**Client** powinien wykona� nast�puj�ce operacje: 
 
 - wywo�a� `getLoad()` z `SupervisedServer` i wydrukowa� uzyskan� warto��
 - wywo�a� `setPermissions(...)` ze �cie�k� do nieistniej�cego pliku - nale�y oczekiwa� odpowiedzi 1
 - wywo�a� `measureSyncMove` z co najmniej 15 plikami - jedn� ze �cie�ek docelowych powinna by� �cie�ka u�yta w poprzednim punkcie, wydrukowa� wynik
 - wywo�a� `setPermissions(...)` z t� sam� �cie�k� co poprzednio - plik ju� istnieje, wi�c nale�y oczekiwa� odpowiedzi 0
 - wywo�a� `measureAsyncMove` z tymi samymi plikami co poprzednio, tylko zamieni� `froms` z `tos` (tzn. przesun�� pliki z powrotem na miejsca pocz�tkowe), wydrukowa� wynik 

Komunikacja mi�dzy klientem a ka�dym z serwer�w powinna by� synchroniczna. 

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje wykonanie i argumenty.

W pliku .puml w tym folderze znajduje si� pomocniczy diagram UML obrazuj�cy sekwencj� komunikacji pomi�dzy obiektami. Diagram jest w formacie PlantUML, ale dla wygody wrzucam tak�e png.
