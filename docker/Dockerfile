FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy
COPY publish App/
WORKDIR /App
ENTRYPOINT ["dotnet", "IPValidator.dll"]
