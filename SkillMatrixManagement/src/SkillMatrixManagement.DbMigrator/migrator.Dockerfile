FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS migrationbuild
WORKDIR /app
COPY . .
WORKDIR "/app/src/SkillMatrixManagement.DbMigrator"
RUN dotnet publish SkillMatrixManagement.DbMigrator.csproj -c Release -o /app/mig/publish

FROM base AS final
WORKDIR /app
COPY --from=migrationbuild /app/mig/publish .
CMD ["dotnet", "SkillMatrixManagement.DbMigrator.dll"]