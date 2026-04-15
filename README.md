# Prototipo AR con Detección de Imágenes (Guía Paso a Paso)

Este proyecto es un prototipo de realidad aumentada desarrollado en Unity.
Permite detectar imágenes de referencia y posicionar contenido 3D y multimedia (video) sobre ellas, sin uso de servicios cloud.

Esta guía está pensada para estudiantes sin experiencia previa en Unity o desarrollo móvil.

---

# 1. Requisitos

Antes de comenzar, debes tener instalado:

* Unity Hub
* Unity versión **6000.3.x** (idealmente la misma del proyecto)
* Módulos de Unity:

  * iOS Build Support
  * Android Build Support
  * Android SDK + NDK + OpenJDK
* Xcode (Mac)
* Un iPhone (para pruebas iOS)
* (Opcional) Un teléfono Android compatible con ARCore

---

# 2. Abrir el proyecto

1. Clonar el repositorio:
   git clone <REPO_URL>

2. Abrir Unity Hub

3. Click en:
   "Add" → seleccionar la carpeta del proyecto

4. Abrir el proyecto con la versión correcta de Unity

5. Esperar a que Unity cargue todo (puede tardar la primera vez)

---

# 3. Estructura importante del proyecto

Los elementos clave que debes conocer son:

* Escena principal:
  Assets/Scenes/MainAR.unity

* Biblioteca de imágenes:
  Assets/XR/ReferenceImages.asset

* Prefab del contenido:
  Assets/Prefabs/MarkerContent.prefab

---

# 4. Cómo agregar una nueva imagen a detectar

NO debes crear una nueva librería.

Debes usar la existente:

1. En el panel Project, navegar a:
   Assets/XR/

2. Seleccionar:
   ReferenceImages

3. En el Inspector:

   * Click en "Add Image"
   * Arrastrar tu imagen (PNG/JPG)

4. Configurar:

   * Name: nombre identificador
   * Specify Size: ACTIVADO
   * Size: tamaño real en metros (ej: 0.15)

IMPORTANTE: el tamaño debe coincidir con el tamaño real de la imagen.

---

# 5. Cómo cambiar el contenido del marcador (3D y video)

El contenido mostrado al detectar la imagen está definido en el prefab:

Assets/Prefabs/MarkerContent

Este prefab puede contener:

* Objetos 3D (ej. cubo)
* Elementos multimedia (video)

## Para modificar el contenido:

1. Ir a:
   Assets/Prefabs/

2. Abrir:
   MarkerContent

3. Modificar o agregar:

   * modelos 3D
   * objetos adicionales
   * pantalla de video

4. Asegurarse de que los objetos estén levemente elevados:

   * Y ≈ 0.05 (para evitar que queden dentro del plano)

5. Guardar el prefab

---

# 6. Contenido multimedia: reproducción de video sobre el marcador

El prototipo permite reproducir un video junto con el objeto 3D cuando se detecta la imagen.

---

## 6.1 Cómo está implementado

El sistema usa:

### Quad (pantalla)

* Objeto: `VideoScreen`
* Tipo: Quad
* Función: superficie donde se muestra el video

### Render Texture

* Archivo: `VideoRenderTexture`
* Recibe la salida del Video Player

### Material

* Shader: Unlit/Texture
* Textura: `VideoRenderTexture`

### Video Player

Configuración:

* Source: Video Clip
* Render Mode: Render Texture
* Target Texture: VideoRenderTexture
* Play On Awake: activado
* Loop: opcional

---

## 6.2 Formato del video

Formatos soportados:

* .mp4
* .mov

Recomendado:

* Codec: H.264
* Resolución: 720p o 1080p
* Duración corta

Ejemplo:

1920 × 1080 (16:9)

---

## 6.3 Escala correcta del video

Para evitar deformación:

Y = X × (9 / 16)

Ejemplos:

* X = 2 → Y = 1.125
* X = 1 → Y = 0.5625
* X = 0.16 → Y = 0.09

Configuración recomendada:

* Scale X = 0.16
* Scale Y = 0.09
* Scale Z = 1

---

## 6.4 Cómo cambiar el video

1. Importar el archivo a Assets

2. Seleccionar el objeto con Video Player

3. Cambiar el campo:
   Video Clip

4. Verificar:

   * Render Mode = Render Texture
   * Target Texture correcto

---

## 6.5 Problemas comunes

Pantalla negra:

* Render Texture no asignado
* Material incorrecto

Video deformado:

* Escala incorrecta

Video oscuro:

* Shader no es Unlit

Video no aparece:

* Quad mal orientado
* Objeto fuera de cámara

---

## 6.6 Audio (opcional)

El Video Player puede reproducir audio.

Para prototipos:

* se puede ignorar inicialmente

---

## 6.7 Audio espacial (avanzado)

Para mayor inmersión:

1. Agregar componente Audio Source

2. Configurar:

   * Spatial Blend = 3D

3. Posicionar el objeto cerca del marcador

Esto permite que el sonido dependa de la posición del usuario.

---

# 7. Ejecutar en iOS (Paso a paso)

## En Unity

1. Edit → Project Settings → XR Plug-in Management

2. En iOS:

   * Activar ARKit

3. File → Build Settings

4. Seleccionar iOS

5. Click en "Switch Platform"

6. Click en "Build"

7. Elegir carpeta

---

## En Xcode

1. Abrir el proyecto generado

2. Seleccionar:
   Unity-iPhone

3. Signing & Capabilities

4. Activar:
   Automatically manage signing

5. Seleccionar cuenta

6. Conectar iPhone

7. Presionar Run

---

## En el iPhone

1. Aceptar permisos de cámara

2. Apuntar a la imagen

3. Aparece:

   * objeto 3D
   * video

---

# 8. Ejecutar en Android

## Preparación

* Activar Developer Mode
* Activar USB Debugging

---

## En Unity

1. File → Build Settings

2. Seleccionar Android

3. Switch Platform

4. Edit → Project Settings → XR Plug-in Management

5. Activar ARCore

6. Build And Run

---

# 9. Requisitos de las imágenes

✔ Alto contraste
✔ Detalles visibles
✔ Texturas

Evitar:

✘ Imágenes simples
✘ Patrones repetitivos
✘ Superficies brillantes

---

# 10. Debug

Para verificar detección:

* Revisar consola en Xcode
* Buscar:
  [ADDED], [UPDATED]

Si no aparecen:
→ la imagen no está siendo detectada

---

# 11. Extensiones posibles

* múltiples imágenes
* distintos modelos
* múltiples videos
* interacción
* animaciones
* UI
* persistencia

---

# 12. Notas importantes

* NO subir:

  * Library
  * Temp
  * Builds

* Usar misma versión de Unity

* Instalar packages desde Unity Registry
