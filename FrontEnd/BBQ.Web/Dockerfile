FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FrontEnd/BBQ.Web/BBQ.Web.csproj", "BBQ.Web/"]
RUN dotnet restore "FrontEnd/BBQ.Web/BBQ.Web.csproj"
COPY . .
WORKDIR "/src/BBQ.Web"
RUN dotnet build "BBQ.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BBQ.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BBQ.Web.dll"]
