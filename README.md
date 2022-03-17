# ApiRegistroPersona
API que permite el registro de personas y usuarios

# Instalación y prueba de API 
1. Para poder desplegar aplicaciones .Net core es necesario .NET Core Hosting Bundle el cual prepara IIS para .net core.
   descargarlo desde el siguiente link e instalarlo
   https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.3-windows-hosting-bundle-installer

2. Descargar y descomprimir el archivo ApiRegistroPersona.rar, el cual se encuentra en el repositorio
3. Ejecutar el script de base de datos llamado "BaseDatos.sql"
4. Verificar la cadena de conexion en el archivo "appsettings.json" configurar el servidor que correspondan y las credenciales para acceder a la base de datos.
5. Ingresar al IIS y en sitios, Default Web Site, dar clic derecho y seleccionar la opción agregar aplicación.
6. Agregar un nombre para el Api y seleccionar la ruta donde se encuentra el Api, en este caso será donde se haya descomprimido el archivo ApiRegistroPersona.rar

# Documentación
El API desarrollada, cuenta con tres controladores
* LoginController => Utilizado para validar que un usuario se encuentre registrado en la base de datos
* RegistroController => Utilizado para registrar las personas, contiene todos los metodos de un CRUD
* UsuarioController => Utilizado para registrar los usuarios, contiene todos los metodos de un CRUD


# Prueba
1. Instalar Postman
2. Crear una collection para organizar los requests
3. Recuperar Personas (get), se puede probar de la siguiente manera (http://localhost/{NombreApi}/Api/Registro) en este caso como se ha publicado de manera local el Api, la url queda como localhost, el nombre del Api quedó "ApiRegistroPersona" y para acceder a los metodos se escribe seguidamente "Api/Registro"
   ![image](https://user-images.githubusercontent.com/39510736/158113640-00657bab-7295-442f-8c10-16d5c422d7f4.png)
4. Insertar Personas (post), se usa la siguiente forma (http://localhost/{NombreApi}/Api/Registro) y se envía el JSON con los datos a insertar 
   JSON de ejemplo:
   {    "nombres": "Devis alberto",
        "apellidos": "Barraza araujo",
        "numeroIdentificacion": "1143158728",
        "email": "devisbarraza1@gmail.com",
        "tipoIdentificacion": "CC",
        "fechaCreacion": "2022-03-16T12:45:47.977",
        "identificacionCompleta": "1143158728CC",
        "nombreCompleto": "Devis alberto Barraza araujo" }
   ![image](https://user-images.githubusercontent.com/39510736/158760077-a33f5f89-eaeb-4bfb-9f97-e2fd6df1423e.png)




   

