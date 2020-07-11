# 1000000_in_1

Projekt ___"1000000_in_1"___ jest grą zbierającą kilka prostych gierek logicznych. Swoją formą próbuje przywołać wspomnienia wczesnych lat dla konsoli i doświadczenia grania u młodego odbiorcy.
Jak sama nazwa obiecuje, w pliku możemy znależć aż 1 000 000 gier. Są one uporządkowane w przejrzystym i intuicyjnym menu.
Nawiązanie do retro gier odnosi się do kasetek kupowanych na targach oferujących wspomniane 1000000 gier, a tak naprawdę zawierających zaledwie kilka gier, które w zależności od strony, startowały np od 2 poziomu co według twórców czyniło z nich nową grę. W aplikacji wspomniana retro wizja objawia się w wpływie aktualnie wyświetlanej strony na grę. wraz z zmianą stron zmieniają się takie elementy jak wartości początkowe, ilość składników itp. 


## Program

  Program składa się z 3 funkcji:
  - ***GUI()*** - odpowiedzialnej za warstwe wizualną menu.
  - ***GUIend()*** - odpowiedizalnej za interfejs zamykania programu.
  - ***Main()*** - odpowiedzialną za połączenie logiki aplikacji zawartej w ClassLibrary z interfejsem GUI.
  
  
## ClassLibrary

  Jest to biblioteka zawierająca w 7 klas i 1 enum, bedących zbiorem funkcji, odpowiedzialnych za funkcionowanie gier jak i logikę menu.

### GameList

  Pierwszą klasą, jest klasa GameList. Jest to klasa odpowiedzialna za logikę menu jak i połączenie go z odpowiednimi grami. Zawiera w sobie zmienną typu string przechowywującą dane wejściowe jak i 8 funkcji:
  - ***List()*** - jest to funkcja odpowiedzialną za logikę listy menu. Wczytuje przechwyconą informacje od użytkownika na wejściu i intepretuje ją.
  - ***CaseMenu()*** - jest to funkcja uruchamiająca dostępne gry w zależności od podanych parametrów wejściowych i zgłaszająca wyjątek w przypadku błędnego ID gry.
  - ***BUM()*** - jest to prosta gra polegająca na wzajemnym odliczaniu. Funkcja organizuje interfejs GUI jak i logikę gry, korzystając z biblioteki BumGame.
  - ***RACHMISTRZ()*** - jest to gra polegajaca na sumowaniu liczb. Funkcja organizuje interfejs GUI jak i logikę gry, korzystając z biblioteki Rachmistrz.
  - ***FUNDELS()*** - jest to gra polegająca na wzajemny tworzeniu coraz to większej liczby z dostępnej tali. Funkcja organizuje interfejs GUI jak i logikę gry,    korzystając z biblioteki FundelsGame.
  - ***SIMON()*** - jest to gra polegająca na odtworzeniu instrukcji podanej przez komputer. Funkcja organizuje interfejs GUI jak i logikę gry, korzystając z biblioteki Simon.
  - ***SQUALA()*** - jest to gra polegająca na wykonywaniu odpowiednich obliczeń na danych liczbach. Funkcja organizuje interfejs GUI jak i logikę gry, korzystając z biblioteki SqualaGame.

### - BumGame

```
BumGame jest prostą grą polegającą na tym że dwóch graczy (w tym przypadku gracz i komputer) liczą na zmianę od podanej liczby.
W momencie kiedy dana liczba ktr będą mieli napisać, będzie podzielna lub zawierała w sobie wcześniej zdefiniowaną liczbę, graczę piszą "BUM"
```

Jest to pierwsza klasa związana z konkretną grą. Zawiera w sobie Regulamin gry, jak i dwie funkcje odpowiedzialne za logikę aplikacji.
  - ***IfBUM*** - Funkcje typu bool, zwracającą true, w momencie gdy podany test przy danych warunkach powinien być tz. liczbą BUM.
  - ***Si*** - funkcja typu string, zwracająca odpowiedź komputera, uwzględniając mechanizmy pozwalające graczowi wygrać.

### - Rachmistrz

