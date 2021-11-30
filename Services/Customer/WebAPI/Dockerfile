#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Customer/WebAPI/WebAPI.csproj", "Services/Customer/WebAPI/"]
COPY ["Services/Customer/Services/Services.csproj", "Services/Customer/Services/"]
COPY ["Services/Customer/Infrastructure/Infrastructure.csproj", "Services/Customer/Infrastructure/"]
COPY ["Services/Customer/Models/Models.csproj", "Services/Customer/Models/"]
RUN dotnet restore "Services/Customer/WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/Customer/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]