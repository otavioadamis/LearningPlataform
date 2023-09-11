#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LearningPlataform.API/LearningPlataform.API.csproj", "LearningPlataform.API/"]
COPY ["LearningPlataform.Dal/LearningPlataform.Dal.csproj", "LearningPlataform.Dal/"]
COPY ["LearningPlataform.Domain/LearningPlataform.Domain.csproj", "LearningPlataform.Domain/"]
COPY ["LearningPlataform.Service/LearningPlataform.Service.csproj", "LearningPlataform.Service/"]
RUN dotnet restore "LearningPlataform.API/LearningPlataform.API.csproj"
COPY . .
WORKDIR "/src/LearningPlataform.API"
RUN dotnet build "LearningPlataform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningPlataform.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningPlataform.API.dll"]