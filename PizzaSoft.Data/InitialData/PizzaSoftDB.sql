-- =====================================================================
-- Script de Creación Inicial de Base de Datos - PizzaSoft
-- =====================================================================

-- CREATE DATABASE PizzaLeone;
-- GO
-- USE PizzaLeone;
-- GO

CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(50) NULL,
    Direccion NVARCHAR(250) NULL
);
GO

CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Productos (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(100) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE Ventas (
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    IdCliente INT NOT NULL,
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
);
GO

CREATE TABLE DetalleVenta (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Detalle_Ventas FOREIGN KEY (IdVenta) REFERENCES Ventas(IdVenta) ON DELETE CASCADE,
    CONSTRAINT FK_Detalle_Productos FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);
GO

-- =====================================================================
-- Datos Iniciales (Opcional)
-- =====================================================================

INSERT INTO Clientes (Nombre, Telefono, Direccion) VALUES ('Consumidor Final', 'N/A', 'N/A');
GO

INSERT INTO Categorias (Nombre) VALUES ('Pizzas Clásicas'), ('Pizzas Especiales'), ('Bebidas'), ('Extras');
GO

INSERT INTO Productos (Nombre, Categoria, Precio) VALUES 
('Pizza Pepperoni', 'Pizzas Clásicas', 350.00),
('Pizza Margarita', 'Pizzas Clásicas', 300.00),
('Pizza 4 Quesos', 'Pizzas Especiales', 450.00),
('Coca Cola 2L', 'Bebidas', 90.00),
('Pan de Ajo', 'Extras', 120.00);
GO
