# Warehouse Escape – Diseño de Arquitectura (Primera Parte)
Proyecto Final – Arquitectura del Software – ICAI  
Autores: Javier Mendoza Guerrero y Lucía Tamarit Barberán

## Descripción del proyecto
Warehouse Escape es un videojuego desarrollado en Unity cuyo objetivo es que el jugador, controlando al personaje Thief, recorra un almacén, evite a los GuardRobots, recoja el ObjectiveItem y alcance la ExitZone para completar el nivel.  
Esta primera entrega se centra en el diseño de arquitectura del proyecto, definiendo los componentes principales, patrones de diseño utilizados y la planificación técnica previa al desarrollo.

## Objetivos del videojuego
- Permitir el movimiento del jugador por el almacén.
- Implementar GuardRobots con IA de patrulla y persecución.
- Recoger un objeto objetivo necesario para escapar.
- Generar alarmas y elementos del nivel dinámicamente según la dificultad.
- Gestionar un loop de juego cerrado (inicio, juego, victoria/derrota, reinicio).

## Componentes principales
- Thief (jugador)
- GuardRobot (enemigos con IA basada en estados)
- Alarmas (activadas por detección del jugador)
- ObjectiveItem (objeto clave para completar el nivel)
- ExitZone (punto de salida)
- GameManager (gestión global del juego)
- Sistema de niveles: EasyMap, MediumMap y DifficultMap
- UI: ScoreUI, EndScreen y menú principal

## Diseño UML
La arquitectura se organiza en módulos independientes:
- Lógica del juego a cargo del GameManager.
- Personajes y enemigos (Thief y GuardRobot).
- Máquina de estados (PatrolState, ChaseState, IA).
- Sistema de generación de alarmas mediante AlarmFactory.
- Sistema de dificultad implementado con el patrón Bridge (IMapLevel).
- Interfaz de usuario encargada de la puntuación y pantallas finales.

## Patrones de diseño utilizados
### 1. Factoría
Utilizada para generar alarmas dinámicamente según la dificultad seleccionada.

### 2. State Pattern
Define el comportamiento del GuardRobot mediante estados de patrulla y persecución.

### 3. Bridge Pattern
Permite separar la abstracción del mapa (IMapLevel) de sus implementaciones (EasyMap, MediumMap, DifficultMap).

## Historias de usuario
Las historias de usuario definen las necesidades principales del jugador y del diseñador del nivel.  
Incluyen movimientos básicos, detección y persecución por parte del robot, recogida del objeto clave, validación de condiciones de victoria y generación dinámica de elementos según la dificultad.

## Análisis de historias de usuario
Cada historia se analiza considerando:
- Objetivo que busca el usuario.
- Tareas necesarias para su implementación en Unity.
- Requisitos funcionales y no funcionales relacionados.
- Interacciones con otros componentes.
- Validación necesaria durante las pruebas.
- Estimación de esfuerzo y priorización según su impacto en el desarrollo.

Este análisis permite derivar la arquitectura final reflejada en el diagrama UML y establece el orden lógico de implementación para la segunda parte del proyecto.

## Requisitos del sistema
### Requisitos funcionales
Incluyen el movimiento del jugador, comportamiento de la IA, activación de alarmas, gestión de puntuación, recogida del objeto objetivo y condiciones de victoria y derrota.

### Requisitos no funcionales
Relacionados con rendimiento, mantenibilidad, modularidad, usabilidad y robustez del loop de juego.

### Restricciones
- Proyecto limitado a un jugador.
- Uso obligatorio de Unity como motor.
- Dependencia de los assets disponibles.
- Tres niveles de dificultad definidos para esta entrega.

## Tecnologías utilizadas
- Unity (versión indicada en la documentación)
- C#
- Visual Studio / VS Code
- Git y GitHub para control de versiones

## Contenido del repositorio
- /Docs/ – Documentación del diseño de arquitectura (PDF)
- /UML/ – Diagrama UML del proyecto
- README.md – Documento actual  
- (Segunda parte) Código en C#, escenas, prefabs y assets del videojuego

## Estado del proyecto
Primera parte completada: Diseño de arquitectura  
Segunda parte pendiente: Desarrollo e implementación en Unity

## Autores
Lucía Tamarit Barberán  
Javier Mendoza Guerrero
