# GestionDeStock

Descripción

Esta API permite gestionar productos y movimientos de stock en un almacén. Se pueden registrar productos, realizar movimientos de entrada y salida, y consultar el estado del inventario en tiempo real.

Características principales

Registro de productos con información básica como nombre, código, categoría y precio.

Gestión de movimientos de stock (entrada y salida), asegurando que la cantidad sea siempre un número entero.

Consulta de stock disponible por producto.

Historial de movimientos para rastrear cambios en el inventario.

Validaciones de stock para evitar salidas de productos sin disponibilidad.

Tecnologías utilizadas

.NET 6 (ASP.NET Core Web API)

Entity Framework Core (EF Core) para acceso a datos

SQL Server como base de datos

Inyección de dependencias para una arquitectura modular

Automapper para la conversión de DTOs

Swagger para documentación de la API

Endpoints principales

1. Productos

POST /api/productos → Registrar un nuevo producto

GET /api/productos → Listar todos los productos

GET /api/productos/{id} → Obtener un producto por ID

PUT /api/productos/{id} → Actualizar un producto

DELETE /api/productos/{id} → Eliminar un producto

2. Movimientos de Stock

POST /api/movimientos → Registrar un nuevo movimiento de stock

GET /api/movimientos → Listar movimientos de stock

GET /api/movimientos/{id} → Obtener un movimiento por ID

3. Consultas de Stock

GET /api/stock/{productoId} → Obtener el stock disponible de un producto
