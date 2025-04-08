using System;

// Factory Method Pattern
abstract class OptimizationTool
{
    public abstract void Optimize();
}

class PolygonReducer : OptimizationTool
{
    public override void Optimize()
    {
        Console.WriteLine("Reducing polygon count...");
    }
}

class RetopologyTool : OptimizationTool
{
    public override void Optimize()
    {
        Console.WriteLine("Applying AI-assisted retopology...");
    }
}

class UVUnwrapper : OptimizationTool
{
    public override void Optimize()
    {
        Console.WriteLine("Performing UV unwrapping...");
    }
}

abstract class ModelOptimizerFactory
{
    public abstract OptimizationTool CreateOptimizer();
}

class PolygonReducerFactory : ModelOptimizerFactory
{
    public override OptimizationTool CreateOptimizer() => new PolygonReducer();
}

class RetopologyToolFactory : ModelOptimizerFactory
{
    public override OptimizationTool CreateOptimizer() => new RetopologyTool();
}

class UVUnwrapperFactory : ModelOptimizerFactory
{
    public override OptimizationTool CreateOptimizer() => new UVUnwrapper();
}

// Abstract Factory Pattern (3D Model Export Pipeline)
abstract class MeshExporter { public abstract void ExportMesh(); }
abstract class TextureExporter { public abstract void ExportTexture(); }
abstract class MetadataExporter { public abstract void ExportMetadata(); }

class OBJMeshExporter : MeshExporter { public override void ExportMesh() => Console.WriteLine("Exporting OBJ mesh..."); }
class OBJTextureExporter : TextureExporter { public override void ExportTexture() => Console.WriteLine("Exporting OBJ texture..."); }
class OBJMetadataExporter : MetadataExporter { public override void ExportMetadata() => Console.WriteLine("Exporting OBJ metadata..."); }

class FBXMeshExporter : MeshExporter { public override void ExportMesh() => Console.WriteLine("Exporting FBX mesh..."); }
class FBXTextureExporter : TextureExporter { public override void ExportTexture() => Console.WriteLine("Exporting FBX texture..."); }
class FBXMetadataExporter : MetadataExporter { public override void ExportMetadata() => Console.WriteLine("Exporting FBX metadata..."); }

class STLMeshExporter : MeshExporter { public override void ExportMesh() => Console.WriteLine("Exporting STL mesh..."); }
class STLMetadataExporter : MetadataExporter { public override void ExportMetadata() => Console.WriteLine("Exporting STL metadata..."); }

abstract class ExportPipelineFactory
{
    public abstract MeshExporter CreateMeshExporter();
    public abstract TextureExporter? CreateTextureExporter();
    public abstract MetadataExporter CreateMetadataExporter();
}

class OBJExportFactory : ExportPipelineFactory
{
    public override MeshExporter CreateMeshExporter() => new OBJMeshExporter();
    public override TextureExporter CreateTextureExporter() => new OBJTextureExporter();
    public override MetadataExporter CreateMetadataExporter() => new OBJMetadataExporter();
}

class FBXExportFactory : ExportPipelineFactory
{
    public override MeshExporter CreateMeshExporter() => new FBXMeshExporter();
    public override TextureExporter CreateTextureExporter() => new FBXTextureExporter();
    public override MetadataExporter CreateMetadataExporter() => new FBXMetadataExporter();
}

class STLExportFactory : ExportPipelineFactory
{
    public override MeshExporter CreateMeshExporter() => new STLMeshExporter();
    public override TextureExporter? CreateTextureExporter() => null; 
    public override MetadataExporter CreateMetadataExporter() => new STLMetadataExporter();
}

// Prototype Pattern
interface ICloneableModel
{
    ICloneableModel Clone();
}

class Model3D : ICloneableModel
{
    public string Name { get; set; }
    
    public Model3D(string name)
    {
        Name = name;
    }

    public ICloneableModel Clone()
    {
        return new Model3D(Name);
    }

    public void Display()
    {
        Console.WriteLine($"Model: {Name}");
    }
}

// Builder Pattern
class Model
{
    private List<string> parts = new List<string>();
    
    public void AddPart(string part)
    {
        parts.Add(part);
    }
    
