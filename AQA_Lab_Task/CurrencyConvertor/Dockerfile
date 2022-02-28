FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CurrencyConvertor/CurrencyConvertor.csproj", "CurrencyConvertor/"]
RUN dotnet restore "CurrencyConvertor/CurrencyConvertor.csproj"
COPY . .
WORKDIR "/src/CurrencyConvertor"
RUN dotnet build "CurrencyConvertor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyConvertor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyConvertor.dll"]
