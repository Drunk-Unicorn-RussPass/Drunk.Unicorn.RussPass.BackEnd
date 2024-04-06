#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.API/Drunk.Unicorn.RussPass.Images.API.API.csproj", "Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.API/"]
COPY ["Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.BI/Drunk.Unicorn.RussPass.Images.API.BI.csproj", "Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.BI/"]
COPY ["Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.Data/Drunk.Unicorn.RussPass.Images.API.Data.csproj", "Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.Data/"]
COPY ["Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.General/Drunk.Unicorn.RussPass.Images.API.General.csproj", "Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.General/"]
RUN dotnet restore "Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.API/Drunk.Unicorn.RussPass.Images.API.API.csproj"
COPY . .
WORKDIR "/src/Drunk.Unicorn.RussPass.Images.API/Drunk.Unicorn.RussPass.Images.API.API"
RUN dotnet build "Drunk.Unicorn.RussPass.Images.API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Drunk.Unicorn.RussPass.Images.API.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drunk.Unicorn.RussPass.Images.API.API.dll"]