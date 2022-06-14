FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.OrderAPI/BBQ.Services.OrderAPI.csproj", "BBQ.Services.OrderAPI/"]
RUN dotnet restore "Services/BBQ.Services.OrderAPI/BBQ.Services.OrderAPI.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.OrderAPI"
RUN dotnet build "BBQ.Services.OrderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.OrderAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.OrderAPI.dll"]
