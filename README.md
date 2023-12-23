# Format
```
dotnet tool install -g dotnet-format
```
Usage:
```
dotnet-format .\Christmas.Secret.Gifter.API\
```

# TypeGen
Install:
```
dotnet tool install --global dotnet-typegen
```
Rebuild the solution and then by being in the root directory execute:
```
dotnet-typegen --project-folder  ./Christmas.Secret.Gifter.Domain generate
```
# Frontend Extensions - VS Code
## Generate barrels
```
TypeScript Barrel Generator
```
## Firebase setup
Install firebaseCLI from the official website, then execute:
```
npm install -g firebase-tools
```
## ESLint & Prettier - VS Code
```
npm install -D eslint prettier eslint-config-prettier --force
npx eslint --init
```

# Database.SQLite:
navigate to the database project directory first.
Then execute as follows:
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef database update --connection "Data Source=gifter.db"
```

# Known issues
Nuget: invalid data while decoding:
```
dotnet nuget locals all --clear
```

# Algorithm
```
https://developers.google.com/optimization/assignment/assignment_example
```
