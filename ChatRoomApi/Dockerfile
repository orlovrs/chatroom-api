FROM mcr.microsoft.com/dotnet/core/runtime:3.0
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ChatRoomApi.dll