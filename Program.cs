using System;

// Factory Pattern
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
    public override OptimizationTool CreateOptimizer()
    {
        return new PolygonReducer();
    }
}

class RetopologyToolFactory : ModelOptimizerFactory
{
    public override OptimizationTool CreateOptimizer()
    {
        return new RetopologyTool();
    }
}

class UVUnwrapperFactory : ModelOptimizerFactory
{
    public override OptimizationTool CreateOptimizer()
    {
        return new UVUnwrapper();
    }
}

// Abstract Factory Pattern
abstract class MeshExporter
{
    public abstract void ExportMesh();
}

abstract class TextureExporter
{
    public abstract void ExportTexture();
}

abstract class MetadataExporter
{
    public abstract void ExportMetadata();
}

// Concrete Exporters for OBJ
class OBJMeshExporter : MeshExporter
{
    public override void ExportMesh()
    {
        Console.WriteLine("Exporting OBJ mesh...");
    }
}

class OBJTextureExporter : TextureExporter
{
    public override void ExportTexture()
    {
        Console.WriteLine("Exporting OBJ texture...");
    }
}

class OBJMetadataExporter : MetadataExporter
{
    public override void ExportMetadata()
    {
        Console.WriteLine("Exporting OBJ metadata...");
    }
}

// Concrete Exporters for FBX
class FBXMeshExporter : MeshExporter
{
    public override void ExportMesh()
    {
        Console.WriteLine("Exporting FBX mesh...");
    }
}

class FBXTextureExporter : TextureExporter
{
    public override void ExportTexture()
    {
        Console.WriteLine("Exporting FBX texture...");
    }
}

class FBXMetadataExporter : MetadataExporter
{
    public override void ExportMetadata()
    {
        Console.WriteLine("Exporting FBX metadata...");
    }
}

// Concrete Exporters for STL (No textures)
class STLMeshExporter : MeshExporter
{
    public override void ExportMesh()
    {
        Console.WriteLine("Exporting STL mesh...");
    }
}

class STLMetadataExporter : MetadataExporter
{
    public override void ExportMetadata()
    {
        Console.WriteLine("Exporting STL metadata...");
    }
}

// Abstract Factory for Export Pipelines
abstract class ExportPipelineFactory
{
    public abstract MeshExporter CreateMeshExporter();
    public abstract TextureExporter? CreateTextureExporter();
    public abstract MetadataExporter CreateMetadataExporter();
}

// Concrete Factories for Export Pipelines
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

// Test Program
class Program
{
    static void Main()
    {
        // Factory Method Example
        ModelOptimizerFactory factory = new PolygonReducerFactory();
        OptimizationTool tool = factory.CreateOptimizer();
        tool.Optimize();

        // Abstract Factory Example: 3D Model Export Pipeline
        ExportPipelineFactory exportFactory = new OBJExportFactory();
        MeshExporter mesh = exportFactory.CreateMeshExporter();
        TextureExporter? texture = exportFactory.CreateTextureExporter();
        MetadataExporter metadata = exportFactory.CreateMetadataExporter();

        mesh.ExportMesh();
        texture?.ExportTexture();
        metadata.ExportMetadata();
    }
}
