// INSERT INTO Orders (OrderDate, DeliveryDate, DeliveryAddressId)
// VALUES
// ('2025-06-01 10:00:00', '2025-06-01 12:00:00', 1),
// ('2025-06-02 09:30:00', '2025-06-02 11:00:00', 2),
// ('2025-06-03 13:15:00', '2025-06-03 15:00:00', 3),
// ('2025-06-04 16:45:00', '2025-06-04 18:30:00', 4);

// INSERT INTO Meals (Type, IsVegetarian, Description, Price)
// VALUES
// ('Pizza', 0, 'Pizza Margherita', 29.99),
// ('Salad', 1, 'Greek Salad', 19.50),
// ('Burger', 0, 'Beef Burger with Fries', 34.99),
// ('Pasta', 1, 'Pasta with Tomato Sauce', 24.00),
// ('Soup', 1, 'Tomato Soup', 14.99);

// INSERT INTO Addresses (Country, City, Street, ZipCode, BuildingNumber, ApartmentNumber)
// VALUES
// ('Poland', 'Warsaw', 'Marszalkowska', '00-001', 10, 5),
// ('Poland', 'Krakow', 'Dluga', '30-002', 15, 8),
// ('Poland', 'Gdansk', 'Morska', '80-003', 20, NULL),
// ('Poland', 'Wroclaw', 'Legnicka', '50-004', 7, 12),
// ('Poland', 'Poznan', 'Polwiejska', '60-005', 25, NULL);

// dotnet ef migrations add MigracjaPierwsza --project Kolokwium.DAL/Kolokwium.DAL.csproj --startup-project Kolokwium.Web/Kolokwium.Web.csproj

// dotnet ef database update --project Kolokwium.DAL/Kolokwium.DAL.csproj --startup-project Kolokwium.Web/Kolokwium.Web.csproj   

// dotnet run --project Kolokwium.Web/Kolokwium.Web.csproj 
