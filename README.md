# Colector de Datos Meteorológicos y CRUD con MongoDB + Grafana

## 📌 Descripción del Proyecto

Este proyecto es un ejercicio para Bases de Datos II, enfocado en aprender MongoDB y construir una aplicación práctica que integra APIs externas, almacenamiento local y visualización de datos.

Implementamos una aplicación estilo servidor en C# que

 Recopila datos meteorológicos en tiempo real de la API GraphQL del Servicio Meteorológico Nacional (SMN) (o Ogimet como alternativa).
 Almacena la información en una instancia local de MongoDB.
 Proporciona operaciones CRUD (Crear, Leer, Actualizar, Eliminar) directamente en la misma aplicación, ya sea a través de comandos de consola o una API REST mínima.
 Expone los datos almacenados para visualización en dashboards de Grafana.

Esta solución demuestra el flujo completo de ingestión de datos, persistencia y análisis usando una base de datos NoSQL.

---

## 🎯 Objetivos del Proyecto

 Aprender a instalar y configurar MongoDB localmente.
 Entender los esquemas estilo JSON y cómo se diferencian de los modelos SQL relacionales.
 Practicar la construcción de un servicio recolector para obtener y almacenar datos automáticamente.
 Implementar funcionalidades CRUD sobre MongoDB.
 Usar Grafana como capa de visualización para consultas y dashboards.

---

## 🏗️ Arquitectura

```
[ API GraphQL del SMN  Ogimet ]
             ↓
    [ Aplicación C# Colector & CRUD ]
    - Obtiene datos periódicamente
    - Inserta en MongoDB
    - Expone CRUD (CLI o REST)
             ↓
        [ MongoDB Local ]
    - Colección de observaciones
    - Colección de estaciones (opcional)
             ↓
           [ Grafana ]
    - Visualizaciones series temporales, mapas, estadísticas
```

---

## 📂 Modelo de Datos

### Colección `observations`

```json
{
  stationId 87585,
  stationName Aeroparque,
  datetime 2025-09-29T220000Z,
  temperature 22.5,
  humidity 68,
  pressure 1011.8,
  wind { direction NE, speed 15 },
  source SMN
}
```

### Colección `stations` (metadatos opcionales)

```json
{
  stationId 87585,
  name Aeroparque,
  lat -34.559,
  lon -58.415,
  elevation 6
}
```

📌 Estrategia de Índices

 Índice único en `stationId + datetime` → previene entradas duplicadas.

---

## ⚙️ Funcionalidades

 Recolección Automática de Datos

   Obtiene periódicamente los últimos datos del SMN.
   Intervalo configurable (por ejemplo, cada 10 minutos).
   Previene duplicados mediante índices.

 Operaciones CRUD

   Crear → Insertar registros manuales.
   Leer → Consultarfiltrar observaciones.
   Actualizar → Modificar valores existentes.
   Eliminar → Borrar registros por ID o condición.

 Depuración  Logging

   Salida en terminal mostrando ciclos de recolección, inserciones y acciones CRUD.
   Ejemplo

    ```
    [INFO] Obteniendo últimos datos del SMN...
    [OK] 12 nuevos registros insertados
    [INFO] Próxima recolección programada a las 2230
    ```

 Dashboards en Grafana

   Conexión directa al datasource de MongoDB.
   Visualizaciones incluyen

     Series temporales tendencias de temperaturahumedad.
     Vista de mapa estaciones y condiciones.
     Paneles de estadísticas máximosmínimospromedios por estación.

---

## 🛠️ Stack Tecnológico

 Lenguaje C#  .NET 8
 Base de Datos MongoDB (instalación local)
 Fuente de Datos

   Principal [API GraphQL del SMN](httpsgithub.comgastonpereyrasmnQL)
   Alternativa [Ogimet](httpwww.ogimet.com)
 Visualización Grafana + plugin de MongoDB

---

## 🚀 Cómo Empezar

### 1. Instalar MongoDB Localmente

 Descargar [MongoDB Community Server](httpswww.mongodb.comtrydownloadcommunity)
 Ejecutar servicio MongoDB en `mongodblocalhost27017`.
 Crear base de datos `weatherDB`.

### 2. Clonar este Repositorio

```bash
git clone httpsgithub.comyourusernameweather-mongo-crud.git
cd weather-mongo-crud
```

### 3. Instalar Dependencias

En la carpeta del proyecto

```bash
dotnet restore
```

### 4. Ejecutar la Aplicación

```bash
dotnet run
```

### 5. Conectar Grafana

 Instalar Grafana localmente.
 Añadir datasource de MongoDB.
 Construir dashboards usando las colecciones de `weatherDB`.

---

## 📈 Ejemplos de Uso

 Monitorear condiciones en tiempo real de estaciones del SMN.
 Almacenar y analizar series históricas de datos meteorológicos.
 Calcular estadísticas (temperatura promedio diaria, máximas de viento).
 Visualizar tendencias entre múltiples estaciones mediante Grafana.

---

## 👨‍🏫 Alcance Académico

Este proyecto mantiene el alcance enfocado

 Un único servicio recolector que también maneja CRUD.
 Una base de datos MongoDB con dos colecciones simples.
 Grafana para visualización en lugar de construir un cliente separado.

Esto asegura que el trabajo demuestre conocimientos de

 Integración de APIs
 Operaciones CRUD en MongoDB
 Diseño de aplicaciones estilo servidor
 Flujos de visualización de datos

---

## 📌 Licencia

Licencia MIT – libre para usar y modificar.
