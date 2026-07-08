## Prototipo AR Geoespacial con Google Geospatial Creator

Este proyecto corresponde a un prototipo de realidad aumentada geoespacial desarrollado en Unity.

Permite posicionar objetos 3D y contenido audiovisual en ubicaciones reales mediante coordenadas geográficas, utilizando Google Geospatial Creator, AR Foundation, ARCore Extensions, Google Map Tiles API y Cesium for Unity.

El objetivo del prototipo es evaluar la factibilidad técnica de asociar contenido digital a puntos físicos del entorno, como base para una futura experiencia situada de divulgación científica.

---

## 1. Tecnologías utilizadas

| Herramienta / paquete | Versión |
|---|---|
| Unity | 6000.3.13f1 |
| AR Foundation | 6.3.5 |
| ARCore XR Plugin | 6.3.5 |
| ARCore Extensions | 1.54.0 |
| Geospatial Creator | Incluido en el flujo de ARCore Geospatial |
| Google Map Tiles API | Servicio de Google Cloud |
| Cesium for Unity | 1.23.2 |

---

## 2. Requisitos previos

Antes de abrir el proyecto, se recomienda tener instalado:

- Unity Hub.
- Unity 6000.3.13f1.
- Android Build Support.
- Android SDK.
- Android NDK.
- OpenJDK.
- Dispositivo Android compatible con ARCore.
- Cuenta de Google Cloud.
- API Key configurada para los servicios necesarios.
- Conexión a internet para las pruebas geoespaciales.

Opcionalmente, para una futura versión iOS:

- Xcode.
- Dispositivo iPhone o iPad compatible con ARKit.

---

## 3. Documentación y repositorios útiles

### 3.1 Google Geospatial Creator

Documentación oficial con guía paso a paso:

