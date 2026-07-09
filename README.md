# Prototipo AR Geoespacial para iOS con Google Geospatial Creator

Este proyecto corresponde a un **prototipo de realidad aumentada geoespacial para iOS**, desarrollado en Unity.

El prototipo permite posicionar objetos 3D y contenido audiovisual en ubicaciones reales mediante coordenadas geográficas, utilizando **Google Geospatial Creator**, **AR Foundation**, **ARKit XR Plugin**, **ARCore Extensions**, **Google Map Tiles API** y **Cesium for Unity**.

El objetivo es evaluar la factibilidad técnica de asociar contenido digital a puntos físicos del entorno, como base para una futura experiencia situada de divulgación científica.


---

## 1. Tecnologías utilizadas

| Herramienta / paquete | Versión utilizada |
|---|---|
| Unity | 6000.3.13f1 |
| AR Foundation | 6.3.5 |
| ARKit XR Plugin | 6.3.5 |
| ARCore Extensions | 1.54.0 |
| Geospatial Creator | Incluido en ARCore Extensions |
| Google Map Tiles API | Servicio de Google Cloud |
| Cesium for Unity | 1.19.0 |
| Xcode | Requerido para compilar en iOS |

> Nota: este proyecto utiliza Cesium for Unity `1.19.0` por compatibilidad con ARCore Extensions `1.54.0`, Google Geospatial Creator y Unity `6000.3.13f1`.

---

## 2. Requisitos previos

Antes de abrir o compilar el proyecto, se recomienda tener instalado:

- Unity Hub.
- Unity `6000.3.13f1`.
- iOS Build Support para Unity.
- Xcode instalado en macOS.
- Dispositivo iPhone o iPad compatible con ARKit.
- Cuenta de desarrollador Apple o equipo de firma configurado en Xcode.
- Cuenta de Google Cloud.
- API Key configurada para los servicios necesarios.
- Conexión a internet para descargar paquetes y usar servicios geoespaciales.

El proyecto está orientado a pruebas en dispositivo físico. No se recomienda validar la experiencia geoespacial en simulador de iOS, ya que la funcionalidad AR requiere cámara, sensores y localización real.

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

## 4. Abrir el proyecto por primera vez

### 4.1 Clonar el repositorio

Clonar el repositorio:

```bash
git clone <REPO_URL>
```

Entrar a la carpeta del proyecto:

```bash
cd <NOMBRE_DEL_PROYECTO>
```

La estructura general debe ser similar a:

```text
Proyecto/
├─ Assets/
├─ Packages/
├─ ProjectSettings/
├─ README.md
└─ .gitignore
```

---

### 4.2 Abrir con Unity Hub

1. Abrir Unity Hub.
2. Seleccionar:

```text
Add → Add project from disk
```

3. Elegir la carpeta raíz del proyecto.
4. Abrir el proyecto con:

```text
Unity 6000.3.13f1
```

5. Esperar a que Unity importe paquetes y compile scripts.

La primera apertura puede tardar varios minutos.

---

## 5. Configuración de paquetes

El proyecto usa paquetes de Unity, Google y Cesium. Las versiones esperadas son:

```text
AR Foundation: 6.3.5
ARKit XR Plugin: 6.3.5
ARCore Extensions: 1.54.0
Cesium for Unity: 1.19.0
```

En `Packages/manifest.json` debe estar configurado Cesium mediante Scoped Registry:

```json
"scopedRegistries": [
  {
    "name": "Cesium",
    "url": "https://unity.pkg.cesium.com/",
    "scopes": [
      "com.cesium.unity"
    ]
  }
]
```

Y dentro de `dependencies` debe estar:

```json
"com.cesium.unity": "1.19.0"
```

Ejemplo parcial de `manifest.json`:

```json
{
  "scopedRegistries": [
    {
      "name": "Cesium",
      "url": "https://unity.pkg.cesium.com/",
      "scopes": [
        "com.cesium.unity"
      ]
    }
  ],
  "dependencies": {
    "com.cesium.unity": "1.19.0",
    "com.google.ar.core.arfoundation.extensions": "1.54.0",
    "com.unity.xr.arfoundation": "6.3.5",
    "com.unity.xr.arkit": "6.3.5"
  }
}
```

