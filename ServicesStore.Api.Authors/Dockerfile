#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServicesStore.Api.Authors/ServicesStore.Api.Authors.csproj", "ServicesStore.Api.Authors/"]
RUN dotnet restore "ServicesStore.Api.Authors/ServicesStore.Api.Authors.csproj"
COPY . .
WORKDIR "/src/ServicesStore.Api.Authors"
RUN dotnet build "ServicesStore.Api.Authors.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServicesStore.Api.Authors.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServicesStore.Api.Authors.dll"]
