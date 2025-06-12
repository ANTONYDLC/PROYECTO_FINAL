# Imagen base para la aplicación ya compilada
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para compilar y publicar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto
COPY . .

# Restaurar dependencias
RUN dotnet restore "./HamburguesasTienda.csproj"

# Publicar en modo Release
RUN dotnet publish "./HamburguesasTienda.csproj" -c Release -o /app/publish

# Imagen final que ejecuta la aplicación
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Comando de inicio
ENTRYPOINT ["dotnet", "HamburguesasTienda.dll"]
