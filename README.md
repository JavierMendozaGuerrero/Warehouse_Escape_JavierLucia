# Warehouse Escape – Proyecto Final Unity
Arquitectura del Software – ICAI (Universidad Pontificia Comillas)

**Autores**  
Javier Mendoza Guerrero  
Lucía Tamarit Barberán  

---

## Descripción del proyecto
Warehouse Escape es un videojuego desarrollado en Unity en el que el jugador controla a un personaje (Thief) que debe escapar de un almacén vigilado. Para lograrlo, el jugador debe explorar el entorno, evitar a los GuardRobots, recoger un objeto objetivo y alcanzar la zona de salida antes de ser capturado.

El proyecto implementa un bucle de juego completo que incluye menú principal, selección de dificultad, jugabilidad, condiciones de victoria y derrota, y reinicio de la partida. La arquitectura está diseñada siguiendo principios de modularidad y mantenibilidad, aplicando patrones de diseño vistos en la asignatura.

---

## Objetivo del juego
El objetivo del jugador es recoger el objeto objetivo y escapar por la salida sin ser atrapado por los guardias. Al activar una alarma, los guardias pasan de patrullar a perseguir activamente al jugador, incrementando la dificultad del nivel.

---

## Funcionalidades implementadas
El proyecto incluye las siguientes funcionalidades principales:

- Movimiento completo del jugador (Thief).
- Sistema de enemigos (GuardRobot) con inteligencia artificial basada en estados.
- Estados de patrulla y persecución implementados mediante una máquina de estados.
- Sistema de alarmas que, al ser activadas, alertan a los guardias y cambian su comportamiento.
- Generación dinámica de alarmas según la dificultad seleccionada.
- Objeto objetivo que debe recogerse antes de poder escapar.
- Zona de salida que valida la condición de victoria.
- Sistema de puntuación.
- Menú principal con selección de dificultad.
- Paneles de UI para victoria, derrota y alertas durante la partida.
- Reinicio completo del nivel tras finalizar la partida.

---

## Maquina de estados del guardia
El GuardRobot utiliza una máquina de estados para gestionar su comportamiento:

- **PatrolState**: el guardia recorre una serie de puntos de patrulla (waypoints).
- **ChaseState**: el guardia persigue activamente al jugador tras activarse una alarma.

Durante la persecución, el guardia incorporan un sistema de evasión de obstáculos y detección de atascos, evitando quedarse bloqueados contra paredes mediante comprobaciones de colisión y lógica de escape.

---

## Sistema de dificultad
La dificultad del juego se gestiona mediante ScriptableObjects (`DifficultySettings`), lo que permite configurar parámetros como:

- Número de alarmas en el nivel.
- Velocidad del guardia.
- Comportamiento general del nivel.

Este enfoque permite modificar la dificultad directamente desde el editor de Unity sin necesidad de cambiar el código, separando claramente los datos de configuración de la lógica del juego.

---

## Interfaz de usuario (UI)
El sistema de UI incluye:

- Menú principal con selección de dificultad.
- Visualización de la puntuación durante la partida.
- Panel de alerta que se muestra al activar una alarma.
- Pantalla de victoria al escapar correctamente.
- Pantalla de derrota cuando el jugador es capturado.

Los paneles se gestionan de forma desacoplada mediante eventos lanzados por el GameManager.

---

## Patrones de diseño utilizados
Durante el desarrollo se han aplicado varios patrones de diseño:

- **State Pattern**: utilizado para la IA de los GuardRobots (patrulla y persecución).
- **Factory Pattern**: empleado para la creación dinámica de alarmas en el nivel.
- **Singleton / GameManager**: gestión centralizada del estado global del juego.
- **ScriptableObject**: configuración de la dificultad del juego separada de la lógica.

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

