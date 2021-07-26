# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src

# Copy csproj and restore as distinct layers
# TODO: Copy all at once but retain folder structure (eg "./**/*.csproj ./")
COPY ./Pointer.sln ./
COPY ./Pointer.Core.Application/*.csproj ./Pointer.Core.Application/
COPY ./Pointer.Core.Domain/*.csproj ./Pointer.Core.Domain/
COPY ./Pointer.Infrastructure.Persistence/*.csproj ./Pointer.Infrastructure.Persistence/
COPY ./Pointer.Presentation.Api/*.csproj ./Pointer.Presentation.Api/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish "Pointer.Presentation.Api" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "Pointer.Presentation.Api.dll"]