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
- WASD / flechas: mover
---

## Descripción del proyecto
Warehouse Escape es un videojuego desarrollado en Unity en el que el jugador controla a un personaje (Thief) que debe escapar de un almacén vigilado. Para lograrlo, el jugador debe explorar el entorno, evitar a los GuardRobots, recoger un objeto objetivo y alcanzar la zona de salida antes de ser capturado.

El proyecto implementa un bucle de juego completo que incluye menú principal, selección de dificultad, jugabilidad, condiciones de victoria y derrota, y reinicio de la partida. La arquitectura está diseñada siguiendo principios de modularidad y mantenibilidad, aplicando patrones de diseño vistos en la asignatura.

---

## Objetivo del juego
El objetivo del jugador es recoger el objeto objetivo y escapar por la salida sin ser atrapado por los guardias. Al activar una alarma, el guardia pasa de patrullar a perseguir activamente al jugador, incrementando la dificultad del nivel.


## Interfaz de usuario (UI)
El sistema de UI incluye:

- Menú principal con selección de dificultad.
- Visualización de la puntuación durante la partida.
- Panel de alerta que se muestra al activar una alarma.
- Pantalla de victoria y de derrota

---
## Arquitectura y UML
La arquitectura del proyecto se basa en componentes desacoplados que se comunican mediante eventos.  
El diagrama UML final refleja las relaciones entre los distintos sistemas del juego, incluyendo asociaciones, dependencias y composiciones justificadas en la documentación.

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

---

## Estado del proyecto
Proyecto finalizado.  
Incluye diseño, implementación completa en Unity y versión jugable compilada.

