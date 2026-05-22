# PizzaSoft - Sistema de Punto de Venta (POS) para Pizzerías

![Interfaz del Proyecto](docs/assets/interfaz.jpg)

PizzaSoft es un sistema de escritorio desarrollado en Windows Forms 
(.NET 10, C# 14) orientado a la gestión, control y automatización de procesos
de venta para pizzerías o restaurantes de comida rápida. El proyecto está 
pensado para organizar de forma ágil la relación entre clientes, productos, 
categorías y el registro del historial de ventas, con una base técnica robusta 
y moderna preparada para crecer modularmente.

El sistema está inspirado en flujos reales de puntos de venta (POS), con el 
objetivo de resolver el desorden administrativo, agilizar la toma de pedidos 
mediante una interfaz visual y profesionalizar la gestión comercial.

## Objetivo del sistema
Diseñar una aplicación que permita:

- Gestionar el catálogo completo de productos (Pizzas, bebidas, extras) y sus 
  categorías.
- Mantener una base de datos de clientes para agilizar futuros pedidos.
- Realizar ventas de manera rápida mediante un sistema de tarjetas visuales 
  interactivo y carrito de compras.
- Visualizar y tener un control claro del historial de ventas realizadas.
- Aplicar una arquitectura por capas para facilitar mantenimiento, testing y 
  escalabilidad.

## Arquitectura del proyecto

```text
PizzaSoft/
├── PizzaSoft.Data (Class Library)
│   ├── Entities/
│   │   ├── Producto.cs
│   │   ├── Categoria.cs
│   │   ├── Cliente.cs
│   │   ├── Venta.cs
│   │   └── DetalleVenta.cs
│   ├── Context/
│   │   └── PizzaLeoneDbContext.cs
│   └── App.config
│
├── PizzaSoft.Ui (Windows Forms Project)
│   ├── Form1.cs (Menú Principal)
│   ├── UCGestionProductos/
│   ├── UCGestionCategorias/
│   ├── UCGestionClientes/
│   ├── UCNuevaVenta/
│   ├── UCHistorialVentas/
│   ├── UCTarjetaPizza/
│   ├── Services/
│   │   ├── ProductoService.cs
│   │   ├── CategoriaService.cs
│   │   ├── ClienteService.cs
│   │   └── VentaService.cs
│   └── Program.cs
│
└── PizzaSoft.Tests (xUnit Project)
    ├── Services/
    │   ├── ProductoServiceTests.cs
    │   ├── CategoriaServiceTests.cs
    │   └── VentaServiceTests.cs
```

## Descripción de capas

**PizzaSoft.Data**
Contiene la estructura del dominio y la persistencia en SQL Server. Aquí se 
definen las entidades principales del sistema, las relaciones entre ellas y la 
configuración del contexto utilizando Entity Framework Core.

**PizzaSoft.Ui**
Es la capa de presentación en Windows Forms. Desde aquí el usuario interactúa 
con el sistema mediante controles de usuario (`UserControls`) especializados 
para interactuar como si fuera una sola ventana ("Single Page Application" o 
SPA de escritorio). Permite gestionar inventarios, añadir productos visuales 
al carrito, procesar checkout iterativo y visualizar historiales.

**PizzaSoft.Tests**
Contiene las pruebas unitarias del sistema. Su propósito es validar la lógica 
de negocio (CRUDs y creación de ventas), evitar regresiones y asegurar mediante 
el uso de bases de datos `InMemory` que los servicios críticos funcionen 
correctamente.

## Componentes principales del sistema

### 1. Capa de Presentación (PizzaSoft.Ui) - Interfaz Gráfica
La interfaz de usuario está compuesta por un contenedor central y módulos dinámicos:

- **Form1.cs**: Panel central de la aplicación. Gestiona la navegación principal 
  mediante un menú lateral estilizado corporativamente y carga los diferentes 
  módulos sin recargar formularios independientes.
- **UCNuevaVenta.cs**: El punto de venta principal. Incluye un catálogo filtrable 
  de productos, tarjetas interactivas de pizzas (`UCTarjetaPizza`) y un carrito 
  de compras. Permite añadir y eliminar productos individualmente antes de 
  procesar el pago y solicitar el nombre del cliente de manera emergente.
- **UCGestionProductos.cs**: Gestión del catálogo de productos. Permite listar, 
  buscar en tiempo real, agregar, editar y eliminar con diseño e interfaz limpia.
- **UCGestionCategorias.cs**: Administrador de las clasificaciones del menú 
  (ej. Pizzas, Entradas, Bebidas).
- **UCGestionClientes.cs**: Base de datos de clientes recurrentes.
- **UCHistorialVentas.cs**: Visor de auditoría financiera. Muestra el historial 
  de todas las transacciones realizadas, permitiendo búsquedas instantáneas por 
  número de venta o cliente.

### 2. Capa de Datos (PizzaSoft.Data) - Modelos
- **Producto.cs**: Entidad que representa a los elementos vendibles del menú.
- **Categoria.cs**: Clasificación principal para organizar el catálogo de forma 
  visual en la venta.
- **Cliente.cs**: Entidad para el comprador final.
- **Venta.cs**: Entidad central de compras de cara al negocio. Almacena montos 
  totales, cliente y fecha.
- **DetalleVenta.cs**: Tabla intermedia que vincula los productos físicos 
  comercializados de forma atómica dentro de cada ticket de Venta.

### 3. Capa de Lógica de Negocio (Servicios)
- **ProductoService.cs**: Ejecuta la lógica para registrar, editar y listar 
  productos filtrando por múltiples criterios.
- **CategoriaService.cs**: Maneja la jerarquía e integridad de las categorías 
  para la UI.
- **ClienteService.cs**: Gestiona clientes y asegura que no haya duplicados si 
  el sistema se amplía.
- **VentaService.cs**: Motor transaccional. Coordina el alta de un ticket 
  (Venta), de sus partes (DetalleVenta) y la recuperación paramétrica temporal 
  del cliente si es nuevo.

### 4. Capa de Calidad (PizzaSoft.Tests) - Pruebas
Asegura la solidez mediante la inyección de repositorios simulados (`InMemory 
Database`) bajo el framework xUnit:

![Pruebas Unitarias](docs/assets/pruebas.jpg)

- **Pruebas de CRUD**: Valida que los productos y categorías se guarden, lean, 
  actualicen y eliminen.
- **Pruebas de Búsqueda**: Asegura que el motor de filtrado de los 
  `DataGridViews` es hermético.

## Principales funcionalidades del proyecto

- **Catálogo Visual de Venta (Touch-Friendly)**: Uso de controles tipo "Tarjeta" 
  facilitando que los operadores encuentren visualmente la comida en el sistema 
  y armen el pedio con solo dar "clics".
- **Carrito de Compras Editable**: Posibilidad de sumar múltiples unidades, 
  visualizar subtotales inmediatos y eliminar unidades individuales antes de 
  procesar una transacción.
- **Filtrado Universal**: Barras de búsqueda instantánea acopladas a la base de 
  datos (EF Core Linq) en todas las entidades corporativas (Productos, histórico, etc).
- **Cierre Rápido de Venta**: Minimiza fricciones al agrupar la confirmación 
  comercial y pedir los datos opcionales de facturación mediante prompts de una 
  sola visual.
- **UX Consistente**: Estética basada en colores unificadores (rojo, verde, 
  blanco y grises estructurados), garantizando que botones de acción principal 
  (crear/procesar) destaquen visualmente de los destructivos (cancelar/eliminar).

## Qué viene a solucionar
PizzaSoft viene a resolver las fricciones de un mostrador de pizzería rápido, 
eliminando la toma de notas en papel o sistemas estáticos aburridos. Permite 
que el dependiente despache con rapidez.

Con esto se logra:
- Mayor velocidad en el levantamiento de comandas.
- Eliminación de errores de precios mentales al dejar que el sistema asuma la 
  matemática completa.
- Un historial permanente para medir flujo de caja directamente.
- Catálogos dinámicos que se reflejan al instante tras dar de alta en inventario, 
  sin necesidad de reiniciar la app.

## Estado del proyecto
Actualmente PizzaSoft se encuentra en una etapa completamente funcional cubriendo 
todo el ciclo básico de ventas (Catálogos, POS Visual, Modificaciones de Carrito, 
Pagos, Manejo de Clientes y Tests Unitarios).

## Conclusión
PizzaSoft ejemplifica cómo un negocio a pequeña escala puede transformarse usando 
arquitectura por capas (Data-UI-Service-Testing). Su diseño visual y su 
arquitectura de `Services` permite construir escalabilidad fácil para agregar 
más adelante: control de stock en cocina, usuarios y roles, reportes contables 
complejos en PDF y facturación electrónica.