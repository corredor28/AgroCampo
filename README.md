# AgroCampo - Requerimienntos

#### 1. Propuesta de arquitectura

Se incluye [propuesta](https://github.com/corredor28/AgroCampo/blob/master/files/propuesta_arquitectura.pptx) como anexo.

#### 2. Monitoreo de la solución

Para el monitoreo se utilizará Azure Monitor y Prometheus como se puede ver en la arquitectura general de la solución.

#### 3. Arquitecturas utilizadas

Se propuso una arquitectura orientada a microservicios, con base en lo expuesto en el [estándar de Microsoft](https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/containers/aks-microservices/aks-microservices).

#### 4. Costos

Los costos se minimizan al apegarse al standard de Microsoft que tiene en cuenta los principios de optimización expuestos en https://docs.microsoft.com/en-us/azure/architecture/framework/cost/overview

#### 5. Puntos a favor y en contra

##### Ventajas

Agilidad. Dado que microservicios se implementan de forma independiente, resulta más fácil de administrar las correcciones de errores y las versiones de características.

Equipos pequeños y centrados. Un microservicio es lo suficientemente pequeño como para que un solo equipo lo pueda compilar, probar e implementar.

Base de código pequeña. Al no compartir el código ni los almacenes de datos, la arquitectura de microservicios minimiza las dependencias y resulta más fácil agregar nuevas características.

Mezcla de tecnologías. Los equipos pueden elegir la tecnología que mejor se adapte al servicio.

Aislamiento de errores. Si un microservicio individual no está disponible, no interrumpe toda la aplicación, siempre y cuando los microservicios de nivel superior estén diseñados para controlar los errores correctamente.

Escalabilidad. Los servicios se pueden escalar de forma independiente, lo que permite escalar horizontalmente los subsistemas que requieren más recursos, sin tener que escalar horizontalmente toda la aplicación.

Aislamiento de los datos. Al verse afectado solo un microservicio, es mucho más fácil realizar actualizaciones del esquema.

##### Desventajas

Complejidad. Una aplicación de microservicios tiene más partes en movimiento que la aplicación monolítica equivalente. Cada servicio es más sencillo, pero el sistema como un todo es más complejo.

Desarrollo y pruebas. La escritura de un servicio pequeño que utilice otros servicios dependientes requiere un enfoque que no sea escribir una aplicación tradicional monolítica o en capas.

Falta de gobernanza. Puede acabar con tantos lenguajes y marcos de trabajo diferentes que la aplicación puede ser difícil de mantener. Puede resultar útil establecer algunos estándares para todo el proyecto sin restringir excesivamente la flexibilidad de los equipos. 

Congestión y latencia de red. El uso de muchos servicios pequeños y detallados puede dar lugar a más comunicación interservicios. Además, si la cadena de dependencias del servicio se hace demasiado larga (el servicio A llama a B, que llama a C...), la latencia adicional puede constituir un problema.

Integridad de datos. Cada microservicio es responsable de la conservación de sus propios datos. Como consecuencia, la coherencia de los datos puede suponer un problema. Adopte una coherencia final cuando sea posible.

Administración. Para tener éxito con los microservicios se necesita una cultura de DevOps consolidada.

Control de versiones. Las actualizaciones de un servicio no deben interrumpir servicios que dependen de él. Es posible que varios servicios se actualicen en cualquier momento; por lo tanto, sin un cuidadoso diseño, podrían surgir problemas con la compatibilidad con versiones anteriores o posteriores.

Fuente: https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/microservices

#### 6. DevOps

Se incluyen recomendaciones en diapositivas de arquitectura.

Fuente: https://docs.microsoft.com/en-us/azure/architecture/solution-ideas/articles/microservices-with-aks

#### 7. API demo

Versión publicada como [Azure App Service](https://wtestevragc.azurewebsites.net) (se puede ver la descripción en [Swagger](https://wtestevragc.azurewebsites.net/swagger)).

Para ejecutar localmente:
1. Correr [script](https://github.com/corredor28/AgroCampo/blob/master/files/agrocampo_createdb.sql) para crear base de datos.
2. Incluir variable de entorno **AgroCampoEV** con cadena de conexión a base de datos creada SQL Server.
3. Correr solución.

Prácticas y recomendaciones para la construccion de APIs:
1. Utilice capas:
	-Datos: Contiene el andamiaje generado en Entity Framework. Si necesita agregar propiedades adicionales a una entidad utilice clases parciales para extenderlas, ubique esas clases en otra carpeta (Extensions) en esta misma capa. También ubique acá los DTOs que requiera. Si necesita mapear se recomienda AutoMapper.
	-Negocio: Utilice esta capa para las operaciones y reglas que se requieran. En la clase BaseBL ubique las operaciones que sean comunes a todas las entidades, y herede de esa clase en otras para implementar métodos específicos.
	-API: De forma similar utilice la clase BaseController y herede de ella para crear los puntos de acceso a la API.
2. El andamiaje se actualiza con una instrucción en la consola del admnistrador de paquetes:
    Scaffold-DbContext "{Cadena de conexión}" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ./EFEntities -ContextDir ./ -Context AgroCampoContext -Project F_Data -StartupProject Q_API -Force -NoOnConfiguring -NoPluralize
3. Habilite Swagger para los entornos en los que necesite ver la especificación.
4. Haga pruebas unitarias. Idealmente, cada bug solucionado debería tener un caso de prueba asociado.
5. No se repita (DRY). Utilice las clases base, si lo considera necesario use genéricos. Revise en la especificación actual si la funcionalidad que quiere agregar ya existe o si hay alguna similar que pueda extender. Use plantillas para generar código similar de ser necesario.
6. Si encuentra algún problema o sugerencia para implementar en este proyecto de ejemplo consulte a su líder técnico :)

#### 8. Versionamiento

Se entrega este repositorio público.