[Google Geospatial Creator for Unity - Quickstart](https://developers.google.com/ar/geospatialcreator/unity/quickstart)

Guía de desarrollo geoespacial para Unity + AR Foundation:

[Geospatial developer guide for Unity](https://developers.google.com/ar/develop/unity-arf/geospatial/developer-guide)

Documentación de anclajes geoespaciales:

[Geospatial anchors](https://developers.google.com/ar/develop/geospatial/anchors)

---

### 3.2 ARCore Extensions

Repositorio oficial:

[google-ar/arcore-unity-extensions](https://github.com/google-ar/arcore-unity-extensions)

Releases de ARCore Extensions:

[ARCore Extensions releases](https://github.com/google-ar/arcore-unity-extensions/releases)

---

### 3.3 Cesium for Unity

Repositorio oficial:

[CesiumGS/cesium-unity](https://github.com/CesiumGS/cesium-unity)

Repositorio de ejemplos:

[CesiumGS/cesium-unity-samples](https://github.com/CesiumGS/cesium-unity-samples)

Quickstart oficial:

[Cesium for Unity Quickstart](https://cesium.com/learn/unity/unity-quickstart/)

---

## 4. Abrir el proyecto

1. Clonar el repositorio:

    ```bash
    git clone <REPO_URL>
    ```

2. Abrir Unity Hub.

3. Seleccionar:

    ```text
    Add → Add project from disk
    ```

4. Elegir la carpeta raíz del proyecto.

5. Abrir el proyecto con:

    ```text
    Unity 6000.3.13f1
    ```

6. Esperar a que Unity importe los paquetes.

La primera apertura puede tardar varios minutos.

---

## 5. Estructura general del proyecto

La estructura puede variar, pero los elementos principales deberían estar organizados de forma similar a esta:

```text
Assets/
├─ Scenes/
│  └─ prototipovps.unity
├─ Prefabs/
│  ├─ GeospatialAnchorContent.prefab
│  ├─ VideoScreen.prefab
│  └─ DebugUI.prefab
├─ Materials/
├─ RenderTextures/
├─ Videos/
├─ Scripts/
├─ Config/
│  └─ Secrets.example.json
Packages/
ProjectSettings/
```

Elementos relevantes:

| Elemento | Función |
|---|---|
| `MainGeospatialAR.unity` | Escena principal del prototipo |
| `AR Session` | Controla la sesión de realidad aumentada |
| `XR Origin` / `AR Origin` | Referencia principal de cámara y tracking |
| `ARCore Extensions` | Habilita funciones geoespaciales de ARCore |
| `Geospatial Creator` | Permite configurar y previsualizar puntos geográficos |
| `Cesium Georeference` | Apoya la representación geoespacial dentro de Unity |
| `VideoScreen` | Superficie virtual donde se reproduce contenido audiovisual |
| `DebugUI` | Interfaz temporal para mostrar distancia, precisión, orientación y altura |

---

## 6. Instalación de paquetes

### 6.1 AR Foundation

En Unity:

```text
Window → Package Manager
```

Buscar e instalar:

```text
AR Foundation
```

Versión usada:

```text
6.3.5
```

---

### 6.2 ARCore XR Plugin

En Unity:

```text
Window → Package Manager
```

Buscar e instalar:

```text
ARCore XR Plugin
```

Versión usada:

```text
6.3.5
```

---

### 6.3 ARCore Extensions

ARCore Extensions puede revisarse desde el repositorio oficial:

[google-ar/arcore-unity-extensions](https://github.com/google-ar/arcore-unity-extensions)

Versión usada:

```text
1.54.0
```

Si el paquete no está instalado, revisar la sección de releases del repositorio oficial:

[ARCore Extensions releases](https://github.com/google-ar/arcore-unity-extensions/releases)

---

### 6.4 Cesium for Unity

Cesium for Unity se utiliza para apoyar la representación geoespacial y la visualización del entorno 3D dentro de Unity.

Repositorio oficial:

[CesiumGS/cesium-unity](https://github.com/CesiumGS/cesium-unity)

Guía oficial de instalación:

[Cesium for Unity Quickstart](https://cesium.com/learn/unity/unity-quickstart/)

Versión usada:

```text
1.23.2
```

Para agregarlo en Unity:

```text
Window → Package Manager
```

Luego seguir la guía oficial de Cesium for Unity para instalar el paquete correspondiente.

Una vez instalado, se puede agregar un objeto de referencia geoespacial desde las herramientas de Cesium en Unity. Por ejemplo:

```text
Cesium → Cesium Georeference
```

También puede agregarse desde la jerarquía de la escena si el paquete ya está disponible.

---

## 7. Configuración de Google Cloud

Para que el prototipo funcione, se requiere una API Key de Google Cloud.

### 7.1 Servicios necesarios

En Google Cloud Console, activar los servicios requeridos:

```text
ARCore API
Map Tiles API
```

Google Cloud Console:

[Google Cloud Console](https://console.cloud.google.com/)

---

### 7.2 Crear API Key

En Google Cloud Console:

```text
APIs & Services → Credentials → Create credentials → API key
```

Copiar la clave y guardarla localmente.

---

### 7.3 Restringir API Key

No se recomienda dejar la API Key sin restricciones.

Para Android:

```text
Application restrictions → Android apps
```

Agregar:

```text
Package name: com.tuempresa.tuapp
SHA-1 certificate fingerprint: [COMPLETAR]
```

Para una futura versión iOS:

```text
Application restrictions → iOS apps
Bundle ID: com.tuempresa.tuapp
```

En API restrictions, limitar la clave solo a las APIs necesarias:

```text
ARCore API
Map Tiles API
```

---

## 8. Manejo seguro de API Keys

No subir API Keys reales al repositorio.

### 8.1 Archivos que no deben subirse

No subir:

```text
.env
local_keys.json
archivos con API Keys reales
certificados
keystores
tokens
client secrets
```

---

### 8.2 Archivo de ejemplo

El repositorio puede incluir un archivo de ejemplo:

```text
Assets/Config/Secrets.example.json
```

Contenido sugerido:

```json
{
  "googleMapTilesApiKey": "REEMPLAZAR_LOCALMENTE",
  "googleGeospatialApiKey": "REEMPLAZAR_LOCALMENTE"
}
```

---

### 8.3 Archivo local no versionado

Cada persona que ejecute el proyecto puede crear localmente:

```text
Assets/Config/Secrets/local_keys.json
```

Contenido local:

```json
{
  "googleMapTilesApiKey": "TU_API_KEY_LOCAL",
  "googleGeospatialApiKey": "TU_API_KEY_LOCAL"
}
```

Este archivo no debe subirse al repositorio.

---

### 8.4 `.gitignore` recomendado

En la raíz del proyecto debe existir un archivo `.gitignore` con al menos:

```gitignore
# Unity
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/
MemoryCaptures/

# IDE
.vscode/
.idea/
*.csproj
*.sln
*.user

# OS
.DS_Store
Thumbs.db

# Secrets / API Keys
.env
.env.*
!.env.example
secrets/
Secrets/
Assets/Secrets/
Assets/Config/Secrets/
Assets/**/Secrets/
*.keystore
*.jks
*.p12
*.pem
*.key
*.mobileprovision
```

Antes de hacer commit, revisar que no aparezcan claves con patrones como:

```text
AIza
API_KEY
apiKey
token
secret
client_secret
```

---

## 9. Configuración en Unity

### 9.1 Activar XR Plug-in Management

En Unity:

```text
Edit → Project Settings → XR Plug-in Management
```

En Android:

```text
Activar ARCore
```

Para una futura versión iOS:

```text
Activar ARKit
```

---

### 9.2 Configurar ARCore Extensions

En la escena principal debe existir una configuración asociada a ARCore Extensions.

Verificar la presencia de:

```text
AR Session
XR Origin / AR Origin
ARCore Extensions
ARCore Extensions Config
```

En la configuración de ARCore Extensions, habilitar las opciones geoespaciales según la documentación oficial.

---

### 9.3 Activar Geospatial Creator

Geospatial Creator permite configurar y previsualizar ubicaciones reales dentro del flujo de ARCore Geospatial.

Documentación oficial:

[Google Geospatial Creator for Unity - Quickstart](https://developers.google.com/ar/geospatialcreator/unity/quickstart)

Desde Geospatial Creator se pueden configurar ubicaciones reales, previsualizar el entorno y posicionar objetos en coordenadas específicas.

---

## 10. Configuración de anclajes geoespaciales

Los contenidos se posicionan mediante coordenadas reales.

Cada punto debe tener:

```text
Latitud
Longitud
Altitud
Orientación
Objeto asociado
```

Ejemplo conceptual:

```text
Anchor 1
Latitud: [COMPLETAR]
Longitud: [COMPLETAR]
Altitud: [COMPLETAR]
Contenido: esfera roja / video / modelo 3D

Anchor 2
Latitud: [COMPLETAR]
Longitud: [COMPLETAR]
Altitud: [COMPLETAR]
Contenido: esfera azul / video / modelo 3D
```

---

## 11. Cómo agregar un nuevo punto geoespacial

1. Abrir la escena principal:

    ```text
    Assets/Scenes/MainGeospatialAR.unity
    ```

2. Abrir la herramienta de Geospatial Creator.

3. Crear un nuevo objeto geoespacial o anchor.

4. Ingresar:

    ```text
    Latitude
    Longitude
    Altitude
    ```

5. Asociar un prefab o GameObject como contenido.

6. Ajustar:

    ```text
    Position local
    Rotation
    Scale
    ```

7. Guardar la escena.

8. Probar en un dispositivo Android compatible con ARCore.

---

## 12. Contenido 3D georreferenciado

El contenido 3D puede estar compuesto por:

```text
esferas de referencia
modelos 3D
flechas de orientación
paneles informativos
objetos asociados a fenómenos costeros
```

Recomendaciones:

- Mantener una escala moderada.
- Evitar modelos excesivamente pesados.
- Usar materiales visibles en exteriores.
- Verificar orientación.
- Probar el objeto desde distintas distancias.
- Revisar la altura del contenido respecto del usuario.

---

## 13. Contenido audiovisual georreferenciado

El prototipo permite reproducir video asociado a un punto geográfico.

### 13.1 Implementación

El sistema usa:

#### Quad o plano virtual

Objeto sugerido:

```text
VideoScreen
```

Función:

```text
Superficie donde se muestra el video
```

#### Render Texture

Archivo sugerido:

```text
VideoRenderTexture
```

Función:

```text
Recibe la salida del Video Player
```

#### Material

Configuración recomendada:

```text
Shader: Unlit/Texture
Texture: VideoRenderTexture
```

#### Video Player

Configuración recomendada:

```text
Source: Video Clip
Render Mode: Render Texture
Target Texture: VideoRenderTexture
Play On Awake: activado
Loop: opcional
```

---

### 13.2 Formato recomendado del video

Formatos:

```text
.mp4
.mov
```

Recomendado:

```text
Codec: H.264
Resolución: 720p o 1080p
Duración corta
Relación de aspecto: 16:9
```

---

### 13.3 Escala correcta del video

Para evitar deformación:

```text
Y = X × (9 / 16)
```

Ejemplos:

```text
X = 2     → Y = 1.125
X = 1     → Y = 0.5625
X = 0.16  → Y = 0.09
```

Configuración base recomendada:

```text
Scale X = 0.16
Scale Y = 0.09
Scale Z = 1
```

La escala debe ajustarse según la distancia esperada de observación.

---

### 13.4 Problemas comunes con video

#### Pantalla negra

Posibles causas:

```text
Render Texture no asignado
Material incorrecto
Video Player sin Target Texture
Formato de video no compatible
```

#### Video deformado

Posibles causas:

```text
Escala incorrecta
Relación de aspecto no coincidente
```

#### Video oscuro

Posible causa:

```text
Shader con iluminación en lugar de Unlit
```

#### Video no aparece

Posibles causas:

```text
Quad mal orientado
Objeto fuera del campo visual
Objeto demasiado pequeño
Altitud incorrecta
Anchor detectado pero contenido local desplazado
```

---

## 14. Ejecutar en Android

### 14.1 Preparar teléfono

En el dispositivo Android:

```text
Settings → About phone → Build number
```

Presionar varias veces para activar Developer Mode.

Luego activar:

```text
Developer options → USB debugging
```

Verificar que el dispositivo sea compatible con ARCore.

---

### 14.2 Configurar Unity

En Unity:

```text
File → Build Settings
```

Seleccionar:

```text
Android
```

Luego:

```text
Switch Platform
```

Ir a:

```text
Edit → Project Settings → XR Plug-in Management
```

Activar:

```text
ARCore
```

---

### 14.3 Player Settings

En:

```text
Edit → Project Settings → Player
```

Revisar:

```text
Company Name: [COMPLETAR]
Product Name: [COMPLETAR]
Package Name: com.[COMPLETAR].[COMPLETAR]
Minimum API Level: [COMPLETAR según compatibilidad]
Target API Level: Automatic o recomendado por Unity
```

Verificar permisos:

```text
Camera
Location
Internet
```

---

### 14.4 Build and Run

Conectar el teléfono por USB.

En Unity:

```text
File → Build Settings → Build And Run
```

Al abrir la app en el teléfono, aceptar permisos de:

```text
Cámara
Ubicación
```

---

## 15. Pruebas en terreno

Durante las pruebas, registrar:

```text
Fecha
Hora
Lugar
Dispositivo
Condiciones de luz
Conectividad
Precisión reportada
Distancia al anchor
Dirección indicada
Altura reportada
Visibilidad del contenido
Estabilidad del objeto
Problemas observados
```

Ejemplo:

```text
Prueba 1
Lugar: Campus San Joaquín
Anchor: Punto 1
Distancia inicial: [COMPLETAR]
Precisión horizontal: [COMPLETAR]
Objeto visible: sí / no
Observación: [COMPLETAR]
```

---

## 16. Debug

El prototipo puede incluir una interfaz temporal de debug para mostrar:

```text
Latitud actual
Longitud actual
Altitud actual
Precisión horizontal
Orientación
Distancia al anchor
Dirección hacia el anchor
Diferencia de altura
Estado de localización
```

Esta información es útil durante el desarrollo, pero no debería mostrarse en la versión final destinada a usuarios.

---

## 17. Problemas comunes del prototipo geoespacial

### 17.1 El contenido aparece lejos

Revisar:

```text
Latitud
Longitud
Altitud
Escala
Offset local del objeto
Jerarquía dentro del anchor
```

---

### 17.2 El anchor se detecta, pero el objeto no aparece

Revisar:

```text
Objeto hijo desactivado
Escala demasiado pequeña
Material transparente
Objeto fuera de cámara
Rotación incorrecta
Altitud incorrecta
```

---

### 17.3 La distancia se actualiza, pero no se ve el contenido

Esto puede indicar que la localización funciona, pero el contenido está mal configurado dentro de Unity.

Revisar:

```text
Transform local
Rotation
Scale
Prefab asociado
Canvas o Quad orientado en sentido contrario
```

---

### 17.4 La app no localiza bien

Revisar:

```text
Permisos de ubicación
GPS activo
Conexión a internet
VPS disponible en la zona
Cielo visible
Precisión horizontal reportada
Movimiento inicial del dispositivo
```

---

### 17.5 El video aparece negro

Revisar:

```text
Render Texture
Material Unlit
Video Player
Target Texture
Formato del archivo
Compatibilidad del codec
```

---

## 18. Proyección a iOS

El prototipo fue trabajado principalmente para pruebas geoespaciales en Android mediante ARCore.

Para una futura versión iOS se debe revisar:

```text
Compatibilidad de ARCore Geospatial en iOS
Configuración con ARKit
Bundle ID
Restricción de API Key para iOS
Xcode
Signing & Capabilities
Permisos de cámara y ubicación
```

Pasos generales:

```text
File → Build Settings → iOS → Switch Platform
Edit → Project Settings → XR Plug-in Management → activar ARKit
Build
Abrir proyecto en Xcode
Configurar firma
Ejecutar en iPhone/iPad
```

---

## 19. Buenas prácticas antes de subir al repositorio

No subir:

```text
Library/
Temp/
Obj/
Build/
Builds/
Logs/
UserSettings/
API Keys
Tokens
Keystores
Certificados
```

Antes de hacer commit, revisar en GitHub Desktop que no aparezcan archivos con:

```text
AIza
API_KEY
apiKey
token
secret
client_secret
```

Si aparece una clave real, eliminarla antes del commit.

---

## 20. Extensiones posibles

Este prototipo puede ampliarse con:

```text
más anclajes geoespaciales
modelos 3D costeros
videos científicos
audio espacial
interfaz de usuario final
indicadores de dirección
narrativa por estaciones
recorrido guiado
validación en miradores costeros
pruebas en iOS
evaluación con usuarios
```

---

## 21. Notas importantes

- Este proyecto corresponde a un prototipo geoespacial con Google Geospatial Creator.
- Las coordenadas deben revisarse cuidadosamente.
- La altitud afecta la visibilidad del contenido.
- La localización puede variar según el dispositivo, conectividad, entorno y disponibilidad de VPS.
- Las API Keys no deben subirse al repositorio.
- La interfaz de debug es solo para desarrollo.
- La versión final debería reemplazar los mensajes técnicos por instrucciones comprensibles para usuarios no expertos.

Documentación hecha con IA en base a comentarios y estructura del proyecto