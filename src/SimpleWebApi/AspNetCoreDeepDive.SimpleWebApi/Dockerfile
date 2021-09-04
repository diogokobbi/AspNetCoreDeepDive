FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SimpleWebApi/AspNetCoreDeepDive.SimpleWebApi/AspNetCoreDeepDive.SimpleWebApi.csproj", "AspNetCoreDeepDive.SimpleWebApi/"]
RUN dotnet restore "SimpleWebApi/AspNetCoreDeepDive.SimpleWebApi/AspNetCoreDeepDive.SimpleWebApi.csproj"
COPY . .
WORKDIR "/src/AspNetCoreDeepDive.SimpleWebApi"
RUN dotnet build "AspNetCoreDeepDive.SimpleWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreDeepDive.SimpleWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreDeepDive.SimpleWebApi.dll"]
