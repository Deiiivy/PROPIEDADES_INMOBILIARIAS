# 🏠 PROPIEDADES_INMOBILIARIAS

## 📌 Propósito

Este proyecto tiene como objetivo desarrollar una aplicación de gestión de propiedades inmobiliarias aplicando buenas prácticas de programación. Se implementan patrones de diseño como **Repository**, **Singleton** y **Factory**, junto con principios **SOLID**, para garantizar un código mantenible, escalable y de alta calidad.

La aplicación gestiona entidades clave como **Clientes, Agentes, Administradores** y **Propiedades**, permitiendo operaciones como registro, asignación, programación de visitas y seguimiento de transacciones.

---

## 🛠 Tecnologías Utilizadas

- Lenguaje: **C#**
- Interfaz Gráfica: **Windows Forms**
- Base de Datos: **SQL Server**
- ORM: No aplica, uso directo de ADO.NET
- Patrones de diseño: `Repository`, `Singleton`, `Factory`
- Principios SOLID aplicados: `OCP (Open/Closed Principle)`, `SRP (Single Responsibility Principle)`

---

## ⚙️ Descripción de Funcionalidades

### 🔐 Formulario de Login con Control de Acceso por Roles

- **Administrador**
  - Correo: `admin_new@inmobiliaria.com`
  - Contraseña: `admin123`
  - Funcionalidades:
    - Gestión de propiedades
    - Gestión de agentes
    - Gestión de clientes
    - CRUD completo para cada entidad

- **Agente**
  - Correo: `agente1_new@inmobiliaria.com`
  - Contraseña: `agente123`
  - Funcionalidades:
    - Ver propiedades asignadas
    - Gestionar visitas

- **Cliente**
  - Correo: `ana@mail.com`
  - Contraseña: `cliente123`
  - Funcionalidades:
    - Visualizar propiedades disponibles

---

## 🗂️ Diagrama Entidad-Relación

![image](https://github.com/user-attachments/assets/37d3f3b4-e1d3-43ca-bb8c-69d0f664eb52)

---

## 🧪 Instrucciones para Compilar y Ejecutar

1. Tener instalado **Git** y **Visual Studio (versión recomendada: 2019 o superior)**.
2. Clonar el repositorio:
   ```bash
   git clone https://github.com/Deiiivy/PROPIEDADES_INMOBILIARIAS.git
    ```
3. Abrir el archivo PROPIEDADES_INMOBILIARIAS.sln en Visual Studio.

4. Cargar la base de datos:
  - En SQL Server, abrir el archivo Scripts/SQLpropiedadinmobiliaria.sql.
  - Ejecutar todo el script para crear las tablas, insertar datos iniciales y cargar los procedimientos almacenados.

5. Ejecutar la aplicación desde Visual Studio.


