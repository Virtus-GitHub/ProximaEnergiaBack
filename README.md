Esta api obtiene y actualiza los datos de una base de datos local.
La he hecho siguiendo un patrón Repository, en principio empecé creándola con una capa de servicios
donde iría toda la lógica de negocio. Pero después añadí otros controladores utilizando el patrón Mediator
y usando este patrón, la lógica de negocio pasaría a estar en el Handler. En el caso de esta api no tiene
practicamente lógica de negocio ya que son consultas y procesos sencillos.

Para poder ejecutarla hay que cambiar el connection string en el archivo appsettings.json para el acceso a la base de datos local
o para configurar un acceso a otra base de datos.

No he puesto ningún tipo de autenticación porque no sabía si sería necesario, en caso de serlo actualizare la api con la autenticación necesaria.
