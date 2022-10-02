## startup commands
sudo docker build -t choremonitor.api .
sudo docker run -d -p 8080:80 --name myapp choremonitor.api

sudo docker-compose build
sudo docker-compose up

## cleanup commands
sudo docker ps -ls
sudo docker stop myapp
sudo docker rm myapp
sudo docker container ls -a

sudo docker system prune -f

## test commands
curl http://localhost:8080/api/chores
http://localhost:8080/api/chores

## explore docker filesystem
sudo docker exec -it myapp bash

## run sql server in docker
https://www.codeproject.com/Articles/5258260/Using-Docker-for-Local-SQL-Server-Development

sudo docker pull mcr.microsoft.com/mssql/server
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Sample123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:latest

## Docker.DotNet
sudo usermod -aG docker $USER