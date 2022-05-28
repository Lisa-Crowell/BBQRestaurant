FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.ShoppingCartAPI/BBQ.Services.ShoppingCartAPI.csproj", "BBQ.Services.ShoppingCartAPI/"]
RUN dotnet restore "Services/BBQ.Services.ShoppingCartAPI/BBQ.Services.ShoppingCartAPI.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.ShoppingCartAPI"
RUN dotnet build "BBQ.Services.ShoppingCartAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.ShoppingCartAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.ShoppingCartAPI.dll"]
