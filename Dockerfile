FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
COPY --from=build-env /App/.env .env

ENTRYPOINT ["dotnet", "Chat_AspnetCore.dll"]

EXPOSE 80