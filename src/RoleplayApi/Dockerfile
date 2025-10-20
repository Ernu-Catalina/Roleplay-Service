FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8086

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["RoleplayApi.csproj", "./"]
RUN dotnet restore "RoleplayApi.csproj"
COPY . .
RUN dotnet publish "RoleplayApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RoleplayApi.dll"]
