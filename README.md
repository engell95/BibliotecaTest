Se te encarga crear un sistema de gestión de bibliotecas que consista tanto en una API de
backend desarrollada en .NET Core como en una aplicación frontend desarrollada en React.
La API de backend se encargará de gestionar los libros en la biblioteca, mientras que el
frontend de React consumirá esta API para mostrar e interactuar con los datos de la
biblioteca.

Requisitos del backend (API):
  1. Crear un proyecto de API web .NET Core para servir como backend.
  2. Implementar puntos finales RESTful para gestionar los libros en la biblioteca:
  a. Agregar un libro
  b. Eliminar un libro
  c. Prestar un libro
  d. Devolver un libro
  e. Recuperar todos los libros
  3. Vamos a utilizar Entity Framework e InMemoryDatabase para esta tarea. Todos
  sabemos que no es adecuado para producción, pero en este escenario será
  suficiente.
  4. Asegurar el cumplimiento de los principios SOLID, especialmente el Principio de
  Responsabilidad Única (SRP), el Principio de Inversión de Dependencias (DIP) y el
  Principio de Abierto/Cerrado (OCP).
  5. Implementar manejo adecuado de errores y validación para las solicitudes de la API.
  Ejemplo: No se puede prestar un libro inexistente, o si tenemos 0 copias de un libro.

Requisitos del frontend (React):
  1. Crear una aplicación React para servir como frontend del sistema de gestión de
  bibliotecas.
  2. Utilizar componentes funcionales y hooks para la gestión del estado y las
  interacciones con la API.
  3. Consumir la API de backend para mostrar la lista de libros en la biblioteca y permitir
  a los usuarios realizar acciones como agregar, eliminar, prestar y devolver libros.
  4. Implementar componentes separados para agregar, mostrar y gestionar libros.
  5. Asegurar un manejo adecuado de eventos y actualizaciones de estado.
  6. Implementar manejo adecuado de errores y mostrar mensajes de error al usuario
  cuando sea necesario.
  Requisitos generales:
  1. Configurar una comunicación adecuada entre el frontend y el backend mediante
  solicitudes HTTP (por ejemplo, fetch o axios).
  2. Asegurar una validación adecuada de datos y manejo de errores tanto en el frontend
  como en el backend.
  3. Escribir pruebas unitarias para los puntos finales de la API de backend y cualquier
  componente crítico del frontend.
  4. Puntos extra por implementar mecanismos de autenticación y autorización para
  restringir ciertas acciones (por ejemplo, prestar libros) a usuarios autenticados.

Notas adicionales:
● Puedes optar por utilizar cualquier biblioteca o framework adicional que consideres
apropiado para completar la tarea.
● Presta atención a la arquitectura general, organización del código y documentación
de tu solución.
● La solución debe presentarse en un repositorio de Github / Gitlab con sus
respectivos commits, se valorará el uso de ramas y commits adecuados.
Crear un repositorio privado en github y compartirlo con @hectorbenitez
