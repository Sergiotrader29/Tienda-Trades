# Tienda-TredaSolutions

Este es un proyecto de ejemplo que muestra una API para administrar tiendas y sus productos.

## Configuración

1. Clonar el repositorio: (https://github.com/Sergiotrader29/Tienda-TredaSolutions.git)

2. Abrir el proyecto: 
- Navega al directorio del proyecto clonado.
- Ábrelo en tu entorno de desarrollo preferido (por ejemplo, Visual Studio).

3. Restaurar dependencias:
- Si estás utilizando Visual Studio, el IDE debería restaurar automáticamente las dependencias del proyecto.

4. Configurar la base de datos:
- Asegúrate de tener una instancia de SQL Server en ejecución.
- Actualiza la cadena de conexión en el archivo `appsettings.Development.json` para que coincida con tu configuración de base de datos.

5. Aplicar migraciones:
- En la terminal o línea de comandos:
  ```
  update-database
  ```

6. Ejecutar la aplicación:
- En la terminal o línea de comandos:
  ```
  dotnet run
  ```

7. Acceder a Swagger:
- Abre tu navegador web y visita la siguiente URL: `https://localhost:7005/swagger/index.html`
- Se abrirá la interfaz de Swagger, donde podrás explorar y probar los endpoints de la API.

 
