FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DoctorAppointment/DoctorAppointment.csproj", "DoctorAppointment/"]
RUN dotnet restore "DoctorAppointment/DoctorAppointment.csproj"
COPY . .
WORKDIR "/src/DoctorAppointment"
RUN dotnet build "DoctorAppointment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorAppointment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorAppointment.dll"]
