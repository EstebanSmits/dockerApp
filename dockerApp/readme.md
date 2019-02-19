# Containerization
[image](https://www.ontrack.com/blog/wp-content/uploads/sites/7/docker-300x225.png)


## dotnet build  Commands
- dotnet publish -o ./app
- docker build . -t testapp -f dockerfile_create
- docker run -p 8083:80 -e ENV_TEST1=test1 -e ENV_TEST1=test2 testapp
- docker run -p 8082:80 -e ENV_TEST1=test1 -e ENV_TEST2=test2 -e ConnectionStrings:Books="Server=host.docker.internal,1433;User Id=sa;Password=tempP@ssw0rd;Initial Catalog=dockerApp;"  -e Logging:LogLevel:Default=Trace testapp 
## Docker Commands
- docker build . -t testapp -f Dockerfile_build_and_create
- docker run -p 8081:80 -e ENV_TEST1=test1 -e ENV_TEST2=test2 testapp -e ConnectionStrings:Books="Server=host.docker.internal,1433;User Id=sa;Password=tempP@ssw0rd;Initial Catalog=dockerApp;"  -e Logging:LogLevel:Default=Trace testapp 

## some  Containers to run
docker run -d --name some-ghost -p 3001:2368 ghost
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_PID=Express' -e 'SA_PASSWORD=tempP@ssw0rd' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest

## Connection String
Docker Containers : ConnectionStrings:Books="Server=host.docker.internal,1433;User Id=sa;Password=tempP@ssw0rd;Initial Catalog=dockerApp;" 
VS\Code: "ConnectionStrings__Books":"Server=localhost,1433;User Id=sa;Password=tempP@ssw0rd;Initial Catalog=dockerApp;"
## Docker Hub - Container Registry
[Dockerapp registered in Docker Hub](https://cloud.docker.com/repository/docker/estebansmits/dockerapp/general)

## Relevant Links
[Docker hub SQL Server link](https://hub.docker.com/_/microsoft-mssql-server)