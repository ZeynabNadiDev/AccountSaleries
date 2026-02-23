FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY AccountSaleries.sln .
COPY Salary/*.csproj Salary/
COPY OvertimePolicies/OvertimePolicies/*.csproj OvertimePolicies/OvertimePolicies/

RUN dotnet restore

COPY . .
WORKDIR /src/Salary
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Salary.dll"]
