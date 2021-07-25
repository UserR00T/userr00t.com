# https://userr00t.com
Personal portfolio website. Created using C#, aspnetcore, nuxt, tailwindcss, docker, and more.

[![](.media/screely.png)](https://userr00t.com)

## Stack
### Frontend/Client (userr00t.com)
- nuxt
- nuxtjs/tailwindcss

_Other dependencies_
- sparticles
- vue-class-component
- vue-property-decorator
- nuxtjs/axios
- dayjs
- marked

### Backend/Server (Pointer)
- ASP.NET Core
- Dapper
- SqlKata
- Npgsql

## Installation
Before trying to initialize this project on a webhost, make sure docker, and docker-compose are installed. Along with that, make sure you got a web server ready to serve the client html files. This is only required if you use nuxt's generate static pages method.

Note that while you may pull the docker container for server/Pointer, the client project does not have such feature. For that part of the application you must build it yourself. You can do so by using `nuxt generate` within the `client` folder.

### Backend/Server (Pointer)
1. Download the [docker-compose.yml](server/docker-compose.yml) to your hosting path. Double check port numbers, image names, and volumes.
2. Create a `.env` file based on the [.env.sample][server/.env.sample] file. Here you must set the three environment variables for postgres: `POSTGRES_USER`, `POSTGRES_PASSWORD`, & `POSTGRES_DB`
3. Create a `appsettings.json` file based on the [appsettings.json.sample](server/appsettings.json.sample). Make sure the Connection string matches the one set above in the `.env`.
4. Your directory tree should now look something like this:
- `.env`
- `appsettings.json`
- `docker-compose.yml`  
Run `docker-compose up -d` within the directory to start the api. By now you should be able to navigate to one of the routes in the application. You can also visit swagger by going to `{YOUR_DOMAIN}/swagger`.
5. Create a way for the world to interface with the running api. This is different for everyone, and depends on your usecase. For one, they might want to use Traefik while others (myself included) just create nginx reverse proxy listing on a path of choosing (eg `/api/`). 

### Frontend/Client (userr00t.com)
1. This varies from person to person. I myself just used `nuxt generate` and used nginx to serve the provided html files. Do make sure your `try_files` includes the `200.html` file for dynamic routing. eg: `try_files $uri $uri/ /200.html;`

## Building

## Building (Docker)