FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY empty/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY empty/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "empty.dll"]
