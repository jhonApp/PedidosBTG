#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PedidosBTG.Core/PedidosBTG.Core.csproj", "PedidosBTG.Core/"]
RUN dotnet restore "PedidosBTG.Core/PedidosBTG.Core.csproj"
COPY . .
WORKDIR "/src/PedidosBTG.Core"
RUN dotnet build "PedidosBTG.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PedidosBTG.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PedidosBTG.Core.dll"]