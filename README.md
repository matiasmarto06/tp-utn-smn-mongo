# Proyecto: Sistema de Observaciones Meteorológicas con MongoDB

### Materia: Bases de Datos II  
### Año: 2025  
### Tecnología: MongoDB + C# (.NET 8) + Grafana  
### Licencia: GNU General Public License v3.0

---

## 🧭 Descripción general

El proyecto consiste en el desarrollo de una **base de datos NoSQL** en **MongoDB** utilizada para almacenar y administrar **observaciones meteorológicas horarias** obtenidas en tiempo real desde la **API pública de Meteostat**.

El objetivo es demostrar el uso práctico de una base NoSQL en un contexto real, implementando un **colector automático de datos**, junto con un **módulo CRUD** (Create, Read, Update, Delete) desarrollado en **C# WinForms** que permite visualizar, modificar y gestionar los registros almacenados.  
Los datos se presentan gráficamente mediante **Grafana**, conectado directamente a MongoDB.

---

## ⚙️ Arquitectura del sistema

[Meteostat API]
↓
[Aplicación C# - Colector + CRUD]
↓
[MongoDB Local]
↓
[Grafana - Visualización de métricas]


1. **Colector (C#):** obtiene observaciones meteorológicas de múltiples puntos del país (ej. Buenos Aires, Córdoba, Mendoza, Ushuaia).  
2. **CRUD (C#):** permite ver, filtrar, editar o eliminar registros desde la misma aplicación.  
3. **MongoDB Local:** almacena los documentos JSON de observaciones horarias.  
4. **Grafana:** consulta la base y genera dashboards con temperatura, humedad, presión y viento en tiempo real.

---

## 💾 Estructura de datos

Cada documento en la colección `observaciones` sigue la estructura:

```json
{
  "station": "Buenos Aires",
  "latitude": -34.60,
  "longitude": -58.38,
  "time": "2025-10-07T00:00:00",
  "temp": 13.3,
  "dwpt": 6.4,
  "rhum": 63,
  "prcp": 0.0,
  "wspd": 3.7,
  "wdir": 211,
  "pres": 1020.3
}
