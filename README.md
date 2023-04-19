# Kolokwium
## Przygotowanie do kolokwium
### Pobranie i przetestowanie szablonu kolokwium
1) Proszę pobrać gałąź kolokwium w formie pliku zip. A następnie wypakować jego zawartość.
  <img src="Img/download_zip.png" width=350 height=300></img>
2) Proszę otworzyć folder `Kolokwium` przy pomocy Visual Studio Code.

    <img src="Img/open_folder.png" width=400 height=270></img>

    <img src="Img/open_folder2.png" width=400 height=250></img>

    <img src="Img/open_folder3a.png" width=400 height=350></img>

3) Proszę otworzyć plik `Kolokwium -> appsettings.json` a następnie podmienić wartość `Database` connection stringa podając swoje imię i nazwisko (bez znaków diakrytycznych) zamiast `Imie_Nazwisko`. Dzięki temu w momencie zastosowania pierwszej migracji utworzy się nowa baza danych zaczynającą się Państwa imieniem i nazwiskiem.
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Imie_NazwiskoAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }
    ```
4) Proszę w Visual Studio Code otworzyć nowy terminal `Terminal -> New Terminal`.
    
5) Nastepnie proszę pobrać wszystkie potrzebne biblioteki oraz skompilować całą solucję. W tym celu proszę wykonać poniższe polecenie.

    ```
    dotnet build
    ```
6) Proszę upewnić się że narzędzia `dotnet-ef tool update` oraz `dotnet-aspnet-codegenerator` są poprawnie zainstalowane, w tym celu proszę wykonać poniższe polecenia.    
    ```
    dotnet tool update --global dotnet-ef --version 6.0.10
    dotnet tool update -g dotnet-aspnet-codegenerator --version 6.0.10
    ```
    
7) W celu weryfikacji poprawności działania aplikacji proszę ją uruchomić.

    ```
    dotnet run --project Kolokwium
    ```

    Aplikacja powinna być dostępna pod adresem: [http://localhost:5000](http://localhost:5000).
    ![Alt text](Img/run_web.png?raw=true)
    
8) Jeśli aplikacja działa poprawnie proszę ją zamknąć przy pomocy kombinacji klawiszy `ctrl + c`.

### Uruchomienie dokumentacji
W trakcie trwania kolokwium mogą Państwo korzystać z dostarczonej dokumentacji Microsoft Learn. 
[https://learn.microsoft.com](https://learn.microsoft.com)
### Proszę przejść do wykonywania zadań

```diff
- Życzę Państwu powodzenia na kolokwium! :)
```

### Umieszenie rozwiązania w archiwum
1)  Po otrzymaniu oceny proszę w folderze `Kolokwium` wykonać poniższe polecenia.
    ```powershell
    Remove-Item Kolokwium/bin -Recurse -Force
    Remove-Item Kolokwium/obj -Recurse -Force
    ```
    Proszę się upewnić że foldery `bin` i `obj` zostały usunięte ze wszystkich projektów.
    
    <img src="Img/del_folders.png" width=600 height=300></img>
    
2)  Następnie proszę spakować rozwiązanie przy pomocy poniższego kodu. Plik `Rozwiazanie_Kolokwium.zip` będzie znajdował sie w folderze `Kolokwium`

    ```
    tar caf Rozwiazanie_Kolokwium.zip --exclude=./Rozwiazanie_Kolokwium.zip Kolokwium 
    ```
    
3)  Proszę przejść pod adres [Archiver](http://ik2a.kik.pcz.czest.pl/archiver/TestArchive/Index)
4)  Następnie proszę wybrać Państwa test i kilknąć przycisk `Link`.

    ![Alt text](Img/ArchiverUpload1.png?raw=true)
    
5)  Proszę wypełnić formularz podając swoje dane, wskazać plik `Rozwiazanie_Kolokwium.zip`, a następnie nacisnąc przycisk `Upload`

    ![Alt text](Img/ArchiverUpload2.png?raw=true)
    
 
