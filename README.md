# AgroCampo

API de prueba. 

Versión publicada en https://wtestevragc.azurewebsites.net (Se puede ver la descripción en https://wtestevragc.azurewebsites.net/swagger)

Para ejecutar:
-Correr script ubicado en /db/agrocampo_createdb.sql para crear base de datos.
-Incluir variable de entorno AgroCampoEV con cadena de conexión a base de datos creada SQL Server.
-Correr solución.

Prácticas y recomendaciones para la construccion de APIs:
1. Utilice capas:
	-Datos: Contiene el andamiaje generado en Entity Framework. Si necesita agregar propiedades adicionales a una entidad utilice clases parciales para extenderlas, ubique esas clases en otra carpeta (Extensions, p.ej.) en esta misma capa. También ubique acá los DTOs que requiera. Si necesita mapear se recomienda AutoMapper.
	-Negocio: Utilice esta capa para las operaciones y reglas que se requieran. En la clase BaseBL ubique las operaciones que sean comunes a todas las entidades, y herede de esa clase en otras para implementar métodos específicos.
	-API: De forma similar utilice la clase BaseController y herede de ella para crear los puntos de acceso a la API.
2. Habilite Swagger para los entornos en los que necesite ver la especificación.
3. Haga pruebas unitarias. Idealmente, cada bug solucionado debería tener un caso de prueba asociado.
4. No se repita (DRY). Utilice las clases base, si lo considera necesario use genéricos. Revise en la especificación actual si la funcionalidad que quiere agregar ya existe o si hay alguna similar que pueda extender. Use plantillas para generar código similar de ser necesario.
5. Si encuentra algún problema o sugerencia para implementar en este proyecto de ejemplo consulte a su líder técnico :)

