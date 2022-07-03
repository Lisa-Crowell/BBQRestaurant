FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/BBQ.Services.Email/BBQ.Services.Email.csproj", "BBQ.Services.Email/"]
RUN dotnet restore "Services/BBQ.Services.Email/BBQ.Services.Email.csproj"
COPY . .
WORKDIR "/src/BBQ.Services.Email"
RUN dotnet build "BBQ.Services.Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Services.Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Services.Email.dll"]
