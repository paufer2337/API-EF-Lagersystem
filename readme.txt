=== C# API-EF - Lagersystem ===
___________________________________________________________


Detta är en Web API-övning där jag har byggt ett enklare lagersystem med
ASP.NET Core, Entity Framework Core och SQL Server.

API:t hanterar produkter i ett lager och stödjer CRUD, DTOs, migrations,
Swagger och enklare lagerstatistik.

============================================================


¤ Tekniker

|   C#                         |
|   ASP.NET Core Web API       |
|   Entity Framework Core      |
|   SQL Server                 |
|   Migrations                 |
|   DTOs                       |
|   Swagger                    |
|   Postman                    |

============================================================


¤ Hur är projektets struktur uppbyggd?

 - Program.cs                  (Startar API:t + registrerar services)
 - Controllers                 (API-endpoints)
 - Data                        (StorageContext / databaskoppling)
 - Models                      (Databasmodeller)
 - DTOs                        (Input/output-modeller för API:t)
 - Migrations                  (Databasstruktur via EF)
 - appsettings.json            (Connection string)

============================================================


¤ Vad innehåller API:t?


~ Products:
|   GET     /api/products              = Hämtar alla produkter               |
|   GET     /api/products/{id}         = Hämtar en produkt via id            |
|   POST    /api/products              = Skapar en ny produkt                |
|   PUT     /api/products/{id}         = Uppdaterar en produkt               |
|   DELETE  /api/products/{id}         = Tar bort en produkt                 |

~ Extra funktionalitet:
|   GET     /api/products/stats        = Hämtar lagerstatistik               |
|   GET     /api/products?category=x   = Filtrerar produkter på kategori     |

============================================================


¤ Databas / Persistence

|   SQL Server        = Databasen som lagrar produkterna                      |
|   StorageContext    = Kopplar C#-koden till databasen                       |
|   Products          = Tabellen där produkterna sparas                       |
|   Migrations        = Skapar/uppdaterar databasens struktur                 |

============================================================


¤ DTOs

DTOs används för att separera databasmodellen från det som skickas till och
från API:t.

|   CreateProductDto   = Används när en produkt skapas                       |
|   ProductDto         = Används när produkter skickas tillbaka              |
|   InventoryValue     = Beräknat fält: Price * Count                        |

============================================================


¤ Swagger / API-testning

Swagger används för att testa API:t direkt i webbläsaren.

Postman har också använts för att testa GET, POST, PUT och DELETE manuellt.

============================================================


¤ Kommandon

cmd:
dotnet build

cmd:
dotnet run

cmd:
dotnet ef database update

============================================================


¤ Kort sammanfattning

Projektet är ett enklare lagersystem där jag har tränat på Web API,
Entity Framework, SQL Server, migrations, DTOs och API-testning.

Målet var att skapa ett API som kan hantera produkter i en databas och
samtidigt returnera tydligare data till klienten med hjälp av DTOs.

============================================================