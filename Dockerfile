FROM microsoft/dotnet:2.1-sdk
COPY /DotNetCoreBackend /app
WORKDIR /app
RUN ["dotnet", "restore"] && ["dotnet", "build"]
EXPOSE 80


