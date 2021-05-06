FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app

COPY . .

RUN dotnet publish -c Release --output publish ArthurMarichal.Musics.Api/ArthurMarichal.Musics.Api.csproj

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS publish

COPY --from=build /app/publish/* /app/

WORKDIR /app

CMD ["dotnet", "ArthurMarichal.Musics.Api.dll"]