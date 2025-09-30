# Weather Mongo CRUD

## Descripción

Aplicación única en **C#** que actúa como:

* **Colector**: obtiene datos meteorológicos desde la API del SMN (o alternativamente Ogimet).
* **CRUD**: permite crear, leer, actualizar y eliminar registros directamente en **MongoDB**.

La visualización de métricas se realiza con **Grafana** conectado a la base de datos.

## 🏗️ Arquitectura

* **App C#**: un único ejecutable que integra colector y CRUD.
* **MongoDB**: almacenamiento principal.
* **Grafana**: visualización conectada a MongoDB.

```
[ API GraphQL del SMN u Ogimet ]
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

## Alcance

* Descarga automática de datos vía API.
* Inserción en MongoDB.
* Operaciones CRUD (insertar, consultar con filtros, modificar, borrar).
* Consola para activar/desactivar el colector y ejecutar comandos CRUD.
* Visualización de datos en Grafana.

## 📈 Ejemplos de Uso

 Monitorear condiciones en tiempo real de estaciones del SMN.
 Almacenar y analizar series históricas de datos meteorológicos.
 Calcular estadísticas (temperatura promedio diaria, máximas de viento).
 Visualizar tendencias entre múltiples estaciones mediante Grafana.

## Requisitos

* MongoDB (instalación local)
* .NET 8 / C#
* Grafana

## 🛠️ Stack Tecnológico

 Lenguaje C#  .NET 8
 Base de Datos MongoDB (instalación local)
 Fuente de Datos

   Principal [API GraphQL del SMN](httpsgithub.comgastonpereyrasmnQL)
   Alternativa [Ogimet](httpwww.ogimet.com)
 Visualización Grafana + plugin de MongoDB

## Modelo de Datos (ejemplo)

```json
{
  "stationId": "87645",
  "name": "Aeroparque",
  "datetime": "2025-09-30T15:00:00Z",
  "temperature": 23.5,
  "humidity": 62,
  "pressure": 1012.3
}
```

## Instalación

1. Instalar MongoDB local.
2. Clonar este repositorio.
3. Configurar la cadena de conexión en `appsettings.json`.
4. Ejecutar la aplicación con `dotnet run`.
5. Conectar Grafana a MongoDB para dashboards.

## Licencia

GNU General Public License v3.0
