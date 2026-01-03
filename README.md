# Warehouse Escape – Proyecto Final Unity
Arquitectura del Software – ICAI (Universidad Pontificia Comillas)

**Autores**  
Javier Mendoza Guerrero  
Lucía Tamarit Barberán  


# Warehouse Escape (Unity)

Autores: Javier Mendoza Guerrero y Lucía Tamarit Barberán  
Unity: 6000.2.6f2 (Unity 6.2)

## Cómo abrir y ejecutar
1. Abrir el proyecto con Unity Hub.
2. Abrir la escena final:
   **Assets/_Project/LowPolyFPSLite/Scenes/LowPolyFPS_Lite_Demo_2.unity**
3. Play y seleccionar dificultad (Easy/Medium/Hard) en el menú.

## Ruta de la escena final
Escena jugable final:
- `Assets/_Project/LowPolyFPSLite/Scenes/LowPolyFPS_Lite_Demo_2.unity`

## Estructura de carpetas (resumen)
- `Assets/_Project/LowPolyFPSLite/` → Assets del entorno + escena final
  - `Scenes/` → aquí está la escena final
- `Assets/Scripts/` → scripts del juego (GameManager, GuardRobot, Alarm, etc.)
- `Assets/_Project/Difficulty/` → ScriptableObjects de dificultad (Easy/Medium/Hard)
- `Assets/Prefabs/` → prefabs del proyecto 
- `Assets/TextMesh Pro/` → dependencias de UI (TMP)

## Controles
-flechas: mover
---


## Objetivo del juego
El jugador controla a un ladrón infiltrado en un almacén el cual debe encontrar un objeto y 
escapar por la salida, en cada partida cambia la localización del objeto, la localización de 
la salida y la localización de las alarmas. El juego incluye varios niveles de dificultad, 
donde cambian la velocidad del robot y el número de alarmas. 


## Interfaz de usuario (UI)
El sistema de UI incluye:

- Menú principal con selección de dificultad.
- Visualización de la puntuación durante la partida.
- Panel de alerta que se muestra al activar una alarma.
- Pantalla de victoria y de derrota

---
## Arquitectura y UML
El UML y la memoria completa del proyecto se encuentran en la carpeta `/doc`.

---

## Tecnologías utilizadas
- Unity 6.x
- C#
- TextMeshPro
- Visual Studio / VS Code
- Git y GitHub para control de versiones
---

## Contenido del repositorio
- `Assets/` – Código fuente, escenas, prefabs y scripts del proyecto.
- `Packages/` – Dependencias de Unity.
- `ProjectSettings/` – Configuración del proyecto.
- `doc/` – Documentación del proyecto y diagramas UML.
- `Build/` – Versión compilada del juego para PC/Mac.
- `README.md` – Documento descriptivo del proyecto.
