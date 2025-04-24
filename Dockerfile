FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Todo.Web.Api/Todo.Web.Api.csproj", "Todo.Web.Api/"]
COPY ["Todo.Domain/Todo.Domain.csproj", "Todo.Domain/"]
COPY ["Todo.Infrastructure/Todo.Infrastructure.csproj", "Todo.Infrastructure/"]
RUN dotnet restore "Todo.Web.Api/Todo.Web.Api.csproj"
COPY . .
WORKDIR "/src/Todo.Web.Api"
RUN dotnet build "Todo.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Web.Api.dll"] 