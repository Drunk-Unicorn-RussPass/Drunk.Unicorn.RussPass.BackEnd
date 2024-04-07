#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.API/Drunk.Unicorn.RussPass.Users.API.csproj", "Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.API/"]
COPY ["Drunk.Unicorn.RussPass.Kafka/Drunk.Unicorn.RussPass.Kafka.csproj", "Drunk.Unicorn.RussPass.Kafka/"]
COPY ["Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.BI/Drunk.Unicorn.RussPass.Users.BI.csproj", "Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.BI/"]
COPY ["Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.Data/Drunk.Unicorn.RussPass.Users.Data.csproj", "Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.Data/"]
COPY ["Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.General/Drunk.Unicorn.RussPass.Users.General.csproj", "Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.General/"]
RUN dotnet restore "Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.API/Drunk.Unicorn.RussPass.Users.API.csproj"
COPY . .
WORKDIR "/src/Drunk.Unicorn.RussPass.Users/Drunk.Unicorn.RussPass.Users.API"
RUN dotnet build "Drunk.Unicorn.RussPass.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Drunk.Unicorn.RussPass.Users.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drunk.Unicorn.RussPass.Users.API.dll"]