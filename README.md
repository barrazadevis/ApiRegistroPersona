# ApiRegistroPersona
Permite el registro de Entidades de tipo personas y Usuarios en una base de datos.

# Instalación y prueba de API 
1. Para poder desplegar aplicaciones .Net core es necesario .NET Core Hosting Bundle el cual prepara IIS para .net core.
   descargarlo desde el siguiente link e instalarlo
   https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-6.0.3-windows-hosting-bundle-installer

2. Descargar y descomprimir el archivo ApiRegistroPersona.rar, el cual se encuentra en el repositorio
3. Ejecutar el script de base de datos llamado "BaseDatos.sql"
4. Verificar la cadena de conexion en el archivo "appsettings.json" configurar el servidor que correspondan y las credenciales para acceder a la base de datos.
   ![image](https://user-images.githubusercontent.com/39510736/158765112-f0ad8845-2bea-4995-a347-581b214129ad.png)

5. Ingresar al IIS y en sitios, Default Web Site, dar clic derecho y seleccionar la opción agregar aplicación.
   ![image](https://user-images.githubusercontent.com/39510736/158765230-832ad6a0-0982-443b-9027-5358e064fc3a.png)

7. Agregar un nombre para el Api y seleccionar la ruta donde se encuentra el Api, en este caso será donde se haya descomprimido el archivo ApiRegistroPersona.rar y dar    clic en aceptar
   ![image](https://user-images.githubusercontent.com/39510736/158765481-ca3365af-c4df-4b11-906e-b1a5dc68b9bf.png)


# Documentación
El API desarrollada, cuenta con tres controladores
* LoginController => Utilizado para validar que un usuario se encuentre registrado en la base de datos
* RegistroController => Utilizado para registrar las personas, contiene todos los metodos de un CRUD
* UsuarioController => Utilizado para registrar los usuarios, contiene todos los metodos de un CRUD


# Prueba
1. Instalar Postman

2. Crear una collection para organizar los requests

3. Recuperar Personas (get), se puede probar de la siguiente manera (http://localhost/{NombreApi}/Api/Registro) en este caso como se ha publicado de manera local el      Api, la url queda como localhost, el nombre del Api quedó "ApiRegistroPersona" y para acceder a los metodos se escribe seguidamente "Api/Registro"
![image](https://user-images.githubusercontent.com/39510736/158761022-287a3899-3e6c-438a-941f-3ba8d1d3db1c.png)

4. Recuperar una persona por id, se prueba de la siguiente manera  (http://localhost/{NombreApi}/Api/Registro/{id}) en este caso es igual que el punto anterior, solo      se le adiciona el parametro id, en este caso es un valor entero
![image](https://user-images.githubusercontent.com/39510736/158761305-b239cdd5-a272-4e91-9908-07d9cff9097d.png)

5. Insertar Persona (post), se usa la siguiente forma (http://localhost/{NombreApi}/Api/Registro) y se envía el JSON con los datos a insertar 
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
   
 6. Recuperar Usuarios (Get), se prueba de la siguiente forma (http://localhost/{NombreApi}/Api/Usuario), en este caso el endpoint solo cambia el nombre del               controlador que en este caso es Usuario
 ![image](https://user-images.githubusercontent.com/39510736/158762043-158a28c2-26df-4c44-9700-13153bd2a608.png)

 7. Recuperar un usuario por id, (http://localhost/{NombreApi}/Api/Usuario/{id}), igual al punto anterior solo se le adiciona el parametro id, en este caso se debe         reemplazar "{id}" por el valor a buscar
    ![image](https://user-images.githubusercontent.com/39510736/158762245-ab6cdfbb-9414-4fc2-8711-db6de3095cbc.png)
    
 8. Insertar Usuario (Post), (http://localhost/{NombreApi}/Api/Usuario), se consume con el metodo POST y se envía el JSON con los datos como se ve en la siguiente         imagen  
    {
       "usuario1": "devis",
       "pass": "123456",
       "fechaCreacion": null,
       "fkPersona": 2
    }
    ![image](https://user-images.githubusercontent.com/39510736/158762740-4379a1c1-e147-4c63-b864-7790e066b40c.png)
    
  9. Consultar si un Usuario existe (Post), se usa el controlador Login, con el siguiente endpoint (http://localhost/ApiRegistroPersona/Api/Login),se envía un JSON de      tipo usuario pero solo son necesarios usuario y contraseña.
     ![image](https://user-images.githubusercontent.com/39510736/158763618-02673e17-78d2-42a3-8dae-68d9fbdaebe8.png)


 




   

