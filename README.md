# 🏠 PROPIEDADES_INMOBILIARIAS

## 📌 Propósito

Este proyecto tiene como objetivo desarrollar una aplicación de gestión de propiedades inmobiliarias aplicando buenas prácticas de programación. Se implementan patrones de diseño como **Repository**, **Singleton**. junto con principios **SOLID**, para garantizar un código mantenible, escalable y de alta calidad.

La aplicación gestiona entidades clave como **Clientes, Agentes, Administradores** y **Propiedades**, permitiendo operaciones como registro, asignación, programación de visitas y seguimiento de transacciones.

---

## 🛠 Tecnologías Utilizadas

- Lenguaje: **C#**
- Interfaz Gráfica: **Windows Forms**
- Base de Datos: **SQL Server**
- ORM: No aplica, uso directo de ADO.NET
- Patrones de diseño: `Repository`, `Singleton`, `Unit OF work`
- Principios SOLID aplicados: `OCP (Open/Closed Principle)`, `SRP (Single Responsibility Principle)`,  `Interface Segregation Principle (ISP) o Principio de Segregación de Interfaz`, `Dependency Inversion Principle (DIP) o Principio de Inversión de Dependencia.`.

---

## Capturas de pantalla iniciales
- Login Form
![image](https://github.com/user-attachments/assets/91e719d8-6d79-4fe2-bde6-fc4d05f155f9)


- ClienteDashboard
  ![image](https://github.com/user-attachments/assets/f2ca433f-ba82-42cd-bd7d-655ac8851e89)


- AdminDashboard
  ![image](https://github.com/user-attachments/assets/efe144a0-6154-4328-9e6b-701c50d03c7f)

  
  --
  ![image](https://github.com/user-attachments/assets/b71ba6ac-e4c2-4d71-9993-25dff18cc519)


- AgenteDashboard
  ![image](https://github.com/user-attachments/assets/4b3ef959-a26d-4cd9-9182-d8707b753842)


  


## ⚙️ Descripción de Funcionalidades

### 🔐 Formulario de Login con Control de Acceso por Roles

- **Administrador**
  - Correo: `admin@inmobiliaria.com`
  - Contraseña: `adminpass`
  - Funcionalidades:
    - Gestión de propiedades
    - Gestión de agentes
    - Gestión de clientes
    - Gestión de visitas
    - CRUD completo para cada entidad

- **Agente**
  - Correo: `carlos.perez@inmobiliaria.com`
  - Contraseña: `carlospass`
  - Funcionalidades:
    - Gestión de propiedades

- **Cliente**
  - Correo: `juan.torres@example.com`
  - Contraseña: `juanpass`
  - Funcionalidades:
    - Visualizar propiedades disponible
    - marcar interes en alguna propiedad
    - ver visitas agendadas
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


