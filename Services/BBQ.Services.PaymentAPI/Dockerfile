FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.PaymentAPI/BBQ.Services.PaymentAPI.csproj", "BBQ.Services.PaymentAPI/"]
RUN dotnet restore "Services/BBQ.Services.PaymentAPI/BBQ.Services.PaymentAPI.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.PaymentAPI"
RUN dotnet build "BBQ.Services.PaymentAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.PaymentAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.PaymentAPI.dll"]
