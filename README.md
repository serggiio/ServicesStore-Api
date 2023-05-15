# ServicesStore-Api

#Excecute migrations
- dotnet ef migrations add AuthorMigration --project ServicesStore.Api.Authors
- dotnet ef migrations add BookMigration --project ServicesStore.Api.Book

#Create database tables
- dotnet ef database update --project ServicesStore.Api.Book
- dotnet ef database update --project ServicesStore.Api.Authors
