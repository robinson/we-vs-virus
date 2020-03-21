FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS builder
ARG Configuration=Release
WORKDIR /
COPY *.sln ./
COPY Business/Business.csproj Business/
COPY DataAccess/DataAccess.csproj DataAccess/
COPY Models/Models.csproj Models/
COPY WebApp/WebApp.csproj WebApp/
RUN dotnet restore
COPY . .
WORKDIR /WebApp
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApp.dll"]
