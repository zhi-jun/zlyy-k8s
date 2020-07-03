FROM hub.iflytek.com/zlyy-public/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM hub.iflytek.com/zlyy-public/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["demo.healthcheck/demo.healthcheck.csproj", "demo.healthcheck/"]
RUN dotnet restore "demo.healthcheck/demo.healthcheck.csproj"
COPY . .
WORKDIR "/src/demo.healthcheck"
RUN dotnet build "demo.healthcheck.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo.healthcheck.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ Asia/Shanghai
ENTRYPOINT ["dotnet", "demo.healthcheck.dll"]