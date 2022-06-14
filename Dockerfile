FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY  /published ./
ENTRYPOINT ["dotnet", "Lioncato.dll"]