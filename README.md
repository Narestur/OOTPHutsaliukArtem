# Огляд проекту
Цей проект є програмою, призначеною для обробки 3D-моделей. Програмне забезпечення надає інструменти для автоматичної оптимізації полігонів, розгортки UV та очищення моделей для підвищення продуктивності та сумісності на різних 3D-платформах. Воно поєднує функції на базі ШІ для автоматизованої ретопології сітки, генерації текстур та інтелектуального коригування моделей.
- **Оптимізація 3D-моделей** – зменшення кількості полігонів при збереженні візуальної якості.
- **Ретопологія на основі ШІ** – автоматичне спрощення та реструктуризація сітки.
- **Автоматизоване UV-розгортання** – оптимальне упакування UV.
- **Генерація LOD** – створення різних рівнів деталізації для ефективного рендерингу.
- **Пакетна обробка** – одночасна обробка кількох моделей.
- **Підтримка форматів** – імпорт/експорт (OBJ, FBX, STL, GLTF тощо).
- **Генерація текстур** – автоматичне масштабування та поліпшення текстур.
- **Поліпшення на основі ШІ** – запікання текстур, UV-розгортка та ретопологія.

---

# Технологічний стек
- **Мова програмування:** C#
- **Фреймворк:** .NET
- **3D-графіка:** OpenGL / DirectX
- **GUI:** WPF / WinForms
- **Формати файлів:** OBJ, FBX, STL, GLTF

---

# Розв'яок заввань за допомогою шаблонів проектування
**Задачі**
- **Оптимізація 3D-моделей** – Factory Method
- **Підтримка форматів** – Abstract Factory
- **Пакетна обробка** – *Prototype*.
- **Генерація LOD** – *Builder*


## Factory Method
**Factory Method** використовується для створення інструментів оптимізації на основі параметрів вхідної 3D-моделі.

### 🔹 Учасники:
- **`OptimizationTool`** (Abstract Class) – базовий клас для всіх інструментів оптимізації.
- **`PolygonReducer`**, **`RetopologyTool`**, **`UVUnwrapper`** (Concrete Classes) – реалізують методи оптимізації.
- **`ModelOptimizerFactory`** (Creator) – фабричний метод для вибору правильного інструменту.
- **`ConcreteOptimizerFactory`** (Concrete Creator) – реалізує створення інструментів оптимізації.

## Abstract Factory
**Abstract Factory** використовується для створення модулів експорту у різні формати файлів.

### 🔹 Учасники:
- **`ExportPipelineFactory`** – абстрактна фабрика для генерації експортерів.
- **`OBJExportFactory`**, **`FBXExportFactory`**, **`STLExportFactory`**, **`GLTFExportFactory`** – реалізація фабрик експорту.
- **`MeshExporter`**, **`TextureExporter`**, **`MetadataExporter`** – абстрактні продукти для експорту.
- **Конкретні експортери:** `OBJMeshExporter`, `FBXMeshExporter`, `STLMeshExporter`, `GLTFMeshExporter`, `OBJTextureExporter`, `FBXTextureExporter`, `GLTFTextureExporter`, `OBJMetadataExporter` тощо.

## **Prototype**
**Prototype** використовується для створення копій 3D-моделей, дозволяючи модифікувати без зміни вихідного екземпляра. Це корисно для операцій скасування, пакетної обробки та створення варіантів моделі.

🔹 **Учасники:**
- **ICloneableModel (інтерфейс прототипу)** – визначає метод для клонування об’єктів.
- **Model3D (конкретний прототип)** – реалізує метод клонування для створення глибоких копій 3D-моделей.

## **Builder**
Builder використовується для покрокової побудови складних 3D-моделей, забезпечуючи структуроване та гнучке створення моделей з різним рівнем деталізації. Це дозволяє вибірково застосовувати компоненти сітки, текстури та метаданих, оптимізуючи моделі для різних потреб візуалізації.

🔹 **Учасники:**
- **Model** (Product) – представляє повну 3D-модель, зберігаючи всі частини, такі як сітка, текстура та метадані.
- **ModelBuilder** (Builder) – визначає інтерфейс для створення та складання різних компонентів 3D-моделі.
- **LODModelBuilder** (ConcreteBuilder) – реалізує створення 3D-моделі з різними рівнями деталізації (LOD), поступово спрощуючи геометрію, зберігаючи візуальну якість.
- **ModelDirector** (Director) – Керує покроковим складанням моделі, забезпечуючи узгоджену структуру та застосування відповідного LOD.
