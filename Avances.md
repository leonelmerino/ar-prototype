# Avances: Prototipos AR

En este documento se indicarán los cambios y avances realizados dentro del proyecto

---

# 04 de Mayo

Se tuvo que recuperar versión inicial del proyecto, dado a archivos que corrompieron la versión.
Se priorizarán las funcionalidades conversadas en la reunión anterior.
Se indagó métodos de implementación de Hand Tracking y VPS.

# 06 de Mayo
Se identificaron los posibles métodos para Hand Tracking: ManoMotion SDK (50 usd para Unity 6000.0.67f1) y MediaPipeUnityPlugin con MediaPipe Gesture Recognition (plugin con modificaciones para bajar requerimientos del sistema)
En el caso de VPS:
Lightship ARDK (actualmente Niantic Spacial que es pagado y requiere un buen escaneo de la zona) y GeoSpatial Creator Google API (permite posicionarlo en cualquier lugar del mundo)

# 14 de Mayo
Se prueba aplicación de prueba ManoMotion Tech PRO en Android y en iOS, no existe diferencia notable. Se prueba detección de manos y funcionalidades existentes en la aplicación.
Interacción con objetos según distancia presenta una dificultad al momento de uso. Oclusión en Android hace que se cierre la aplicación, mientras que en iOS si funciona correctamente.

# 28 de Mayo
Errores de compilación en prototipo orientado a iOS generan la decisión de desarrollar en primer lugar prototipo de georreferenciación en dispositivos Android para facilidad en realizar pruebas dentro del campus.
Se desarrolla proyecto orientado en Android, se busca adaptar este mismo a iOS en un futuro.
Se realizan primeras pruebas de prototipo de georeferenciación con Google Geospatial Creator.
Se presentan errores de OPENGL_NATIVE PLUG-IN ERROR GL_INVALID_ENUM en Development console de a aplicación en dispositivo Android


# 3 de Junio
Se realizan más pruebas de prototipo. Objetos no se visualizan por problemas con material e iluminación. Se revisa Graphics y se le agrega Universal Render Pipeline Asset.

# 4 de Junio
Se realizan pruebas de visualización de objetos tridimensionales en los dos anchors realizados. Se nota dificultad por reconocer ubicación de objeto 3D en un inicio, por lo que se implementa un ubicador que notifica qué tan cerca el usuario se encuentra del objeto y hacia donde debe mover la cámara para visualizarlo.

# 10 y 11 de Junio
Se realizan pruebas de prototipo de altura y distancia. Se realizan distintos recorridos desde distintas ubicaciones para revisar escala, puntos ciegos y la posible desvinculación con el punto.
Se logra observar que dentro de distintos puntos de observación y en distintos horarios del día, con distintas iluminaciones, se visualiza correctamente.
El objeto no posee oclusión y se sobrepone cualquier objeto que se ubique entre medio.

# 24 y 25 de Junio
Se realizan pruebas de prototipo de georreferenciación de contenido audiovisual. Concretamente una simulación realizada por José que se encuentra en los activos del proyecto.
En estas, se revisa visualización en puntos de baja iluminación (en la noche) y dentro del día. Se adiciona Script para que el video rote y se pueda visualizar en cualquier punto de observación.
En la última prueba, de noche, se prueba la implementación de dos objetos audiovisuales simultáneos en la misma ubicación. Se visualizan correctamente.

# 28 de Junio a 8 de Julio
Redacción de informe