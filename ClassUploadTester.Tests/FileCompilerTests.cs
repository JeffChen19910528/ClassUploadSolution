
using System.IO;
using Xunit;

public class FileCompilerTests
{
    [Fact]
    public void Compile_ValidClass_ShouldReturnSuccess()
    {
        var compiler = new FileCompiler();
        var filePath = "ValidClass.cs";

        File.WriteAllText(filePath, @"
        public class ValidClass {
            public int Add(int a, int b) => a + b;
        }");

        var result = compiler.Compile(filePath);

        Assert.True(result.success);
        Assert.Equal("編譯成功", result.message);

        File.Delete(filePath);
    }

    [Fact]
    public void Compile_InvalidClass_ShouldReturnError()
    {
        var compiler = new FileCompiler();
        var filePath = "InvalidClass.cs";

        File.WriteAllText(filePath, @"
        public class InvalidClass {
            public int Add(int a, int b) => a + ; // 錯誤
        }");

        var result = compiler.Compile(filePath);

        Assert.False(result.success);
        Assert.Contains("編譯失敗", result.message);

        File.Delete(filePath);
    }
}
