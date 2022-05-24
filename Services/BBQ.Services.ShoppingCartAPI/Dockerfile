FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/ShoppingCartAPI/ShoppingCartAPI.csproj", "ShoppingCartAPI/"]
RUN dotnet restore "Services/ShoppingCartAPI/ShoppingCartAPI.csproj"
COPY . .
WORKDIR "/src/ShoppingCartAPI"
RUN dotnet build "ShoppingCartAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCartAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCartAPI.dll"]
