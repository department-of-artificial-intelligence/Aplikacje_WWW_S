# Kolokwium
## Przygotowanie do kolokwium
### Pobranie i przetestowanie szablonu kolokwium
1) Proszę pobrać gałąź kolokwium w formie pliku zip. A następnie wypakować jego zawartość.
  <img src="Img/download_zip.png" width=350 height=300></img>
2) Proszę otworzyć folder `Kolokwium` przy pomocy Visual Studio Code.

    <img src="Img/open_folder.png" width=400 height=270></img>

    <img src="Img/open_folder2.png" width=400 height=250></img>

    <img src="Img/open_folder3a.png" width=400 height=350></img>

3) Proszę otworzyć plik `Kolokwium.Web -> appsettings.json` a następnie podmienić wartość `Database` connection stringa podając swoje imię i nazwisko (bez znaków diakrytycznych) zamiast `Imie_Nazwisko`. Dzięki temu w momencie zastosowania pierwszej migracji utworzy się nowa baza danych zaczynającą się Państwa imieniem i nazwiskiem.
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
4) Proszę postąpić analogicznie dla projektu `Kolokwium.API -> appsettings.json`.
5) Proszę w Visual Studio Code otworzyć nowy terminal `Terminal -> New Terminal`.
    
6) Nastepnie proszę pobrać wszystkie potrzebne biblioteki oraz skompilować całą solucję. W tym celu proszę wykonać poniższe polecenie.

    ```
    dotnet build
    ```
7) Proszę upewnić się że narzędzia `dotnet-ef tool update` oraz `dotnet-aspnet-codegenerator` są poprawnie zainstalowane, w tym celu proszę wykonać poniższe polecenia.    
    ```
    dotnet tool update --global dotnet-ef --version 5.0.3
    dotnet tool install -g dotnet-aspnet-codegenerator --version 5.0.2
    ```
    
8) W celu weryfikacji poprawności działania aplikacji proszę ją uruchomić.

    ```
    dotnet run --project Kolokwium.Web\Kolokwium.Web.csproj
    ```

    Aplikacja powinna być dostępna pod adresem: [http://localhost:5000](http://localhost:5000).
    ![Alt text](Img/run_web.png?raw=true)
    
8) Analogicznie należy uruchomić aplikację Web API.
  
    ```
    dotnet run --project Kolokwium.API\Kolokwium.API.csproj
    ```
   Web API powinno być dostępne pod adresem: `http://localhost:5050/api/{controller}` 

   Aplikacja Swagger jest dostępna pod adresem: [http://localhost:5050](http://localhost:5050).
   ![Alt text](Img/run_api.png?raw=true)
    
9) Jeśli obie aplikacje działają poprawnie proszę je zamknąć przy pomocy kombinacji klawiszy `ctrl + c`.

### Proszę przejść do wykonywania zadań

```diff
- Życzę Państwu powodzenia na kolokwium! :)
```

### Umieszenie rozwiązania w archiwum
1)  Po otrzymaniu oceny proszę w folderze `Kolokwium` wykonać poniższe polecenia.
    ```powershell
    rmdir Kolokwium.Web/obj -recurse
    rmdir Kolokwium.Web/bin -recurse
    rmdir Kolokwium.API/obj -recurse
    rmdir Kolokwium.API/bin -recurse
    rmdir Kolokwium.ViewModel/obj -recurse
    rmdir Kolokwium.ViewModel/bin -recurse
    rmdir Kolokwium.Test/obj -recurse
    rmdir Kolokwium.Test/bin -recurse
    rmdir Kolokwium.Services/obj -recurse
    rmdir Kolokwium.Services/bin -recurse
    rmdir Kolokwium.DAL/obj -recurse
    rmdir Kolokwium.DAL/bin -recurse
    rmdir Kolokwium.Model/obj -recurse
    rmdir Kolokwium.Model/bin -recurse    
    
    ```
    Proszę się upewnić że foldery `bin` i `obj` zostały usunięte ze wszystkich projektów.
    
    <img src="Img/del_folders.png" width=600 height=300></img>
    
2)  Następnie proszę spakować rozwiązanie przy pomocy poniższego kodu. Plik `Rozwiazanie_Kolokwium.zip` będzie znajdował sie w folderze `Kolokwium`

    ```
    tar caf Rozwiazanie_Kolokwium.zip --exclude=./Rozwiazanie_Kolokwium.zip . 
    ```
    
3)  Proszę przejść pod adres [Archiver](http://ik2a.kik.pcz.czest.pl/archiver/TestArchive/Index)
4)  Następnie proszę wybrać Państwa test i kilknąć przycisk `Link`.

    ![Alt text](Img/ArchiverUpload1.png?raw=true)
    
5)  Proszę wypełnić formularz podając swoje dane, wskazać plik `Rozwiazanie_Kolokwium.zip`, a następnie nacisnąc przycisk `Upload`

    ![Alt text](Img/ArchiverUpload2.png?raw=true)
    
 
