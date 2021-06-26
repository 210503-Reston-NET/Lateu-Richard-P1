#base image
FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build

#baby of mkdir and cd

WORKDIR /app

COPY *.sln ./

COPY StoreBL/*.csproj StoreBL/
COPY StoreDL/*.csproj StoreDL/
COPY StoreTests/*.csproj StoreTests/
COPY StoreWebUI/*.csproj StoreWebUI/
COPY StoreModels/*.csproj StoreModels/

#Restores any deps that we would need
#if the csproj files have not changed since the last build on this laptop, then, the above layers will be recovered  from cache,
#and we don't need to run restore again.

RUN cd StoreWebUI && dotnet restore

# we use .dockerignore file to hide files from being copied with the build context, so COPY here won't see them either.
#which files? bin/, obj/, etc.


#copy the source code
COPY . ./
#CMD /bin/bash

# we comment out previous command because our image is already built, we now going to publish it

#Pulishes the application and its dependencies to a folder for deployment to hosting system

RUN dotnet publish StoreWebUI -c Release -o publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app
#From the build stage, I wanna get the published version of my app
COPY --from=build /app/publish ./

CMD ["dotnet","StoreWebUI.dll"]

# this final image does not have the sdk, nor the src code, only
# 1 what is in the base image (the runtime)
# 2 my published build output





