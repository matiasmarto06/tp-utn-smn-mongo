# Proyecto: Sistema de Observaciones Meteorológicas con MongoDB

### Materia: Bases de Datos II
### Año: 2025
### Tecnología: MongoDB + C# (.NET Framework 4.8)
### Licencia: GNU General Public License v3.0

---

## 🧭 Descripción general

El proyecto consiste en el desarrollo de una **base de datos NoSQL** en **MongoDB** utilizada para almacenar y administrar **observaciones meteorológicas horarias** obtenidas en tiempo real desde la **API pública de Meteostat**.

El objetivo es demostrar el uso práctico de una base NoSQL en un contexto real, implementando un **colector automático de datos**, junto con un **módulo CRUD** (Create, Read, Update, Delete) y **módulos de visualización** desarrollados en **C# WinForms** que permiten gestionar y analizar los registros almacenados.

---

## ⚙️ Arquitectura del sistema

[Meteostat API]
↓
[Aplicación C# - Colector + CRUD + Visualización]
↓
[MongoDB Local]


1.  **Colector (C#):** Obtiene observaciones meteorológicas de múltiples puntos del país (ej. Buenos Aires, Córdoba, Mendoza, Ushuaia) de forma automática y programada, gestionando la cuota de la API.
2.  **CRUD (C#):** Permite ver, filtrar, editar o eliminar las *estaciones* meteorológicas desde la misma aplicación.
3.  **Visualización (C#):** Permite generar gráficos y consultar los *datos* (mediciones) almacenados en la base de datos.
4.  **MongoDB Local:** Almacena los documentos JSON de las estaciones y sus observaciones horarias.

---

## 💾 Estructura de datos

El sistema utiliza dos colecciones principales: `stations` y `measurements`.

La colección `measurements` (mediciones) almacena un documento por cada hora, para cada estación. Sigue la estructura (basada en `Measurement.cs` y `Station.cs`):

```json
{
  "_id": {
    "$oid": "672f3e8b1b5e8a4a2c98d0a1"
  },
  "station": {
    "_id": {
      "$oid": "672f3a4d1b5e8a4a2c98d09f"
    },
    "Code": "87585",
    "OACI": "SABA",
    "Name": "BUENOS AIRES OBSERVATORIO",
    "Province": "CAPITAL FEDERAL",
    "Latitude": -34.5833,
    "Longitude": -58.4833,
    "Altitude": 25
  },
  "time": {
    "$date": "2025-10-27T14:00:00.000Z"
  },
  "temp": 19.5,
  "dwpt": 10.1,
  "rhum": 54,
  "prcp": 0.0,
  "snow": null,
  "wdir": 110,
  "wspd": 13.7,
  "wpgt": 25.9,
  "pres": 1015.2,
  "tsun": null,
  "coco": 2
}