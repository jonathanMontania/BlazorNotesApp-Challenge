# Blazor Notes App — Setup Guide

This document explains how to configure the SQL Server database and run the BlazorNotesApp.

---

Before running the project, ensure you have the following installed:

1. **.NET SDK 8.0** or later  
   👉 [Download from Microsoft](https://dotnet.microsoft.com/download)

2. **SQL Server** (any of these options will work):
   - **SQL Server Express / LocalDB** (default connection string works out of the box)

3. **EF Core Tools** (used for migrations)
   ```bash
   dotnet tool install --global dotnet-ef
   ```

4. **Visual Studio 2022+** or **Visual Studio Code** (optional, for development)

---

## ⚙️ Step 1 — Configure the Connection String

The default configuration is located in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlazorNotesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### ✅ If you’re using LocalDB (default)
No change needed — LocalDB is included with Visual Studio. EF Core will automatically create the database.

### ⚙️ If you’re using a remote or full SQL Server instance
Replace the connection string with your SQL Server credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BlazorNotesDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

For example:
```json
"Server=localhost;Database=BlazorNotesDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

---

## 🧱 Step 2 — Install Required EF Core Packages

If you created a fresh Blazor Server project, install the following NuGet packages:

```bash
cd BlazorNotesApp

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools
```

---

## 🧩 Step 3 — Create the Initial Migration

This step builds the migration scripts based on your model (`Note` class).

### ▶ Using PowerShell (Visual Studio Package Manager Console)
```powershell
Add-Migration InitialCreate
```

### ▶ Using the .NET CLI
```bash
dotnet ef migrations add InitialCreate
```

This command creates a new folder called **Migrations/** with all the necessary EF Core migration files.

---

## 🗄️ Step 4 — Apply the Migration (Create the Database)

Once the migration is created, apply it to your SQL Server instance.

### ▶ Using PowerShell (Visual Studio)
```powershell
Update-Database
```

### ▶ Using the .NET CLI
```bash
dotnet ef database update
```

EF Core will now:
- Create the database named **BlazorNotesDb** (if it doesn’t exist)
- Apply the schema for the `Notes` table

---

## 🔍 Step 5 — Verify Database Creation

Open **SQL Server Management Studio (SSMS)** or **Azure Data Studio** and connect to your SQL Server.

- Expand `Databases` → you should see **BlazorNotesDb**.
- Inside, open `Tables` → there will be a table named **Notes**.

---

## 🧪 Step 6 — Run the Application

Finally, launch the Blazor Server app:

```bash
dotnet run
```

or, if using Visual Studio, press **F5** or click **Run**.

Navigate to:
```
https://localhost:5001/notes
```

You should be able to:
- Create new notes
- Edit notes inline
- Delete notes
- See notes in reverse chronological order

---
