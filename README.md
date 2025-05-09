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
- **Генерація текстур** - *Strategy*
- **Багатокутник і моніторинг продуктивності** - *Observer*
- **Логування команд та операції Undo/Redo** - *Command*
- **Створення простої геометрії** - *Шаблонний метод*
- **Консрування команд** - *Макрокоманди*


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

## **Strategy**
 Патерн «Стратегія» дозволить використовувати різні підходи до генерації текстур, наприклад процедурне текстурування, текстури з розширеним штучним інтелектом або стандартне відображення текстур.
 
 🔹 **Учасники:**
 - **ITextureGenerationStrategy** – визначає інтерфейс для стратегій генерації текстур.
 - **ProceduralTextureStrategy**, **AITextureStrategy**, **StandardTextureStrategy** – конкретні реалізації для різних методів генерації текстур.
 - **TextureGenerator** – контекст, який вибирає та застосовує стратегію на основі вимог моделі.

## **Observer**
 Шаблон спостерігача відстежуватиме складність моделі, кількість полігонів, розмір текстури та використання пам’яті. Спостерігачі можуть попередити користувача, якщо потрібна оптимізація.
 
🔹 **Учасники:**
 - **IMonitor** – Інтерфейс для моніторингу компонентів.
 - **PolygonCountMonitor**, **MemoryUsageMonitor** – конкретні спостерігачі, які реагують на зміни в складності моделі.
 - **ModelStatistics** – суб’єкт, який реєструє спостерігачів і сповіщає їх, коли складність моделі перевищує порогові значення.

## **Command**
Шаблон команди, який використовується для скасування/повторення трансформацій у 3D-моделях (таких як масштабування, обертання та перенесення).

🔹 **Учасники**
- **I4Command** (інтерфейс) – визначає метод виконання та скасування.
- **ConcreteCommand4** (MoveCommand, ScaleCommand, RotateCommand) – реалізує перетворення та зберігає стан для операцій скасування.
- **Invoker** (CommandManager) – зберігає історію команд і дозволяє скасувати/повторити.
- **ModelReceiver** (Model3D) – об’єкт, який зазнає перетворень.

## **Макрокоманди**
**Макрокоманди** використовується для групування кількох операцій моделювання в одну виконувану команду, що полегшує керування складними робочими процесами на основі вузлів.

🔹 **Учасники:**
- **Command** (інтерфейс) – визначає методи `Execute()` і `Undo()` для всіх команд.
- **ConcreteCommand** (ExtrudeCommand, ScaleCommand, MergeCommand) – реалізує певні операції моделювання на основі вузлів.

## **Шаблонний метод**
**Шаблонний метод** використовується для створення простої геометрії за допомогою штучного інтелекту шляхом визначення стандартного процесу, дозволяючи налаштувати конкретні кроки.

🔹 **Учасники:**
- **GeometryTemplate** (абстрактний клас) – визначає метод `Generate()`, який включає кроки для створення базової геометрії.
- **AICubeGenerator**, **AISphereGenerator** (конкретні класи) – реалізуйте певні кроки створення геометрії, керованої ШІ.
- **Client** – викликає метод шаблону для генерації 3D-моделей за допомогою ШІ.

## **Ітератор**
**Ітератор** використовується, щоб перебирати колекцію частин 3D-моделі або об’єктів сцени для перевірки, трансформації або експорту, не не відкриваючи їх базову структуру.

🔹 Учасники:
- **IIterator** (інтерфейс) – визначає методи для ітерації по колекції (наприклад, `HasNext()`, `Next()`).
- **ConcreteIterator** (ModelIterator) – реалізує інтерфейс ітератора для колекцій 3D-моделей.
- **IAggregate** (інтерфейс) – визначає інтерфейс для створення ітератора.
- **ConcreteAggregate** (ModelCollection) – реалізує зберігання колекції та забезпечує доступ через ітератор.

## **State**
**State** використовується для керування різними режимами обробки моделі (наприклад, «Необроблений», «Перевірений», «Оптимізований», «Експортований»), де операції дозволені або обмежені залежно від поточного стану.

🔹 **Учасники**
- **IState** (інтерфейс) – визначає операції на основі різних станів.
- **ConcreteState** (IdleState, EditingState, PreviewState, SavedState) – реалізує поведінку, пов’язану з певним станом моделі.
- **Context** (ModelEditor) – підтримує поточний стан і дозволяє переходи між станами.

## **Chain of Responsibility**  
Патерн **Chain of Responsibility** використовується для обробки 3D-моделей через ланцюжок обробників, кожен з яких відповідає за конкретне завдання перевірки або обробки (наприклад, перевірка сітки, перевірка текстур, перевірка UV).

🔹 **Учасники**
- **Handler** (абстрактний клас або інтерфейс) – визначає метод обробки запитів і їх пересилання.
- **ConcreteHandler** (MeshValidator, TextureChecker, UVVerifier) ​​– обробляє певні аспекти 3D-моделі.
- **Client** (ModelProcessor) – ініціює запит і будує ланцюжок обробки.

## **Interpreter**
**Interpreter** використовується для інтерпретації користувацьких запитів на трансформацію 3D-моделей за власною мовою.