```
Rachmistrz jest grą do ćwiczenie dodawania coraz to większych ilości liczb w głowie.
Komputer losuje a następnie wyświetla liczby a gracz ma za zadanie je zsumować i zapisać wynik na wejściu.
```

Jest to klasa odpowiedzialna za funkcionowanie gry Rachmistrz. Klasa zawiera w sobie zmienną typu string _RndNumbers_ z zapisanymi liczbami do wypisania, regulamin jak i funkcje typu int odpowiedzialną za losowanie liczb, wypisanie ich do zmiennej _RndNumbers_ i zwrócenie ich sumy.

### - FundelsGame

```
Na ekranie wyświetlają się karty, które tworzą jedną liczbę.
Zadaniem graczy (komputera i gracza) jest podanie nr id cyfry tworzącej te liczbę, która ma zostać zamieniona na wylosowaną kartę.
Celem jest utworzenie najmniejszej liczby większej od porzedniej, tworzonej przez karty na stole.
```

Jest to klasa odpowiedzialna za logikę gry Fundels. Zawiera w sobie dwie kolekcje generyczne typu Dictionary, będące talią gracza i komputera. Zawiera w sobie 6 funkcji:
  - ***Regulamin()*** - funkcja wypisująca regulamin.
  - ***InicjowanieTalli()*** - Funkcja zapisująca kart do talli. Losuje liczby i wpisuje je do kolekcji.
  - ***Tasowanie()*** - Tasowanie kolekcji taliaSI i taliaGracz.
  - ***InicjowanieStolu()*** - funkcja zwracająca tablicę int zawierającą wartości kart wypisanych na stole, tworzących liczbę w celu inicjowania tej tablicy.
  - ***TableCards*** - Funkcja wracająca tablicę int zawierającą wartości kart wypisanych na stole, po zamianie danej liczby na daną karte gracza, lub zwracająca wyjątki w sytuacji gdy liczba nie spełnia warunku takiego że, liczba po operacji zamiany jest najmniejszą możliwą liczbą większą od poprzedniej.
  - ***Si*** - Funkcja zwracająca wartość typu int, będącą odpowiedzią komputera.

### - Simon

```
Simon, gra polegająca odtworzeniu kombinacji kolorów, wylosowanej przez komputer.
```

Jest to klasa odpowiedzialna za logikę gry simon. Znajduje się tam typ wyliczeniowy zawierający kolory, jak i kilekcje generyczną Queue, zawierającą kolory zapisane w odpowiedniej kolejności, wylosowanej przez komputer. Klasa zawiera 4 funkcje:
  - ***private RandomEnumValue<działanie>()*** - funkcja zwracająca losowy kolor.
  - ***Regulamin()*** - funkcja wypisująca regulamin.
  - ***SimonSay()*** - funkcja zwraca losowy kolor i zapisuje go do kolejki.
  - ***PlayerSaid()*** - funkcja typu bool, zwracająca true, jeżeli podany test jest kolejną wartością w kolejce.

### - SqualaGame

``` 
Prosta gra polegająca na wykonywaniu odpowiedniej ilości zadań na dwóch liczbach.
Gra naipierw losuje działanie a potem podaje nam liczbyy na których mamy wykonać to zadanie.
```

Są to tak naprawdę 2 klasy i jeden typ wyliczeniowy, uporządkowane tak, dla przejrzystości. W enum znajdują się dostępne działania, w klasie Trudność, dostępne stałe przechowywujące wartości dla danych poziomów trudności, i klasa SqualaGame, zawierająca całą logikę gry w squala.
___SqualaGame___ - Zawiera w sobie zdefiniowane typy, konstruktor jak i metody.
  ##Typy:
  - działanie - przechowywujący działanie wylosowane w konstruktorze.
  - liczba1 i liczba2 - przechowywujące liczby na ktr będą wykonywane operacje.
  ##Konstruktor:
  - Losujący działanie wykorzystując metode RandomEnumValue<>().
  ##Metody:
  - przeLosowanie() - motoda typu void, losujący i wpisująca wartości do liczba1 i liczba2.
  - Wynik() - metoda zwracająca wartość tyou int, będącą wynikiem działania na liczba1 i liczba2.
  - private RandomEnumValue<działanie>() - Prywatna metoda zwracająca losowe działanie
