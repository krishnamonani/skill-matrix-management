# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/SkillMatrixManagement.HttpApi.Host/SkillMatrixManagement.HttpApi.Host.csproj"
RUN dotnet build "src/SkillMatrixManagement.HttpApi.Host/SkillMatrixManagement.HttpApi.Host.csproj" -c Release -o /app/build
RUN dotnet publish "src/SkillMatrixManagement.HttpApi.Host/SkillMatrixManagement.HttpApi.Host.csproj" -c Release -o /app/publish

# Install Node.js, NPM, ABP CLI and libs
WORKDIR /src/src/SkillMatrixManagement.HttpApi.Host
RUN apt-get update && apt-get install -y \
    curl \
    && curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs \
    && npm install -g yarn

RUN dotnet tool install -g Volo.Abp.Cli
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN mkdir -p /app/publish/wwwroot
RUN abp install-libs
RUN cp -r wwwroot/libs /app/publish/wwwroot/

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:44302
ENTRYPOINT ["dotnet", "SkillMatrixManagement.HttpApi.Host.dll"]