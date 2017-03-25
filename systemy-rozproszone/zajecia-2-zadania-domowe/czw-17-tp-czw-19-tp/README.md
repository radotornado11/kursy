Kontynuujemy implementowanie namiastki systemu zarz�dzania biblioteczk�. 

W ramach zadania domowego zajmiemy si� tworzeniem dodatkowych funkcjonalno�ci zwi�zanych ze wsp�dzieleniem danych.

Nale�y zaimplementowa�: 

**Client**, uruchamiany na maszynie u�ytkownika. W tej klasie b�dziemy dodawa� ksi��ki do biblioteczki. W czasie test�w b�dziemy uruchamia� dwie instancje klienta.

**BookshelfServer**, reprezentuj�cy dzia�anie biblioteczki.

Typ **Book** reprezentuj�cy ksi��k�. Klasa **Book** powinna udost�pnia� pola: `String author` i `String title`.

**BookshelfServer** powinien oferowa� 4 operacje:

 - `int putPrivate(Book book, String ownerName)` - umieszcza na w prywatnej bibliotecze u�ytkownika `ownerName` ksi��k� `book` i zwraca nadany jej identyfikator.
 Identyfikator powinien by� unikalny dla ka�dej ksi��ki. Ksi��ka powinna by� zawsze dost�pna pod danym identyfikatorem (a� do jej usuni�cia z biblioteczki), 
 niezale�nie od innych zmian na p�ce. Dost�p do ksi��ki powinien mie� tylko u�ytkownik `ownerName`.
 - `int putPublic(Book book)` - umieszcza w publicznie dost�pnej biblioteczce ksi��k� `book` i zwraca nadany jej identyfikator. Ka�dy u�ytkownik powinien mie� dost�p
 do ksi��ki publicznej pod otrzymanym identyfikatorem.
 - `Book get(String user, int id)` - zwraca ksi��k� znajduj�c� si� pod podanym id, o ile jest dost�pna dla u�ytkownika `user`. 
 Je�li ksi��ka o zadanym id nie istnieje, nale�y zwr�ci� `null`
 - `bool delete(String user, int id)` - usuni�cie danej ksi��ki z biblioteczki, o ile jest dost�pna dla u�ytkownika `user`.
 Je�li ksi��ka zosta�a usuni�ta nale�y zwr�ci� `true`, w przeciwnym razie - `false`.
 
to oznacza, �e w stanie serwera **BookshelfServer** nale�y przechowa� w jaki� spos�b (proponuj� map�) identyfikatory ksi��ek, w�a�cicieli i same ksi��ki.

Ka�da wywo�ana funkcja na serwerze powinna drukowa� swoje wykonanie i argumenty.

W testowaniu serwera wykorzystamy dwie instancje klienta. Klienty powinny by� uruchomione **w osobnych procesach**. Przekazywanie id pomi�dzy klientami
mo�na wykonywa� r�cznie, tzn. wczytywa� identyfikator ksi��ki do pobrania z poziomu wiersza polece� (nie ma potrzeby implementowania komunikacji mi�dzy klientami)

W pliku .puml w tym folderze znajduje si� diagram UML obrazuj�cy sekwencj� komunikacji pomi�dzy klientami a serwerem. 
Diagram jest w formacie PlantUML, ale dla wygody wrzucam tak�e png.
