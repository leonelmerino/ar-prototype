# Avances: Prototipos AR

En este documento se indicarán los cambios realizados dentro del proyecto

---

# 04 de Mayo

Se tuvo que recuperar versión inicial del proyecto, dado a archivos que corrompieron la versión.
Se priorizarán las funcionalidades conversadas en la reunión anterior.
Se indagó métodos de implementación de Hand Tracking y VPS.

# 06 de Mayo
Se identificaron los posibles métodos para Hand Tracking: ManoMotion SDK (50 usd para Unity 6000.0.67f1) y MediaPipeUnityPlugin con MediaPipe Gesture Recognition (plugin con modificaciones para bajar requerimientos del sistema)
En el caso de VPS:
Lightship ARDK (actualmente Niantic Spacial que es pagado y requiere un buen escaneo de la zona) y GeoSpatial Creator Google API (permite posicionarlo en cualquier lugar del mundo)