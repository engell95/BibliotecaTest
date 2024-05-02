# Test para FullStack Ensitech
-- Proyectos
  -- BibliotecaApi
  -- BibliotecaApp

## tecnologías:

- **Backend**
Net Core SDK 8.0

- **Frontend**
react 18.2.0
node 20.11.0 
npm 10.2.4
vite 5.2.0
typescript 5.2.2

- **Bases de Datos**
EF - InMemoryDatabase


## Entorno

Comando para verficar versiones de sdk dotnet instaladas, para desarrollo de este proyecto fue usado
la versión netcore 8.0, pero esté puede ser corrido con versiones superiores, o en caso de usar
Visual Studio, este solicitara la versión requerida en caso de no poder funcionar con la encontrada.

```sh
dotnet --list-sdks
```
## Visual Studio

Para ejecución del proyecto estamos haciendo uso de Visual Studio Code 1.88.1

### Configuraciones de entorno Backend (BibliotecaApi)

1. Editar archivo launchSettings.json, clave applicationUrl, para agregar o modificar url de la aplicacion -- Por Defecto: http://localhost:5024
2. Base de datos InMemoria Configurada en Program.cs en la linea 84 clave UseInMemoryDatabase con el nombre AuthorDb

### Configuraciones de entorno Frontend (BibliotecaApp)

1. Editar archivo .env, clave VITE_API_BASE_URL, para agregar o modificar url de la api -- Por Defecto: http://localhost:5024/api/

## Data insertada 

El Proyecto BibliotecaApi cuenta con una inserción de datos semillas configurada en el archivo DbModel/DBSeeder.cs
la cual se inserta al iniciar el proyecto luego de crear en memoria la base de datos, este proceso es invocado
en la línea 108 del archivo Program.cs 

## Correr proyecto

Una vez cumplido los requisitos para los proyectos debemos iniciarlos por serparo

-- Proyectos
  -- BibliotecaApi
      comando: 
        dotnet build
        dotnet run
  -- BibliotecaApp
      comando: 
        - npm install
        - npm run dev

Una vez se encuentre ejecutando los proyectos en local deberá poder acceder a este 
haciendo uso de las siguientes URL locales

> http://localhost:5024/api/swagger  -API
> http://localhost:5173/             - APP

## Acceso a las aplicaciones

1) acceder ah: http://localhost:5173/   (o el puerto configurado para la aplicacion web)
2) Ingresar credenciales

Administrador
- Admin
- Superadmin@123

Usuario1
- Usuario1
- Seguro@123

Usuario2
- Usuario2
- Seguro@123