🔹 **Учасники**
- **`AbstractExpression`** *(AbstractExpression)* — визначає інтерфейс `Interpret(Context context)` для всіх виразів.
- **`TerminalScaleExpression`**, **`TerminalRotateExpression`** *(TerminalExpression)* — реалізують інтерпретацію термінальних команд, таких як `scale`, `rotate`, `translate`.
- **`NonterminalSequenceExpression`** *(NonterminalExpression)* — представляє комбінації команд, об'єднані у правила.
- **`Context`** — зберігає текст команди та модель, до якої застосовуються інтерпретації.
- **`InterpreterClient`** *(Client)* — будує дерево синтаксису з виразів та викликає метод `Interpret`.

  ## **Посередник**

**Mediator** координує взаємодію між частинами інтерфейсу 3D-редактора — наприклад, між списком моделей, вікном властивостей і панеллю команд, забезпечуючи слабке зв’язування між компонентами

🔹 **Учасники**
- **`IMediator`** (Інтерфейс) – оголошує метод зв’язку між компонентами.
- **`ConcreteMediator`** (Concrete Mediator) – реалізує комунікацію та координує дії між компонентами.
- **`Colleague`** (Базовий клас) – зберігає посилання на посередника.
- **`ModelList`**, **`PropertyPanel`**, **`Toolbar`** – конкретні компоненти, які спілкуються через посередник.
Звісно! Нижче — **технічне завдання з декомпозицією задач**, де частина з них реалізується за допомогою шаблонів проєктування **Memento** (Зберігач) та **Visitor** (Відвідувач). Оформлено за шаблоном, який ви надали.


## **Memento**
**Memento** використовується для **збереження стану 3D-моделі** у певний момент часу, **без розкриття внутрішньої структури** об’єкта. Це дозволяє **повернутися до попереднього стану**, наприклад, для порівняння або відновлення після руйнівних змін.

🔹 **Учасники**:
- **`ModelState`** (Memento) – інкапсулює внутрішній стан об’єкта `Model3D`: геометрію, матеріали, трансформації.
- **`Model3D`** (Originator) – створює об’єкт `ModelState` для збереження поточного стану, і може відновити себе на його основі.
- **`StateVault`** (Caretaker) – зберігає набір збережених станів (контрольні точки), дозволяє обирати і вручну відновити один із них.


## **Visitor**
**Visitor** застосовується для **розділення операцій** над елементами 3D-моделі від самих елементів. Це дозволяє **додавати нові функції**, не змінюючи класи елементів (відкрите для розширення, закрите для модифікації).

🔹 **Учасники**:
- **`IVisitor`** – інтерфейс для всіх відвідувачів. Містить методи `VisitModel3D`, `VisitMaterial`.
- **`Model3D`, `Material`, `Mesh`** (Element) – елементи сцени, які приймають відвідувача.
- **`ExportVisitor`, `PolygonCountVisitor`, `ValidationVisitor`** (ConcreteVisitor) – реалізують конкретні операції, наприклад експорт, підрахунок полігонів, валідацію геометрії.
- **`Client`** – запускає проходження об’єктів сцени з конкретним відвідувачем.

## **Facade**

**Facade** спрощує взаємодію зі складними підсистемами, що беруть участь в імпорті/експорті 3D-моделей, надаючи клієнтам єдиний інтерфейс для загальних операцій.

### 🔹 **Учасники**:

* **`ModelSubsystem`**, **`TextureSubsystem`**, **`MaterialSubsystem`** – внутрішні підсистеми для обробки різних аспектів моделі.
* **`ModelingFacade`** – надає спрощений інтерфейс для виконання повних операцій імпорту/експорту.
* **`Client`** – взаємодіє лише з фасадом для завантаження/збереження моделей.

## **Proxy**

**Proxy** діє як локальний представник для віддаленого рендерингу 3D-моделей, дозволяючи програмі взаємодіяти з великими моделями, розміщеними на зовнішніх серверах, без їх безпосереднього завантаження.

### 🔹 **Учасники**:

* **`IRemoteModel`** – спільний інтерфейс для локальних та віддалено рендерованих моделей.
* **`RemoteModel`** – виконує фактичну логіку рендерингу на віддаленому сервері.
* **`RemoteModelProxy`** – спілкується із сервером та абстрагує мережеві операції.
* **`Client`** – взаємодіє з проксі-сервером, ніби працює з локальною моделлю.

## **Bridge**

**Bridge** відокремлює абстракцію рендерингу 3D-моделі від її реалізації, дозволяючи використовувати абстракці для попереднього перегляду та базової модифікації, не змінюючи основну реалізацію.

### 🔹 **Учасники**:

* **`IRenderEngine`** – інтерфейс реалізації для рендерингу.
* **`OpenGLRenderer`**, **`DirectXRenderer`** – конкретні реалізації рендерерів.
* **`RenderableModel`** – абстракція для моделей, що рендеряться.
* **`MeshModel`**, **`NURBSModel`** – уточнені абстракції, що делегують рендеринг механізму.
* **`Client`** – створює та використовує `RenderableModel` з певним механізмом рендерингу.

