FROM hub.iflytek.com/zlyy-public/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM hub.iflytek.com/zlyy-public/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["demo.gateway/demo.gateway.csproj", "demo.gateway/"]
RUN dotnet restore "demo.gateway/demo.gateway.csproj"
COPY . .
WORKDIR "/src/demo.gateway"
RUN dotnet build "demo.gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo.gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ Asia/Shanghai
ENTRYPOINT ["dotnet", "demo.gateway.dll"]