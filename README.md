# Proyecto: Sistema de Observaciones Meteorológicas Antárticas con MongoDB

### Materia: Bases de Datos II
### Año: 2025
### Tecnología: MongoDB + C# (.NET Framework 4.8)
### Licencia: GNU General Public License v3.0

---

## 🧭 Descripción General

El proyecto consiste en el desarrollo de una base de datos NoSQL en **MongoDB** utilizada para almacenar y administrar observaciones meteorológicas horarias. El sistema se enfoca en la recolección de datos de las **seis bases científicas de la Antártida**, obtenidos desde la **API pública de Meteostat**.

Debido a que la API gratuita tiene una **restricción estricta de 500 llamadas por mes**, el núcleo del proyecto es un **colector automático de datos** (polling) diseñado para operar eficientemente dentro de este límite.

La aplicación se complementa con un **módulo CRUD** para la gestión de las estaciones y un **módulo de visualización** de datos en C# WinForms.

---

## ⚙️ Arquitectura del Sistema

[Meteostat API (Límite: 500 llamadas/mes)]
↓
[Aplicación C# - Colector + CRUD + Visualización]
↓
[MongoDB Local]

1.  **Colector (C#):** Obtiene observaciones meteorológicas de las 6 estaciones antárticas. El sondeo está programado con un **intervalo de sondeo optimizado** (ej. cada 8 o 12 horas) para distribuir las 500 llamadas mensuales de forma equitativa entre las estaciones sin exceder la cuota.
2.  **CRUD (C#):** Permite ver, filtrar, editar o eliminar las *estaciones* meteorológicas.
3.  **Visualización (C#):** Permite consultar y filtrar las *mediciones* históricas almacenadas en la base de datos (MongoDB) y mostrarlas en una grilla.
4.  **MongoDB Local:** Almacena los documentos JSON de las estaciones y sus observaciones horarias.

---

## 🇦🇶 Estaciones Monitoreadas

El alcance del colector se limita a las siguientes 6 estaciones antárticas:

* BASE BELGRANO II
* BASE CARLINI (EX JUBANY)
* BASE ESPERANZA
* BASE MARAMBIO
* BASE ORCADAS
* BASE SAN MARTIN

---

## 💾 Estructura de Datos

El sistema utiliza dos colecciones principales: `stations` y `measurements`.

La colección `measurements` (mediciones) almacena un documento por cada hora, para cada estación. Sigue la estructura (basada en `Measurement.cs`):

```json
{
  "_id": {
    "$oid": "672f3e8b1b5e8a4a2c98d0a1"
  },
  "station": {
    "_id": {
      "$oid": "672f3a4d1b5e8a4a2c98d09f"
    },
    "Code": "89055",
    "OACI": "SAWB",
    "Name": "BASE MARAMBIO",
    "Province": "ANTARTIDA",
    "Latitude": -64.2333,
    "Longitude": -56.6167,
    "Altitude": 198
  },
  "time": {
    "$date": "2025-10-27T14:00:00.000Z"
  },
  "temp": -3.5,
  "dwpt": -4.9,
  "rhum": 90,
  "prcp": 0.0,
  "snow": null,
  "wdir": 25,
  "wspd": 14.8,
  "wpgt": null,
  "pres": 993.5,
  "tsun": null,
  "coco": 5
}