> No reemplazar todo el archivo `manifest.json` por este ejemplo, ya que el proyecto puede tener más dependencias. Solo verificar que las líneas principales estén presentes y correctamente escritas.

---

## 6. Configuración de Google Cloud

Para usar la funcionalidad geoespacial y visualizar tiles 3D, se requiere una API Key de Google Cloud.

### 6.1 Servicios necesarios

En Google Cloud Console, activar:

```text
ARCore API
Map Tiles API
```

Google Cloud Console:

[Google Cloud Console](https://console.cloud.google.com/)

---

### 6.2 Crear API Key

En Google Cloud Console:

```text
APIs & Services → Credentials → Create credentials → API key
```

Copiar la clave y guardarla localmente.

---

### 6.3 Restringir API Key para iOS

No se recomienda dejar la API Key sin restricciones.

Para iOS:

```text
Application restrictions → iOS apps
```

Agregar el Bundle ID utilizado por la aplicación:

```text
Bundle ID: com.tuempresa.tuapp
```

En API restrictions, limitar la clave solo a las APIs necesarias:

```text
ARCore API
Map Tiles API
```

El Bundle ID configurado en Google Cloud debe coincidir exactamente con el Bundle Identifier utilizado en Unity y Xcode.

---

## 7. Manejo seguro de API Keys

Las API Keys reales no deben subirse al repositorio.

### 7.1 Archivos que no deben subirse

No subir:

```text
.env
.env.*
local_keys.json
archivos con API Keys reales
certificados
keystores
tokens
client secrets
```

---

### 7.2 Carpeta local para claves

Se recomienda crear una carpeta local ignorada por Git:

```text
LocalSecrets/
```

Ejemplo:

```text
Proyecto/
├─ Assets/
├─ Packages/
├─ ProjectSettings/
├─ LocalSecrets/
│  └─ google_api_keys.json
```

Contenido sugerido de `LocalSecrets/google_api_keys.json`:

```json
{
  "IPRE_GOOGLE_MAP_TILES_API_KEY": "TU_API_KEY_LOCAL",
  "IPRE_GOOGLE_GEOSPATIAL_API_KEY": "TU_API_KEY_LOCAL"
}
```

Esta carpeta debe estar ignorada por Git.

---

### 7.3 Archivo de ejemplo para el repositorio

El repositorio puede incluir un archivo de ejemplo sin claves reales:

```text
LocalSecrets.example.json
```

Contenido sugerido:

```json
{
  "IPRE_GOOGLE_MAP_TILES_API_KEY": "REEMPLAZAR_LOCALMENTE",
  "IPRE_GOOGLE_GEOSPATIAL_API_KEY": "REEMPLAZAR_LOCALMENTE"
}
```

---

### 7.4 Configuración manual de la key en Cesium

Si se configura manualmente la URL del tileset, el formato es:

```text
https://tile.googleapis.com/v1/3dtiles/root.json?key=TU_API_KEY_LOCAL
```

Antes de hacer commit, no debe quedar una key real dentro de escenas, prefabs o assets.

Reemplazar por:

```text
https://tile.googleapis.com/v1/3dtiles/root.json?key=REEMPLAZAR_CON_API_KEY_LOCAL
```

o dejar el campo vacío.

---

### 7.5 Búsqueda de claves antes del commit

Antes de subir cambios, buscar claves en el proyecto.

En Terminal de macOS:

```bash
grep -R "AIza" Assets Packages ProjectSettings --include="*.unity" --include="*.prefab" --include="*.asset" --include="*.json" --include="*.cs" --include="*.txt"
```

También revisar patrones como:

```text
API_KEY
apiKey
token
secret
client_secret
```

---

## 8. `.gitignore` recomendado

En la raíz del proyecto debe existir un archivo `.gitignore`.

Contenido recomendado:

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

# Unity recovery files
Assets/_Recovery/
Assets/**/_Recovery/

# IDE
.vscode/
.idea/
*.csproj
*.sln
*.user
*.pidb
*.booproj
*.svd
*.pdb
*.mdb
*.opendb

# OS
.DS_Store
Thumbs.db

# Local API Keys
LocalSecrets/
.env
.env.*
!.env.example
*.local.json

# Secrets / credentials
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

# Large local Unity packages
Assets/package/*.tgz
Assets/packages/*.tgz
Assets/Package/*.tgz
Assets/Packages/*.tgz
LocalPackages/
*.tgz
```

---

## 9. Estructura general del proyecto

La estructura puede variar, pero los elementos principales deberían estar organizados de forma similar a esta:

```text
Assets/
├─ Scenes/
│  └─ MainGeospatialAR.unity
├─ Prefabs/
│  ├─ GeospatialAnchorContent.prefab
│  ├─ VideoScreen.prefab
│  └─ DebugUI.prefab
├─ Materials/
├─ RenderTextures/
├─ Videos/
├─ Scripts/
├─ Config/
Packages/
ProjectSettings/
```

Elementos relevantes:

| Elemento | Función |
|---|---|
| `MainGeospatialAR.unity` | Escena principal del prototipo |
| `AR Session` | Controla la sesión de realidad aumentada |
| `XR Origin` / `AR Origin` | Referencia principal de cámara y tracking |
| `AR Camera` | Cámara principal utilizada por ARKit |
| `ARCore Extensions` | Habilita funciones geoespaciales de ARCore sobre AR Foundation |
| `ARCoreExtensionsConfig` | Asset de configuración donde se habilita Geospatial Mode |
| `Geospatial Creator` | Permite configurar y previsualizar puntos geográficos |
| `Cesium Georeference` | Apoya la representación geoespacial dentro de Unity |
| `Cesium 3D Tileset` | Carga tiles 3D desde una URL |
| `VideoScreen` | Superficie virtual donde se reproduce contenido audiovisual |
| `DebugUI` | Interfaz temporal para mostrar distancia, precisión, orientación y altura |

---

## 10. Configuración en Unity para iOS

### 10.1 Activar plataforma iOS

En Unity:

```text
File → Build Settings
```

Seleccionar:

```text
iOS
```

Luego:

```text
Switch Platform
```

---

### 10.2 Activar XR Plug-in Management

En Unity:

```text
Edit → Project Settings → XR Plug-in Management
```

En la pestaña de iOS, activar:

```text
ARKit
```

---

### 10.3 Configurar ARCore Extensions para iOS

En Unity:

```text
Edit → Project Settings → XR Plug-in Management → ARCore Extensions
```

Verificar:

```text
iOS Support Enabled: activado
Optional Features → Geospatial: activado
```

---

### 10.4 Configurar ARCoreExtensionsConfig

En la escena principal debe existir una configuración asociada a ARCore Extensions.

Verificar la presencia de:

```text
AR Session
XR Origin / AR Origin
AR Camera
ARCore Extensions
ARCoreExtensionsConfig
```

El objeto `ARCore Extensions` debe tener asignado un asset `ARCoreExtensionsConfig`.

En el asset `ARCoreExtensionsConfig`, verificar:

```text
Geospatial Mode: Enabled
```

Si se utilizan funciones de Streetscape Geometry, verificar además:

```text
Streetscape Geometry Mode: Enabled
```

Solo habilitar Streetscape Geometry si el prototipo efectivamente utiliza esa función.

---

### 10.5 Player Settings para iOS

En Unity:

```text
Edit → Project Settings → Player → iOS
```

Revisar:

```text
Company Name: [COMPLETAR]
Product Name: [COMPLETAR]
Bundle Identifier: com.[COMPLETAR].[COMPLETAR]
Target minimum iOS Version: 13.0 o superior
```

Verificar permisos y descripciones de uso:

```text
Camera Usage Description
Location Usage Description
```

Ejemplo de texto para ubicación:

```text
Esta aplicación utiliza la ubicación para posicionar contenido de realidad aumentada geoespacial.
```

Ejemplo de texto para cámara:

```text
Esta aplicación utiliza la cámara para mostrar experiencias de realidad aumentada.
```

---

## 11. Exportar desde Unity a Xcode

1. Abrir la escena principal o la escena mínima de prueba.
2. Ir a:

```text
File → Build Settings
```

3. Seleccionar:

```text
iOS
```

4. Confirmar que la escena esté agregada en:

```text
Scenes In Build
```

5. Presionar:

```text
Build
```

6. Seleccionar una carpeta de salida para el proyecto Xcode.

Unity generará una carpeta con archivos de Xcode, incluyendo:

```text
Unity-iPhone.xcodeproj
Unity-iPhone.xcworkspace
```

---

## 12. Compilar en Xcode

Al abrir el proyecto exportado desde Unity, se debe abrir:

```text
Unity-iPhone.xcworkspace
```

No abrir:

```text
Unity-iPhone.xcodeproj
```

Esto es importante porque las dependencias externas se resuelven mediante CocoaPods o integraciones generadas por Unity, y el workspace conserva esa configuración.

---

### 12.1 Configurar firma

En Xcode:

```text
Unity-iPhone → Signing & Capabilities
```

Revisar:

```text
Team: [EQUIPO APPLE]
Bundle Identifier: debe coincidir con Unity y Google Cloud
Automatically manage signing: activado o configurado manualmente
```

También revisar la firma de:

```text
UnityFramework
```

si Xcode lo solicita.

---

### 12.2 Seleccionar dispositivo físico

Conectar el iPhone o iPad por USB.

En Xcode, seleccionar el dispositivo físico como destino de ejecución.

No utilizar el simulador para validar esta funcionalidad, ya que ARKit, cámara y localización geoespacial requieren hardware real.

---

### 12.3 Compilar y ejecutar

En Xcode:

```text
Product → Build
```

Luego:

```text
Product → Run
```

Al abrir la app en el dispositivo, aceptar permisos de:

```text
Cámara
Ubicación
```

---

## 13. Prueba mínima recomendada antes de la escena completa

Antes de ejecutar la escena completa con Cesium y contenido georreferenciado, se recomienda validar primero una escena mínima con:

```text
AR Session
XR Origin / AR Origin
AR Camera
ARCore Extensions
ARCoreExtensionsConfig con Geospatial Mode habilitado
```

Esta prueba permite confirmar que Geospatial funciona correctamente en iOS antes de integrar la escena completa.

Si la escena mínima abre correctamente, se puede continuar con Cesium, Geospatial Creator y los objetos georreferenciados.

Si la escena mínima no abre o queda en pantalla negra, revisar primero:

```text
Bundle Identifier
API Key para iOS
ARCore API activada
Map Tiles API activada
Permisos de cámara
Permisos de ubicación
Dispositivo compatible
Deployment target iOS
Firma en Xcode
```

---

## 14. Configuración de anclajes geoespaciales

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

## 15. Cómo agregar un nuevo punto geoespacial

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
8. Exportar nuevamente a iOS y probar en un dispositivo compatible.

---

## 16. Contenido 3D georreferenciado

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

## 17. Contenido audiovisual georreferenciado

El prototipo permite reproducir video asociado a un punto geográfico.

### 17.1 Implementación

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

### 17.2 Formato recomendado del video

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

### 17.3 Escala correcta del video

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

## 18. Pruebas en terreno

Durante las pruebas, registrar:

```text
Fecha
Hora
Lugar
Dispositivo
Versión de iOS
Versión de Xcode
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
Dispositivo: iPad / iPhone [COMPLETAR]
Anchor: Punto 1
Distancia inicial: [COMPLETAR]
Precisión horizontal: [COMPLETAR]
Objeto visible: sí / no
Observación: [COMPLETAR]
```

---

## 19. Debug

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

Esta información es útil durante el desarrollo, pero no debería mostrarse en una versión final destinada a usuarios.

---

## 20. Problemas comunes en iOS

### 20.1 La app queda en pantalla negra al iniciar

Revisar:

```text
Permisos de cámara
Permisos de ubicación
Bundle Identifier
API Key restringida para iOS
ARCore API activada
Map Tiles API activada
Firma en Xcode
Dispositivo compatible
Escena mínima con Geospatial
```

También revisar la primera línea de error real en la consola de Xcode antes del stack completo.

---

### 20.2 La app compila, pero Geospatial no localiza

Revisar:

```text
GPS activo
Conexión a internet
Permiso de ubicación aceptado
Disponibilidad de VPS en la zona
Cielo visible
Precisión horizontal reportada
Movimiento inicial del dispositivo
```

---

### 20.3 El contenido aparece lejos

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

### 20.4 El anchor se detecta, pero el objeto no aparece

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

### 20.5 La distancia se actualiza, pero no se ve el contenido

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

### 20.6 El video aparece negro

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

## 21. Buenas prácticas antes de subir al repositorio

No subir:

```text
Library/
Temp/
Obj/
Build/
Builds/
Logs/
UserSettings/
Assets/_Recovery/
API Keys
Tokens
Keystores
Certificados
Archivos .tgz grandes
```

Antes de hacer commit, revisar que no aparezcan archivos con:

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

## 22. Extensiones posibles

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
evaluación con usuarios
```

---

## 23. Notas importantes

- Este proyecto corresponde a un prototipo geoespacial para iOS con Google Geospatial Creator.
- El proyecto usa Cesium for Unity `1.19.0` por compatibilidad con ARCore Extensions `1.54.0`.
- Las pruebas deben realizarse en un iPhone o iPad compatible con ARKit.
- Las coordenadas deben revisarse cuidadosamente.
- La altitud afecta la visibilidad del contenido.
- La localización puede variar según el dispositivo, conectividad, entorno y disponibilidad de VPS.
- Las API Keys no deben subirse al repositorio.
- La interfaz de debug es solo para desarrollo.
- La versión final debería reemplazar los mensajes técnicos por instrucciones comprensibles para usuarios no expertos.

---

## 24. Paso a seguir para compilar y validar

Para quien descargue el proyecto, el flujo recomendado es el siguiente:

1. Abrir el proyecto en Unity `6000.3.13f1`.
2. Verificar que las dependencias principales estén instaladas:
   - AR Foundation `6.3.5`.
   - ARKit XR Plugin `6.3.5`.
   - ARCore Extensions `1.54.0`.
   - Cesium for Unity `1.19.0`.
3. En Unity, cambiar la plataforma a iOS:

```text
File → Build Settings → iOS → Switch Platform
```

4. Activar ARKit:

```text
Edit → Project Settings → XR Plug-in Management → iOS → ARKit
```

5. Activar Geospatial para iOS:

```text
Edit → Project Settings → XR Plug-in Management → ARCore Extensions
iOS Support Enabled: activado
Optional Features → Geospatial: activado
```

6. Verificar en la escena que el objeto `ARCore Extensions` tenga asignado un `ARCoreExtensionsConfig` con:

```text
Geospatial Mode: Enabled
```

7. Verificar en Google Cloud que estén activadas:

```text
ARCore API
Map Tiles API
```

8. Confirmar que la API Key esté restringida para iOS con el mismo Bundle ID configurado en Unity/Xcode.

9. Exportar el proyecto desde Unity a Xcode.

10. Abrir en Xcode:

```text
Unity-iPhone.xcworkspace
```

11. Configurar firma en Xcode:

```text
Signing & Capabilities → Team → [EQUIPO APPLE]
```

12. Conectar un iPhone o iPad físico compatible.

13. Ejecutar primero una escena mínima con Geospatial.

14. Si la escena mínima funciona, ejecutar la escena completa con Cesium y contenido georreferenciado.

15. Si la app queda en pantalla negra o se cierra, revisar la primera línea de error real en la consola de Xcode y validar API Key, Bundle ID, permisos de cámara, permisos de ubicación y compatibilidad del dispositivo.

---

Documentación actualizada para orientar el proyecto como prototipo iOS de realidad aumentada geoespacial.
Elaborada con IA en base a documentacion previa y agregando comentarios y cambios respecto a la version para iOS.