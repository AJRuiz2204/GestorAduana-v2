```markdown
# GestorAduana_v1

**GestorAduana_v1** es una aplicación web desarrollada con ASP.NET MVC que facilita la gestión de operaciones aduaneras. La aplicación está diseñada para manejar diferentes entidades y roles de usuario, permitiendo una administración eficiente y segura de la información relacionada con usuarios, camioneros, oficinas de back-office y empresas asociadas.

## Índice

1. [Descripción del Proyecto](#descripción-del-proyecto)
2. [Características](#características)
3. [Tecnologías Utilizadas](#tecnologías-utilizadas)
4. [Instalación](#instalación)
5. [Configuración](#configuración)
6. [Arquitectura del Proyecto](#arquitectura-del-proyecto)
7. [Roles y Permisos](#roles-y-permisos)
8. [Autenticación y Autorización](#autenticación-y-autorización)
9. [Uso de la Aplicación](#uso-de-la-aplicación)
10. [Solución de Problemas](#solución-de-problemas)
11. [Contribuciones](#contribuciones)
12. [Licencia](#licencia)
13. [Contacto](#contacto)

---

## Descripción del Proyecto

**GestorAduana_v1** está diseñada para gestionar de manera integral las operaciones aduaneras, permitiendo a los diferentes roles de usuario acceder y administrar la información según sus permisos. La aplicación soporta funcionalidades CRUD (Crear, Leer, Actualizar, Eliminar) para entidades principales como Usuarios, Camioneros, BackOffice y Empresas.

## Características

- **Gestión de Usuarios**: Agregar, editar, eliminar y visualizar usuarios registrados.
- **Gestión de Camioneros**: Administrar la información de los camioneros, incluyendo detalles como licencia y empresa asociada.
- **Gestión de BackOffice**: Manejar registros de back-office, incluyendo datos de transporte y rutas.
- **Gestión de Empresas**: Administrar las empresas asociadas a las unidades de transporte.
- **Autenticación y Autorización**: Sistema robusto de autenticación basado en roles para garantizar la seguridad y el acceso adecuado.
- **Interfaz Intuitiva**: Diseño responsivo y fácil de usar, facilitando la navegación y gestión de información.
- **Manejo de Errores**: Sistema de manejo de errores para una mejor experiencia del usuario y facilidad de depuración.

## Tecnologías Utilizadas

- **Framework**: ASP.NET MVC 5
- **Lenguaje**: C#
- **Base de Datos**: Entity Framework con SQL Server (LocalDB para desarrollo)
- **Autenticación**: Forms Authentication
- **Frontend**: Bootstrap para diseño responsivo
- **IDE**: Visual Studio 2019 o superior

## Instalación

1. **Clonar el Repositorio**

   ```bash
   git clone https://github.com/tu-usuario/GestorAduana_v1.git
   ```

2. **Abrir el Proyecto en Visual Studio**

   - Inicia **Visual Studio**.
   - Selecciona **Archivo > Abrir > Proyecto/Solución**.
   - Navega hasta la carpeta clonada y abre el archivo `.sln`.

3. **Restaurar Paquetes NuGet**

   Visual Studio debería restaurar automáticamente los paquetes NuGet necesarios. Si no es así:
   
   - Ve a **Herramientas > Administrador de paquetes NuGet > Administrar paquetes NuGet para la solución**.
   - Haz clic en **Restaurar**.

## Configuración

1. **Configurar la Cadena de Conexión**

   - Abre el archivo `Web.config`.
   - Asegúrate de que la cadena de conexión `DefaultConnection` apunte a tu instancia de SQL Server. Por defecto, está configurada para usar **LocalDB**:
   
     ```xml
     <connectionStrings>
        <add name="DefaultConnection" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=GestorAduanasDB;Integrated Security=True;MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
      </connectionStrings>
     ```

2. **Ejecutar Migraciones de Entity Framework**

   - Abre la **Consola del Administrador de Paquetes** en Visual Studio (**Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes**).
   - Ejecuta los siguientes comandos para crear la base de datos y aplicar las migraciones:
   
     ```powershell
     Enable-Migrations
     Add-Migration InitialCreate
     Update-Database
     ```

## Arquitectura del Proyecto

El proyecto sigue el patrón de arquitectura **Modelo-Vista-Controlador (MVC)**, que separa la lógica de la aplicación en tres componentes principales:

- **Modelo**: Representa la estructura de los datos y las reglas de negocio.
- **Vista**: Es la interfaz de usuario que presenta los datos.
- **Controlador**: Maneja las solicitudes del usuario, interactúa con el modelo y selecciona la vista adecuada para responder.

Además, la aplicación utiliza **Entity Framework** para la gestión de la base de datos mediante el enfoque **Code-First**, lo que permite definir los modelos en código y generar la base de datos automáticamente.

## Roles y Permisos

La aplicación maneja diferentes roles de usuario, cada uno con permisos específicos:

- **Administrador**: Tiene acceso completo a todas las funcionalidades de la aplicación, incluyendo la gestión de usuarios, camioneros, back-office y empresas.
- **Gestor**: Puede gestionar entidades como camioneros y back-office, pero tiene permisos limitados en comparación con el administrador.
- **BackOffice**: Tiene acceso a la gestión de back-office y empresas.
- **Camionero**: Accede a funcionalidades específicas relacionadas con sus operaciones, pero no puede gestionar otras entidades.

## Autenticación y Autorización

El sistema de autenticación se basa en **Forms Authentication**, asegurando que solo los usuarios autenticados puedan acceder a las áreas protegidas de la aplicación. La autorización se gestiona mediante atributos `[Authorize]` en los controladores y acciones, restringiendo el acceso según los roles asignados a cada usuario.

### Flujo de Autenticación

1. **Inicio de Sesión**: Los usuarios ingresan sus credenciales a través de la página de login.
2. **Validación**: Las credenciales se validan contra la base de datos.
3. **Asignación de Roles**: Si las credenciales son válidas, se crea un ticket de autenticación que incluye los roles del usuario.
4. **Acceso**: El usuario es redirigido a la sección correspondiente según su rol.

## Uso de la Aplicación

### Acceso y Navegación

- **Inicio de Sesión**: Accede a `/Account/Login` para iniciar sesión.
- **Registro**: Accede a `/Account/Register` para crear una nueva cuenta de usuario.
- **Panel de Administración**: Disponible para roles con permisos administrativos, permite gestionar usuarios y otras entidades.
- **Gestión de Entidades**: Desde el panel de administración, se pueden gestionar usuarios, camioneros, back-office y empresas mediante interfaces intuitivas.

### Gestión de Entidades

- **Usuarios**: Permite crear, editar, eliminar y visualizar usuarios registrados en el sistema.
- **Camioneros**: Administrar información de los camioneros, incluyendo detalles personales y licencias.
- **BackOffice**: Manejar registros de back-office, datos de transporte y rutas.
- **Empresas**: Gestionar las empresas asociadas a las unidades de transporte, incluyendo operaciones CRUD.

## Solución de Problemas

### Problema: Redirección al Iniciar Sesión como Camionero

**Descripción**: Al intentar iniciar sesión como "Camionero", la sesión se cierra automáticamente.

**Posibles Causas**:
- **Configuración Incorrecta de Roles**: El rol "Camionero" puede no estar correctamente asignado o reconocido.
- **Restricciones en Controladores**: Los controladores o acciones a los que intenta acceder el "Camionero" pueden no permitir su rol.
- **Ticket de Autenticación**: El ticket de autenticación puede no estar almacenando correctamente los roles.

**Soluciones**:
1. **Verificar Asignación de Roles**: Asegúrate de que el usuario "Camionero" tiene asignado el rol correcto en la base de datos.
2. **Revisar Controladores**: Verifica que los controladores permitan el acceso a usuarios con el rol "Camionero".
3. **Depurar Autenticación**: Revisa la configuración de autenticación para asegurarte de que los roles se están asignando y leyendo correctamente.

### Problema: Acceso Restringido a la Página de Registro

**Descripción**: Al intentar acceder a `/Account/Register`, la aplicación redirige a la página de login.

**Posibles Causas**:
- **Atributos de Autorización**: La acción `Register` puede estar protegida por `[Authorize]` en lugar de `[AllowAnonymous]`.
- **Configuración en `Web.config`**: Las reglas de autorización en `Web.config` pueden estar bloqueando el acceso a la página de registro.

**Soluciones**:
1. **Revisar Atributos del Controlador**: Asegúrate de que las acciones `Register` y `Login` estén decoradas con `[AllowAnonymous]`.
2. **Verificar `Web.config`**: Asegúrate de que las reglas de autorización no estén bloqueando el acceso a las acciones `Register` y `Login`.
3. **Comprobar Vistas**: Asegúrate de que las vistas `Register` y `Login` estén correctamente configuradas y accesibles.

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir al proyecto, por favor sigue estos pasos:

1. **Fork el Repositorio**
2. **Crea una Rama para tu Feature** (`git checkout -b feature/nueva-funcionalidad`)
3. **Realiza tus Cambios**
4. **Commit tus Cambios** (`git commit -m 'Añadir nueva funcionalidad'`)
5. **Push a la Rama** (`git push origin feature/nueva-funcionalidad`)
6. **Crea un Pull Request**
