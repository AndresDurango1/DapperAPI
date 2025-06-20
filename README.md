# 📘 DapperApi
Una API RESTful sencilla desarrollada en **.NET 8** con **ASP.NET Core Web API**, que utiliza **Dapper** como micro ORM y **procedimientos almacenados** para comunicarse eficientemente con **SQL Server**.
Este proyecto gestiona información de **libros y autores** conectando con **dos bases de datos distintas**, demostrando una arquitectura modular y limpia.
---
## 🧩 Estructura general del proyecto
```
DapperApi.sln
│
├── DapperApi/                 # Capa de presentación (Web API)
│   ├── Controllers/           # Controladores HTTP
│   ├── appsettings.json       # Configuración de conexión
│   └── Program.cs             # Punto de entrada
│
├── Data/                      # Capa de infraestructura
│   ├── ConnectionStringsOptions.cs
│   ├── LibraryDBContext.cs    # Conexión a la base de datos LibraryDB
│   └── PeopleDBContext.cs     # Conexión a la base de datos PeopleDB
│
├── Domain/                   # Capa de entidades del dominio
│   ├── Author.cs             # Entidad Autor
│   └── Book.cs               # Entidad Libro
│
├── Repository/               # Capa de acceso a datos con Dapper
│   ├── Interfaces/
│   │   ├── ILibraryRepository.cs
│   │   └── IPeopleRepository.cs
│   └── Implementations/
│       ├── LibraryRepository.cs
│       └── PeopleRepository.cs
│
└── DatabaseScripts/
    ├── LibraryDB/
    │   ├── dbo.Books.Table.sql
    │   └── dbo.GetBookById.StoredProcedure.sql
    └── PeopleDB/
        ├── dbo.Authors.Table.sql
        └── dbo.GetAuthorById.StoredProcedure.sql
```
---
## 🚀 Características principales
- 📚 Gestión de libros y autores a través de una API REST
- ⚙️ Uso de **Dapper** para ejecutar stored procedures de forma eficiente
- 🧵 Separación de contexto de base de datos por proyecto (LibraryDB y PeopleDB)
- 🧼 Arquitectura modular y clara con buenas prácticas
- 🧪 Endpoint para consultar un libro por ID y cargar su autor desde otra base de datos
---
## 🛠️ Tecnologías usadas
- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Dapper](https://github.com/DapperLib/Dapper)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
---
## ⚙️ Configuración del entorno
### 1. Clonar el repositorio
```bash
git clone https://github.com/AndresDurango1/DapperApi.git
cd DapperApi
```
### 2. Configurar las cadenas de conexión
Edita el archivo `appsettings.json` dentro del proyecto `DapperApi`:
```json
"ConnectionStrings": {
  "LibraryDB": "Server=TU_SERVIDOR;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;",
  "PeopleDB": "Server=TU_SERVIDOR;Database=PeopleDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
> Asegúrate de reemplazar `TU_SERVIDOR` con el nombre o instancia de tu servidor SQL.
### 3. Crear la base de datos
Desde SQL Server Management Studio (SSMS):
- Ejecuta primero los scripts de creación de tablas (`DatabaseScripts/LibraryDB` y `DatabaseScripts/PeopleDB`)
- Luego ejecuta los procedimientos almacenados correspondientes
---
## ▶️ Ejecutar el proyecto
```bash
dotnet restore
dotnet build
dotnet run
```
Una vez levantado el proyecto, puedes probar el endpoint en Postman:
```
GET https://localhost:xxxx/api/book?id=1
```
Este endpoint devuelve un libro con su autor correspondiente cargado desde otra base de datos.
---
## 📌 Notas
- El sistema usa `Guid` para identificar autores y `int` para libros.
- Puedes extender el CRUD fácilmente para autores y libros desde las capas existentes.
---
## 🧑‍💻 Autor
Desarrollado por **Andres Durango**.  
📧 Contacto: [andres.durango1@outlook.com]
---