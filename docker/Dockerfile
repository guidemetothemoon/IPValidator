FROM mcr.microsoft.com/dotnet/aspnet:6.0.4-bullseye-slim-amd64
COPY publish App/
WORKDIR /App
ENTRYPOINT ["dotnet", "IPValidator.dll"]