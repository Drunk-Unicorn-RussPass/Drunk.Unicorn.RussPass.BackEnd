#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.API/Drunk.Unicorn.RussPass.Tracks.API.API.csproj", "Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.API/"]
COPY ["Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.BI/Drunk.Unicorn.RussPass.Tracks.API.BI.csproj", "Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.BI/"]
COPY ["Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.Data/Drunk.Unicorn.RussPass.Tracks.API.Data.csproj", "Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.Data/"]
COPY ["Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.General/Drunk.Unicorn.RussPass.Tracks.API.General.csproj", "Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.General/"]
RUN dotnet restore "Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.API/Drunk.Unicorn.RussPass.Tracks.API.API.csproj"
COPY . .
WORKDIR "/src/Drunk.Unicorn.RussPass.Tracks.API/Drunk.Unicorn.RussPass.Tracks.API.API"
RUN dotnet build "Drunk.Unicorn.RussPass.Tracks.API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Drunk.Unicorn.RussPass.Tracks.API.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drunk.Unicorn.RussPass.Tracks.API.API.dll"]