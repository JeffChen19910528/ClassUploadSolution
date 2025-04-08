
using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public class FileCompiler
{
    public (bool success, string message) Compile(string filePath)
    {
        if (!File.Exists(filePath))
            return (false, "檔案不存在");

        var code = File.ReadAllText(filePath);
        var syntaxTree = CSharpSyntaxTree.ParseText(code);

        var references = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrEmpty(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location));

        var compilation = CSharpCompilation.Create("UploadedAssembly")
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(references)
            .AddSyntaxTrees(syntaxTree);

        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);

        if (!result.Success)
        {
            var errors = string.Join("\n", result.Diagnostics
                .Where(d => d.Severity == DiagnosticSeverity.Error)
                .Select(d => d.ToString()));
            return (false, $"編譯失敗:\n{errors}");
        }

        return (true, "編譯成功");
    }
}
