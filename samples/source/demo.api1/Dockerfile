FROM hub.iflytek.com/zlyy-public/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM hub.iflytek.com/zlyy-public/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["demo.api1/demo.api1.csproj", "demo.api1/"]
RUN dotnet restore "demo.api1/demo.api1.csproj"
COPY . .
WORKDIR "/src/demo.api1"
RUN dotnet build "demo.api1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo.api1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ Asia/Shanghai
ENTRYPOINT ["dotnet", "demo.api1.dll"]