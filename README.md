# AsignaturasUniversidad
Proyecto Web que realiza un CRUD (Create Read Update Delete) con acceso a Base de Datos usando el Patrón de diseño Vista Modelo Vista y el framework 
DotVVM de Visual Studio

# Instalación

Restaurar el archivo Backup de Base de Datos para SQLServer

Cambiar el String de Conexión que se encuentra en el Proyecto AccesoADatos en la carpeta Modelos en el archivo UniversidadABCContext

     optionsBuilder.UseSqlServer("Server=LAPTOP-6F2GNN6S; Database=UniversidadABC; Trusted_Connection = True;");

En la anterior línea cambiarle el nombre del server por la instancia local de Base de Datos local de SQLServer

# Documentación del FrameWork Dotvvm

https://dev.to/esdanielgomez/dotvvm-para-visual-studio-2022-1ef1
