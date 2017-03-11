W tym folderze b�d� umieszczane zadania domowe dotycz�ce komunikacji z u�yciem XMLRPC.

Zadania s� osobne dla ka�dej z grup. Po rozwi�zaniu zadania nale�y projekt skompresowa� w pojednczy .zip, wzgl�dnie .tar.gz i wgra� na ePortal - zadania b�d� odbierane na pocz�tku
nast�pnych zaj��.

W razie powa�nych problem�w zach�cam do przegl�dania StackOverflow lub kontaktu ze mn� przez standardowy mail PWr - w szczeg�lno�ci je�li przyk�ady nie obrazuj�

Uwagi og�lne: 

W szczeg�lno�ci przy u�ywaniu Eclipse, je�li wydaje Wam si� �e kod zosta� poprawnie zmodyfikowany, a na kliencie otrzymujecie informacj�, �e "nie da si� znale�� funkcji", "niew�a�ciwe typy parametr�w"
lub co� innego tego typu, upewnijcie si�, �e odpalona jest poprawna wersja serwera - WebServer Apache XMLRPC dopiero po ok. 30 sekundach od uruchomienia rzuca b��dem "Cannot bind - port already in use", wi�c mo�na
to przeoczy� przy uruchamianiu. Wszystkie instancje uruchomione w Eclipse s� dost�pne z poziomu tamtejszej konsoli - przy wprowadzaniu zmian w serwerze nale�y najpierw wy��czy� wszystkie instancje, a dopiero
potem uruchomi� nowy serwer.

Apache XMLRPC w wersji 3.1.3 tworzy now� instancj� handlera dla ka�dego po��czenia, wi�c nie mo�na przechowywa� stanu w obiekcie handlera.
Przyk�ad dzia�aj�cego rozwi�zania jest w kodzie przyk�adu w tym repozytorium.

Apache XMLRPC umo�liwia przesy�anie w�asnych typ�w danych, ale wymaga to implementacji specjalnej klasy t�umacz�cej. Nie jest to nic trudnego,
ale jest troch� pisania dodatkowego kodu, wi�c nie trzeba tego robi�. Dla zainteresowanych szczeg�y s� tutaj: https://ws.apache.org/xmlrpc/advanced.html

Kody odpowiedzi s� raczej dzia�aniem w stylu C/Basha ni� Javy i stosujemy je tutaj tylko dla uproszczenia. Zasadniczo r�wnie dobrze mogliby�my 
rzuci� wyj�tek i przechwyci� do w odpowiednim miejscu (nie robimy tego, bo wprowadza to troch� dodatkowej z�o�ono�ci)
