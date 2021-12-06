FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Christmas.Secret.Gifter.API/Christmas.Secret.Gifter.API.csproj", "."]
RUN dotnet restore "./Christmas.Secret.Gifter.API.csproj" -v d
COPY . .
WORKDIR "/src/."
RUN dotnet build "Christmas.Secret.Gifter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Christmas.Secret.Gifter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Christmas.Secret.Gifter.API.dll"]