Prosty CRUD do zarządzania kampanią reklamową dla różnych produktów.
Tworząc oraz edytując dane należy wpisywać wartości zmiennoprzecinkowe oddzielając część całkowitą od ułamkowej kropką (spowodowane brakiem ModelBinding dla pl-PL w .NET 6).
Program tworzy konto bankowe w bazie danych zainicjalizowane kwotą 10000.
Nie można wydać więcej niż się posiada, powoduje to wypisanie odpowiedniego komunikatu.
Nie można edytować wartości kampanii.

Aby utworzyć bazę danych należy otworzyć z poziomu VS 2022 konsole menadżera pakietów NUGet,
nastepnie wpisać polecenie: add-migration nazwa_migracji
A potem : update-database.
Nastepnie można uruchomić program do testowania operacji CRUD.
