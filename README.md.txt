
---

## Sistema de dificultad

El sistema de dificultad permite modificar parámetros como:

- Número de alarmas.
- Velocidad del guardia.
- Velocidad de rotación.
- Distancia de detección de obstáculos.

Estos parámetros se almacenan en **ScriptableObjects**, lo que permite crear nuevas dificultades o ajustar las existentes sin modificar código.

---

## Sistema de alertas

Cuando el jugador pisa una alarma:

1. Se notifica a todos los guardias.
2. El guardia cambia de estado de **Patrol** a **Chase**.
3. Se muestra un panel de alerta en pantalla durante unos segundos informando al jugador.

Este sistema está desacoplado mediante eventos para evitar dependencias directas entre lógica y UI.

---

## Patrones de diseño utilizados

- State / Strategy
- Singleton
- Factory
- Observer (eventos)
- Separación de datos y lógica mediante ScriptableObjects

---

## Requisitos

- Unity 6.x
- TextMeshPro habilitado
- Plataforma objetivo: PC

---

## Cómo ejecutar el proyecto

1. Abrir el proyecto en Unity.
2. Cargar la escena principal (`Main.unity`).
3. Pulsar **Play**.
4. Seleccionar la dificultad en el menú.
5. Jugar.

---

## Autores

Proyecto desarrollado por Javier Mendoza Guerrero y Lucía Tamarit Barberán.
