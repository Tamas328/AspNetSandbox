# Tamas Sandbox project for Back-end course

Name | Value
--- | ---
Language | C#
Database | Postgres
Deployed | https://asp-net-sandbox-tamas.herokuapp.com/

## How to run in Docker from the Command Line

Navigate to [AspNetSandbox](AspNetSandbox) directory.

### Build in container
```
docker build -t web_tamas .
```

to run

```
docker run -d -p 8081:80 --name web_container_tamas web_tamas
```

to stop container
```
docker stop web_container_tamas
```

to remove container
```
docker rm web_container_tamas
```

## Deploy to Heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a asp-net-sandbox-tamas web
```

Release the container
```
heroku container:release -a asp-net-sandbox-tamas web
```