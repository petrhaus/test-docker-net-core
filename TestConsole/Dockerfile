FROM microsoft/dotnet:2.2-sdk-alpine3.8 as builder

ENV ASPNETCORE_ENVIRONMENT docker
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-runtime-alpine3.8

ENV ASPNETCORE_ENVIRONMENT docker
WORKDIR /app
COPY --from=builder /app/out ./

ENTRYPOINT ["dotnet", "TestConsole.dll"]