    public void Show()
    {
        Console.WriteLine("Model contains: " + string.Join(", ", parts));
    }
}
// Builder: Defines the interface for creating different parts of the Product object
abstract class ModelBuilder
{
    protected Model model;
    public void CreateNewModel() => model = new Model();
    public abstract void BuildMesh();
    public abstract void BuildTexture();
    public Model GetModel() => model;
}

// ConcreteBuilder: Implements the Builder interface and creates a Product object
class ConcreteModelBuilder : ModelBuilder
{
    public override void BuildMesh()
    {
        model.AddPart("Mesh");
    }
    
    public override void BuildTexture()
    {
        model.AddPart("Texture");
    }
}

// Director: Manages the building process
class Director
{
    public void Construct(ModelBuilder builder)
    {
        builder.CreateNewModel();
        builder.BuildMesh();
        builder.BuildTexture();
    }
}
interface ITextureGenerationStrategy
{
    void GenerateTexture();
}

class ProceduralTextureStrategy : ITextureGenerationStrategy
{
    public void GenerateTexture() => Console.WriteLine("Generating procedural texture...");
}

class AITextureStrategy : ITextureGenerationStrategy
{
    public void GenerateTexture() => Console.WriteLine("Generating AI-enhanced texture...");
}

class StandardTextureStrategy : ITextureGenerationStrategy
{
    public void GenerateTexture() => Console.WriteLine("Applying standard texture mapping...");
}

class TextureGenerator
{
    private ITextureGenerationStrategy _strategy;
    public void SetStrategy(ITextureGenerationStrategy strategy) => _strategy = strategy;
    public void ApplyTexture() => _strategy.GenerateTexture();
}

// Observer Pattern (Polygon and Performance Monitoring)
interface IMonitor
{
    void Update(int polygonCount);
}

class PolygonCountMonitor : IMonitor
{
    public void Update(int polygonCount)
    {
        if (polygonCount > 50000)
            Console.WriteLine("Warning: High polygon count detected!");
    }
}

class MemoryUsageMonitor : IMonitor
{
    public void Update(int polygonCount)
    {
        Console.WriteLine($"Estimated memory usage: {polygonCount * 0.1} MB");
    }
}

class ModelStatistics
{
    private List<IMonitor> _observers = new List<IMonitor>();
    public void Attach(IMonitor observer) => _observers.Add(observer);
    public void Detach(IMonitor observer) => _observers.Remove(observer);
    public void Notify(int polygonCount)
    {
        foreach (var observer in _observers)
            observer.Update(polygonCount);
    }
}

// Command Interface\ 
interface ICommand {
    void Execute();
    void Undo();
}

// Receiver: 3D Model
class Model3Ds
{
    public string Name { get; }
    private float position;
    private float scale;
    private float rotation;

    public Model3Ds(string name)
    {
        Name = name;
        position = 0;
        scale = 1;
        rotation = 0;
    }

    public void Move(float delta)
    {
        position += delta;
        Console.WriteLine($"{Name} moved to position {position}");
    }

    public void Scale(float factor)
    {
        scale *= factor;
        Console.WriteLine($"{Name} scaled to {scale}x");
    }

    public void Rotate(float degrees)
    {
        rotation += degrees;
        Console.WriteLine($"{Name} rotated to {rotation} degrees");
    }

    public void Reset()
    {
        position = 0;
        scale = 1;
        rotation = 0;
        Console.WriteLine($"{Name} reset to default state");
    }
}

// Concrete Commands
class MoveCommand : ICommand
{
    private Model3Ds model;
    private float delta;

    public MoveCommand(Model3Ds model, float delta)
    {
        this.model = model;
        this.delta = delta;
    }

    public void Execute() => model.Move(delta);
    public void Undo() => model.Move(-delta);
}

class ScaleCommand : ICommand
{
    private Model3Ds model;
    private float factor;

    public ScaleCommand(Model3Ds model, float factor)
    {
        this.model = model;
        this.factor = factor;
    }

    public void Execute() => model.Scale(factor);
    public void Undo() => model.Scale(1 / factor);
}

class RotateCommand : ICommand
{
    private Model3Ds model;
    private float degrees;

    public RotateCommand(Model3Ds model, float degrees)
    {
        this.model = model;
        this.degrees = degrees;
    }

