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
    }
}
