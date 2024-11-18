
# Gestión de Eventos - Aplicación Web

## Descripción

Esta es una aplicación web para la gestión de eventos, desarrollada en Angular y .NET. Los usuarios pueden registrarse, iniciar sesión, crear eventos, inscribirse en eventos creados por otros usuarios, y gestionar sus eventos.

## Características

- **Autenticación**: Registro e inicio de sesión de usuarios.
- **Gestión de Eventos**:
  - Crear, editar y eliminar eventos.
  - Solo se pueden editar ciertos detalles del evento (fecha y hora, ubicación, capacidad máxima).
  - Los eventos solo se pueden eliminar si no tienen asistentes inscritos.
- **Inscripción a Eventos**: Los usuarios pueden inscribirse en eventos de otros usuarios.
- **Visualización de Eventos**:
  - Ver eventos creados por otros usuarios.
  - Ver los eventos en los que un usuario está inscrito.
- **Validaciones**: Asegurar que los usuarios solo vean y editen los eventos correspondientes.

## Tecnologías Utilizadas

- **Frontend**: Angular
- **Backend**: .NET (ASP.NET Core Web API)
- **Base de Datos**: MySQL o SQL Server
- **Librerías Adicionales**: `ngx-cookie-service` para manejar cookies en Angular

## Instalación

### Requisitos Previos

- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)

### Pasos para Instalar

1. **Clonar el Repositorio**
   ```bash
   git clone https://github.com/tu-usuario/gestion-eventos.git
   cd gestion-eventos
   ```

2. **Configurar el Backend (API .NET)**
   - Configura tu conexión a la base de datos en el archivo `appsettings.json`, y reemplaza el nombre del servidor y de la base de datos:
     ```bash
     "DefaultConnection": "Server=TuServidor;Database=TuBaseDatos;Trusted_Connection=True;MultipleActiveResultSets=true"
     ```
   - Navega a la carpeta del proyecto .NET y en la consola de comandos ejecutamos la migracion:
     ```bash
     dotnet ef database update --project GestionEventos.Models --startup-project GestionEventos.API
     ```
     
4. **Iniciar el Frontend (Angular) y API**

 - Navega a la carpeta del proyecto Angular:
     ```bash
     cd gestion-eventos-ui
     ```
   - Instala las dependencias:
     ```bash
     npm install
     ```
   - Navega a la carpeta del proyecto Angular e inicia el proyecto (Es necesario iniciar el front y la API al mismo tiempo):
     ```bash
     ng serve
     ```
   - El proyecto estará disponible en `http://localhost:4200`.

## Uso

1. **Registro e Inicio de Sesión**
   - Regístrate como nuevo usuario o inicia sesión si ya tienes una cuenta.

2. **Gestión de Eventos**
   - **Crear Evento**: Accede a la sección "Mis Eventos" y crea un nuevo evento.
   - **Editar Evento**: Solo puedes editar la fecha, ubicación y capacidad de los eventos que has creado.
   - **Eliminar Evento**: Los eventos solo pueden ser eliminados si no tienen asistentes.

3. **Inscripción a Eventos**
   - Ve a la sección "Eventos Disponibles" para ver eventos de otros usuarios y regístrate en ellos.
   - Ve a "Eventos Inscritos" para ver los eventos en los que estás registrado.

## Estructura del Proyecto

- **/gestion-eventos-api**: Proyecto Backend en .NET
- **/gestion-eventos-ui**: Proyecto Frontend en Angular



## Contacto

Si tienes preguntas o sugerencias, por favor contacta a [culma100@gmail.com](mailto:culma100@gmail.com).
