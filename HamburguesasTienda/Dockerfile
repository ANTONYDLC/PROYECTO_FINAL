# Imagen base para la aplicación ya compilada
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 👉 Esto permite que la app escuche en el puerto correcto
ENV ASPNETCORE_URLS=http://+:8080

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
