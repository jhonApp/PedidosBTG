#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PedidosBTG.Data/PedidosBTG.Data.csproj", "PedidosBTG.Data/"]
RUN dotnet restore "PedidosBTG.Data/PedidosBTG.Data.csproj"
COPY . .
WORKDIR "/src/PedidosBTG.Data"
RUN dotnet build "PedidosBTG.Data.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PedidosBTG.Data.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PedidosBTG.Data.dll"]