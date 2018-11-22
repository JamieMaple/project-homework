FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# deps
COPY ./DotNetCoreBackend/*.csproj .
RUN dotnet restore

# build
COPY ./DotNetCoreBackend/ .
RUN dotnet publish -c Release -o out

# runtime
FROM microsoft/dotnet:aspnetcore-runtime AS prod

LABEL Author="Jamie_Maple" \
      Email="jamiemaple007@gmail.com"

WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80

ENTRYPOINT ["dotnet", "DotNetCoreBackend.dll"]

