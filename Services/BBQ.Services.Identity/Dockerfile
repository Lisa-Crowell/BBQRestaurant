FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.Identity/BBQ.Services.Identity.csproj", "BBQ.Services.Identity/"]
RUN dotnet restore "Services/BBQ.Services.Identity/BBQ.Services.Identity.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.Identity"
RUN dotnet build "BBQ.Services.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.Identity.dll"]