    public void Execute() => model.Rotate(degrees);
    public void Undo() => model.Rotate(-degrees);
}

// Invoker: Command Manager
class CommandManager
{
    private Stack<ICommand> history = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        history.Push(command);
    }

    public void UndoLastCommand()
    {
        if (history.Count > 0)
        {
            ICommand lastCommand = history.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

//--------------------------------------------------------------------------------------------------//
//-------------------------------------------------4LR----------------------------------------------//
//--------------------------------------------------------------------------------------------------//

interface I4Command
{
    void Execute();
    void Undo();
}

class ExtrudeCommand : I4Command
{
    public void Execute() => Console.WriteLine("Extruding geometry...");
    public void Undo() => Console.WriteLine("Undoing extrusion...");
}

class ScaleCommand4 : I4Command
{
    public void Execute() => Console.WriteLine("Scaling model...");
    public void Undo() => Console.WriteLine("Undoing scaling...");
}

class MergeCommand : I4Command
{
    public void Execute() => Console.WriteLine("Merging nodes...");
    public void Undo() => Console.WriteLine("Undoing merge...");
}

class MacroCommand : I4Command
{
    private readonly List<I4Command> _commands = new List<I4Command>();
    
    public void AddCommand(I4Command command) => _commands.Add(command);
    public void Execute()
    {
        Console.WriteLine("Executing macro command...");
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
    public void Undo()
    {
        Console.WriteLine("Undoing macro command...");
        for (int i = _commands.Count - 1; i >= 0; i--)
        {
            _commands[i].Undo();
        }
    }
}

// Template Method Pattern
abstract class GeometryTemplate
{
    public void Generate()
    {
        Initialize();
        CreateBaseShape();
        ApplyAIEnhancements();
        FinalizeGeometry();
    }

    protected abstract void CreateBaseShape();
    protected virtual void ApplyAIEnhancements() => Console.WriteLine("Applying AI-based refinements...");
    protected virtual void Initialize() => Console.WriteLine("Initializing geometry generation...");
    protected virtual void FinalizeGeometry() => Console.WriteLine("Finalizing geometry...");
}

class AICubeGenerator : GeometryTemplate
{
    protected override void CreateBaseShape() => Console.WriteLine("Generating AI-enhanced cube...");
}

class AISphereGenerator : GeometryTemplate
{
    protected override void CreateBaseShape() => Console.WriteLine("Generating AI-enhanced sphere...");
}
//--------------------------------------------------------------------------------------------------//
//--------------------------------------------LR5---------------------------------------------------//
//--------------------------------------------------------------------------------------------------//
interface IIterator<T>
{
    bool HasNext();
    T Next();
}

class Model3DI
{
    public string Name { get; set; }
    public Model3DI(string name) { Name = name; }
    public void Display() => Console.WriteLine("Model: " + Name);
}

interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

class ModelCollection : IAggregate<Model3DI>
{
    private List<Model3DI> models = new();
    public void AddModel(Model3DI model) => models.Add(model);
    public IIterator<Model3DI> CreateIterator() => new ModelIterator(models);
}

class ModelIterator : IIterator<Model3DI>
{
    private List<Model3DI> _models;
    private int _index = 0;
    public ModelIterator(List<Model3DI> models) { _models = models; }
    public bool HasNext() => _index < _models.Count;
    public Model3DI Next() => _models[_index++];
}


// ====================
// State Pattern
// ====================
interface IState
{
    void Handle(ModelEditor editor);
}

class ModelEditor
{
    private IState _state;
    public void SetState(IState state) { _state = state; }
    public void Request() { _state.Handle(this); }
}

class IdleState : IState
{
    public void Handle(ModelEditor editor)
    {
        Console.WriteLine("Model is idle.");
        editor.SetState(new EditingState());
    }
}

class EditingState : IState
{
    public void Handle(ModelEditor editor)
    {
        Console.WriteLine("Model is being edited.");
        editor.SetState(new PreviewState());
    }
}

class PreviewState : IState
{
    public void Handle(ModelEditor editor)
    {
        Console.WriteLine("Previewing model.");
        editor.SetState(new SavedState());
    }
}

class SavedState : IState
{
    public void Handle(ModelEditor editor)
    {
        Console.WriteLine("Model has been saved.");
        editor.SetState(new IdleState());
    }
}


// ====================
// Chain of Responsibility Pattern
// ====================
abstract class Handler
{
    protected Handler? _next;
    public void SetNext(Handler next) => _next = next;
    public abstract void Handle(Model3DI model);
}

class MeshValidator : Handler
{
    public override void Handle(Model3DI model)
    {
        Console.WriteLine("Validating mesh of " + model.Name);
        _next?.Handle(model);
    }
}

class TextureChecker : Handler
{
    public override void Handle(Model3DI model)
    {
        Console.WriteLine("Checking textures of " + model.Name);
        _next?.Handle(model);
    }
}

class UVVerifier : Handler
{
    public override void Handle(Model3DI model)
    {
        Console.WriteLine("Verifying UVs of " + model.Name);
        _next?.Handle(model);
    }
}


// Test Program
class Program
{
    static void Main()
    {
        // Factory Method Example
        ModelOptimizerFactory factory = new PolygonReducerFactory();
        OptimizationTool tool = factory.CreateOptimizer();
        tool.Optimize();

        // Abstract Factory Example
        ExportPipelineFactory exportFactory = new OBJExportFactory();
        MeshExporter mesh = exportFactory.CreateMeshExporter();
        TextureExporter? texture = exportFactory.CreateTextureExporter();
        MetadataExporter metadata = exportFactory.CreateMetadataExporter();

        mesh.ExportMesh();
        texture?.ExportTexture();
        metadata.ExportMetadata();

        // Prototype Example
        Model3D originalModel = new Model3D("BaseModel");
        Model3D clonedModel = (Model3D)originalModel.Clone();
        clonedModel.Display();

        // Builder Example
        Director director = new Director();
        ModelBuilder builder = new ConcreteModelBuilder();
        
        director.Construct(builder);
        Model model = builder.GetModel();
        model.Show();

        // Strategy Pattern Example
        TextureGenerator generator = new TextureGenerator();
        generator.SetStrategy(new AITextureStrategy());
        generator.ApplyTexture();
        
        // Observer Pattern Example
        ModelStatistics modelStats = new ModelStatistics();
        modelStats.Attach(new PolygonCountMonitor());
        modelStats.Attach(new MemoryUsageMonitor());
        modelStats.Notify(60000);

        Model3Ds model1 = new Model3Ds("ExampleModel");
        CommandManager manager = new CommandManager();

        ICommand move = new MoveCommand(model1, 5);
        ICommand scale = new ScaleCommand(model1, 1.5f);
        ICommand rotate = new RotateCommand(model1, 45);

        manager.ExecuteCommand(move);
        manager.ExecuteCommand(scale);
        manager.ExecuteCommand(rotate);

        Console.WriteLine("Undoing last action...");
        manager.UndoLastCommand();
        manager.UndoLastCommand();

        // Macro Command Example
        MacroCommand macroCommand = new MacroCommand();
        macroCommand.AddCommand(new ExtrudeCommand());
        macroCommand.AddCommand(new ScaleCommand4());
        macroCommand.AddCommand(new MergeCommand());
        
        macroCommand.Execute();
        macroCommand.Undo();

        // Template Method Example
        GeometryTemplate cubeGenerator = new AICubeGenerator();
        GeometryTemplate sphereGenerator = new AISphereGenerator();
        
        cubeGenerator.Generate();
        sphereGenerator.Generate();

        // Iterator
        var collection = new ModelCollection();
        collection.AddModel(new Model3DI("ModelA"));
        collection.AddModel(new Model3DI("ModelB"));
        var iterator = collection.CreateIterator();
        while (iterator.HasNext()) iterator.Next().Display();

        // State
        var editor = new ModelEditor();
        editor.SetState(new IdleState());
        for (int i = 0; i < 4; i++) editor.Request();

        // Chain of Responsibility
        var modeL = new Model3DI("ComplexModel");
        var mesH = new MeshValidator();
        var texturE = new TextureChecker();
        var uv = new UVVerifier();
        mesH.SetNext(texturE);
        texturE.SetNext(uv);
        mesH.Handle(modeL);
    }
}
