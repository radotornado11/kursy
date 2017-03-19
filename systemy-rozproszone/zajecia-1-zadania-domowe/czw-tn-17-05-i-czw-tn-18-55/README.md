Kontynuujemy implementowanie namiastki systemu zarz�dzania zasobami. 

W ramach zadania domowego zajmiemy si� tworzeniem osobnego serwera zajmuj�cego si� pomiarem czasu komunikacji.

Nale�y zaimplementowa� trzy klasy: 

**Client**, uruchamiany na maszynie u�ytkownika. W tej klasie b�dziemy wy�wietla� u�ytkownikowi wszystkie pomiary.

**MeasurementServer**, reprezentuj�cy dzia�aj�cy w ustalonym miejscu punkt docelowy. W tej klasie b�dziemy wykonywa� pomiary.

**ResourceServer**, reprezentuj�cy dzia�aj�cy w sieci serwer aplikacji. W tej klasie b�dziemy wykonywa� operacje.

**ResourceServer** powinien oferowa� 3 operacje:

 - `String put(String uri, double value)` - umieszcza na serwerze warto�� `value` pod identyfikatorem `uri`. Je�li
 jaki� zas�b jest ju� na serwerze pod tym identyfikatorem nale�y zwr�ci� "403 Forbidden", je�li operacja si� powiedzie - "200 OK"
 - `Object get(String uri)` - zwraca zas�b znajduj�cy si� pod podanym uri. 
 Je�li zas�b o zadanej nazwie nie istnieje, nale�y zwr�ci� String "404 Not Found"
 - `String delete(String uri)` - usuni�cie danego zasobu. 
 Je�li plik o zadanej nazwie nie istnieje nale�y zwr�ci� "404 Not Found", w przeciwnym razie "200 OK"
 
w stanie serwera **ResourceServer** nale�y przechowa� map� zas�b -> warto��

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje wykonanie i argumenty.

**MeasurementServer** powinien oferowa� dwie operacje:

 - `double measureSyncManagement(List<String> uris, List<Double> values)`, kt�ra dla ka�dej pary (uri, value) synchronicznie wywo�uje sekwencj� `get(uri)` -> `put(uri, value)` -> `get(uri)` -> `delete(uri)` -> `get(uri)` `moveFile` dla ka�dej pary (from, to), a na koniec zwraca czas wykonania wszystkich operacji.
  Nale�y sprawdzi� wynik - pierwszy i ostatni get powinny zwr�ci� b��d 404, natomiast trzy �rodkowe operacje (put - get - delete) powinny si� powie�� dla ka�dej danej wej�ciowej.
 Je�li rozmiar uris i values jest r�ny, wynikiem powinno by� `NaN` (Not a Number), tak samo je�li dla kt�rej� z operacji serwer zwr�ci b��d (brak pliku o zadanej nazwie)
 - `double measureAsyncManagement(List<String> uris, List<Double> values,)` - scenariusz jest ten sam co w `measureSyncManagement`, tyle �e sekwencje musz� by� synchronizowane, tzn. nie mo�na za��da� pobrania zasobu przed jego wstawieniem.
 Mo�na to zrobi� na dwa sposoby:
 
  1. Zsynchronizowa� wykonanie wszystkich get�w, wszystkiech put�w itd. (tak robili�my to na zaj�ciach)
  2. Synchronizowa� w ramach jednego uri (tzn. triggerem dla zawo�ania put jest wykonanie poprzedniego zapytania get itd.)
  
  Drugie rozwi�zanie jest trudniejsze z u�yciem Apache XMLRPC (znacznie �atwiej by�oby je wykona� z u�yciem takich mechaniz�w jak CompletableFuture) - prawdopodobnie
  b�dzie te� bardziej wydajne. W przypadku jego poprawnej implementacji mo�na liczy� na dodatkowe punkty, ale zaznaczam, �e napisanie tego mo�e zaj�� do�� du�o czasu i nie b�dzie wymagane (10 pkt jest do zdobycia za wersj� 1, 13 za wersj� 2)
  
 Pomiar mo�e by� trudny w przypadku Apache XMLRPC 1.2b, gdzie nie jest dost�pny TimingOutCallback (oczekiwanie na odpowied�) - w przypadku tej wersji biblioteki mo�na ewentualnie przy oczekiwaniu na wynik u�y� funkcji `sleep` w p�tli z kr�tkim interwa�em czasowym (~10ms)

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje wykonanie i argumenty. 
 
**Client** powinien wykona� nast�puj�ce operacje: 
 
 - wywo�a� `delete()` z `ResourceServer` i wydrukowa� uzyskan� warto��
 - wywo�a� `put(...)` ze �cie�k� do nieistniej�cego pliku - nale�y oczekiwa� odpowiedzi 1
 - wywo�a� `put` z co najmniej 15 plikami - jedn� ze �cie�ek docelowych powinna by� �cie�ka u�yta w poprzednim punkcie, wydrukowa� wynik
 - wywo�a� `measureSyncManagement` z co najmniej 150 parami uri/warto�� - wydrukowa� wynik
 - wywo�a� `measureAsyncManagement` z co najmniej 150 parami uri/wartos� - wydrukowa� wynik

Komunikacja mi�dzy klientem a ka�dym z serwer�w powinna by� synchroniczna. 

Ka�da wywo�ana funkcja z interfejsu powinna drukowa� swoje argumenty.

W pliku .puml w tym folderze znajduje si� pomocniczy diagram UML obrazuj�cy sekwencj� komunikacji pomi�dzy obiektami. Diagram jest w formacie PlantUML, ale dla wygody wrzucam tak�e png.
