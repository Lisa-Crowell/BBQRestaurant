FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.ShoppingCart/BBQ.Services.ShoppingCart.csproj", "BBQ.Services.ShoppingCart/"]
RUN dotnet restore "Services/BBQ.Services.ShoppingCart/BBQ.Services.ShoppingCart.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.ShoppingCart"
RUN dotnet build "BBQ.Services.ShoppingCart.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.ShoppingCart.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.ShoppingCart.dll"]
