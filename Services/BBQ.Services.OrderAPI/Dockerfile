﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/test/test.csproj", "test/"]
RUN dotnet restore "Services/test/test.csproj"
COPY . .
WORKDIR "/src/test"
RUN dotnet build "test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test.dll"]
