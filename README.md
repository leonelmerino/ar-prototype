# Prototipo AR con Detección de Imágenes (Guía Paso a Paso)

Este proyecto es un prototipo de realidad aumentada desarrollado en Unity.  
Permite detectar imágenes de referencia y posicionar contenido 3D sobre ellas, sin uso de servicios cloud.

Esta guía está pensada para estudiantes sin experiencia previa en Unity o desarrollo móvil.

---

# 1. Requisitos

Antes de comenzar, debes tener instalado:

- Unity Hub
- Unity versión **6000.3.x** (idealmente la misma del proyecto)
- Módulos de Unity:
  - iOS Build Support
  - Android Build Support
  - Android SDK + NDK + OpenJDK
- Xcode (Mac)
- Un iPhone (para pruebas iOS)
- (Opcional) Un teléfono Android compatible con ARCore

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

- Escena principal:
  Assets/Scenes/MainAR.unity

- Biblioteca de imágenes:
  Assets/XR/ReferenceImages.asset

- Prefab del objeto:
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
   - Click en "Add Image"
   - Arrastrar tu imagen (PNG/JPG)

4. Configurar:
   - Name: nombre identificador
   - Specify Size: ACTIVADO
   - Size: tamaño real en metros (ej: 0.15)

IMPORTANTE: el tamaño debe coincidir con el tamaño real de la imagen.

---

# 5. Cómo cambiar el objeto 3D

1. Ir a:
   Assets/Prefabs/

2. Abrir o editar:
   MarkerContent

3. Para cambiarlo:
   - Importar un modelo nuevo
   - Crear prefab
   - Ajustar escala

4. Asegurarse de que el objeto esté elevado:
   Y = 0.05 (para evitar que quede enterrado)

5. Guardar cambios en el prefab

---

# 6. Ejecutar en iOS (Paso a paso)

## En Unity

1. Ir a:
   Edit → Project Settings → XR Plug-in Management

2. Seleccionar pestaña iOS:
   - Activar ARKit

3. Ir a:
   File → Build Settings

4. Seleccionar:
   iOS

5. Click en:
   "Switch Platform"

6. Luego click en:
   "Build"

7. Elegir carpeta (ej: Desktop/Build_iOS)

---

## En Xcode

1. Abrir el proyecto generado

2. Seleccionar target:
   Unity-iPhone

3. Ir a:
   Signing & Capabilities

4. Activar:
   "Automatically manage signing"

5. Seleccionar tu cuenta (Personal Team)

6. Conectar iPhone por cable

7. Seleccionar el dispositivo en la barra superior

8. Presionar:
   ▶ Run

---

## En el iPhone

1. Aceptar permisos de cámara

2. Apuntar a la imagen de referencia

3. Debería aparecer el objeto 3D sobre la imagen

---

# 7. Ejecutar en Android

## Preparación

1. En el teléfono:
   - Activar Developer Mode
   - Activar USB Debugging

2. Conectar el teléfono al computador

---

## En Unity

1. Ir a:
   File → Build Settings

2. Seleccionar:
   Android

3. Click en:
   "Switch Platform"

4. Ir a:
   Edit → Project Settings → XR Plug-in Management

5. En Android:
   - Activar ARCore

6. Click en:
   "Build And Run"

---

## En el teléfono Android

1. Aceptar permisos de cámara

2. Aceptar instalación de la app

3. Apuntar a la imagen

---

# 8. Requisitos de las imágenes

Para que funcione correctamente:

✔ Alto contraste  
✔ Detalles visibles  
✔ Bordes y texturas  

Evitar:

✘ Imágenes simples  
✘ Patrones repetitivos  
✘ Superficies brillantes  

---

# 9. Debug

Para verificar detección:

- Revisar consola en Xcode
- Buscar mensajes como:
  [ADDED], [UPDATED]

Si no aparecen:
→ la imagen no está siendo detectada

---

# 10. Extensiones posibles

Este prototipo se puede extender con:

- múltiples imágenes
- distintos modelos por imagen
- interacción del usuario
- animaciones
- interfaz gráfica
- persistencia

---

# 11. Notas importantes

- NO subir carpetas Library, Temp o Builds al repositorio
- Usar siempre la misma versión de Unity
- Instalar packages desde Unity Registry

---

Este documento está pensado como guía inicial para trabajar con AR en Unity usando detección de imágenes.
